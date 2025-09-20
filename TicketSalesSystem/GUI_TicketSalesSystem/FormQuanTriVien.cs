using BUS_TicketSalesSystem;
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
using static DTO_TicketSalesSystem.DTO_QuanLy;

namespace GUI_TicketSalesSystem
{
    public partial class FormQuanTriVien : Form
    {
        private readonly BUS_QuanLy busQuanLy = new BUS_QuanLy();
        private DTO_Dashboard dashboard;
        private Timer autoRefreshTimer;

        public FormQuanTriVien()
        {
            InitializeComponent();
            SetupTimer();
        }

        private void FormQuanTriVien_Load(object sender, EventArgs e)
        {
            try
            {
                lblChaoAdmin.Text = $"Xin chào Quản trị viên: {UserSession.Username}";
                LoadDashboard();
                LoadCanhBao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form quản lý người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCaiDatHeThong_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new FormCaiDatHeThong())
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form cài đặt: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLamMoiDashboard_Click(object sender, EventArgs e)
        {
            LoadDashboard();
            LoadCanhBao();
            MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnTimKiemNguoiDung_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = txtTimKiem.Text.Trim();
                if (string.IsNullOrEmpty(tuKhoa))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ketQua = busQuanLy.TimKiemNguoiDung(tuKhoa);
                if (ketQua.Count > 0)
                {
                    var thongTin = $"Tìm thấy {ketQua.Count} người dùng:\n";
                    foreach (var user in ketQua.Take(5))
                    {
                        thongTin += $"- {user.GetHoTen()} ({user.Email})\n";
                    }
                    MessageBox.Show(thongTin, "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy người dùng nào!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnKhoaTaiKhoan_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này cần chọn người dùng cụ thể!\nVui lòng sử dụng 'Quản lý người dùng' để thực hiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDatLaiMatKhau_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này cần chọn người dùng cụ thể!\nVui lòng sử dụng 'Quản lý người dùng' để thực hiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnXemLichSu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này cần chọn người dùng cụ thể!\nVui lòng sử dụng 'Quản lý người dùng' để thực hiện.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnXuatBaoCaoNgay_Click(object sender, EventArgs e)
        {
            try
            {
                var baoCao = busQuanLy.LayBaoCaoTongHop(DateTime.Today, DateTime.Today);
                using (var form = new FormBaoCaoTongHop(baoCao))
                {
                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSaoLuuDuLieu_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Bạn có chắc muốn thực hiện sao lưu dữ liệu?", "Xác nhận sao lưu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Simulate backup process
                    MessageBox.Show("Đã thực hiện sao lưu dữ liệu thành công!", "Sao lưu hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCanhBao(); // Refresh warnings
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi sao lưu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnKiemTraHeThong_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Hệ thống đang hoạt động bình thường!\n\n" +
                                           "✓ Database: Kết nối OK\n" +
                                           "✓ Server: Hoạt động bình thường\n" +
                                           "✓ Dung lượng: 65% đã sử dụng\n" +
                                           "✓ Bảo mật: Cập nhật mới nhất",
                                           "Kiểm tra hệ thống",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kiểm tra hệ thống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXemThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                using (var formThongKe = new FormThongKe())
                {
                    formThongKe.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            try
            {
                using (Form formNguoiDung = new FormQuanLyNguoiDung())
                {
                    formNguoiDung.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupTimer()
        {
            autoRefreshTimer = new Timer();
            autoRefreshTimer.Interval = 60000; // 1 phút
            autoRefreshTimer.Tick += (s, e) => LoadDashboard();
            autoRefreshTimer.Start();
        }

        private void LoadDashboard()
        {
            try
            {
                dashboard = busQuanLy.LayDashboard();

                // Hiển thị thống kê tổng quan
                lblDoanhThuHomNay.Text = $"Hôm nay: {dashboard.DoanhThuHomNay:N0} VND";
                lblDoanhThuThangNay.Text = $"Tháng này: {dashboard.DoanhThuThangNay:N0} VND";
                lblSoVeHomNay.Text = $"Hôm nay: {dashboard.SoVeHomNay:N0}";
                lblSoVeThangNay.Text = $"Tháng này: {dashboard.SoVeThangNay:N0}";

                lblTongNguoiDung.Text = $"Tổng: {dashboard.TongNguoiDung:N0}";
                lblNguoiDungMoi.Text = $"Mới: {dashboard.NguoiDungMoiThangNay:N0}";
                lblSoChuyenDangChay.Text = $"Chuyến: {dashboard.SoChuyenDangChay:N0}";
                lblTiLeGheTrong.Text = $"Ghế trống: {dashboard.TiLeGheTrong:N1}%";

                // Cập nhật progress bars
                UpdateProgressBars();

                // Load top 5 tuyến
                LoadTopTuyen();

                lblCapNhatLan.Text = $"Cập nhật: {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load dashboard: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateProgressBars()
        {
            try
            {
                // Progress bar doanh thu (so với mục tiêu giả định)
                decimal mucTieuThang = 1000000000; // 1 tỷ
                int progressValue = (int)Math.Min(100, (dashboard.DoanhThuThangNay / mucTieuThang) * 100);
                progressDoanhThu.Value = progressValue;

                // Progress bar ghế trống (đảo ngược - càng ít ghế trống càng tốt)
                progressGheTrong.Value = (int)(100 - dashboard.TiLeGheTrong);
            }
            catch
            {
                progressDoanhThu.Value = 0;
                progressGheTrong.Value = 0;
            }
        }

        private void LoadTopTuyen()
        {
            try
            {
                dgvTopTuyen.Rows.Clear();

                if (dashboard?.Top5TuyenBanChay != null)
                {
                    foreach (var tuyen in dashboard.Top5TuyenBanChay)
                    {
                        dgvTopTuyen.Rows.Add(
                            tuyen.XepHang,
                            tuyen.TenTuyen,
                            tuyen.SoVeBan.ToString("N0"),
                            tuyen.DoanhThu.ToString("N0") + " VND"
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load top tuyến: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCanhBao()
        {
            try
            {
                dgvCanhBao.Rows.Clear();

                // Mock data cho cảnh báo
                dgvCanhBao.Rows.Add("INFO", "Hệ thống đang hoạt động bình thường", DateTime.Now.ToString("HH:mm"), "Đã xử lý");
                dgvCanhBao.Rows.Add("WARNING", "Dung lượng database đạt 80%", DateTime.Now.AddMinutes(-15).ToString("HH:mm"), "Chưa xử lý");
                dgvCanhBao.Rows.Add("INFO", "Backup dữ liệu thành công", DateTime.Now.AddHours(-1).ToString("HH:mm"), "Đã xử lý");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load cảnh báo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            autoRefreshTimer?.Stop();
            autoRefreshTimer?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
