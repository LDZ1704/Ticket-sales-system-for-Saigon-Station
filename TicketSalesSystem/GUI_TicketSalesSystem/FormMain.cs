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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI_TicketSalesSystem
{
    public partial class FormMain : Form
    {
        private bool isDangXuat = false;

        public FormMain(string username)
        {
            InitializeComponent();
            this.FormClosing += FormMain_FormClosing;
            this.Load += FormMain_Load;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            try
            {
                lblChaoMung.Text = $"Xin chào, {UserSession.Username}!";
                PhanQuyen();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo form chính: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isDangXuat)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất trước khi thoát?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    FormLogin loginForm = new FormLogin();
                    loginForm.Show();
                    this.Hide();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi quay về màn hình đăng nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
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

        #region Menu Event Handlers
        private void mnuDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                using (var frm = new FormChangePassword())
                {
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form đổi mật khẩu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mnuDangXuat_Click(object sender, EventArgs e)
        {
            DangXuat();
        }
        private void mnuTraCuu_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem form đã tồn tại chưa
                foreach (Form childForm in this.MdiChildren)
                {
                    if (childForm is FormTraCuu)
                    {
                        childForm.Activate();
                        return;
                    }
                }

                // Tạo form mới
                FormTraCuu frm = new FormTraCuu();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form tra cứu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mnuDatVe_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở form đặt vé với giỏ hàng và thanh toán VNPay
                var formDatVeGioHang = new FormDatVeGioHang(UserSession.UserId);
                formDatVeGioHang.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở chức năng đặt vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void mnuQuanLyVe_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem form đã tồn tại chưa
                foreach (Form childForm in this.MdiChildren)
                {
                    if (childForm is FormVeCuaToi)
                    {
                        childForm.Activate();
                        return;
                    }
                }

                // Tạo form mới
                FormVeCuaToi frm = new FormVeCuaToi();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form quản lý vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuThongKe_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở form test VNPay để debug
                var formVNPayTest = new FormVNPayTest();
                formVNPayTest.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở test VNPay: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Helper Methods
        private void DangXuat()
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    isDangXuat = true;
                    UserSession.Clear();
                    MessageBox.Show("Đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FormLogin loginForm = new FormLogin();
                    loginForm.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi đăng xuất: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PhanQuyen()
        {
            if (UserSession.IsAdmin)
            {
                // Admin có tất cả quyền
                mnuThongKe.Visible = true;
                mnuThongKe.Text = "Thống kê và Báo cáo";

                // Có thể thêm menu admin khác
                // mnuQuanLyUser.Visible = true;
                // mnuQuanLyTau.Visible = true;
            }
            else
            {
                // User thường chỉ có quyền cơ bản
                mnuThongKe.Visible = false;

                // Ẩn các menu admin khác
                // mnuQuanLyUser.Visible = false;
                // mnuQuanLyTau.Visible = false;
            }
        }

        private bool CheckAdminPermission(string action = "")
        {
            if (!UserSession.IsAdmin)
            {
                MessageBox.Show($"Bạn không có quyền thực hiện chức năng này!\nChỉ Quản trị viên mới có thể {action}.", "Không đủ quyền", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion
    }
}
