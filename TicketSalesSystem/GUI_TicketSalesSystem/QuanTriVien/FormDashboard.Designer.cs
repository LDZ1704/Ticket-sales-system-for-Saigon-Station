namespace GUI_TicketSalesSystem
{
    partial class FormDashboard
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
            this.lblDoanhThuHomNay = new System.Windows.Forms.Label();
            this.lblDoanhThuThangNay = new System.Windows.Forms.Label();
            this.lblDoanhThuNamNay = new System.Windows.Forms.Label();
            this.lblSoVeHomNay = new System.Windows.Forms.Label();
            this.lblSoVeThangNay = new System.Windows.Forms.Label();
            this.lblSoVeNamNay = new System.Windows.Forms.Label();
            this.lblTongNguoiDung = new System.Windows.Forms.Label();
            this.lblNguoiDungMoi = new System.Windows.Forms.Label();
            this.lblSoChuyenDangChay = new System.Windows.Forms.Label();
            this.lblTiLeGheTrong = new System.Windows.Forms.Label();
            this.lblCapNhatLan = new System.Windows.Forms.Label();
            this.dgvTop5Tuyen = new System.Windows.Forms.DataGridView();
            this.dgvHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSoVe1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDoanhThu1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDoanhThu7Ngay = new System.Windows.Forms.DataGridView();
            this.dgvNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSoVe2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDoanhThu2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnXemThongKe = new System.Windows.Forms.Button();
            this.btnQuanLyNguoiDung = new System.Windows.Forms.Button();
            this.btnCaiDat = new System.Windows.Forms.Button();
            this.grpTop5 = new System.Windows.Forms.GroupBox();
            this.grpDoanhThu7Ngay = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlDoanhThu = new System.Windows.Forms.Panel();
            this.lblDoanhThuTitle = new System.Windows.Forms.Label();
            this.pnlVe = new System.Windows.Forms.Panel();
            this.lblVeTitle = new System.Windows.Forms.Label();
            this.pnlNguoiDung = new System.Windows.Forms.Panel();
            this.lblNguoiDungTitle = new System.Windows.Forms.Label();
            this.pnlHeThong = new System.Windows.Forms.Panel();
            this.lblHeThongTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop5Tuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu7Ngay)).BeginInit();
            this.grpTop5.SuspendLayout();
            this.grpDoanhThu7Ngay.SuspendLayout();
            this.pnlDoanhThu.SuspendLayout();
            this.pnlVe.SuspendLayout();
            this.pnlNguoiDung.SuspendLayout();
            this.pnlHeThong.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblDoanhThuHomNay
            // 
            this.lblDoanhThuHomNay.BackColor = System.Drawing.Color.Transparent;
            this.lblDoanhThuHomNay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuHomNay.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuHomNay.Location = new System.Drawing.Point(8, 40);
            this.lblDoanhThuHomNay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDoanhThuHomNay.Name = "lblDoanhThuHomNay";
            this.lblDoanhThuHomNay.Size = new System.Drawing.Size(329, 30);
            this.lblDoanhThuHomNay.TabIndex = 1;
            this.lblDoanhThuHomNay.Text = "Hôm nay: 0 VND";
            // 
            // lblDoanhThuThangNay
            // 
            this.lblDoanhThuThangNay.BackColor = System.Drawing.Color.Transparent;
            this.lblDoanhThuThangNay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuThangNay.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuThangNay.Location = new System.Drawing.Point(8, 70);
            this.lblDoanhThuThangNay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDoanhThuThangNay.Name = "lblDoanhThuThangNay";
            this.lblDoanhThuThangNay.Size = new System.Drawing.Size(329, 26);
            this.lblDoanhThuThangNay.TabIndex = 2;
            this.lblDoanhThuThangNay.Text = "Tháng này: 0 VND";
            // 
            // lblDoanhThuNamNay
            // 
            this.lblDoanhThuNamNay.BackColor = System.Drawing.Color.Transparent;
            this.lblDoanhThuNamNay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuNamNay.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuNamNay.Location = new System.Drawing.Point(8, 98);
            this.lblDoanhThuNamNay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDoanhThuNamNay.Name = "lblDoanhThuNamNay";
            this.lblDoanhThuNamNay.Size = new System.Drawing.Size(329, 25);
            this.lblDoanhThuNamNay.TabIndex = 3;
            this.lblDoanhThuNamNay.Text = "Năm nay: 0 VND";
            // 
            // lblSoVeHomNay
            // 
            this.lblSoVeHomNay.BackColor = System.Drawing.Color.Transparent;
            this.lblSoVeHomNay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoVeHomNay.ForeColor = System.Drawing.Color.White;
            this.lblSoVeHomNay.Location = new System.Drawing.Point(8, 37);
            this.lblSoVeHomNay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoVeHomNay.Name = "lblSoVeHomNay";
            this.lblSoVeHomNay.Size = new System.Drawing.Size(245, 28);
            this.lblSoVeHomNay.TabIndex = 1;
            this.lblSoVeHomNay.Text = "Hôm nay: 0";
            // 
            // lblSoVeThangNay
            // 
            this.lblSoVeThangNay.BackColor = System.Drawing.Color.Transparent;
            this.lblSoVeThangNay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoVeThangNay.ForeColor = System.Drawing.Color.White;
            this.lblSoVeThangNay.Location = new System.Drawing.Point(7, 61);
            this.lblSoVeThangNay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoVeThangNay.Name = "lblSoVeThangNay";
            this.lblSoVeThangNay.Size = new System.Drawing.Size(246, 27);
            this.lblSoVeThangNay.TabIndex = 2;
            this.lblSoVeThangNay.Text = "Tháng này: 0";
            // 
            // lblSoVeNamNay
            // 
            this.lblSoVeNamNay.BackColor = System.Drawing.Color.Transparent;
            this.lblSoVeNamNay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoVeNamNay.ForeColor = System.Drawing.Color.White;
            this.lblSoVeNamNay.Location = new System.Drawing.Point(8, 88);
            this.lblSoVeNamNay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoVeNamNay.Name = "lblSoVeNamNay";
            this.lblSoVeNamNay.Size = new System.Drawing.Size(245, 35);
            this.lblSoVeNamNay.TabIndex = 3;
            this.lblSoVeNamNay.Text = "Năm nay: 0";
            // 
            // lblTongNguoiDung
            // 
            this.lblTongNguoiDung.BackColor = System.Drawing.Color.Transparent;
            this.lblTongNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongNguoiDung.ForeColor = System.Drawing.Color.White;
            this.lblTongNguoiDung.Location = new System.Drawing.Point(2, 40);
            this.lblTongNguoiDung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongNguoiDung.Name = "lblTongNguoiDung";
            this.lblTongNguoiDung.Size = new System.Drawing.Size(246, 32);
            this.lblTongNguoiDung.TabIndex = 1;
            this.lblTongNguoiDung.Text = "Tổng: 0";
            // 
            // lblNguoiDungMoi
            // 
            this.lblNguoiDungMoi.BackColor = System.Drawing.Color.Transparent;
            this.lblNguoiDungMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiDungMoi.ForeColor = System.Drawing.Color.White;
            this.lblNguoiDungMoi.Location = new System.Drawing.Point(2, 72);
            this.lblNguoiDungMoi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNguoiDungMoi.Name = "lblNguoiDungMoi";
            this.lblNguoiDungMoi.Size = new System.Drawing.Size(246, 26);
            this.lblNguoiDungMoi.TabIndex = 2;
            this.lblNguoiDungMoi.Text = "Mới: 0";
            // 
            // lblSoChuyenDangChay
            // 
            this.lblSoChuyenDangChay.BackColor = System.Drawing.Color.Transparent;
            this.lblSoChuyenDangChay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoChuyenDangChay.ForeColor = System.Drawing.Color.White;
            this.lblSoChuyenDangChay.Location = new System.Drawing.Point(2, 37);
            this.lblSoChuyenDangChay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoChuyenDangChay.Name = "lblSoChuyenDangChay";
            this.lblSoChuyenDangChay.Size = new System.Drawing.Size(262, 37);
            this.lblSoChuyenDangChay.TabIndex = 1;
            this.lblSoChuyenDangChay.Text = "Chuyến: 0";
            // 
            // lblTiLeGheTrong
            // 
            this.lblTiLeGheTrong.BackColor = System.Drawing.Color.Transparent;
            this.lblTiLeGheTrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiLeGheTrong.ForeColor = System.Drawing.Color.White;
            this.lblTiLeGheTrong.Location = new System.Drawing.Point(2, 70);
            this.lblTiLeGheTrong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTiLeGheTrong.Name = "lblTiLeGheTrong";
            this.lblTiLeGheTrong.Size = new System.Drawing.Size(262, 29);
            this.lblTiLeGheTrong.TabIndex = 2;
            this.lblTiLeGheTrong.Text = "Ghế trống: 0%";
            // 
            // lblCapNhatLan
            // 
            this.lblCapNhatLan.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapNhatLan.ForeColor = System.Drawing.Color.Gray;
            this.lblCapNhatLan.Location = new System.Drawing.Point(967, 9);
            this.lblCapNhatLan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCapNhatLan.Name = "lblCapNhatLan";
            this.lblCapNhatLan.Size = new System.Drawing.Size(226, 25);
            this.lblCapNhatLan.TabIndex = 11;
            this.lblCapNhatLan.Text = "Cập nhật lần cuối: --:--:--";
            // 
            // dgvTop5Tuyen
            // 
            this.dgvTop5Tuyen.AllowUserToAddRows = false;
            this.dgvTop5Tuyen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTop5Tuyen.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvTop5Tuyen.ColumnHeadersHeight = 35;
            this.dgvTop5Tuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvHang,
            this.dgvTuyen,
            this.dgvSoVe1,
            this.dgvDoanhThu1});
            this.dgvTop5Tuyen.Location = new System.Drawing.Point(8, 28);
            this.dgvTop5Tuyen.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTop5Tuyen.Name = "dgvTop5Tuyen";
            this.dgvTop5Tuyen.ReadOnly = true;
            this.dgvTop5Tuyen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTop5Tuyen.Size = new System.Drawing.Size(601, 232);
            this.dgvTop5Tuyen.TabIndex = 0;
            // 
            // dgvHang
            // 
            this.dgvHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvHang.HeaderText = "Hạng";
            this.dgvHang.Name = "dgvHang";
            this.dgvHang.ReadOnly = true;
            this.dgvHang.Width = 92;
            // 
            // dgvTuyen
            // 
            this.dgvTuyen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTuyen.HeaderText = "Tuyến";
            this.dgvTuyen.Name = "dgvTuyen";
            this.dgvTuyen.ReadOnly = true;
            this.dgvTuyen.Width = 102;
            // 
            // dgvSoVe1
            // 
            this.dgvSoVe1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvSoVe1.HeaderText = "Số vé";
            this.dgvSoVe1.Name = "dgvSoVe1";
            this.dgvSoVe1.ReadOnly = true;
            this.dgvSoVe1.Width = 97;
            // 
            // dgvDoanhThu1
            // 
            this.dgvDoanhThu1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvDoanhThu1.HeaderText = "Doanh thu";
            this.dgvDoanhThu1.Name = "dgvDoanhThu1";
            this.dgvDoanhThu1.ReadOnly = true;
            this.dgvDoanhThu1.Width = 145;
            // 
            // dgvDoanhThu7Ngay
            // 
            this.dgvDoanhThu7Ngay.AllowUserToAddRows = false;
            this.dgvDoanhThu7Ngay.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvDoanhThu7Ngay.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDoanhThu7Ngay.ColumnHeadersHeight = 35;
            this.dgvDoanhThu7Ngay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvNgay,
            this.dgvSoVe2,
            this.dgvDoanhThu2});
            this.dgvDoanhThu7Ngay.Location = new System.Drawing.Point(8, 28);
            this.dgvDoanhThu7Ngay.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDoanhThu7Ngay.Name = "dgvDoanhThu7Ngay";
            this.dgvDoanhThu7Ngay.ReadOnly = true;
            this.dgvDoanhThu7Ngay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoanhThu7Ngay.Size = new System.Drawing.Size(542, 232);
            this.dgvDoanhThu7Ngay.TabIndex = 0;
            // 
            // dgvNgay
            // 
            this.dgvNgay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvNgay.HeaderText = "Ngày";
            this.dgvNgay.Name = "dgvNgay";
            this.dgvNgay.ReadOnly = true;
            this.dgvNgay.Width = 91;
            // 
            // dgvSoVe2
            // 
            this.dgvSoVe2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvSoVe2.HeaderText = "Số vé";
            this.dgvSoVe2.Name = "dgvSoVe2";
            this.dgvSoVe2.ReadOnly = true;
            this.dgvSoVe2.Width = 97;
            // 
            // dgvDoanhThu2
            // 
            this.dgvDoanhThu2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvDoanhThu2.HeaderText = "Doanh thu";
            this.dgvDoanhThu2.Name = "dgvDoanhThu2";
            this.dgvDoanhThu2.ReadOnly = true;
            this.dgvDoanhThu2.Width = 145;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Blue;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(27, 484);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(2);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(181, 46);
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnXemThongKe
            // 
            this.btnXemThongKe.BackColor = System.Drawing.Color.Green;
            this.btnXemThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemThongKe.ForeColor = System.Drawing.Color.White;
            this.btnXemThongKe.Location = new System.Drawing.Point(27, 534);
            this.btnXemThongKe.Margin = new System.Windows.Forms.Padding(2);
            this.btnXemThongKe.Name = "btnXemThongKe";
            this.btnXemThongKe.Size = new System.Drawing.Size(181, 41);
            this.btnXemThongKe.TabIndex = 8;
            this.btnXemThongKe.Text = "Xem thống kê";
            this.btnXemThongKe.UseVisualStyleBackColor = false;
            this.btnXemThongKe.Click += new System.EventHandler(this.btnXemThongKe_Click);
            // 
            // btnQuanLyNguoiDung
            // 
            this.btnQuanLyNguoiDung.BackColor = System.Drawing.Color.Orange;
            this.btnQuanLyNguoiDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyNguoiDung.ForeColor = System.Drawing.Color.White;
            this.btnQuanLyNguoiDung.Location = new System.Drawing.Point(1000, 534);
            this.btnQuanLyNguoiDung.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuanLyNguoiDung.Name = "btnQuanLyNguoiDung";
            this.btnQuanLyNguoiDung.Size = new System.Drawing.Size(193, 41);
            this.btnQuanLyNguoiDung.TabIndex = 9;
            this.btnQuanLyNguoiDung.Text = "Quản lý ND";
            this.btnQuanLyNguoiDung.UseVisualStyleBackColor = false;
            this.btnQuanLyNguoiDung.Click += new System.EventHandler(this.btnQuanLyNguoiDung_Click);
            // 
            // btnCaiDat
            // 
            this.btnCaiDat.BackColor = System.Drawing.Color.Purple;
            this.btnCaiDat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaiDat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaiDat.ForeColor = System.Drawing.Color.White;
            this.btnCaiDat.Location = new System.Drawing.Point(1000, 484);
            this.btnCaiDat.Margin = new System.Windows.Forms.Padding(2);
            this.btnCaiDat.Name = "btnCaiDat";
            this.btnCaiDat.Size = new System.Drawing.Size(193, 46);
            this.btnCaiDat.TabIndex = 10;
            this.btnCaiDat.Text = "Cài đặt";
            this.btnCaiDat.UseVisualStyleBackColor = false;
            this.btnCaiDat.Click += new System.EventHandler(this.btnCaiDat_Click);
            // 
            // grpTop5
            // 
            this.grpTop5.Controls.Add(this.dgvTop5Tuyen);
            this.grpTop5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTop5.Location = new System.Drawing.Point(22, 207);
            this.grpTop5.Margin = new System.Windows.Forms.Padding(2);
            this.grpTop5.Name = "grpTop5";
            this.grpTop5.Padding = new System.Windows.Forms.Padding(2);
            this.grpTop5.Size = new System.Drawing.Size(613, 264);
            this.grpTop5.TabIndex = 5;
            this.grpTop5.TabStop = false;
            this.grpTop5.Text = "TOP 5 TUYẾN BÁN CHẠY";
            // 
            // grpDoanhThu7Ngay
            // 
            this.grpDoanhThu7Ngay.Controls.Add(this.dgvDoanhThu7Ngay);
            this.grpDoanhThu7Ngay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDoanhThu7Ngay.Location = new System.Drawing.Point(639, 207);
            this.grpDoanhThu7Ngay.Margin = new System.Windows.Forms.Padding(2);
            this.grpDoanhThu7Ngay.Name = "grpDoanhThu7Ngay";
            this.grpDoanhThu7Ngay.Padding = new System.Windows.Forms.Padding(2);
            this.grpDoanhThu7Ngay.Size = new System.Drawing.Size(554, 264);
            this.grpDoanhThu7Ngay.TabIndex = 6;
            this.grpDoanhThu7Ngay.TabStop = false;
            this.grpDoanhThu7Ngay.Text = "DOANH THU 7 NGÀY GẦN NHẤT";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(22, 16);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(415, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TRANG TỔNG QUAN QUẢN TRỊ VIÊN";
            // 
            // pnlDoanhThu
            // 
            this.pnlDoanhThu.BackColor = System.Drawing.Color.Green;
            this.pnlDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThuTitle);
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThuHomNay);
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThuThangNay);
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThuNamNay);
            this.pnlDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDoanhThu.Location = new System.Drawing.Point(22, 65);
            this.pnlDoanhThu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDoanhThu.Name = "pnlDoanhThu";
            this.pnlDoanhThu.Size = new System.Drawing.Size(341, 125);
            this.pnlDoanhThu.TabIndex = 1;
            // 
            // lblDoanhThuTitle
            // 
            this.lblDoanhThuTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDoanhThuTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuTitle.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuTitle.Location = new System.Drawing.Point(8, 8);
            this.lblDoanhThuTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDoanhThuTitle.Name = "lblDoanhThuTitle";
            this.lblDoanhThuTitle.Size = new System.Drawing.Size(188, 22);
            this.lblDoanhThuTitle.TabIndex = 0;
            this.lblDoanhThuTitle.Text = "DOANH THU";
            // 
            // pnlVe
            // 
            this.pnlVe.BackColor = System.Drawing.Color.Orange;
            this.pnlVe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVe.Controls.Add(this.lblVeTitle);
            this.pnlVe.Controls.Add(this.lblSoVeHomNay);
            this.pnlVe.Controls.Add(this.lblSoVeThangNay);
            this.pnlVe.Controls.Add(this.lblSoVeNamNay);
            this.pnlVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlVe.Location = new System.Drawing.Point(377, 65);
            this.pnlVe.Margin = new System.Windows.Forms.Padding(2);
            this.pnlVe.Name = "pnlVe";
            this.pnlVe.Size = new System.Drawing.Size(258, 125);
            this.pnlVe.TabIndex = 2;
            // 
            // lblVeTitle
            // 
            this.lblVeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblVeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVeTitle.ForeColor = System.Drawing.Color.White;
            this.lblVeTitle.Location = new System.Drawing.Point(8, 8);
            this.lblVeTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVeTitle.Name = "lblVeTitle";
            this.lblVeTitle.Size = new System.Drawing.Size(188, 29);
            this.lblVeTitle.TabIndex = 0;
            this.lblVeTitle.Text = "SỐ VÉ";
            // 
            // pnlNguoiDung
            // 
            this.pnlNguoiDung.BackColor = System.Drawing.Color.Purple;
            this.pnlNguoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlNguoiDung.Controls.Add(this.lblNguoiDungTitle);
            this.pnlNguoiDung.Controls.Add(this.lblTongNguoiDung);
            this.pnlNguoiDung.Controls.Add(this.lblNguoiDungMoi);
            this.pnlNguoiDung.Location = new System.Drawing.Point(647, 65);
            this.pnlNguoiDung.Margin = new System.Windows.Forms.Padding(2);
            this.pnlNguoiDung.Name = "pnlNguoiDung";
            this.pnlNguoiDung.Size = new System.Drawing.Size(252, 124);
            this.pnlNguoiDung.TabIndex = 3;
            // 
            // lblNguoiDungTitle
            // 
            this.lblNguoiDungTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblNguoiDungTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiDungTitle.ForeColor = System.Drawing.Color.White;
            this.lblNguoiDungTitle.Location = new System.Drawing.Point(2, 8);
            this.lblNguoiDungTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNguoiDungTitle.Name = "lblNguoiDungTitle";
            this.lblNguoiDungTitle.Size = new System.Drawing.Size(188, 29);
            this.lblNguoiDungTitle.TabIndex = 0;
            this.lblNguoiDungTitle.Text = "NGƯỜI DÙNG";
            // 
            // pnlHeThong
            // 
            this.pnlHeThong.BackColor = System.Drawing.Color.Blue;
            this.pnlHeThong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHeThong.Controls.Add(this.lblHeThongTitle);
            this.pnlHeThong.Controls.Add(this.lblSoChuyenDangChay);
            this.pnlHeThong.Controls.Add(this.lblTiLeGheTrong);
            this.pnlHeThong.Location = new System.Drawing.Point(921, 65);
            this.pnlHeThong.Margin = new System.Windows.Forms.Padding(2);
            this.pnlHeThong.Name = "pnlHeThong";
            this.pnlHeThong.Size = new System.Drawing.Size(268, 125);
            this.pnlHeThong.TabIndex = 4;
            // 
            // lblHeThongTitle
            // 
            this.lblHeThongTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblHeThongTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeThongTitle.ForeColor = System.Drawing.Color.White;
            this.lblHeThongTitle.Location = new System.Drawing.Point(2, 8);
            this.lblHeThongTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHeThongTitle.Name = "lblHeThongTitle";
            this.lblHeThongTitle.Size = new System.Drawing.Size(188, 29);
            this.lblHeThongTitle.TabIndex = 0;
            this.lblHeThongTitle.Text = "HỆ THỐNG";
            // 
            // FormDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1204, 589);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlDoanhThu);
            this.Controls.Add(this.pnlVe);
            this.Controls.Add(this.pnlNguoiDung);
            this.Controls.Add(this.pnlHeThong);
            this.Controls.Add(this.grpTop5);
            this.Controls.Add(this.grpDoanhThu7Ngay);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnXemThongKe);
            this.Controls.Add(this.btnQuanLyNguoiDung);
            this.Controls.Add(this.btnCaiDat);
            this.Controls.Add(this.lblCapNhatLan);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormDashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard Quản trị";
            this.Load += new System.EventHandler(this.FormDashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTop5Tuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu7Ngay)).EndInit();
            this.grpTop5.ResumeLayout(false);
            this.grpDoanhThu7Ngay.ResumeLayout(false);
            this.pnlDoanhThu.ResumeLayout(false);
            this.pnlVe.ResumeLayout(false);
            this.pnlNguoiDung.ResumeLayout(false);
            this.pnlHeThong.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblDoanhThuHomNay;
        private System.Windows.Forms.Label lblDoanhThuThangNay;
        private System.Windows.Forms.Label lblDoanhThuNamNay;
        private System.Windows.Forms.Label lblSoVeHomNay;
        private System.Windows.Forms.Label lblSoVeThangNay;
        private System.Windows.Forms.Label lblSoVeNamNay;
        private System.Windows.Forms.Label lblTongNguoiDung;
        private System.Windows.Forms.Label lblNguoiDungMoi;
        private System.Windows.Forms.Label lblSoChuyenDangChay;
        private System.Windows.Forms.Label lblTiLeGheTrong;
        private System.Windows.Forms.Label lblCapNhatLan;
        private System.Windows.Forms.DataGridView dgvTop5Tuyen;
        private System.Windows.Forms.DataGridView dgvDoanhThu7Ngay;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Button btnXemThongKe;
        private System.Windows.Forms.Button btnQuanLyNguoiDung;
        private System.Windows.Forms.Button btnCaiDat;
        private System.Windows.Forms.GroupBox grpTop5;
        private System.Windows.Forms.GroupBox grpDoanhThu7Ngay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlDoanhThu;
        private System.Windows.Forms.Label lblDoanhThuTitle;
        private System.Windows.Forms.Panel pnlVe;
        private System.Windows.Forms.Label lblVeTitle;
        private System.Windows.Forms.Panel pnlNguoiDung;
        private System.Windows.Forms.Label lblNguoiDungTitle;
        private System.Windows.Forms.Panel pnlHeThong;
        private System.Windows.Forms.Label lblHeThongTitle;

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSoVe1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDoanhThu1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNgay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSoVe2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDoanhThu2;
    }
}