namespace GUI_TicketSalesSystem
{
    partial class FormQuanTriVien
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
            this.lblChaoAdmin = new System.Windows.Forms.Label();
            this.lblCapNhatLan = new System.Windows.Forms.Label();
            this.dgvTopTuyen = new System.Windows.Forms.DataGridView();
            this.dgvHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSoVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCanhBao = new System.Windows.Forms.DataGridView();
            this.dgvLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNoiDung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvThoiGian = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnXuatBaoCaoNgay = new System.Windows.Forms.Button();
            this.btnSaoLuuDuLieu = new System.Windows.Forms.Button();
            this.btnKiemTraHeThong = new System.Windows.Forms.Button();
            this.grpTopTuyen = new System.Windows.Forms.GroupBox();
            this.grpQuickActions = new System.Windows.Forms.GroupBox();
            this.grpCanhBao = new System.Windows.Forms.GroupBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnLamMoiDashboard = new System.Windows.Forms.Button();
            this.btnCaiDatHeThong = new System.Windows.Forms.Button();
            this.btnQuanLyNguoiDung = new System.Windows.Forms.Button();
            this.btnXemThongKe = new System.Windows.Forms.Button();
            this.pnlSystem = new System.Windows.Forms.Panel();
            this.lblSystemTitle = new System.Windows.Forms.Label();
            this.lblSoChuyenDangChay = new System.Windows.Forms.Label();
            this.lblTiLeGheTrong = new System.Windows.Forms.Label();
            this.progressGheTrong = new System.Windows.Forms.ProgressBar();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.lblUserTitle = new System.Windows.Forms.Label();
            this.lblTongNguoiDung = new System.Windows.Forms.Label();
            this.lblNguoiDungMoi = new System.Windows.Forms.Label();
            this.pnlVe = new System.Windows.Forms.Panel();
            this.lblVeTitle = new System.Windows.Forms.Label();
            this.lblSoVeHomNay = new System.Windows.Forms.Label();
            this.lblSoVeThangNay = new System.Windows.Forms.Label();
            this.pnlDoanhThu = new System.Windows.Forms.Panel();
            this.lblDoanhThuTitle = new System.Windows.Forms.Label();
            this.lblDoanhThuHomNay = new System.Windows.Forms.Label();
            this.lblDoanhThuThangNay = new System.Windows.Forms.Label();
            this.progressDoanhThu = new System.Windows.Forms.ProgressBar();
            this.grpDashboard = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopTuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).BeginInit();
            this.grpTopTuyen.SuspendLayout();
            this.grpQuickActions.SuspendLayout();
            this.grpCanhBao.SuspendLayout();
            this.pnlSystem.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.pnlVe.SuspendLayout();
            this.pnlDoanhThu.SuspendLayout();
            this.grpDashboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblChaoAdmin
            // 
            this.lblChaoAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblChaoAdmin.ForeColor = System.Drawing.Color.Blue;
            this.lblChaoAdmin.Location = new System.Drawing.Point(22, 45);
            this.lblChaoAdmin.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChaoAdmin.Name = "lblChaoAdmin";
            this.lblChaoAdmin.Size = new System.Drawing.Size(300, 20);
            this.lblChaoAdmin.TabIndex = 1;
            this.lblChaoAdmin.Text = "Xin chào Quản trị viên: Admin";
            // 
            // lblCapNhatLan
            // 
            this.lblCapNhatLan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapNhatLan.ForeColor = System.Drawing.Color.Gray;
            this.lblCapNhatLan.Location = new System.Drawing.Point(1247, 12);
            this.lblCapNhatLan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCapNhatLan.Name = "lblCapNhatLan";
            this.lblCapNhatLan.Size = new System.Drawing.Size(209, 24);
            this.lblCapNhatLan.TabIndex = 2;
            this.lblCapNhatLan.Text = "Cập nhật: --:--:--";
            // 
            // dgvTopTuyen
            // 
            this.dgvTopTuyen.AllowUserToAddRows = false;
            this.dgvTopTuyen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTopTuyen.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvTopTuyen.ColumnHeadersHeight = 35;
            this.dgvTopTuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvHang,
            this.dgvTuyen,
            this.dgvSoVe,
            this.dgvDoanhThu});
            this.dgvTopTuyen.Location = new System.Drawing.Point(11, 28);
            this.dgvTopTuyen.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTopTuyen.Name = "dgvTopTuyen";
            this.dgvTopTuyen.ReadOnly = true;
            this.dgvTopTuyen.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopTuyen.Size = new System.Drawing.Size(761, 229);
            this.dgvTopTuyen.TabIndex = 0;
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
            // dgvSoVe
            // 
            this.dgvSoVe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvSoVe.HeaderText = "Số vé";
            this.dgvSoVe.Name = "dgvSoVe";
            this.dgvSoVe.ReadOnly = true;
            this.dgvSoVe.Width = 97;
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvDoanhThu.HeaderText = "Doanh thu";
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.ReadOnly = true;
            this.dgvDoanhThu.Width = 145;
            // 
            // dgvCanhBao
            // 
            this.dgvCanhBao.AllowUserToAddRows = false;
            this.dgvCanhBao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCanhBao.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvCanhBao.ColumnHeadersHeight = 35;
            this.dgvCanhBao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvLoai,
            this.dgvNoiDung,
            this.dgvThoiGian,
            this.dgvTrangThai});
            this.dgvCanhBao.Location = new System.Drawing.Point(11, 24);
            this.dgvCanhBao.Margin = new System.Windows.Forms.Padding(2);
            this.dgvCanhBao.Name = "dgvCanhBao";
            this.dgvCanhBao.ReadOnly = true;
            this.dgvCanhBao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCanhBao.Size = new System.Drawing.Size(761, 255);
            this.dgvCanhBao.TabIndex = 0;
            // 
            // dgvLoai
            // 
            this.dgvLoai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvLoai.HeaderText = "Loại";
            this.dgvLoai.Name = "dgvLoai";
            this.dgvLoai.ReadOnly = true;
            this.dgvLoai.Width = 82;
            // 
            // dgvNoiDung
            // 
            this.dgvNoiDung.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvNoiDung.HeaderText = "Nội dung";
            this.dgvNoiDung.Name = "dgvNoiDung";
            this.dgvNoiDung.ReadOnly = true;
            this.dgvNoiDung.Width = 131;
            // 
            // dgvThoiGian
            // 
            this.dgvThoiGian.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvThoiGian.HeaderText = "Thời gian";
            this.dgvThoiGian.Name = "dgvThoiGian";
            this.dgvThoiGian.ReadOnly = true;
            this.dgvThoiGian.Width = 135;
            // 
            // dgvTrangThai
            // 
            this.dgvTrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTrangThai.HeaderText = "Trạng thái";
            this.dgvTrangThai.Name = "dgvTrangThai";
            this.dgvTrangThai.ReadOnly = true;
            this.dgvTrangThai.Width = 144;
            // 
            // btnXuatBaoCaoNgay
            // 
            this.btnXuatBaoCaoNgay.BackColor = System.Drawing.Color.Purple;
            this.btnXuatBaoCaoNgay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatBaoCaoNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatBaoCaoNgay.ForeColor = System.Drawing.Color.White;
            this.btnXuatBaoCaoNgay.Location = new System.Drawing.Point(81, 188);
            this.btnXuatBaoCaoNgay.Margin = new System.Windows.Forms.Padding(2);
            this.btnXuatBaoCaoNgay.Name = "btnXuatBaoCaoNgay";
            this.btnXuatBaoCaoNgay.Size = new System.Drawing.Size(225, 34);
            this.btnXuatBaoCaoNgay.TabIndex = 6;
            this.btnXuatBaoCaoNgay.Text = "Báo cáo ngày";
            this.btnXuatBaoCaoNgay.UseVisualStyleBackColor = false;
            this.btnXuatBaoCaoNgay.Click += new System.EventHandler(this.BtnXuatBaoCaoNgay_Click);
            // 
            // btnSaoLuuDuLieu
            // 
            this.btnSaoLuuDuLieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(69)))), ((int)(((byte)(19)))));
            this.btnSaoLuuDuLieu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaoLuuDuLieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaoLuuDuLieu.ForeColor = System.Drawing.Color.White;
            this.btnSaoLuuDuLieu.Location = new System.Drawing.Point(310, 188);
            this.btnSaoLuuDuLieu.Margin = new System.Windows.Forms.Padding(2);
            this.btnSaoLuuDuLieu.Name = "btnSaoLuuDuLieu";
            this.btnSaoLuuDuLieu.Size = new System.Drawing.Size(234, 34);
            this.btnSaoLuuDuLieu.TabIndex = 7;
            this.btnSaoLuuDuLieu.Text = "Sao lưu";
            this.btnSaoLuuDuLieu.UseVisualStyleBackColor = false;
            this.btnSaoLuuDuLieu.Click += new System.EventHandler(this.BtnSaoLuuDuLieu_Click);
            // 
            // btnKiemTraHeThong
            // 
            this.btnKiemTraHeThong.BackColor = System.Drawing.Color.Navy;
            this.btnKiemTraHeThong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKiemTraHeThong.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKiemTraHeThong.ForeColor = System.Drawing.Color.White;
            this.btnKiemTraHeThong.Location = new System.Drawing.Point(311, 150);
            this.btnKiemTraHeThong.Margin = new System.Windows.Forms.Padding(2);
            this.btnKiemTraHeThong.Name = "btnKiemTraHeThong";
            this.btnKiemTraHeThong.Size = new System.Drawing.Size(234, 34);
            this.btnKiemTraHeThong.TabIndex = 8;
            this.btnKiemTraHeThong.Text = "Kiểm tra hệ thống";
            this.btnKiemTraHeThong.UseVisualStyleBackColor = false;
            this.btnKiemTraHeThong.Click += new System.EventHandler(this.BtnKiemTraHeThong_Click);
            // 
            // grpTopTuyen
            // 
            this.grpTopTuyen.Controls.Add(this.dgvTopTuyen);
            this.grpTopTuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpTopTuyen.Location = new System.Drawing.Point(684, 73);
            this.grpTopTuyen.Margin = new System.Windows.Forms.Padding(2);
            this.grpTopTuyen.Name = "grpTopTuyen";
            this.grpTopTuyen.Padding = new System.Windows.Forms.Padding(2);
            this.grpTopTuyen.Size = new System.Drawing.Size(780, 261);
            this.grpTopTuyen.TabIndex = 4;
            this.grpTopTuyen.TabStop = false;
            this.grpTopTuyen.Text = "Top 5 tuyến bán chạy";
            // 
            // grpQuickActions
            // 
            this.grpQuickActions.Controls.Add(this.btnXemThongKe);
            this.grpQuickActions.Controls.Add(this.btnLamMoiDashboard);
            this.grpQuickActions.Controls.Add(this.btnCaiDatHeThong);
            this.grpQuickActions.Controls.Add(this.btnQuanLyNguoiDung);
            this.grpQuickActions.Controls.Add(this.btnXuatBaoCaoNgay);
            this.grpQuickActions.Controls.Add(this.btnSaoLuuDuLieu);
            this.grpQuickActions.Controls.Add(this.btnKiemTraHeThong);
            this.grpQuickActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpQuickActions.Location = new System.Drawing.Point(22, 355);
            this.grpQuickActions.Margin = new System.Windows.Forms.Padding(2);
            this.grpQuickActions.Name = "grpQuickActions";
            this.grpQuickActions.Padding = new System.Windows.Forms.Padding(2);
            this.grpQuickActions.Size = new System.Drawing.Size(658, 283);
            this.grpQuickActions.TabIndex = 5;
            this.grpQuickActions.TabStop = false;
            this.grpQuickActions.Text = "Thao tác nhanh";
            // 
            // grpCanhBao
            // 
            this.grpCanhBao.Controls.Add(this.dgvCanhBao);
            this.grpCanhBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCanhBao.Location = new System.Drawing.Point(684, 355);
            this.grpCanhBao.Margin = new System.Windows.Forms.Padding(2);
            this.grpCanhBao.Name = "grpCanhBao";
            this.grpCanhBao.Padding = new System.Windows.Forms.Padding(2);
            this.grpCanhBao.Size = new System.Drawing.Size(776, 283);
            this.grpCanhBao.TabIndex = 6;
            this.grpCanhBao.TabStop = false;
            this.grpCanhBao.Text = "Cảnh báo hệ thống";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblTitle.Location = new System.Drawing.Point(22, 12);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(566, 33);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "BẢNG ĐIỀU KHIỂN QUẢN TRỊ VIÊN";
            // 
            // btnLamMoiDashboard
            // 
            this.btnLamMoiDashboard.BackColor = System.Drawing.Color.Blue;
            this.btnLamMoiDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoiDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoiDashboard.ForeColor = System.Drawing.Color.White;
            this.btnLamMoiDashboard.Location = new System.Drawing.Point(252, 72);
            this.btnLamMoiDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.btnLamMoiDashboard.Name = "btnLamMoiDashboard";
            this.btnLamMoiDashboard.Size = new System.Drawing.Size(111, 35);
            this.btnLamMoiDashboard.TabIndex = 7;
            this.btnLamMoiDashboard.Text = "Làm mới";
            this.btnLamMoiDashboard.UseVisualStyleBackColor = false;
            this.btnLamMoiDashboard.Click += new System.EventHandler(this.BtnLamMoiDashboard_Click);
            // 
            // btnCaiDatHeThong
            // 
            this.btnCaiDatHeThong.BackColor = System.Drawing.Color.Crimson;
            this.btnCaiDatHeThong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCaiDatHeThong.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaiDatHeThong.ForeColor = System.Drawing.Color.White;
            this.btnCaiDatHeThong.Location = new System.Drawing.Point(81, 148);
            this.btnCaiDatHeThong.Margin = new System.Windows.Forms.Padding(2);
            this.btnCaiDatHeThong.Name = "btnCaiDatHeThong";
            this.btnCaiDatHeThong.Size = new System.Drawing.Size(225, 36);
            this.btnCaiDatHeThong.TabIndex = 6;
            this.btnCaiDatHeThong.Text = "Cài đặt hệ thống";
            this.btnCaiDatHeThong.UseVisualStyleBackColor = false;
            this.btnCaiDatHeThong.Click += new System.EventHandler(this.BtnCaiDatHeThong_Click);
            // 
            // btnQuanLyNguoiDung
            // 
            this.btnQuanLyNguoiDung.BackColor = System.Drawing.Color.Orange;
            this.btnQuanLyNguoiDung.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuanLyNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuanLyNguoiDung.ForeColor = System.Drawing.Color.White;
            this.btnQuanLyNguoiDung.Location = new System.Drawing.Point(311, 111);
            this.btnQuanLyNguoiDung.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuanLyNguoiDung.Name = "btnQuanLyNguoiDung";
            this.btnQuanLyNguoiDung.Size = new System.Drawing.Size(234, 35);
            this.btnQuanLyNguoiDung.TabIndex = 5;
            this.btnQuanLyNguoiDung.Text = "Quản lý người dùng";
            this.btnQuanLyNguoiDung.UseVisualStyleBackColor = false;
            this.btnQuanLyNguoiDung.Click += new System.EventHandler(this.btnQuanLyNguoiDung_Click);
            // 
            // btnXemThongKe
            // 
            this.btnXemThongKe.BackColor = System.Drawing.Color.Green;
            this.btnXemThongKe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemThongKe.ForeColor = System.Drawing.Color.White;
            this.btnXemThongKe.Location = new System.Drawing.Point(81, 112);
            this.btnXemThongKe.Margin = new System.Windows.Forms.Padding(2);
            this.btnXemThongKe.Name = "btnXemThongKe";
            this.btnXemThongKe.Size = new System.Drawing.Size(226, 34);
            this.btnXemThongKe.TabIndex = 4;
            this.btnXemThongKe.Text = "Xem thống kê";
            this.btnXemThongKe.UseVisualStyleBackColor = false;
            this.btnXemThongKe.Click += new System.EventHandler(this.btnXemThongKe_Click);
            // 
            // pnlSystem
            // 
            this.pnlSystem.BackColor = System.Drawing.Color.Blue;
            this.pnlSystem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSystem.Controls.Add(this.lblSystemTitle);
            this.pnlSystem.Controls.Add(this.lblSoChuyenDangChay);
            this.pnlSystem.Controls.Add(this.lblTiLeGheTrong);
            this.pnlSystem.Controls.Add(this.progressGheTrong);
            this.pnlSystem.Location = new System.Drawing.Point(503, 24);
            this.pnlSystem.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSystem.Name = "pnlSystem";
            this.pnlSystem.Size = new System.Drawing.Size(151, 233);
            this.pnlSystem.TabIndex = 3;
            // 
            // lblSystemTitle
            // 
            this.lblSystemTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSystemTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemTitle.ForeColor = System.Drawing.Color.White;
            this.lblSystemTitle.Location = new System.Drawing.Point(4, 0);
            this.lblSystemTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSystemTitle.Name = "lblSystemTitle";
            this.lblSystemTitle.Size = new System.Drawing.Size(143, 36);
            this.lblSystemTitle.TabIndex = 0;
            this.lblSystemTitle.Text = "HỆ THỐNG";
            this.lblSystemTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSoChuyenDangChay
            // 
            this.lblSoChuyenDangChay.BackColor = System.Drawing.Color.Transparent;
            this.lblSoChuyenDangChay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoChuyenDangChay.ForeColor = System.Drawing.Color.White;
            this.lblSoChuyenDangChay.Location = new System.Drawing.Point(2, 69);
            this.lblSoChuyenDangChay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoChuyenDangChay.Name = "lblSoChuyenDangChay";
            this.lblSoChuyenDangChay.Size = new System.Drawing.Size(142, 24);
            this.lblSoChuyenDangChay.TabIndex = 1;
            this.lblSoChuyenDangChay.Text = "Chuyến: 0";
            // 
            // lblTiLeGheTrong
            // 
            this.lblTiLeGheTrong.BackColor = System.Drawing.Color.Transparent;
            this.lblTiLeGheTrong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiLeGheTrong.ForeColor = System.Drawing.Color.White;
            this.lblTiLeGheTrong.Location = new System.Drawing.Point(4, 141);
            this.lblTiLeGheTrong.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTiLeGheTrong.Name = "lblTiLeGheTrong";
            this.lblTiLeGheTrong.Size = new System.Drawing.Size(142, 69);
            this.lblTiLeGheTrong.TabIndex = 2;
            this.lblTiLeGheTrong.Text = "Ghế trống: 0%";
            // 
            // progressGheTrong
            // 
            this.progressGheTrong.Location = new System.Drawing.Point(2, 212);
            this.progressGheTrong.Margin = new System.Windows.Forms.Padding(2);
            this.progressGheTrong.Name = "progressGheTrong";
            this.progressGheTrong.Size = new System.Drawing.Size(142, 17);
            this.progressGheTrong.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressGheTrong.TabIndex = 3;
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = System.Drawing.Color.Purple;
            this.pnlUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUser.Controls.Add(this.lblUserTitle);
            this.pnlUser.Controls.Add(this.lblTongNguoiDung);
            this.pnlUser.Controls.Add(this.lblNguoiDungMoi);
            this.pnlUser.Location = new System.Drawing.Point(350, 24);
            this.pnlUser.Margin = new System.Windows.Forms.Padding(2);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(143, 233);
            this.pnlUser.TabIndex = 2;
            // 
            // lblUserTitle
            // 
            this.lblUserTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblUserTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserTitle.ForeColor = System.Drawing.Color.White;
            this.lblUserTitle.Location = new System.Drawing.Point(2, -1);
            this.lblUserTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserTitle.Name = "lblUserTitle";
            this.lblUserTitle.Size = new System.Drawing.Size(138, 57);
            this.lblUserTitle.TabIndex = 0;
            this.lblUserTitle.Text = "NGƯỜI DÙNG";
            this.lblUserTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTongNguoiDung
            // 
            this.lblTongNguoiDung.BackColor = System.Drawing.Color.Transparent;
            this.lblTongNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongNguoiDung.ForeColor = System.Drawing.Color.White;
            this.lblTongNguoiDung.Location = new System.Drawing.Point(2, 69);
            this.lblTongNguoiDung.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTongNguoiDung.Name = "lblTongNguoiDung";
            this.lblTongNguoiDung.Size = new System.Drawing.Size(137, 32);
            this.lblTongNguoiDung.TabIndex = 1;
            this.lblTongNguoiDung.Text = "Tổng: 0";
            // 
            // lblNguoiDungMoi
            // 
            this.lblNguoiDungMoi.BackColor = System.Drawing.Color.Transparent;
            this.lblNguoiDungMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoiDungMoi.ForeColor = System.Drawing.Color.White;
            this.lblNguoiDungMoi.Location = new System.Drawing.Point(-3, 141);
            this.lblNguoiDungMoi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNguoiDungMoi.Name = "lblNguoiDungMoi";
            this.lblNguoiDungMoi.Size = new System.Drawing.Size(137, 26);
            this.lblNguoiDungMoi.TabIndex = 2;
            this.lblNguoiDungMoi.Text = "Mới: 0";
            // 
            // pnlVe
            // 
            this.pnlVe.BackColor = System.Drawing.Color.Orange;
            this.pnlVe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlVe.Controls.Add(this.lblVeTitle);
            this.pnlVe.Controls.Add(this.lblSoVeHomNay);
            this.pnlVe.Controls.Add(this.lblSoVeThangNay);
            this.pnlVe.Location = new System.Drawing.Point(200, 24);
            this.pnlVe.Margin = new System.Windows.Forms.Padding(2);
            this.pnlVe.Name = "pnlVe";
            this.pnlVe.Size = new System.Drawing.Size(146, 233);
            this.pnlVe.TabIndex = 1;
            // 
            // lblVeTitle
            // 
            this.lblVeTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblVeTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVeTitle.ForeColor = System.Drawing.Color.White;
            this.lblVeTitle.Location = new System.Drawing.Point(2, -1);
            this.lblVeTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVeTitle.Name = "lblVeTitle";
            this.lblVeTitle.Size = new System.Drawing.Size(134, 37);
            this.lblVeTitle.TabIndex = 0;
            this.lblVeTitle.Text = "SỐ VÉ";
            this.lblVeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSoVeHomNay
            // 
            this.lblSoVeHomNay.BackColor = System.Drawing.Color.Transparent;
            this.lblSoVeHomNay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoVeHomNay.ForeColor = System.Drawing.Color.White;
            this.lblSoVeHomNay.Location = new System.Drawing.Point(3, 69);
            this.lblSoVeHomNay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoVeHomNay.Name = "lblSoVeHomNay";
            this.lblSoVeHomNay.Size = new System.Drawing.Size(140, 30);
            this.lblSoVeHomNay.TabIndex = 1;
            this.lblSoVeHomNay.Text = "Hôm nay: 0";
            // 
            // lblSoVeThangNay
            // 
            this.lblSoVeThangNay.BackColor = System.Drawing.Color.Transparent;
            this.lblSoVeThangNay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoVeThangNay.ForeColor = System.Drawing.Color.White;
            this.lblSoVeThangNay.Location = new System.Drawing.Point(0, 141);
            this.lblSoVeThangNay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoVeThangNay.Name = "lblSoVeThangNay";
            this.lblSoVeThangNay.Size = new System.Drawing.Size(142, 55);
            this.lblSoVeThangNay.TabIndex = 2;
            this.lblSoVeThangNay.Text = "Tháng này: 0";
            // 
            // pnlDoanhThu
            // 
            this.pnlDoanhThu.BackColor = System.Drawing.Color.Green;
            this.pnlDoanhThu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThuTitle);
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThuHomNay);
            this.pnlDoanhThu.Controls.Add(this.lblDoanhThuThangNay);
            this.pnlDoanhThu.Controls.Add(this.progressDoanhThu);
            this.pnlDoanhThu.Location = new System.Drawing.Point(6, 24);
            this.pnlDoanhThu.Margin = new System.Windows.Forms.Padding(2);
            this.pnlDoanhThu.Name = "pnlDoanhThu";
            this.pnlDoanhThu.Size = new System.Drawing.Size(185, 233);
            this.pnlDoanhThu.TabIndex = 0;
            // 
            // lblDoanhThuTitle
            // 
            this.lblDoanhThuTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblDoanhThuTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuTitle.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuTitle.Location = new System.Drawing.Point(7, -1);
            this.lblDoanhThuTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDoanhThuTitle.Name = "lblDoanhThuTitle";
            this.lblDoanhThuTitle.Size = new System.Drawing.Size(160, 31);
            this.lblDoanhThuTitle.TabIndex = 0;
            this.lblDoanhThuTitle.Text = "DOANH THU";
            this.lblDoanhThuTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDoanhThuHomNay
            // 
            this.lblDoanhThuHomNay.BackColor = System.Drawing.Color.Transparent;
            this.lblDoanhThuHomNay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuHomNay.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuHomNay.Location = new System.Drawing.Point(2, 69);
            this.lblDoanhThuHomNay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDoanhThuHomNay.Name = "lblDoanhThuHomNay";
            this.lblDoanhThuHomNay.Size = new System.Drawing.Size(170, 58);
            this.lblDoanhThuHomNay.TabIndex = 1;
            this.lblDoanhThuHomNay.Text = "Hôm nay: 0 VND";
            // 
            // lblDoanhThuThangNay
            // 
            this.lblDoanhThuThangNay.BackColor = System.Drawing.Color.Transparent;
            this.lblDoanhThuThangNay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDoanhThuThangNay.ForeColor = System.Drawing.Color.White;
            this.lblDoanhThuThangNay.Location = new System.Drawing.Point(0, 141);
            this.lblDoanhThuThangNay.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDoanhThuThangNay.Name = "lblDoanhThuThangNay";
            this.lblDoanhThuThangNay.Size = new System.Drawing.Size(189, 69);
            this.lblDoanhThuThangNay.TabIndex = 2;
            this.lblDoanhThuThangNay.Text = "Tháng này: 0 VND";
            // 
            // progressDoanhThu
            // 
            this.progressDoanhThu.Location = new System.Drawing.Point(4, 212);
            this.progressDoanhThu.Margin = new System.Windows.Forms.Padding(2);
            this.progressDoanhThu.Name = "progressDoanhThu";
            this.progressDoanhThu.Size = new System.Drawing.Size(177, 16);
            this.progressDoanhThu.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressDoanhThu.TabIndex = 3;
            // 
            // grpDashboard
            // 
            this.grpDashboard.Controls.Add(this.pnlDoanhThu);
            this.grpDashboard.Controls.Add(this.pnlVe);
            this.grpDashboard.Controls.Add(this.pnlUser);
            this.grpDashboard.Controls.Add(this.pnlSystem);
            this.grpDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpDashboard.Location = new System.Drawing.Point(22, 73);
            this.grpDashboard.Margin = new System.Windows.Forms.Padding(2);
            this.grpDashboard.Name = "grpDashboard";
            this.grpDashboard.Padding = new System.Windows.Forms.Padding(2);
            this.grpDashboard.Size = new System.Drawing.Size(658, 261);
            this.grpDashboard.TabIndex = 3;
            this.grpDashboard.TabStop = false;
            this.grpDashboard.Text = "Thống kê tổng quan";
            // 
            // FormQuanTriVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1475, 649);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblChaoAdmin);
            this.Controls.Add(this.lblCapNhatLan);
            this.Controls.Add(this.grpDashboard);
            this.Controls.Add(this.grpTopTuyen);
            this.Controls.Add(this.grpQuickActions);
            this.Controls.Add(this.grpCanhBao);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "FormQuanTriVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản trị viên - Tổng quan hệ thống";
            this.Load += new System.EventHandler(this.FormQuanTriVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopTuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCanhBao)).EndInit();
            this.grpTopTuyen.ResumeLayout(false);
            this.grpQuickActions.ResumeLayout(false);
            this.grpCanhBao.ResumeLayout(false);
            this.pnlSystem.ResumeLayout(false);
            this.pnlUser.ResumeLayout(false);
            this.pnlVe.ResumeLayout(false);
            this.pnlDoanhThu.ResumeLayout(false);
            this.grpDashboard.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Label lblChaoAdmin;
        private System.Windows.Forms.Label lblCapNhatLan;
        private System.Windows.Forms.DataGridView dgvTopTuyen;
        private System.Windows.Forms.DataGridView dgvCanhBao;
        private System.Windows.Forms.Button btnXuatBaoCaoNgay;
        private System.Windows.Forms.Button btnSaoLuuDuLieu;
        private System.Windows.Forms.Button btnKiemTraHeThong;
        private System.Windows.Forms.GroupBox grpTopTuyen;
        private System.Windows.Forms.GroupBox grpQuickActions;
        private System.Windows.Forms.GroupBox grpCanhBao;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label lblTitle;

        #endregion
        private System.Windows.Forms.Button btnLamMoiDashboard;
        private System.Windows.Forms.Button btnCaiDatHeThong;
        private System.Windows.Forms.Button btnQuanLyNguoiDung;
        private System.Windows.Forms.Button btnXemThongKe;
        private System.Windows.Forms.Panel pnlSystem;
        private System.Windows.Forms.Label lblSystemTitle;
        private System.Windows.Forms.Label lblSoChuyenDangChay;
        private System.Windows.Forms.Label lblTiLeGheTrong;
        private System.Windows.Forms.ProgressBar progressGheTrong;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Label lblUserTitle;
        private System.Windows.Forms.Label lblTongNguoiDung;
        private System.Windows.Forms.Label lblNguoiDungMoi;
        private System.Windows.Forms.Panel pnlVe;
        private System.Windows.Forms.Label lblVeTitle;
        private System.Windows.Forms.Label lblSoVeHomNay;
        private System.Windows.Forms.Label lblSoVeThangNay;
        private System.Windows.Forms.Panel pnlDoanhThu;
        private System.Windows.Forms.Label lblDoanhThuTitle;
        private System.Windows.Forms.Label lblDoanhThuHomNay;
        private System.Windows.Forms.Label lblDoanhThuThangNay;
        private System.Windows.Forms.ProgressBar progressDoanhThu;
        private System.Windows.Forms.GroupBox grpDashboard;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvHang;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTuyen;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvSoVe;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDoanhThu;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvLoai;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNoiDung;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvThoiGian;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTrangThai;
    }
}