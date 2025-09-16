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
    public partial class FormDatVe : Form
    {
        private readonly BUS_ChuyenTau busChuyenTau = new BUS_ChuyenTau();
        private readonly BUS_Toa busToa = new BUS_Toa();
        private readonly BUS_Ghe busGhe = new BUS_Ghe();
        private readonly BUS_Ve busVe = new BUS_Ve();
        private readonly BUS_DatVe busDatVe = new BUS_DatVe();
        private readonly BUS_TaiKhoan busTaiKhoan = new BUS_TaiKhoan();
        private readonly BUS_NguoiDung busNguoiDung = new BUS_NguoiDung();
        private readonly BUS_HanhKhach busHanhKhach = new BUS_HanhKhach();
        private readonly int maChuyen;
        private List<DTO_Ghe> currentGhes = new List<DTO_Ghe>();
        public FormDatVe(int maChuyen)
        {
            InitializeComponent();
            this.maChuyen = maChuyen;
            this.Load += FormDatVe_Load;
        }

        private void FormDatVe_Load(object sender, EventArgs e)
        {
            try
            {
                LoadThongTinChuyen();
                LoadToas();
                SetupEvents();
                SetDefaultValues();
                LoadThongTinNguoiDung();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo form: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadThongTinNguoiDung()
        {
            try
            {
                var nguoiDung = busNguoiDung.LayNguoiDungTheoID(UserSession.UserId);

                if (nguoiDung != null)
                {
                    txtHoTen.Text = $"{nguoiDung.Ho} {nguoiDung.Ten}";

                    if (nguoiDung.NgaySinh != DateTime.MinValue)
                    {
                        dtpNgaySinh.Value = nguoiDung.NgaySinh;
                    }

                    var existingHanhKhach = busHanhKhach.LayHanhKhachBangEmailHoacSDT(nguoiDung.Email, nguoiDung.SoDienThoai);

                    if (existingHanhKhach != null)
                    {
                        txtHoTen.Text = existingHanhKhach.HoTen;
                        txtSoGiayTo.Text = existingHanhKhach.SoGiayTo;

                        if (!string.IsNullOrEmpty(existingHanhKhach.GioiTinh))
                        {
                            SetGioiTinh(existingHanhKhach.GioiTinh);
                        }

                        if (existingHanhKhach.NgaySinh.HasValue)
                        {
                            dtpNgaySinh.Value = existingHanhKhach.NgaySinh.Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Không thể load thông tin: {ex.Message}");
            }
        }
        // Helper method để set giới tính
        private void SetGioiTinh(string gioiTinh)
        {
            for (int i = 0; i < cboGioiTinh.Items.Count; i++)
            {
                if (cboGioiTinh.Items[i].ToString().Equals(gioiTinh, StringComparison.OrdinalIgnoreCase))
                {
                    cboGioiTinh.SelectedIndex = i;
                    break;
                }
            }
        }


        private void LoadThongTinChuyen()
        {
            try
            {
                var chuyen = busChuyenTau.LayChuyenTauBangId(maChuyen);
                if (chuyen != null && !string.IsNullOrEmpty(chuyen.GhiChu))
                {
                    var parts = chuyen.GhiChu.Split('|');
                    string tenTau = parts.Length > 0 ? parts[0] : "";
                    string tuyen = parts.Length > 1 ? parts[1] : "";

                    lblThongTinChuyen.Text = $"{tenTau} - {tuyen}";
                    this.Text += $" - {tenTau}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin chuyến: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadToas()
        {
            try
            {
                var list = busToa.LayToaBangChuyenTau(maChuyen);
                cboToa.Items.Clear();

                foreach (var toa in list)
                {
                    cboToa.Items.Add(new ComboBoxItem
                    {
                        Text = toa.DisplayText,
                        Value = toa.MaToa
                    });
                }

                if (cboToa.Items.Count > 0)
                {
                    cboToa.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách toa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadGhes(int maToa)
        {
            try
            {
                var list = busGhe.LayGheBangToa(maToa);
                currentGhes = list;

                dgvVe.Rows.Clear();
                foreach (var ghe in list)
                {
                    dgvVe.Rows.Add(
                        maChuyen,
                        "", //Mã hành khách sẽ được tạo sau
                        ghe.SoHieu,
                        ghe.TrangThai,
                        "" //Mã QR sẽ được tạo sau khi đặt
                    );

                    // Đổi màu dòng theo trạng thái ghế
                    var row = dgvVe.Rows[dgvVe.Rows.Count - 1];
                    if (ghe.TrangThai == "DADAT")
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGray;
                        row.DefaultCellStyle.SelectionBackColor = Color.Gray;
                        row.ReadOnly = true;
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        row.DefaultCellStyle.SelectionBackColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải danh sách ghế: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SetupEvents()
        {
            cboToa.SelectedIndexChanged += cboToa_SelectedIndexChanged;
            btnDatVe.Click += btnDatVe_Click;
            dgvVe.SelectionChanged += dgvVe_SelectionChanged;
        }
        private void SetDefaultValues()
        {
            // Set giá vé default
            txtGiaVe.Text = "350,000 VND";
        }

        private void cboToa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboToa.SelectedItem is ComboBoxItem item)
            {
                LoadGhes((int)item.Value);
            }
        }

        private void dgvVe_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVe.SelectedRows.Count > 0)
            {
                var selectedRow = dgvVe.SelectedRows[0];
                string trangThai = selectedRow.Cells["dgvTrangThai"].Value?.ToString() ?? "";

                // Enable button nếu ghế trống
                btnDatVe.Enabled = (trangThai == "TRONG");
            }
            else
            {
                btnDatVe.Enabled = false;
            }
        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                var selectedRow = dgvVe.SelectedRows[0];
                string soGhe = selectedRow.Cells["dgvSoGhe"].Value.ToString();

                var selectedGhe = currentGhes.FirstOrDefault(g => g.SoHieu == soGhe);
                if (selectedGhe == null || selectedGhe.TrangThai != "TRONG")
                {
                    MessageBox.Show("Ghế đã được chọn hoặc không hợp lệ!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var datVeInput = new DTO_DatVe
                {
                    MaChuyen = maChuyen,
                    MaGhe = selectedGhe.MaGhe ?? 0,
                    HoTen = txtHoTen.Text.Trim(),
                    SoGiayTo = txtSoGiayTo.Text.Trim(),
                    GioiTinh = cboGioiTinh.SelectedItem.ToString(),
                    NgaySinh = dtpNgaySinh.Value,
                    GiaVe = ParseGiaVe(txtGiaVe.Text),
                    MaNguoiDung = LayMaNguoiDungHienTai()
                };

                // Xác nhận đặt vé
                var confirmResult = MessageBox.Show(
                    $"Xác nhận đặt vé:\n" +
                    $"Hành khách: {datVeInput.HoTen}\n" +
                    $"Ghế: {selectedGhe.SoHieu}\n" +
                    $"Giá vé: {txtGiaVe.Text}",
                    "Xác nhận đặt vé",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmResult == DialogResult.Yes)
                {
                    bool success = busDatVe.DatVe(datVeInput);
                    if (success)
                    {
                        MessageBox.Show("Đặt vé thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        // Reload ghế để cập nhật trạng thái
                        if (cboToa.SelectedItem is ComboBoxItem item)
                        {
                            LoadGhes((int)item.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đặt vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (cboToa.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn toa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvVe.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn ghế!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (txtHoTen.Text.Trim().Length < 2)
            {
                MessageBox.Show("Họ tên phải có ít nhất 2 ký tự!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoGiayTo.Text))
            {
                MessageBox.Show("Vui lòng nhập số giấy tờ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoGiayTo.Focus();
                return false;
            }

            if (txtSoGiayTo.Text.Trim().Length < 9)
            {
                MessageBox.Show("Số giấy tờ không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoGiayTo.Focus();
                return false;
            }

            if (cboGioiTinh.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpNgaySinh.Value >= DateTime.Now.AddYears(-16))
            {
                MessageBox.Show("Hành khách phải từ 16 tuổi trở lên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private decimal ParseGiaVe(string giaVeText)
        {
            try
            {
                string cleanText = giaVeText.Replace(" VND", "").Replace(",", "").Replace(".", "");
                return decimal.Parse(cleanText);
            }
            catch
            {
                return 350000; // Giá mặc định
            }
        }

        private int LayMaNguoiDungHienTai()
        {
            return UserSession.UserId;
        }

        private void ClearForm()
        {
            txtHoTen.Clear();
            txtSoGiayTo.Clear();
            cboGioiTinh.SelectedIndex = 0;
            dtpNgaySinh.Value = DateTime.Now.AddYears(-18);
            dgvVe.ClearSelection();
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
