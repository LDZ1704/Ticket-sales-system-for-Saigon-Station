using System.Drawing;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem
{
    partial class FormQuanLyNguoiDung
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
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.cboLoaiNguoiDung = new System.Windows.Forms.ComboBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.dgvNguoiDung = new System.Windows.Forms.DataGridView();
            this.MaNguoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoDienThoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoaiNguoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThaiTaiKhoan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayTao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongChiTieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnKhoaTaiKhoan = new System.Windows.Forms.Button();
            this.btnCapQuyen = new System.Windows.Forms.Button();
            this.btnDatLaiMatKhau = new System.Windows.Forms.Button();
            this.btnXemLichSu = new System.Windows.Forms.Button();
            this.lblTongNguoiDung = new System.Windows.Forms.Label();
            this.lblThongKe = new System.Windows.Forms.Label();
            this.btnXoaTaiKhoan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.Blue;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(354, 30);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "QUẢN LÝ NGƯỜI DÙNG";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(20, 65);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(462, 38);
            this.txtTimKiem.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(488, 65);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(141, 39);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.BtnTimKiem_Click);
            // 
            // cboLoaiNguoiDung
            // 
            this.cboLoaiNguoiDung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiNguoiDung.Location = new System.Drawing.Point(972, 64);
            this.cboLoaiNguoiDung.Name = "cboLoaiNguoiDung";
            this.cboLoaiNguoiDung.Size = new System.Drawing.Size(387, 39);
            this.cboLoaiNguoiDung.TabIndex = 3;
            this.cboLoaiNguoiDung.SelectedIndexChanged += new System.EventHandler(this.CboLoaiNguoiDung_SelectedIndexChanged);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(1365, 64);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(142, 39);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.BtnLamMoi_Click);
            // 
            // dgvNguoiDung
            // 
            this.dgvNguoiDung.AllowUserToAddRows = false;
            this.dgvNguoiDung.AllowUserToDeleteRows = false;
            this.dgvNguoiDung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvNguoiDung.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvNguoiDung.ColumnHeadersHeight = 40;
            this.dgvNguoiDung.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNguoiDung,
            this.HoTen,
            this.Email,
            this.SoDienThoai,
            this.LoaiNguoiDung,
            this.TrangThaiTaiKhoan,
            this.NgayTao,
            this.SoVe,
            this.TongChiTieu});
            this.dgvNguoiDung.Location = new System.Drawing.Point(20, 110);
            this.dgvNguoiDung.MultiSelect = false;
            this.dgvNguoiDung.Name = "dgvNguoiDung";
            this.dgvNguoiDung.ReadOnly = true;
            this.dgvNguoiDung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNguoiDung.Size = new System.Drawing.Size(1487, 450);
            this.dgvNguoiDung.TabIndex = 5;
            this.dgvNguoiDung.SelectionChanged += new System.EventHandler(this.DgvNguoiDung_SelectionChanged);
            // 
            // MaNguoiDung
            // 
            this.MaNguoiDung.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.MaNguoiDung.HeaderText = "Mã";
            this.MaNguoiDung.Name = "MaNguoiDung";
            this.MaNguoiDung.ReadOnly = true;
            this.MaNguoiDung.Width = 76;
            // 
            // HoTen
            // 
            this.HoTen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.HoTen.HeaderText = "Họ tên";
            this.HoTen.Name = "HoTen";
            this.HoTen.ReadOnly = true;
            this.HoTen.Width = 119;
            // 
            // Email
            // 
            this.Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 106;
            // 
            // SoDienThoai
            // 
            this.SoDienThoai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SoDienThoai.HeaderText = "Số ĐT";
            this.SoDienThoai.Name = "SoDienThoai";
            this.SoDienThoai.ReadOnly = true;
            this.SoDienThoai.Width = 116;
            // 
            // LoaiNguoiDung
            // 
            this.LoaiNguoiDung.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LoaiNguoiDung.HeaderText = "Loại";
            this.LoaiNguoiDung.Name = "LoaiNguoiDung";
            this.LoaiNguoiDung.ReadOnly = true;
            this.LoaiNguoiDung.Width = 90;
            // 
            // TrangThaiTaiKhoan
            // 
            this.TrangThaiTaiKhoan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TrangThaiTaiKhoan.HeaderText = "Trạng thái";
            this.TrangThaiTaiKhoan.Name = "TrangThaiTaiKhoan";
            this.TrangThaiTaiKhoan.ReadOnly = true;
            this.TrangThaiTaiKhoan.Width = 161;
            // 
            // NgayTao
            // 
            this.NgayTao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.NgayTao.HeaderText = "Ngày tạo";
            this.NgayTao.Name = "NgayTao";
            this.NgayTao.ReadOnly = true;
            this.NgayTao.Width = 148;
            // 
            // SoVe
            // 
            this.SoVe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SoVe.HeaderText = "Số vé";
            this.SoVe.Name = "SoVe";
            this.SoVe.ReadOnly = true;
            this.SoVe.Width = 108;
            // 
            // TongChiTieu
            // 
            this.TongChiTieu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.TongChiTieu.HeaderText = "Chi tiêu";
            this.TongChiTieu.Name = "TongChiTieu";
            this.TongChiTieu.ReadOnly = true;
            this.TongChiTieu.Width = 131;
            // 
            // btnKhoaTaiKhoan
            // 
            this.btnKhoaTaiKhoan.Enabled = false;
            this.btnKhoaTaiKhoan.Location = new System.Drawing.Point(1294, 616);
            this.btnKhoaTaiKhoan.Name = "btnKhoaTaiKhoan";
            this.btnKhoaTaiKhoan.Size = new System.Drawing.Size(213, 41);
            this.btnKhoaTaiKhoan.TabIndex = 6;
            this.btnKhoaTaiKhoan.Text = "Khóa tài khoản";
            this.btnKhoaTaiKhoan.Click += new System.EventHandler(this.BtnKhoaTaiKhoan_Click);
            // 
            // btnCapQuyen
            // 
            this.btnCapQuyen.Enabled = false;
            this.btnCapQuyen.Location = new System.Drawing.Point(1149, 569);
            this.btnCapQuyen.Name = "btnCapQuyen";
            this.btnCapQuyen.Size = new System.Drawing.Size(175, 42);
            this.btnCapQuyen.TabIndex = 7;
            this.btnCapQuyen.Text = "Cấp quyền";
            this.btnCapQuyen.Click += new System.EventHandler(this.BtnCapQuyen_Click);
            // 
            // btnDatLaiMatKhau
            // 
            this.btnDatLaiMatKhau.Enabled = false;
            this.btnDatLaiMatKhau.Location = new System.Drawing.Point(914, 569);
            this.btnDatLaiMatKhau.Name = "btnDatLaiMatKhau";
            this.btnDatLaiMatKhau.Size = new System.Drawing.Size(229, 41);
            this.btnDatLaiMatKhau.TabIndex = 8;
            this.btnDatLaiMatKhau.Text = "Đặt lại mật khẩu";
            this.btnDatLaiMatKhau.Click += new System.EventHandler(this.BtnDatLaiMatKhau_Click);
            // 
            // btnXemLichSu
            // 
            this.btnXemLichSu.Enabled = false;
            this.btnXemLichSu.Location = new System.Drawing.Point(1330, 569);
            this.btnXemLichSu.Name = "btnXemLichSu";
            this.btnXemLichSu.Size = new System.Drawing.Size(177, 41);
            this.btnXemLichSu.TabIndex = 9;
            this.btnXemLichSu.Text = "Xem lịch sử";
            this.btnXemLichSu.Click += new System.EventHandler(this.BtnXemLichSu_Click);
            // 
            // lblTongNguoiDung
            // 
            this.lblTongNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongNguoiDung.ForeColor = System.Drawing.Color.Blue;
            this.lblTongNguoiDung.Location = new System.Drawing.Point(21, 580);
            this.lblTongNguoiDung.Name = "lblTongNguoiDung";
            this.lblTongNguoiDung.Size = new System.Drawing.Size(230, 44);
            this.lblTongNguoiDung.TabIndex = 10;
            // 
            // lblThongKe
            // 
            this.lblThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblThongKe.ForeColor = System.Drawing.Color.Green;
            this.lblThongKe.Location = new System.Drawing.Point(269, 580);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(550, 44);
            this.lblThongKe.TabIndex = 11;
            // 
            // btnXoaTaiKhoan
            // 
            this.btnXoaTaiKhoan.Location = new System.Drawing.Point(1059, 617);
            this.btnXoaTaiKhoan.Name = "btnXoaTaiKhoan";
            this.btnXoaTaiKhoan.Size = new System.Drawing.Size(229, 41);
            this.btnXoaTaiKhoan.TabIndex = 12;
            this.btnXoaTaiKhoan.Text = "Xóa tài khoản";
            this.btnXoaTaiKhoan.UseVisualStyleBackColor = true;
            this.btnXoaTaiKhoan.Click += new System.EventHandler(this.btnXoaTaiKhoan_Click);
            // 
            // FormQuanLyNguoiDung
            // 
            this.ClientSize = new System.Drawing.Size(1519, 668);
            this.Controls.Add(this.btnXoaTaiKhoan);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.cboLoaiNguoiDung);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.dgvNguoiDung);
            this.Controls.Add(this.btnKhoaTaiKhoan);
            this.Controls.Add(this.btnCapQuyen);
            this.Controls.Add(this.btnDatLaiMatKhau);
            this.Controls.Add(this.btnXemLichSu);
            this.Controls.Add(this.lblTongNguoiDung);
            this.Controls.Add(this.lblThongKe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.Name = "FormQuanLyNguoiDung";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý người dùng";
            this.Load += new System.EventHandler(this.FormQuanLyNguoiDung_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNguoiDung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private Label lblTieuDe;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private ComboBox cboLoaiNguoiDung;
        private Button btnLamMoi;
        private DataGridView dgvNguoiDung;
        private Button btnKhoaTaiKhoan;
        private Button btnCapQuyen;
        private Button btnDatLaiMatKhau;
        private Button btnXemLichSu;
        private Label lblTongNguoiDung;
        private Label lblThongKe;

        #endregion

        private DataGridViewTextBoxColumn MaNguoiDung;
        private DataGridViewTextBoxColumn HoTen;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn SoDienThoai;
        private DataGridViewTextBoxColumn LoaiNguoiDung;
        private DataGridViewTextBoxColumn TrangThaiTaiKhoan;
        private DataGridViewTextBoxColumn NgayTao;
        private DataGridViewTextBoxColumn SoVe;
        private DataGridViewTextBoxColumn TongChiTieu;
        private Button btnXoaTaiKhoan;
    }
}