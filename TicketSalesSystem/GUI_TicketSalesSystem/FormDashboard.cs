using BUS_TicketSalesSystem;
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
    public partial class FormDashboard : Form
    {
        private readonly BUS_QuanLy busQuanLy = new BUS_QuanLy();
        private Timer refreshTimer;

        public FormDashboard()
        {
            InitializeComponent();
            SetupTimer();
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo dashboard: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupTimer()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 30000; // 30 giây
            refreshTimer.Tick += RefreshTimer_Tick;
            refreshTimer.Start();
        }

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            LoadDashboard();
        }

        private void LoadDashboard()
        {
            try
            {
                var dashboard = busQuanLy.LayDashboard();

                // Hiển thị số liệu tổng quan
                lblDoanhThuHomNay.Text = $"Hôm nay: {dashboard.DoanhThuHomNay:N0} VND";
                lblDoanhThuThangNay.Text = $"Tháng này: {dashboard.DoanhThuThangNay:N0} VND";
                lblDoanhThuNamNay.Text = $"Năm nay: {dashboard.DoanhThuNamNay:N0} VND";

                lblSoVeHomNay.Text = $"Hôm nay: {dashboard.SoVeHomNay:N0}";
                lblSoVeThangNay.Text = $"Tháng này: {dashboard.SoVeThangNay:N0}";
                lblSoVeNamNay.Text = $"Năm nay: {dashboard.SoVeNamNay:N0}";

                lblTongNguoiDung.Text = $"Tổng: {dashboard.TongNguoiDung:N0}";
                lblNguoiDungMoi.Text = $"Mới: {dashboard.NguoiDungMoiThangNay:N0}";
                lblSoChuyenDangChay.Text = $"Chuyến: {dashboard.SoChuyenDangChay:N0}";
                lblTiLeGheTrong.Text = $"Ghế trống: {dashboard.TiLeGheTrong:N1}%";

                // Hiển thị top 5 tuyến bán chạy
                LoadTop5Tuyen(dashboard.Top5TuyenBanChay);

                // Hiển thị doanh thu 7 ngày gần nhất
                LoadDoanhThu7Ngay(dashboard.DoanhThu7NgayGanNhat);

                lblCapNhatLan.Text = $"Cập nhật lần cuối: {DateTime.Now:HH:mm:ss}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load dashboard: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTop5Tuyen(List<DTO_ThongKeTuyen> topTuyen)
        {
            dgvTop5Tuyen.Rows.Clear();

            if (topTuyen == null || topTuyen.Count == 0)
            {
                dgvTop5Tuyen.Rows.Add("", "Chưa có dữ liệu", "0", "0 VND");
                return;
            }

            foreach (var tuyen in topTuyen)
            {
                int rowIndex = dgvTop5Tuyen.Rows.Add(
                    tuyen.XepHang,
                    tuyen.TenTuyen,
                    tuyen.SoVeBan.ToString("N0"),
                    tuyen.DoanhThu.ToString("N0") + " VND"
                );

                var row = dgvTop5Tuyen.Rows[rowIndex];

                // Màu sắc theo thứ hạng
                switch (tuyen.XepHang)
                {
                    case 1:
                        row.DefaultCellStyle.BackColor = Color.Gold;
                        row.DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                        break;
                    case 2:
                        row.DefaultCellStyle.BackColor = Color.Silver;
                        row.DefaultCellStyle.ForeColor = Color.DarkSlateGray;
                        break;
                    case 3:
                        row.DefaultCellStyle.BackColor = Color.FromArgb(205, 127, 50); // Bronze
                        row.DefaultCellStyle.ForeColor = Color.White;
                        break;
                }
            }
        }

        private void LoadDoanhThu7Ngay(List<DTO_ThongKeDoanhThu> doanhThu7Ngay)
        {
            dgvDoanhThu7Ngay.Rows.Clear();

            if (doanhThu7Ngay == null || doanhThu7Ngay.Count == 0)
            {
                dgvDoanhThu7Ngay.Rows.Add(DateTime.Today.ToString("dd/MM/yyyy"), "0", "0 VND");
                return;
            }

            foreach (var ngay in doanhThu7Ngay.OrderByDescending(x => x.NgayBaoCao))
            {
                int rowIndex = dgvDoanhThu7Ngay.Rows.Add(
                    ngay.NgayBaoCao.ToString("dd/MM/yyyy"),
                    ngay.SoVeBan.ToString("N0"),
                    ngay.DoanhThuTheoNgay.ToString("N0") + " VND"
                );

                var row = dgvDoanhThu7Ngay.Rows[rowIndex];

                // Màu xanh cho ngày có doanh thu cao
                if (ngay.DoanhThuTheoNgay > 0)
                {
                    var maxDoanhThu = doanhThu7Ngay.Max(x => x.DoanhThuTheoNgay);
                    if (ngay.DoanhThuTheoNgay == maxDoanhThu)
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    }
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDashboard();
            MessageBox.Show("Đã cập nhật dữ liệu mới nhất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show($"Lỗi mở form quản lý người dùng: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCaiDat_Click(object sender, EventArgs e)
        {
            try
            {
                using (Form formCaiDat = new FormCaiDatHeThong())
                {
                    formCaiDat.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form cài đặt: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            refreshTimer?.Stop();
            refreshTimer?.Dispose();
            base.OnFormClosed(e);
        }
    }
}
