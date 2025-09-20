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
    public partial class FormCaiDatHeThong : Form
    {
        private readonly BUS_QuanLy busQuanLy = new BUS_QuanLy();
        private List<DTO_CauHinhHeThong> danhSachCauHinh;

        public FormCaiDatHeThong()
        {
            InitializeComponent();
        }

        private void FormCaiDatHeThong_Load(object sender, EventArgs e)
        {
            try
            {
                SetupComboBox();
                LoadCauHinh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupComboBox()
        {
            cboNhomCauHinh.Items.AddRange(new[] { "Tất cả", "Vé", "Thanh toán", "Hệ thống" });
            cboNhomCauHinh.SelectedIndex = 0;
        }

        private void LoadCauHinh(string nhom = "")
        {
            try
            {
                if (string.IsNullOrEmpty(nhom) || nhom == "Tất cả")
                    danhSachCauHinh = busQuanLy.LayTatCaCauHinh();
                else
                    danhSachCauHinh = busQuanLy.LayCauHinhTheoNhom(ChuyenDoiNhom(nhom));

                HienThiCauHinh(danhSachCauHinh);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load cấu hình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiCauHinh(List<DTO_CauHinhHeThong> danhSach)
        {
            dgvCauHinh.Rows.Clear();

            foreach (var config in danhSach)
            {
                int rowIndex = dgvCauHinh.Rows.Add(
                    config.TenCauHinh,
                    config.MoTa,
                    config.GiaTri,
                    config.DonVi,
                    ChuyenDoiNhomHienThi(config.NhomCauHinh),
                    config.NgayCapNhat.ToString("dd/MM/yyyy HH:mm"),
                    config.NguoiCapNhat
                );

                var row = dgvCauHinh.Rows[rowIndex];

                // Đổi màu theo nhóm
                switch (config.NhomCauHinh)
                {
                    case "VE":
                        row.DefaultCellStyle.BackColor = Color.LightBlue;
                        break;
                    case "THANHTOAN":
                        row.DefaultCellStyle.BackColor = Color.LightYellow;
                        break;
                    case "HETHONG":
                        row.DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                }
            }

            lblTongCauHinh.Text = $"Tổng số cấu hình: {danhSach.Count}";
        }

        private void CboNhomCauHinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCauHinh(cboNhomCauHinh.SelectedItem.ToString());
        }

        private void DgvCauHinh_SelectionChanged(object sender, EventArgs e)
        {
            bool hasSelection = dgvCauHinh.SelectedRows.Count > 0;
            btnCapNhat.Enabled = hasSelection;
            btnKhoiPhucMacDinh.Enabled = hasSelection;

            if (hasSelection)
            {
                var row = dgvCauHinh.SelectedRows[0];
                txtTenCauHinh.Text = row.Cells["dgvTenCauHinh"].Value.ToString();
                txtMoTa.Text = row.Cells["dgvMoTa"].Value.ToString();
                txtGiaTri.Text = row.Cells["dgvGiaTri"].Value.ToString();
                txtDonVi.Text = row.Cells["dgvDonVi"].Value?.ToString();
            }
        }

        private void DgvCauHinh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvCauHinh.Rows[e.RowIndex];
                txtTenCauHinh.Text = row.Cells["dgvTenCauHinh"].Value.ToString();
                txtMoTa.Text = row.Cells["dgvMoTa"].Value.ToString();
                txtGiaTri.Text = row.Cells["dgvGiaTri"].Value.ToString();
                txtDonVi.Text = row.Cells["dgvDonVi"].Value?.ToString();
            }
        }

        private void BtnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTenCauHinh.Text))
                {
                    MessageBox.Show("Vui lòng chọn cấu hình cần cập nhật!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtGiaTri.Text))
                {
                    MessageBox.Show("Vui lòng nhập giá trị mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show(
                    $"Bạn có chắc muốn cập nhật cấu hình '{txtTenCauHinh.Text}' thành '{txtGiaTri.Text}'?",
                    "Xác nhận cập nhật",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    bool success = busQuanLy.CapNhatCauHinh(
                        txtTenCauHinh.Text,
                        txtGiaTri.Text,
                        UserSession.Username
                    );

                    if (success)
                    {
                        MessageBox.Show("Cập nhật cấu hình thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCauHinh(cboNhomCauHinh.SelectedItem.ToString());
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Không thể cập nhật cấu hình!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật cấu hình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnKhoiPhucMacDinh_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCauHinh.SelectedRows.Count == 0) return;

                var row = dgvCauHinh.SelectedRows[0];
                string tenCauHinh = row.Cells["TenCauHinh"].Value.ToString();

                var result = MessageBox.Show(
                    $"Bạn có chắc muốn khôi phục cấu hình '{tenCauHinh}' về giá trị mặc định?",
                    "Xác nhận khôi phục",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("Đã khôi phục cấu hình về mặc định!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCauHinh(cboNhomCauHinh.SelectedItem.ToString());
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khôi phục cấu hình: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            LoadCauHinh(cboNhomCauHinh.SelectedItem.ToString());
            ClearForm();
            MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ClearForm()
        {
            txtTenCauHinh.Clear();
            txtMoTa.Clear();
            txtGiaTri.Clear();
            txtDonVi.Clear();
        }

        private string ChuyenDoiNhom(string nhomHienThi)
        {
            switch (nhomHienThi)
            {
                case "Vé": return "VE";
                case "Thanh toán": return "THANHTOAN";
                case "Hệ thống": return "HETHONG";
                default: return "";
            }
        }

        private string ChuyenDoiNhomHienThi(string nhomCode)
        {
            switch (nhomCode)
            {
                case "VE": return "Vé";
                case "THANHTOAN": return "Thanh toán";
                case "HETHONG": return "Hệ thống";
                default: return nhomCode;
            }
        }
    }
}
