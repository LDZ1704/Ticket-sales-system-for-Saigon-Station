using BUS_TicketSalesSystem;
using DTO_TicketSalesSystem;
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
    public partial class FormDatVeGioHang : Form
    {
        private BUS_ChuyenTau busChuyenTau;
        private BUS_Ghe busGhe;
        private BUS_DatVe busDatVe;
        private int maNguoiDung;
        private FormGioHang formGioHang;

        public FormDatVeGioHang(int maNguoiDung)
        {
            InitializeComponent();
            this.maNguoiDung = maNguoiDung;
            this.busChuyenTau = new BUS_ChuyenTau();
            this.busGhe = new BUS_Ghe();
            this.busDatVe = new BUS_DatVe();
            this.formGioHang = new FormGioHang(maNguoiDung);
            LoadChuyenTau();
        }

        private void LoadChuyenTau()
        {
            try
            {
                var chuyenTau = busChuyenTau.LayTatCaChuyenTau();
                cboChuyenTau.DataSource = chuyenTau.Select(c => new
                {
                    MaChuyen = c.MaChuyen,
                    TenChuyen = $"{c.TenTau} - {c.TenGaDi} → {c.TenGaDen}",
                    GioKhoiHanh = c.GioKhoiHanh.ToString("dd/MM/yyyy HH:mm"),
                    GiaVe = c.GiaVe
                }).ToList();

                cboChuyenTau.DisplayMember = "TenChuyen";
                cboChuyenTau.ValueMember = "MaChuyen";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải chuyến tàu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboChuyenTau_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChuyenTau.SelectedValue != null && int.TryParse(cboChuyenTau.SelectedValue.ToString(), out int maChuyen))
            {
                LoadGhe(maChuyen);
            }
        }

        private void LoadGhe(int maChuyen)
        {
            try
            {
                var ghe = busGhe.LayGheTheoChuyen(maChuyen);
                dgvGhe.DataSource = ghe.Select(g => new
                {
                    g.MaGhe,
                    g.SoHieu,
                    g.ViTri,
                    g.TrangThai,
                    g.TenToa,
                    g.LoaiGhe,
                    GiaVe = g.GiaVe.ToString("N0") + " VNĐ"
                }).ToList();

                dgvGhe.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải ghế: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            if (dgvGhe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ghế!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtHoTen.Text) || string.IsNullOrEmpty(txtSoGiayTo.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hành khách!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var selectedRow = dgvGhe.SelectedRows[0];
                int maGhe = (int)selectedRow.Cells["MaGhe"].Value;
                string trangThai = selectedRow.Cells["TrangThai"].Value.ToString();

                if (trangThai != "TRONG")
                {
                    MessageBox.Show("Ghế đã được đặt!", "Thông báo", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy thông tin chuyến tàu đã chọn
                var selectedChuyen = busChuyenTau.LayChuyenTauBangId((int)cboChuyenTau.SelectedValue);
                
                // Tạo vé trong giỏ hàng
                var veTrongGio = new DTO_VeTrongGio
                {
                    MaChuyen = (int)cboChuyenTau.SelectedValue,
                    MaGhe = maGhe,
                    HoTen = txtHoTen.Text,
                    GioiTinh = cboGioiTinh.Text,
                    NgaySinh = dtpNgaySinh.Value,
                    SoGiayTo = txtSoGiayTo.Text,
                    GiaVe = decimal.Parse(selectedRow.Cells["GiaVe"].Value.ToString().Replace(" VNĐ", "").Replace(",", "")),
                    TenGaDi = selectedChuyen?.TenGaDi ?? "N/A",
                    TenGaDen = selectedChuyen?.TenGaDen ?? "N/A", 
                    TenTau = selectedChuyen?.TenTau ?? "N/A",
                    SoHieuGhe = selectedRow.Cells["SoHieu"].Value.ToString(),
                    TenToa = selectedRow.Cells["TenToa"].Value.ToString(),
                    GioKhoiHanh = selectedChuyen?.GioKhoiHanh ?? DateTime.Now.AddDays(1)
                };

                formGioHang.ThemVeVaoGio(veTrongGio);
                
                MessageBox.Show("Đã thêm vé vào giỏ hàng!", "Thành công", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa thông tin nhập
                txtHoTen.Clear();
                txtSoGiayTo.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thêm vé: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemGioHang_Click(object sender, EventArgs e)
        {
            formGioHang.ShowDialog();
        }

        private void btnThanhToanTrucTiep_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy giỏ hàng từ form giỏ hàng
                var gioHang = formGioHang.GetGioHang();
                
                // Kiểm tra giỏ hàng có vé không
                if (gioHang == null || !gioHang.DanhSachVe.Any())
                {
                    MessageBox.Show("Giỏ hàng trống! Vui lòng thêm vé vào giỏ hàng trước khi thanh toán.", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận thanh toán
                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn thanh toán {gioHang.DanhSachVe.Count} vé với tổng tiền {gioHang.TongTien:N0} VNĐ?\n\n" +
                    "Sau khi xác nhận, hệ thống sẽ mở trang thanh toán VNPay.",
                    "Xác nhận thanh toán", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                // Tạo URL thanh toán VNPay
                string paymentUrl = busDatVe.TaoUrlThanhToanVNPay(gioHang);
                
                // Mở trình duyệt để thanh toán
                System.Diagnostics.Process.Start(paymentUrl);
                
                MessageBox.Show(
                    "Đã mở trang thanh toán VNPay.\n\n" +
                    "Vui lòng hoàn tất thanh toán trong trình duyệt.\n" +
                    "Sau khi thanh toán thành công, vé sẽ được gửi qua email của bạn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Xóa giỏ hàng sau khi thanh toán
                gioHang.DanhSachVe.Clear();
                formGioHang.LoadGioHang();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thanh toán: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
