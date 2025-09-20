using BUS_TicketSalesSystem;
using DTO_TicketSalesSystem;
using DTO_TicketSalesSystem.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem
{
    public partial class FormDoiVe : Form
    {
        private int _maVeCu;
        private DTO_Ve _thongTinVeCu;
        private readonly BUS_Ve busVe = new BUS_Ve();
        private readonly BUS_ChuyenTau busChuyenTau = new BUS_ChuyenTau();
        private readonly BUS_Toa busToa = new BUS_Toa();
        private readonly BUS_ThanhToan busThanhToan = new BUS_ThanhToan();
        public FormDoiVe(int maVeCu)
        {
            InitializeComponent();
            _maVeCu = maVeCu;
        }

        private void FormDoiVe_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin vé cũ
                _thongTinVeCu = busVe.LayVeChiTietBangId(_maVeCu);
                if (_thongTinVeCu == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin vé!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                HienThiThongTinVeCu();
                if (!KiemTraDieuKienDoiVe())
                {
                    return;
                }

                LoadChuyenTauCoTheDoi();
                SetupGiaoDien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void HienThiThongTinVeCu()
        {
            grpVeCu.Text = $"Thông tin vé cũ (#{_thongTinVeCu.MaVe})";
            lblVeCuInfo.Text = $"Hành khách: {_thongTinVeCu.HanhKhach}\n" +
                               $"Tuyến: {_thongTinVeCu.Tuyen}\n" +
                               $"Toa - Ghế: {_thongTinVeCu.ToaGhe}\n" +
                               $"Ngày khởi hành: {_thongTinVeCu.NgayKhoiHanh:dd/MM/yyyy HH:mm}\n" +
                               $"Giá vé: {_thongTinVeCu.GiaVe:N0} VND";
        }

        private bool KiemTraDieuKienDoiVe()
        {
            try
            {
                // Kiểm tra trạng thái vé
                if (_thongTinVeCu.TrangThai != "Đã thanh toán")
                {
                    MessageBox.Show("Chỉ có thể đổi vé đã thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Close();
                    return false;
                }

                // Kiểm tra thời gian 24h
                if (!busThanhToan.KiemTraThoiGianChoPhep(_thongTinVeCu.NgayKhoiHanh, DateTime.Now))
                {
                    var soGioConLai = (_thongTinVeCu.NgayKhoiHanh - DateTime.Now).TotalHours;
                    MessageBox.Show(
                        $"Không thể đổi vé trong vòng 24h trước khởi hành!\n\nThời gian còn lại: {Math.Floor(soGioConLai)}h {Math.Floor((soGioConLai % 1) * 60)}p",
                        "Không thể đổi vé",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    this.Close();
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra điều kiện: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return false;
            }
        }

        private void LoadChuyenTauCoTheDoi()
        {
            try
            {
                // Lấy tất cả chuyến mở bán
                var dsChuyen = busChuyenTau.LayDanhSachChuyenTauMoBan();

                // Lọc chuyến có thể đổi (cùng ngày hoặc sau ngày khởi hành cũ)
                var chuyenCoTheDoi = dsChuyen.Where(c =>
                    c.GioKhoiHanh.Date >= _thongTinVeCu.NgayKhoiHanh.Date &&
                    c.MaChuyen != _thongTinVeCu.MaChuyen // Loại trừ chuyến hiện tại
                ).ToList();

                // Tạo danh sách hiển thị với thông tin đầy đủ
                var dsHienThi = new List<dynamic>();
                foreach (var chuyen in chuyenCoTheDoi)
                {
                    var tenTau = busChuyenTau.LayTuyenBangChuyen(chuyen.MaChuyen ?? 0);
                    var tuyen = busChuyenTau.LayTuyenBangChuyen(chuyen.MaChuyen ?? 0);
                    chuyen.TenTau = tenTau;
                    chuyen.Tuyen = tuyen;

                    dsHienThi.Add(new
                    {
                        MaChuyen = chuyen.MaChuyen,
                        HienThi = $"{tenTau} - {tuyen} - {chuyen.GioKhoiHanh:dd/MM/yyyy HH:mm}",
                        TenTau = tenTau,
                        Tuyen = tuyen,
                        GioKhoiHanh = chuyen.GioKhoiHanh,
                        MaTau = chuyen.MaTau
                    });
                }

                cboChuyenMoi.DataSource = dsHienThi;
                cboChuyenMoi.DisplayMember = "HienThi";
                cboChuyenMoi.ValueMember = "MaChuyen";

                if (dsHienThi.Count == 0)
                {
                    MessageBox.Show("Không có chuyến tàu nào khả dụng để đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnXacNhan.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách chuyến: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupGiaoDien()
        {
            txtTuyen.ReadOnly = true;
            txtTau.ReadOnly = true;
            txtGiaVeMoi.ReadOnly = true;
            txtChenhLech.ReadOnly = true;

            // Ẩn thông tin chênh lệch ban đầu
            lblChenhLech.Visible = false;
            txtChenhLech.Visible = false;
            lblThongBao.Visible = false;
        }

        private void cboChuyenMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboChuyenMoi.SelectedItem != null)
                {
                    var selectedItem = (dynamic)cboChuyenMoi.SelectedItem;
                    txtTuyen.Text = selectedItem.Tuyen;
                    txtTau.Text = selectedItem.TenTau;

                    // Load toa theo tàu
                    var dsToa = busToa.LayToaBangChuyenTau(selectedItem.MaTau);
                    cboToaMoi.DataSource = dsToa;
                    cboToaMoi.DisplayMember = "TenToa";
                    cboToaMoi.ValueMember = "MaToa";

                    // Reset ghế và giá vé
                    cboGheMoi.DataSource = null;
                    txtGiaVeMoi.Text = "";
                    HienThiChenhLech(0);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load thông tin chuyến: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateThongTin())
                    return;

                int maChuyenMoi = (int)cboChuyenMoi.SelectedValue;
                int maGheMoi = (int)cboGheMoi.SelectedValue;
                decimal giaVeMoi = TinhGiaVeMoi();

                if (giaVeMoi <= 0)
                {
                    MessageBox.Show("Không thể xác định giá vé mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Tính chênh lệch
                decimal chenhLech = busThanhToan.TinhChenhLechGiaVe(_thongTinVeCu.GiaVe, giaVeMoi);

                // Xác nhận với người dùng
                string thongBaoXacNhan = $"Xác nhận đổi vé:\n\n" +
                                        $"Vé cũ: {_thongTinVeCu.Tuyen} - {_thongTinVeCu.ToaGhe}\n" +
                                        $"Vé mới: {txtTuyen.Text} - {cboToaMoi.Text} - {cboGheMoi.Text}\n" +
                                        $"Giá vé mới: {giaVeMoi:N0} VND\n";

                if (chenhLech != 0)
                {
                    thongBaoXacNhan += chenhLech > 0
                        ? $"Cần thanh toán thêm: {chenhLech:N0} VND\n"
                        : $"Được hoàn lại: {Math.Abs(chenhLech):N0} VND\n";
                }

                thongBaoXacNhan += "\nBạn có chắc chắn muốn đổi vé?";

                var result = MessageBox.Show(thongBaoXacNhan, "Xác nhận đổi vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Thực hiện đổi vé
                    bool ketQua = busVe.DoiVe(_maVeCu, maChuyenMoi, maGheMoi, UserSession.UserId);

                    if (ketQua)
                    {
                        string thongBaoThanhCong = "Đổi vé thành công!\n\n";

                        if (chenhLech > 0)
                            thongBaoThanhCong += $"Đã thanh toán thêm: {chenhLech:N0} VND";
                        else if (chenhLech < 0)
                            thongBaoThanhCong += $"Số tiền hoàn lại: {Math.Abs(chenhLech):N0} VND sẽ được chuyển về tài khoản trong 3-5 ngày";

                        MessageBox.Show(thongBaoThanhCong, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Không thể đổi vé! Vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đổi vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateThongTin()
        {
            if (cboChuyenMoi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn chuyến tàu mới!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboChuyenMoi.Focus();
                return false;
            }
            if (cboToaMoi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn toa!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboToaMoi.Focus();
                return false;
            }
            if (cboGheMoi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn ghế!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboGheMoi.Focus();
                return false;
            }

            return true;
        }

        private void cboToaMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboToaMoi.SelectedValue == null) return;

                int maToa;
                if (!int.TryParse(cboToaMoi.SelectedValue.ToString(), out maToa))
                    return;

                var dsGhe = busChuyenTau.LayDanhSachGheTrongBangMaToa(maToa);

                cboGheMoi.DataSource = dsGhe;
                cboGheMoi.DisplayMember = "SoHieu";
                cboGheMoi.ValueMember = "MaGhe";

                if (dsGhe.Count == 0)
                {
                    MessageBox.Show("Toa này đã hết ghế trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load danh sách ghế: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboGheMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboGheMoi.SelectedValue != null)
            {
                // Giả lập giá vé mới (có thể lấy từ database theo loại ghế/toa)
                decimal giaVeMoi = TinhGiaVeMoi();
                txtGiaVeMoi.Text = $"{giaVeMoi:N0} VND";

                // Tính và hiển thị chênh lệch
                decimal chenhLech = busThanhToan.TinhChenhLechGiaVe(_thongTinVeCu.GiaVe, giaVeMoi);
                HienThiChenhLech(chenhLech);
            }
        }

        private decimal TinhGiaVeMoi()
        {
            try
            {
                if (cboToaMoi.SelectedValue != null)
                {
                    int maToa = Convert.ToInt32(cboToaMoi.SelectedValue);
                    return busVe.LayGiaVeTuToa(maToa);
                }
                return 0;
            }
            catch
            {
                return 0;
            }
        }

        private void HienThiChenhLech(decimal chenhLech)
        {
            if (chenhLech == 0)
            {
                lblChenhLech.Visible = false;
                txtChenhLech.Visible = false;
                lblThongBao.Visible = false;
            }
            else
            {
                lblChenhLech.Visible = true;
                txtChenhLech.Visible = true;
                lblThongBao.Visible = true;

                if (chenhLech > 0)
                {
                    txtChenhLech.Text = $"+{chenhLech:N0} VND";
                    txtChenhLech.ForeColor = Color.Red;
                    lblThongBao.Text = "Bạn cần thanh toán thêm số tiền chênh lệch";
                    lblThongBao.ForeColor = Color.Red;
                }
                else
                {
                    txtChenhLech.Text = $"{chenhLech:N0} VND";
                    txtChenhLech.ForeColor = Color.Green;
                    lblThongBao.Text = "Bạn sẽ được hoàn lại số tiền chênh lệch";
                    lblThongBao.ForeColor = Color.Green;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
