using System.Drawing;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem
{
    partial class FormVeCuaToi
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
            this.dgvVe = new System.Windows.Forms.DataGridView();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnHuyVe = new System.Windows.Forms.Button();
            this.btnDoiVe = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.dgvMaVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvHanhKhach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvKhoiHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGiaVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNgayDat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvVe
            // 
            this.dgvVe.AllowUserToAddRows = false;
            this.dgvVe.AllowUserToDeleteRows = false;
            this.dgvVe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvVe.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvVe.ColumnHeadersHeight = 35;
            this.dgvVe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvMaVe,
            this.dgvHanhKhach,
            this.dgvTuyen,
            this.dgvGhe,
            this.dgvKhoiHanh,
            this.dgvGiaVe,
            this.dgvTrangThai,
            this.dgvNgayDat});
            this.dgvVe.Location = new System.Drawing.Point(4, 65);
            this.dgvVe.Name = "dgvVe";
            this.dgvVe.ReadOnly = true;
            this.dgvVe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVe.Size = new System.Drawing.Size(1237, 485);
            this.dgvVe.TabIndex = 4;
            this.dgvVe.SelectionChanged += new System.EventHandler(this.dgvVe_SelectionChanged);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(855, 20);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(125, 30);
            this.btnLamMoi.TabIndex = 1;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnHuyVe
            // 
            this.btnHuyVe.Location = new System.Drawing.Point(1000, 20);
            this.btnHuyVe.Name = "btnHuyVe";
            this.btnHuyVe.Size = new System.Drawing.Size(115, 30);
            this.btnHuyVe.TabIndex = 2;
            this.btnHuyVe.Text = "Hủy vé";
            this.btnHuyVe.Click += new System.EventHandler(this.btnHuyVe_Click);
            // 
            // btnDoiVe
            // 
            this.btnDoiVe.Location = new System.Drawing.Point(1133, 20);
            this.btnDoiVe.Name = "btnDoiVe";
            this.btnDoiVe.Size = new System.Drawing.Size(108, 30);
            this.btnDoiVe.TabIndex = 3;
            this.btnDoiVe.Text = "Đổi vé";
            this.btnDoiVe.Click += new System.EventHandler(this.btnDoiVe_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(12, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(336, 47);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Danh sách vé đã đặt";
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(713, 20);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(125, 30);
            this.btnThongKe.TabIndex = 1;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(571, 20);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(125, 30);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // dgvMaVe
            // 
            this.dgvMaVe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvMaVe.HeaderText = "Mã vé";
            this.dgvMaVe.Name = "dgvMaVe";
            this.dgvMaVe.ReadOnly = true;
            this.dgvMaVe.Width = 86;
            // 
            // dgvHanhKhach
            // 
            this.dgvHanhKhach.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvHanhKhach.HeaderText = "Hành khách";
            this.dgvHanhKhach.Name = "dgvHanhKhach";
            this.dgvHanhKhach.ReadOnly = true;
            this.dgvHanhKhach.Width = 137;
            // 
            // dgvTuyen
            // 
            this.dgvTuyen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTuyen.HeaderText = "Tuyến";
            this.dgvTuyen.Name = "dgvTuyen";
            this.dgvTuyen.ReadOnly = true;
            this.dgvTuyen.Width = 89;
            // 
            // dgvGhe
            // 
            this.dgvGhe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvGhe.HeaderText = "Toa - Ghế";
            this.dgvGhe.Name = "dgvGhe";
            this.dgvGhe.ReadOnly = true;
            this.dgvGhe.Width = 120;
            // 
            // dgvKhoiHanh
            // 
            this.dgvKhoiHanh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvKhoiHanh.HeaderText = "Ngày khởi hành";
            this.dgvKhoiHanh.Name = "dgvKhoiHanh";
            this.dgvKhoiHanh.ReadOnly = true;
            this.dgvKhoiHanh.Width = 167;
            // 
            // dgvGiaVe
            // 
            this.dgvGiaVe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvGiaVe.HeaderText = "Giá vé";
            this.dgvGiaVe.Name = "dgvGiaVe";
            this.dgvGiaVe.ReadOnly = true;
            this.dgvGiaVe.Width = 88;
            // 
            // dgvTrangThai
            // 
            this.dgvTrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTrangThai.HeaderText = "Trạng thái";
            this.dgvTrangThai.Name = "dgvTrangThai";
            this.dgvTrangThai.ReadOnly = true;
            this.dgvTrangThai.Width = 119;
            // 
            // dgvNgayDat
            // 
            this.dgvNgayDat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvNgayDat.HeaderText = "Ngày đặt";
            this.dgvNgayDat.Name = "dgvNgayDat";
            this.dgvNgayDat.ReadOnly = true;
            this.dgvNgayDat.Width = 110;
            // 
            // FormVeCuaToi
            // 
            this.ClientSize = new System.Drawing.Size(1244, 553);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnHuyVe);
            this.Controls.Add(this.btnDoiVe);
            this.Controls.Add(this.dgvVe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormVeCuaToi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống bán vé ga Sài Gòn - Vé của tôi";
            this.Load += new System.EventHandler(this.FormVeCuaToi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvVe;
        private Button btnLamMoi;
        private Button btnHuyVe;
        private Button btnDoiVe;
        private Label lblTitle;
        private Button btnThongKe;
        private Button btnTimKiem;
        private DataGridViewTextBoxColumn dgvMaVe;
        private DataGridViewTextBoxColumn dgvHanhKhach;
        private DataGridViewTextBoxColumn dgvTuyen;
        private DataGridViewTextBoxColumn dgvGhe;
        private DataGridViewTextBoxColumn dgvKhoiHanh;
        private DataGridViewTextBoxColumn dgvGiaVe;
        private DataGridViewTextBoxColumn dgvTrangThai;
        private DataGridViewTextBoxColumn dgvNgayDat;
    }
}