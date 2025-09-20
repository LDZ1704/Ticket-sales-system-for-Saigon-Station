using System.Drawing;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuTaiKhoan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangXuat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuChuyenTau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTraCuu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuVe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDatVe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLyVe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanTri = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongKe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCaiDatHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanLyNguoiDung = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDashboard = new System.Windows.Forms.ToolStripMenuItem();
            this.lblChaoMung = new System.Windows.Forms.Label();
            this.mnuQuanTriVien = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTaiKhoan,
            this.mnuChuyenTau,
            this.mnuVe,
            this.mnuQuanTri});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(752, 38);
            this.menuStrip.TabIndex = 1;
            // 
            // mnuTaiKhoan
            // 
            this.mnuTaiKhoan.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDoiMatKhau,
            this.mnuDangXuat});
            this.mnuTaiKhoan.Name = "mnuTaiKhoan";
            this.mnuTaiKhoan.Size = new System.Drawing.Size(113, 34);
            this.mnuTaiKhoan.Text = "Tài khoản";
            // 
            // mnuDoiMatKhau
            // 
            this.mnuDoiMatKhau.Name = "mnuDoiMatKhau";
            this.mnuDoiMatKhau.Size = new System.Drawing.Size(211, 34);
            this.mnuDoiMatKhau.Text = "Đổi mật khẩu";
            this.mnuDoiMatKhau.Click += new System.EventHandler(this.mnuDoiMatKhau_Click);
            // 
            // mnuDangXuat
            // 
            this.mnuDangXuat.Name = "mnuDangXuat";
            this.mnuDangXuat.Size = new System.Drawing.Size(211, 34);
            this.mnuDangXuat.Text = "Đăng xuất";
            this.mnuDangXuat.Click += new System.EventHandler(this.mnuDangXuat_Click);
            // 
            // mnuChuyenTau
            // 
            this.mnuChuyenTau.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTraCuu});
            this.mnuChuyenTau.Name = "mnuChuyenTau";
            this.mnuChuyenTau.Size = new System.Drawing.Size(131, 34);
            this.mnuChuyenTau.Text = "Chuyến tàu";
            // 
            // mnuTraCuu
            // 
            this.mnuTraCuu.Name = "mnuTraCuu";
            this.mnuTraCuu.Size = new System.Drawing.Size(276, 34);
            this.mnuTraCuu.Text = "Tra cứu lịch chạy tàu";
            this.mnuTraCuu.Click += new System.EventHandler(this.mnuTraCuu_Click);
            // 
            // mnuVe
            // 
            this.mnuVe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDatVe,
            this.mnuQuanLyVe});
            this.mnuVe.Name = "mnuVe";
            this.mnuVe.Size = new System.Drawing.Size(48, 34);
            this.mnuVe.Text = "Vé";
            // 
            // mnuDatVe
            // 
            this.mnuDatVe.Name = "mnuDatVe";
            this.mnuDatVe.Size = new System.Drawing.Size(178, 34);
            this.mnuDatVe.Text = "Đặt vé";
            this.mnuDatVe.Click += new System.EventHandler(this.mnuDatVe_Click);
            // 
            // mnuQuanLyVe
            // 
            this.mnuQuanLyVe.Name = "mnuQuanLyVe";
            this.mnuQuanLyVe.Size = new System.Drawing.Size(178, 34);
            this.mnuQuanLyVe.Text = "Vé của tôi";
            this.mnuQuanLyVe.Click += new System.EventHandler(this.mnuQuanLyVe_Click);
            // 
            // mnuQuanTri
            // 
            this.mnuQuanTri.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDashboard,
            this.mnuQuanTriVien,
            this.mnuThongKe,
            this.mnuQuanLyNguoiDung,
            this.mnuCaiDatHeThong});
            this.mnuQuanTri.Name = "mnuQuanTri";
            this.mnuQuanTri.Size = new System.Drawing.Size(344, 34);
            this.mnuQuanTri.Text = "Chức năng dành cho Quản trị viên";
            // 
            // mnuThongKe
            // 
            this.mnuThongKe.Name = "mnuThongKe";
            this.mnuThongKe.Size = new System.Drawing.Size(272, 34);
            this.mnuThongKe.Text = "Thống kê";
            this.mnuThongKe.Click += new System.EventHandler(this.mnuThongKe_Click);
            // 
            // mnuCaiDatHeThong
            // 
            this.mnuCaiDatHeThong.Name = "mnuCaiDatHeThong";
            this.mnuCaiDatHeThong.Size = new System.Drawing.Size(272, 34);
            this.mnuCaiDatHeThong.Text = "Cài đặt hệ thống";
            this.mnuCaiDatHeThong.Click += new System.EventHandler(this.mnuCaiDatHeThong_Click);
            // 
            // mnuQuanLyNguoiDung
            // 
            this.mnuQuanLyNguoiDung.Name = "mnuQuanLyNguoiDung";
            this.mnuQuanLyNguoiDung.Size = new System.Drawing.Size(272, 34);
            this.mnuQuanLyNguoiDung.Text = "Quản lý người dùng";
            this.mnuQuanLyNguoiDung.Click += new System.EventHandler(this.mnuQuanLyNguoiDung_Click);
            // 
            // mnuDashboard
            // 
            this.mnuDashboard.Name = "mnuDashboard";
            this.mnuDashboard.Size = new System.Drawing.Size(272, 34);
            this.mnuDashboard.Text = "Trang tổng quan";
            this.mnuDashboard.Click += new System.EventHandler(this.mnuDashboard_Click);
            // 
            // lblChaoMung
            // 
            this.lblChaoMung.AutoSize = true;
            this.lblChaoMung.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChaoMung.Location = new System.Drawing.Point(50, 50);
            this.lblChaoMung.Name = "lblChaoMung";
            this.lblChaoMung.Size = new System.Drawing.Size(301, 31);
            this.lblChaoMung.TabIndex = 2;
            this.lblChaoMung.Text = "Xin chào, Người dùng!";
            // 
            // mnuQuanTriVien
            // 
            this.mnuQuanTriVien.Name = "mnuQuanTriVien";
            this.mnuQuanTriVien.Size = new System.Drawing.Size(272, 34);
            this.mnuQuanTriVien.Text = "Trang quản trị";
            this.mnuQuanTriVien.Click += new System.EventHandler(this.mnuQuanTriVien_Click);
            // 
            // FormMain
            // 
            this.ClientSize = new System.Drawing.Size(752, 491);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.lblChaoMung);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống bán vé ga Sài Gòn";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem mnuTaiKhoan;
        private ToolStripMenuItem mnuDangXuat;
        private ToolStripMenuItem mnuDoiMatKhau;
        private ToolStripMenuItem mnuChuyenTau;
        private ToolStripMenuItem mnuTraCuu;
        private ToolStripMenuItem mnuVe;
        private ToolStripMenuItem mnuDatVe;
        private ToolStripMenuItem mnuQuanLyVe;
        private ToolStripMenuItem mnuQuanTri;
        private Label lblChaoMung;
        private ToolStripMenuItem mnuThongKe;
        private ToolStripMenuItem mnuCaiDatHeThong;
        private ToolStripMenuItem mnuQuanLyNguoiDung;
        private ToolStripMenuItem mnuDashboard;
        private ToolStripMenuItem mnuQuanTriVien;
    }
}