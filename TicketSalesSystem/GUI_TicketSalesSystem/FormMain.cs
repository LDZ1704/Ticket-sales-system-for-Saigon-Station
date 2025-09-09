using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI_TicketSalesSystem
{
    public partial class FormMain : Form
    {
        private string currentUsername;
        private bool isDangXuat = false;
        public FormMain(string username)
        {
            InitializeComponent();
            this.currentUsername = username;
            this.FormClosing += FormMain_FormClosing;
        }

        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            using (var frm = new FormChangePassword(currentUsername))
            {
                frm.ShowDialog();
            }
        }

        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DangXuat();
        }
        private void DangXuat()
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                isDangXuat = true;
                MessageBox.Show("Đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                this.Close();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblChaoMung.Text = $"Xin chào, {currentUsername}";
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDangXuat)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất trước khi thoát?", "Xác nhận",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                FormLogin loginForm = new FormLogin();
                loginForm.Show();
                this.Hide();
            }
            else if (result == DialogResult.No)
            {
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
