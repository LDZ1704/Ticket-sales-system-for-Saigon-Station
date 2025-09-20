using BUS_TicketSalesSystem;
using DTO_TicketSalesSystem.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DTO_TicketSalesSystem.DTO_QuanLy;

namespace GUI_TicketSalesSystem
{
    public partial class FormQuanLyNguoiDung : Form
    {
        private readonly BUS_QuanLy busQuanLy = new BUS_QuanLy();

        public FormQuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void FormQuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            try
            {
                SetupComboBox();
                LoadDanhSachNguoiDung();
                HienThiThongKe();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupComboBox()
        {
            cboLoaiNguoiDung.Items.AddRange(new[] { "Tất cả", "Khách hàng", "Nhân viên", "Quản trị viên" });
            cboLoaiNguoiDung.SelectedIndex = 0;
        }

        private void LoadDanhSachNguoiDung()
        {
            try
            {
                var data = busQuanLy.LayDanhSachNguoiDung();
                HienThiDanhSach(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load danh sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDanhSach(List<DTO_QuanLyNguoiDung> data)
        {
            dgvNguoiDung.Rows.Clear();

            foreach (var user in data)
            {
                int rowIndex = dgvNguoiDung.Rows.Add(
                    user.MaNguoiDung,
                    user.GetHoTen(),
                    user.Email,
                    user.SoDienThoai,
                    ChuyenDoiLoaiNguoiDung(user.LoaiNguoiDung),
                    ChuyenDoiTrangThaiTaiKhoan(user.TrangThaiTaiKhoan),
                    user.NgayTao.ToString("dd/MM/yyyy"),
                    user.SoVeDaDat,
                    user.TongChiTieu.ToString("N0") + " VND"
                );

                var row = dgvNguoiDung.Rows[rowIndex];

                // Đổi màu theo trạng thái
                if (user.TrangThaiTaiKhoan == "KHOA")
                {
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                }
                else if (user.LoaiNguoiDung == "QUANTRI")
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                    row.DefaultCellStyle.ForeColor = Color.DarkBlue;
                }
                else if (user.LoaiNguoiDung == "NHANVIEN")
                {
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                    row.DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                }
            }

            lblTongNguoiDung.Text = $"Tổng số: {data.Count} người dùng";
        }

        private void HienThiThongKe()
        {
            try
            {
                var thongKe = busQuanLy.LayThongKeNguoiDung();

                lblThongKe.Text = $"Khách hàng: {(thongKe.ContainsKey("KhachHang") ? thongKe["KhachHang"] : 0)} | " +
                                  $"Nhân viên: {(thongKe.ContainsKey("NhanVien") ? thongKe["NhanVien"] : 0)} | " +
                                  $"Admin: {(thongKe.ContainsKey("QuanTriVien") ? thongKe["QuanTriVien"] : 0)} | " +
                                  $"Hoạt động: {(thongKe.ContainsKey("TaiKhoanHoatDong") ? thongKe["TaiKhoanHoatDong"] : 0)}";
            }
            catch
            {
                lblThongKe.Text = "Không thể tải thống kê";
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(tuKhoa))
                {
                    LoadDanhSachNguoiDung();
                    return;
                }

                var data = busQuanLy.TimKiemNguoiDung(tuKhoa);
                HienThiDanhSach(data);

                if (data.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy người dùng nào!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                txtTimKiem.Clear();
                cboLoaiNguoiDung.SelectedIndex = 0;
                LoadDanhSachNguoiDung();
                HienThiThongKe();
                MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi làm mới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CboLoaiNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string loaiNguoiDung = cboLoaiNguoiDung.SelectedIndex.ToString();
                switch(loaiNguoiDung)
                {
                    case "0":
                        loaiNguoiDung = "ALL";
                        break;
                    case "1":
                        loaiNguoiDung = "KHACH";
                        break;
                    case "2":
                        loaiNguoiDung = "NHANVIEN";
                        break;
                    case "3":
                        loaiNguoiDung = "QUANTRI";
                        break;
                    default:
                        loaiNguoiDung = "ALL";
                        break;
                }

                var data = busQuanLy.LocNguoiDung(loaiNguoiDung);
                HienThiDanhSach(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvNguoiDung_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvNguoiDung.SelectedRows.Count > 0;
            btnKhoaTaiKhoan.Enabled = hasSelection;
            btnCapQuyen.Enabled = hasSelection;
            btnDatLaiMatKhau.Enabled = hasSelection;
            btnXemLichSu.Enabled = hasSelection;

            if (hasSelection)
            {
                var row = dgvNguoiDung.SelectedRows[0];
                string trangThai = row.Cells["TrangThaiTaiKhoan"].Value.ToString();
                btnKhoaTaiKhoan.Text = trangThai == "Hoạt động" ? "Khóa TK" : "Mở khóa TK";
            }
        }

        private void BtnKhoaTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNguoiDung.SelectedRows.Count == 0) return;

                var row = dgvNguoiDung.SelectedRows[0];
                int maNguoiDung = (int)row.Cells["MaNguoiDung"].Value;
                string hoTen = row.Cells["HoTen"].Value.ToString();
                string trangThai = row.Cells["TrangThaiTaiKhoan"].Value.ToString();
                string loaiNguoiDung = row.Cells["LoaiNguoiDung"].Value.ToString();

                // Không cho khóa admin cuối cùng
                if (loaiNguoiDung == "Quản trị viên" && trangThai == "Hoạt động")
                {
                    var adminCount = busQuanLy.LocNguoiDung("QUANTRI").Count(u => u.DangHoatDong);
                    if (adminCount <= 1)
                    {
                        MessageBox.Show("Không thể khóa admin cuối cùng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                bool khoa = (trangThai == "Hoạt động");
                string action = khoa ? "khóa" : "mở khóa";

                var result = MessageBox.Show($"Bạn có chắc muốn {action} tài khoản của {hoTen}?",
                    $"Xác nhận {action}", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = busQuanLy.KhoaTaiKhoan(maNguoiDung, khoa);
                    if (success)
                    {
                        MessageBox.Show($"Đã {action} tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachNguoiDung();
                        HienThiThongKe();
                    }
                    else
                    {
                        MessageBox.Show($"Không thể {action} tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thay đổi trạng thái: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCapQuyen_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNguoiDung.SelectedRows.Count == 0) return;

                var row = dgvNguoiDung.SelectedRows[0];
                int maNguoiDung = (int)row.Cells["MaNguoiDung"].Value;
                string hoTen = row.Cells["HoTen"].Value.ToString();

                //form cấp quyền
                using (var formCapQuyen = new FormCapQuyen(maNguoiDung, hoTen))
                {
                    if (formCapQuyen.ShowDialog() == DialogResult.OK)
                    {
                        LoadDanhSachNguoiDung();
                        HienThiThongKe();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cấp quyền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDatLaiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNguoiDung.SelectedRows.Count == 0) return;

                var row = dgvNguoiDung.SelectedRows[0];
                int maNguoiDung = (int)row.Cells["MaNguoiDung"].Value;
                string hoTen = row.Cells["HoTen"].Value.ToString();

                var result = MessageBox.Show($"Đặt lại mật khẩu thành '123456' cho {hoTen}?",
                    "Xác nhận đặt lại mật khẩu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = busQuanLy.DatLaiMatKhau(maNguoiDung);
                    if (success)
                    {
                        MessageBox.Show("Đã đặt lại mật khẩu thành '123456'!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể đặt lại mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đặt lại mật khẩu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnXemLichSu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNguoiDung.SelectedRows.Count == 0) return;

                var row = dgvNguoiDung.SelectedRows[0];
                int maNguoiDung = (int)row.Cells["MaNguoiDung"].Value;
                string hoTen = row.Cells["HoTen"].Value.ToString();

                var lichSu = busQuanLy.LayLichSuHoatDong(maNguoiDung, 20);

                //Xem lịch sử hoạt động
                using (var formLichSu = new FormLichSuHoatDong(hoTen, lichSu))
                {
                    formLichSu.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xem lịch sử: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaTaiKhoan_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNguoiDung.SelectedRows.Count == 0) return;

                var row = dgvNguoiDung.SelectedRows[0];
                int maNguoiDung = (int)row.Cells["MaNguoiDung"].Value;
                string hoTen = row.Cells["HoTen"].Value.ToString();
                string loaiNguoiDung = row.Cells["LoaiNguoiDung"].Value.ToString();

                // Không cho xóa admin cuối cùng
                if (loaiNguoiDung == "Quản trị viên")
                {
                    var adminCount = busQuanLy.LocNguoiDung("QUANTRI").Count(u => u.DangHoatDong);
                    if (adminCount <= 1)
                    {
                        MessageBox.Show("Không thể xóa admin cuối cùng!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                var result = MessageBox.Show(
                    $"Bạn có chắc muốn XÓA HOÀN TOÀN người dùng '{hoTen}'?\n\n" +
                    "- Tất cả vé đã mua sẽ bị xóa\n" +
                    "- Ghế đã đặt sẽ được trả về trạng thái trống\n" +
                    "- Thông tin hành khách sẽ bị xóa\n" +
                    "- Tất cả giao dịch thanh toán sẽ bị xóa\n" +
                    "- Tài khoản sẽ bị xóa vĩnh viễn\n\n" +
                    "Hành động này KHÔNG THỂ hoàn tác!",
                    "XÁC NHẬN XÓA VĨNH VIỄN",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    bool success = busQuanLy.XoaNguoiDung(maNguoiDung);
                    if (success)
                    {
                        MessageBox.Show("Đã xóa người dùng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDanhSachNguoiDung();
                        HienThiThongKe();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xóa người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ChuyenDoiLoaiNguoiDung(string loai)
        {
            switch (loai)
            {
                case "KHACH":
                    return "Khách hàng";
                case "NHANVIEN":
                    return "Nhân viên";
                case "QUANTRI":
                    return "Quản trị viên";
                default:
                    return loai;
            }
        }

        private string ChuyenDoiTrangThaiTaiKhoan(string trangThai)
        {
            switch (trangThai)
            {
                case "HOATDONG":
                    return "Hoạt động";
                case "KHOA":
                    return "Đã khóa";
                case "CHUA_CO_TK":
                    return "Chưa có TK";
                default:
                    return trangThai;
            }
        }
    }
}
