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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GUI_TicketSalesSystem
{
    public partial class FormMain : Form
    {
        private bool isDangXuat = false;

        public FormMain()
        {
            InitializeComponent();
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
            if (!isDangXuat)
            {
                DialogResult result = MessageBox.Show("Bạn có muốn đăng xuất trước khi thoát?", "Xác nhận", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    DangXuat();
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
                // Mở form tra cứu để chọn chuyến tàu trước khi đặt vé
                mnuTraCuu_Click(sender, e);
                MessageBox.Show("Vui lòng chọn chuyến tàu và nhấn 'Đặt vé' để tiếp tục!", "Hướng dẫn", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (!CheckAdminPermission("xem thống kê")) return;
            try
            {
                foreach (Form childForm in this.MdiChildren)
                {
                    if (childForm is FormThongKe)
                    {
                        childForm.Activate();
                        return;
                    }
                }

                FormThongKe frm = new FormThongKe();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuQuanLyNguoiDung_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission("quản lý người dùng")) return;
            try
            {
                using (Form formNguoiDung = new FormQuanLyNguoiDung())
                {
                    formNguoiDung.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuCaiDatHeThong_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission("cài đặt hệ thống")) return;
            try
            {
                using (var formCaiDat = new FormCaiDatHeThong())
                {
                    formCaiDat.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở cài đặt hệ thống: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuDashboard_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission("xem dashboard")) return;
            try
            {
                foreach (Form childForm in this.MdiChildren)
                {
                    if (childForm is FormDashboard)
                    {
                        childForm.Activate();
                        return;
                    }
                }

                FormDashboard frm = new FormDashboard();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở dashboard: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuQuanTriVien_Click(object sender, EventArgs e)
        {
            if (!CheckAdminPermission("quản trị hệ thống")) return;
            try
            {
                foreach (Form childForm in this.MdiChildren)
                {
                    if (childForm is FormQuanTriVien)
                    {
                        childForm.Activate();
                        return;
                    }
                }

                FormQuanTriVien frm = new FormQuanTriVien();
                frm.MdiParent = this;
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi mở form quản trị: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Helper Methods
        private void DangXuat()
        {
            isDangXuat = true;
            UserSession.Clear();
            this.Close();
        }

        private void PhanQuyen()
        {
            if (UserSession.IsAdmin)
            {
                mnuQuanTri.Visible = true;
                mnuQuanTriVien_Click(null, null);
            }
            else
            {
                mnuQuanTri.Visible = false;
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
