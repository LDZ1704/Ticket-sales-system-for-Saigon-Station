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
    public partial class FormCapQuyen : Form
    {
        private readonly int maNguoiDung;
        private readonly string hoTen;
        private readonly BUS_QuanLy busQuanLy = new BUS_QuanLy();

        public FormCapQuyen(int maNguoiDung, string hoTen)
        {
            InitializeComponent();
            this.maNguoiDung = maNguoiDung;
            this.hoTen = hoTen;
        }

        private void FormCapQuyen_Load(object sender, EventArgs e)
        {
            lblNguoiDung.Text = $"Cấp quyền cho: {hoTen}";
            rbKhachHang.Checked = true; // Default
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            try
            {
                string quyenMoi = "";
                string tenQuyen = "";

                if (rbKhachHang.Checked)
                {
                    quyenMoi = "KHACH";
                    tenQuyen = "Khách hàng";
                }
                else if (rbNhanVien.Checked)
                {
                    quyenMoi = "NHANVIEN";
                    tenQuyen = "Nhân viên";
                }
                else if (rbQuanTriVien.Checked)
                {
                    quyenMoi = "QUANTRI";
                    tenQuyen = "Quản trị viên";
                }

                var result = MessageBox.Show(
                    $"Xác nhận cấp quyền '{tenQuyen}' cho {hoTen}?",
                    "Xác nhận cấp quyền",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    bool success = busQuanLy.CapQuyenNguoiDung(maNguoiDung, quyenMoi);
                    if (success)
                    {
                        MessageBox.Show(
                            $"Đã cấp quyền '{tenQuyen}' thành công!",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Không thể cấp quyền! Vui lòng thử lại.",
                            "Lỗi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cấp quyền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
