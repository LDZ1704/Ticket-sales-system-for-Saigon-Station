using BUS_TicketSalesSystem;
using DTO_TicketSalesSystem;
using DTO_TicketSalesSystem.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI_TicketSalesSystem
{
    public partial class FormVeCuaToi : Form
    {
        private readonly BUS_Ve busVe = new BUS_Ve();
        private readonly BUS_TaiKhoan busTaiKhoan = new BUS_TaiKhoan();
        private List<DTO_Ve> currentVes = new List<DTO_Ve>();
        public FormVeCuaToi()
        {
            InitializeComponent();
            this.Load += FormVeCuaToi_Load;
        }

        private void FormVeCuaToi_Load(object sender, EventArgs e)
        {
            try
            {
                LoadVes();
                SetupEvents();
                SetupDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDataGridView()
        {
            // Cấu hình DataGridView
            dgvVe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVe.MultiSelect = false;
            dgvVe.ReadOnly = true;
            dgvVe.AllowUserToAddRows = false;
            dgvVe.AllowUserToDeleteRows = false;
            dgvVe.AllowUserToResizeRows = false;

            // Set column headers
            if (dgvVe.Columns.Count >= 8)
            {
                dgvVe.Columns[0].HeaderText = "Mã vé";
                dgvVe.Columns[1].HeaderText = "Hành khách";
                dgvVe.Columns[2].HeaderText = "Tuyến đường";
                dgvVe.Columns[3].HeaderText = "Toa - Ghế";
                dgvVe.Columns[4].HeaderText = "Ngày khởi hành";
                dgvVe.Columns[5].HeaderText = "Giá vé";
                dgvVe.Columns[6].HeaderText = "Trạng thái";
                dgvVe.Columns[7].HeaderText = "Ngày đặt";
            }
        }

        private void LoadVes()
        {
            try
            {
                var list = busVe.LayVeBangNguoiDung(UserSession.UserId);
                currentVes = list;

                dgvVe.Rows.Clear();

                if (list.Count == 0)
                {
                    MessageBox.Show("Bạn chưa đặt vé nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var ve in list)
                {
                    int rowIndex = dgvVe.Rows.Add(
                        ve.MaVe,
                        ve.HanhKhach,
                        ve.Tuyen,
                        ve.ToaGhe,
                        ve.NgayKhoiHanh.ToString("dd/MM/yyyy HH:mm"),
                        ve.GiaVe.ToString("N0") + " VND",
                        ve.TrangThai,
                        ve.NgayDat.ToString("dd/MM/yyyy")
                    );

                    // Đổi màu dòng theo trạng thái
                    var row = dgvVe.Rows[rowIndex];
                    SetRowColor(row, ve.TrangThai);
                }

                // Hiển thị thống kê
                ShowStatistics(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetRowColor(DataGridViewRow row, string trangThai)
        {
            switch (trangThai)
            {
                case "Đã hủy":
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                    row.DefaultCellStyle.ForeColor = Color.DarkRed;
                    break;
                case "Đã đổi":
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                    row.DefaultCellStyle.ForeColor = Color.DarkGoldenrod;
                    break;
                case "Đã thanh toán":
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    break;
                default:
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                    break;
            }
        }

        private void ShowStatistics(List<DTO_Ve> ves)
        {
            try
            {
                int tongVe = ves.Count;
                int veDaThanhToan = ves.Count(v => v.TrangThai == "Đã thanh toán");
                int veDaHuy = ves.Count(v => v.TrangThai == "Đã hủy");

                this.Text = $"Hệ thống bán vé ga Sài Gòn - Vé của tôi (Tổng: {tongVe}, Hoạt động: {veDaThanhToan}, Đã hủy: {veDaHuy})";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupEvents()
        {
            btnLamMoi.Click += btnLamMoi_Click;
            btnHuyVe.Click += btnHuyVe_Click;
            btnDoiVe.Click += btnDoiVe_Click;
            dgvVe.SelectionChanged += dgvVe_SelectionChanged;
        }

        private void dgvVe_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                bool hasSelection = dgvVe.SelectedRows.Count > 0;

                if (hasSelection)
                {
                    var selectedRow = dgvVe.SelectedRows[0];
                    string trangThai = selectedRow.Cells["dgvTrangThai"].Value?.ToString() ?? "";

                    //Enable/disable buttons based on ticket status
                    btnHuyVe.Enabled = busVe.KiemTraVeCoTheHuy(trangThai);
                    btnDoiVe.Enabled = busVe.KiemTraVeCoTheHuy(trangThai);

                    //Update button text based on status
                    if (trangThai == "Đã hủy")
                    {
                        btnHuyVe.Text = "Đã hủy";
                        btnDoiVe.Text = "Không thể đổi";
                    }
                    else
                    {
                        btnHuyVe.Text = "Hủy vé";
                        btnDoiVe.Text = "Đổi vé";
                    }
                }
                else
                {
                    btnHuyVe.Enabled = false;
                    btnDoiVe.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật giao diện: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadVes();
        }

        private void btnHuyVe_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVe.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn vé cần hủy!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dgvVe.SelectedRows[0];
                int maVe = (int)selectedRow.Cells["dgvMaVe"].Value;
                string trangThai = selectedRow.Cells["dgvTrangThai"].Value?.ToString() ?? "";
                string hanhKhach = selectedRow.Cells["dgvHanhKhach"].Value?.ToString() ?? "";
                string tuyen = selectedRow.Cells["dgvTuyen"].Value?.ToString() ?? "";

                if (!busVe.KiemTraVeCoTheHuy(trangThai))
                {
                    MessageBox.Show("Chỉ có thể hủy vé đã thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Hiển thị thông tin vé để xác nhận
                var confirmMessage = $"Bạn có chắc chắn muốn hủy vé này?\n\n" +
                                   $"Mã vé: {maVe}\n" +
                                   $"Hành khách: {hanhKhach}\n" +
                                   $"Tuyến: {tuyen}\n\n" +
                                   $"Lưu ý: Hành động này không thể hoàn tác!";

                var result = MessageBox.Show(confirmMessage, "Xác nhận hủy vé", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    bool success = busVe.HuyVe(maVe);
                    if (success)
                    {
                        MessageBox.Show("Hủy vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadVes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hủy vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDoiVe_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvVe.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn vé cần đổi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dgvVe.SelectedRows[0];
                string trangThai = selectedRow.Cells["dgvTrangThai"].Value?.ToString() ?? "";

                if (!busVe.KiemTraVeCoTheHuy(trangThai))
                {
                    MessageBox.Show("Chỉ có thể đổi vé đã thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show("Chức năng đổi vé đang được phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đổi vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
