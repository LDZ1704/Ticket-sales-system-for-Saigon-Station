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

namespace GUI_TicketSalesSystem
{
    public partial class FormThongKe : Form
    {
        private readonly BUS_QuanLy busQuanLy = new BUS_QuanLy();

        public FormThongKe()
        {
            InitializeComponent();
        }

        private void FormThongKe_Load(object sender, EventArgs e)
        {
            try
            {
                dtpTuNgay.Value = DateTime.Today.AddDays(-30);
                dtpDenNgay.Value = DateTime.Today;

                SetupTabVe();
                SetupTabTuyen();
                LoadThongKeDoanhThu();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Tab Doanh Thu

        private void BtnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabThongKe.SelectedIndex == 0)
                {
                    LoadThongKeDoanhThu();
                }
                else if (tabThongKe.SelectedIndex == 1)
                {
                    LoadThongKeVe();
                }
                else if (tabThongKe.SelectedIndex == 2)
                {
                    LoadThongKeTuyen();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadThongKeDoanhThu()
        {
            try
            {
                if (!ValidateDate()) return;

                var data = busQuanLy.LayThongKeDoanhThu(dtpTuNgay.Value.Date, dtpDenNgay.Value.Date);

                dgvDoanhThu.Rows.Clear();
                decimal tongDoanhThu = 0;
                int tongSoVe = 0;

                foreach (var item in data)
                {
                    dgvDoanhThu.Rows.Add(
                        item.NgayBaoCao.ToString("dd/MM/yyyy"),
                        item.SoVeBan.ToString("N0"),
                        item.DoanhThuTheoNgay.ToString("N0") + " VND"
                    );

                    tongDoanhThu += item.DoanhThuTheoNgay;
                    tongSoVe += item.SoVeBan;
                }

                lblDoanhThu.Text = $"Tổng doanh thu: {tongDoanhThu:N0} VND";
                lblSoVe.Text = $"Tổng số vé: {tongSoVe:N0}";

                if (data.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trong khoảng thời gian này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load thống kê doanh thu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Tab thống kê vé

        private DataGridView dgvVe;
        private Label lblTongVe;
        private Label lblVeDaThanhToan;
        private Label lblVeHuy;
        private Label lblVeDoi;

        private void SetupTabVe()
        {
            // Tạo controls cho tab vé
            dgvVe = new DataGridView
            {
                Location = new Point(20, 120),
                Size = new Size(1090, 400),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells,
                ColumnHeadersHeight = 40
            };

            dgvVe.Columns.Add("TrangThai", "Trạng thái");
            dgvVe.Columns.Add("SoLuong", "Số lượng");
            dgvVe.Columns.Add("TiLe", "Tỷ lệ (%)");

            lblTongVe = new Label
            {
                Location = new Point(30, 30),
                Size = new Size(300, 30),
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.Blue,
                Text = "Tổng số vé: 0"
            };

            lblVeDaThanhToan = new Label
            {
                Location = new Point(350, 30),
                Size = new Size(300, 30),
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.Green,
                Text = "Đã thanh toán: 0"
            };

            lblVeHuy = new Label
            {
                Location = new Point(30, 70),
                Size = new Size(300, 30),
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.Red,
                Text = "Đã hủy: 0"
            };

            lblVeDoi = new Label
            {
                Location = new Point(350, 70),
                Size = new Size(300, 30),
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.Orange,
                Text = "Đã đổi: 0"
            };

            tabVe.Controls.AddRange(new Control[] { dgvVe, lblTongVe, lblVeDaThanhToan, lblVeHuy, lblVeDoi });
        }

        private void LoadThongKeVe()
        {
            try
            {
                if (!ValidateDate()) return;

                var data = busQuanLy.LayThongKeVe(dtpTuNgay.Value.Date, dtpDenNgay.Value.Date);

                dgvVe.Rows.Clear();
                int tongVe = 0;
                int veDaThanhToan = 0, veHuy = 0, veDoi = 0;

                foreach (var item in data)
                {
                    string trangThaiDisplay = ChuyenDoiTrangThai(item.TrangThai);

                    dgvVe.Rows.Add(
                        trangThaiDisplay,
                        item.SoLuong.ToString("N0"),
                        item.TiLe.ToString("N2") + "%"
                    );

                    tongVe += item.SoLuong;

                    switch (item.TrangThai)
                    {
                        case "DATHANHTOAN": veDaThanhToan = item.SoLuong; break;
                        case "DAHUY": veHuy = item.SoLuong; break;
                        case "DADOI": veDoi = item.SoLuong; break;
                    }
                }

                lblTongVe.Text = $"Tổng số vé: {tongVe:N0}";
                lblVeDaThanhToan.Text = $"Đã thanh toán: {veDaThanhToan:N0}";
                lblVeHuy.Text = $"Đã hủy: {veHuy:N0}";
                lblVeDoi.Text = $"Đã đổi: {veDoi:N0}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load thống kê vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Tab thống kê tuyến

        private DataGridView dgvTuyen;
        private Label lblTuyenBanChay;
        private Label lblTongTuyen;

        private void SetupTabTuyen()
        {
            dgvTuyen = new DataGridView
            {
                Location = new Point(20, 120),
                Size = new Size(1090, 400),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells,
                ColumnHeadersHeight = 40
            };

            dgvTuyen.Columns.Add("XepHang", "Xếp hạng");
            dgvTuyen.Columns.Add("TenTuyen", "Tên tuyến");
            dgvTuyen.Columns.Add("SoVeBan", "Số vé bán");
            dgvTuyen.Columns.Add("DoanhThu", "Doanh thu");
            dgvTuyen.Columns.Add("DoanhThuTB", "Doanh thu TB");

            lblTuyenBanChay = new Label
            {
                Location = new Point(30, 30),
                Size = new Size(500, 30),
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.Blue,
                Text = "Tuyến bán chạy nhất: N/A"
            };

            lblTongTuyen = new Label
            {
                Location = new Point(30, 70),
                Size = new Size(300, 30),
                Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold),
                ForeColor = Color.Green,
                Text = "Tổng số tuyến: 0"
            };

            tabTuyen.Controls.AddRange(new Control[] { dgvTuyen, lblTuyenBanChay, lblTongTuyen });
        }

        private void LoadThongKeTuyen()
        {
            try
            {
                if (!ValidateDate()) return;

                var data = busQuanLy.LayThongKeTuyen(dtpTuNgay.Value.Date, dtpDenNgay.Value.Date);

                dgvTuyen.Rows.Clear();

                foreach (var item in data)
                {
                    dgvTuyen.Rows.Add(
                        item.XepHang.ToString(),
                        item.TenTuyen,
                        item.SoVeBan.ToString("N0"),
                        item.DoanhThu.ToString("N0") + " VND",
                        item.DoanhThuTrungBinh.ToString("N0") + " VND"
                    );
                }

                lblTongTuyen.Text = $"Tổng số tuyến: {data.Count}";
                lblTuyenBanChay.Text = data.Count > 0 ? $"Tuyến bán chạy nhất: {data[0].TenTuyen}" : "Tuyến bán chạy nhất: N/A";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load thống kê tuyến: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Events

        private void TabThongKe_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                switch (tabThongKe.SelectedIndex)
                {
                    case 0: // Doanh thu
                        LoadThongKeDoanhThu();
                        break;
                    case 1: // Vé
                        LoadThongKeVe();
                        break;
                    case 2: // Tuyến
                        LoadThongKeTuyen();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi chuyển tab: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Helper Methods

        private bool ValidateDate()
        {
            if (dtpTuNgay.Value > dtpDenNgay.Value)
            {
                MessageBox.Show("Ngày bắt đầu không thể lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var khoangCach = (dtpDenNgay.Value - dtpTuNgay.Value).TotalDays;
            if (khoangCach > 365)
            {
                MessageBox.Show("Khoảng thời gian không được quá 1 năm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private string ChuyenDoiTrangThai(string trangThai)
        {
            switch (trangThai)
            {
                case "DATHANHTOAN":
                    return "Đã thanh toán";
                case "DAHUY":
                    return "Đã hủy";
                case "DADOI":
                    return "Đã đổi";
                default:
                    return trangThai;
            }
        }

        #endregion

        #region Menu Functions

        private void btnXuatBaoCao_Click(object sender, EventArgs e)
        {
            try
            {
                var baoCao = busQuanLy.LayBaoCaoTongHop(dtpTuNgay.Value.Date, dtpDenNgay.Value.Date);

                using (var formBaoCao = new FormBaoCaoTongHop(baoCao))
                {
                    formBaoCao.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất báo cáo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                dtpTuNgay.Value = DateTime.Today.AddDays(-30);
                dtpDenNgay.Value = DateTime.Today;

                BtnThongKe_Click(sender, e);

                MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi làm mới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
