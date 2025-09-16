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

namespace GUI_TicketSalesSystem
{
    public partial class FormChangePassword : Form
    {
        private readonly BUS_TaiKhoan bus_TaiKhoan = new BUS_TaiKhoan();

        public FormChangePassword()
        {
            InitializeComponent();
            this.Load += FormChangePassword_Load;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string matKhauCu = txtOldPass.Text.Trim();
            string matKhauMoi = txtNewPass.Text.Trim();
            string xacNhan = txtConfirmPass.Text.Trim();

            if (matKhauMoi != xacNhan)
            {
                MessageBox.Show("Xác nhận mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPass.Focus();
                return;
            }

            string ketQua = bus_TaiKhoan.DoiMatKhau(UserSession.Username, matKhauCu, matKhauMoi);
            if (ketQua == "Đổi mật khẩu thành công")
            {
                MessageBox.Show(ketQua, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(ketQua, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormChangePassword_Load(object sender, EventArgs e)
        {
            txtOldPass.UseSystemPasswordChar = true;
            txtNewPass.UseSystemPasswordChar = true;
            txtConfirmPass.UseSystemPasswordChar = true;
            txtOldPass.Focus();
        }
    }
}
