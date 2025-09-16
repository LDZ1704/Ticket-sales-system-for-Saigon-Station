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
        private readonly BUS_ThanhToan busThanhToan = new BUS_ThanhToan();
        private List<DTO_Ve> currentVes = new List<DTO_Ve>();
        public FormVeCuaToi()
        {
            InitializeComponent();
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
                    DoiMauCot(row, ve.TrangThai);
                }

                // Hiển thị thống kê
                HienThongKe(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoiMauCot(DataGridViewRow row, string trangThai)
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

        private void HienThongKe(List<DTO_Ve> ves)
        {
            try
            {
                int tongVe = ves.Count;
                int veDaThanhToan = ves.Count(v => v.TrangThai == "Đã thanh toán");
                int veDaHuy = ves.Count(v => v.TrangThai == "Đã hủy");
                int veDaDoi = ves.Count(v => v.TrangThai == "Đã đổi");

                this.Text = $"Hệ thống bán vé ga Sài Gòn - Vé của tôi (Tổng: {tongVe}, Hoạt động: {veDaThanhToan}, Đã hủy: {veDaHuy}, Đã đổi: {veDaDoi})";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupEvents()
        {
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
                    int maVe = (int)selectedRow.Cells["dgvMaVe"].Value;
                    string trangThai = selectedRow.Cells["dgvTrangThai"].Value?.ToString() ?? "";

                    // Kiểm tra điều kiện có thể hủy/đổi
                    bool coTheThaoTac = busVe.KiemTraVeCoTheHuyDoi(maVe, UserSession.UserId);

                    // Enable/disable buttons
                    btnHuyVe.Enabled = coTheThaoTac;
                    btnDoiVe.Enabled = coTheThaoTac;

                    // Update button text và tooltip
                    if (!coTheThaoTac)
                    {
                        string lyDo = busVe.LayLyDoKhongTheHuyDoi(maVe, UserSession.UserId);
                        btnHuyVe.Text = "Không thể hủy";
                        btnDoiVe.Text = "Không thể đổi";

                        // Set tooltip để hiển thị lý do
                        var tooltip = new ToolTip();
                        tooltip.SetToolTip(btnHuyVe, lyDo);
                        tooltip.SetToolTip(btnDoiVe, lyDo);
                    }
                    else
                    {
                        btnHuyVe.Text = "Hủy vé";
                        btnDoiVe.Text = "Đổi vé";

                        // Clear tooltip
                        var tooltip = new ToolTip();
                        tooltip.SetToolTip(btnHuyVe, "");
                        tooltip.SetToolTip(btnDoiVe, "");
                    }
                }
                else
                {
                    btnHuyVe.Enabled = false;
                    btnDoiVe.Enabled = false;
                    btnHuyVe.Text = "Hủy vé";
                    btnDoiVe.Text = "Đổi vé";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật giao diện: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                LoadVes();
                MessageBox.Show("Đã làm mới danh sách vé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi làm mới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                if (!busVe.KiemTraVeCoTheHuyDoi(maVe, UserSession.UserId))
                {
                    string lyDo = busVe.LayLyDoKhongTheHuyDoi(maVe, UserSession.UserId);
                    MessageBox.Show($"Không thể hủy vé!\n\nLý do: {lyDo}", "Không thể hủy", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var veInfo = currentVes.FirstOrDefault(v => v.MaVe == maVe);
                if (veInfo == null)
                {
                    MessageBox.Show("Không tìm thấy thông tin vé!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var formHuyVe = new FormHuyVe(maVe, veInfo))
                {
                    if (formHuyVe.ShowDialog() == DialogResult.OK)
                    {
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
                int maVeCu = (int)selectedRow.Cells["dgvMaVe"].Value;

                if (!busVe.KiemTraVeCoTheHuyDoi(maVeCu, UserSession.UserId))
                {
                    string lyDo = busVe.LayLyDoKhongTheHuyDoi(maVeCu, UserSession.UserId);
                    MessageBox.Show($"Không thể đổi vé!\n\nLý do: {lyDo}", "Không thể đổi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var formDoiVe = new FormDoiVe(maVeCu))
                {
                    if (formDoiVe.ShowDialog() == DialogResult.OK)
                    {
                        LoadVes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đổi vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                var thongKe = busVe.LayThongKeVe(UserSession.UserId);
                var thongBao = new StringBuilder();
                thongBao.AppendLine("THỐNG KÊ VÉ CỦA BẠN:");
                thongBao.AppendLine(new string('-', 30));

                foreach (var item in thongKe)
                {
                    string tenTrangThai = item.Key;
                    switch (item.Key)
                    {
                        case "DATHANHTOAN":
                            tenTrangThai = "Đã thanh toán";
                            break;
                        case "DAHUY":
                            tenTrangThai = "Đã hủy";
                            break;
                        case "DADOI":
                            tenTrangThai = "Đã đổi";
                            break;
                    }
                    thongBao.AppendLine($"{tenTrangThai}: {item.Value} vé");
                }

                if (thongKe.Count == 0)
                {
                    thongBao.AppendLine("Chưa có vé nào được đặt.");
                }

                MessageBox.Show(thongBao.ToString(), "Thống kê vé", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lấy thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string tuKhoa = "";
                using (var inputForm = new Form())
                {
                    inputForm.Width = 600;
                    inputForm.Height = 200;
                    inputForm.Text = "Tìm kiếm vé";
                    inputForm.StartPosition = FormStartPosition.CenterParent;
                    inputForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                    inputForm.MaximizeBox = false;
                    inputForm.MinimizeBox = false;
                    inputForm.Font = new Font("Segoe UI", 16, FontStyle.Regular);

                    var label = new Label() { Text = "Nhập từ khóa (tên hành khách, tuyến đường):", Left = 20, Top = 20, Width = 550, Height = 40, Font = new Font("Segoe UI", 16, FontStyle.Bold)};
                    var textBox = new TextBox() { Left = 20, Top = 67, Width = 400, Height = 35, Font = new Font("Segoe UI", 16)};
                    var btnOK = new Button() { Text = "Tìm kiếm", Left = 440, Top = 65, Width = 120, Height = 40, DialogResult = DialogResult.OK, Font = new Font("Segoe UI", 16, FontStyle.Bold)};
                    var btnCancel = new Button() { Text = "Hủy", Left = 440, Top = 115, Width = 120, Height = 40, DialogResult = DialogResult.Cancel, Font = new Font("Segoe UI", 16, FontStyle.Bold)};

                    inputForm.Controls.Add(label);
                    inputForm.Controls.Add(textBox);
                    inputForm.Controls.Add(btnOK);
                    inputForm.Controls.Add(btnCancel);

                    inputForm.AcceptButton = btnOK;
                    inputForm.CancelButton = btnCancel;

                    if (inputForm.ShowDialog() == DialogResult.OK)
                    {
                        tuKhoa = textBox.Text;
                    }
                }

                if (string.IsNullOrEmpty(tuKhoa))
                    return;

                var ketQuaTimKiem = currentVes.Where(v =>
                    v.HanhKhach.ToLower().Contains(tuKhoa.ToLower()) ||
                    v.Tuyen.ToLower().Contains(tuKhoa.ToLower())
                ).ToList();

                dgvVe.Rows.Clear();

                if (ketQuaTimKiem.Count == 0)
                {
                    MessageBox.Show($"Không tìm thấy vé nào với từ khóa: {tuKhoa}", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadVes(); // Load lại toàn bộ
                    return;
                }

                foreach (var ve in ketQuaTimKiem)
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

                    var row = dgvVe.Rows[rowIndex];
                    DoiMauCot(row, ve.TrangThai);
                }

                MessageBox.Show($"Tìm thấy {ketQuaTimKiem.Count} vé phù hợp!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
