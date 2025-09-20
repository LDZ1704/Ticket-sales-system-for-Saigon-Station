namespace GUI_TicketSalesSystem
{
    partial class FormDatVeGioHang
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
            this.lblChuyenTau = new System.Windows.Forms.Label();
            this.cboChuyenTau = new System.Windows.Forms.ComboBox();
            this.dgvGhe = new System.Windows.Forms.DataGridView();
            this.lblThongTinHanhKhach = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblSoGiayTo = new System.Windows.Forms.Label();
            this.txtSoGiayTo = new System.Windows.Forms.TextBox();
            this.btnThemVaoGio = new System.Windows.Forms.Button();
            this.btnXemGioHang = new System.Windows.Forms.Button();
            this.btnThanhToanVNPay = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGhe)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblTieuDe.Location = new System.Drawing.Point(27, 25);
            this.lblTieuDe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(242, 31);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Đặt vé - Giỏ hàng";
            // 
            // lblChuyenTau
            // 
            this.lblChuyenTau.AutoSize = true;
            this.lblChuyenTau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChuyenTau.Location = new System.Drawing.Point(27, 74);
            this.lblChuyenTau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChuyenTau.Name = "lblChuyenTau";
            this.lblChuyenTau.Size = new System.Drawing.Size(98, 20);
            this.lblChuyenTau.TabIndex = 1;
            this.lblChuyenTau.Text = "Chuyến tàu:";
            // 
            // cboChuyenTau
            // 
            this.cboChuyenTau.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuyenTau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChuyenTau.FormattingEnabled = true;
            this.cboChuyenTau.Location = new System.Drawing.Point(160, 70);
            this.cboChuyenTau.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboChuyenTau.Name = "cboChuyenTau";
            this.cboChuyenTau.Size = new System.Drawing.Size(532, 28);
            this.cboChuyenTau.TabIndex = 2;
            this.cboChuyenTau.SelectedIndexChanged += new System.EventHandler(this.cboChuyenTau_SelectedIndexChanged);
            // 
            // dgvGhe
            // 
            this.dgvGhe.AllowUserToAddRows = false;
            this.dgvGhe.AllowUserToDeleteRows = false;
            this.dgvGhe.BackgroundColor = System.Drawing.Color.White;
            this.dgvGhe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGhe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGhe.Location = new System.Drawing.Point(0, 0);
            this.dgvGhe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvGhe.Name = "dgvGhe";
            this.dgvGhe.ReadOnly = true;
            this.dgvGhe.RowHeadersWidth = 51;
            this.dgvGhe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGhe.Size = new System.Drawing.Size(800, 246);
            this.dgvGhe.TabIndex = 3;
            // 
            // lblThongTinHanhKhach
            // 
            this.lblThongTinHanhKhach.AutoSize = true;
            this.lblThongTinHanhKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTinHanhKhach.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.lblThongTinHanhKhach.Location = new System.Drawing.Point(27, 123);
            this.lblThongTinHanhKhach.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblThongTinHanhKhach.Name = "lblThongTinHanhKhach";
            this.lblThongTinHanhKhach.Size = new System.Drawing.Size(228, 25);
            this.lblThongTinHanhKhach.TabIndex = 4;
            this.lblThongTinHanhKhach.Text = "Thông tin hành khách:";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(27, 160);
            this.lblHoTen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(64, 20);
            this.lblHoTen.TabIndex = 5;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(133, 156);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(265, 26);
            this.txtHoTen.TabIndex = 6;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.AutoSize = true;
            this.lblGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGioiTinh.Location = new System.Drawing.Point(427, 160);
            this.lblGioiTinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(76, 20);
            this.lblGioiTinh.TabIndex = 7;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGioiTinh.Location = new System.Drawing.Point(533, 156);
            this.cboGioiTinh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(132, 28);
            this.cboGioiTinh.TabIndex = 8;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinh.Location = new System.Drawing.Point(27, 197);
            this.lblNgaySinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(88, 20);
            this.lblNgaySinh.TabIndex = 9;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(133, 193);
            this.dtpNgaySinh.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(265, 26);
            this.dtpNgaySinh.TabIndex = 10;
            // 
            // lblSoGiayTo
            // 
            this.lblSoGiayTo.AutoSize = true;
            this.lblSoGiayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoGiayTo.Location = new System.Drawing.Point(427, 197);
            this.lblSoGiayTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSoGiayTo.Name = "lblSoGiayTo";
            this.lblSoGiayTo.Size = new System.Drawing.Size(88, 20);
            this.lblSoGiayTo.TabIndex = 11;
            this.lblSoGiayTo.Text = "Số giấy tờ:";
            // 
            // txtSoGiayTo
            // 
            this.txtSoGiayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoGiayTo.Location = new System.Drawing.Point(533, 193);
            this.txtSoGiayTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSoGiayTo.Name = "txtSoGiayTo";
            this.txtSoGiayTo.Size = new System.Drawing.Size(265, 26);
            this.txtSoGiayTo.TabIndex = 12;
            // 
            // btnThemVaoGio
            // 
            this.btnThemVaoGio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(102)))), ((int)(((byte)(204)))));
            this.btnThemVaoGio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemVaoGio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemVaoGio.ForeColor = System.Drawing.Color.White;
            this.btnThemVaoGio.Location = new System.Drawing.Point(27, 330);
            this.btnThemVaoGio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThemVaoGio.Name = "btnThemVaoGio";
            this.btnThemVaoGio.Size = new System.Drawing.Size(160, 49);
            this.btnThemVaoGio.TabIndex = 13;
            this.btnThemVaoGio.Text = "Thêm vào giỏ";
            this.btnThemVaoGio.UseVisualStyleBackColor = false;
            this.btnThemVaoGio.Click += new System.EventHandler(this.btnThemVaoGio_Click);
            // 
            // btnXemGioHang
            // 
            this.btnXemGioHang.BackColor = System.Drawing.Color.Orange;
            this.btnXemGioHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXemGioHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXemGioHang.ForeColor = System.Drawing.Color.White;
            this.btnXemGioHang.Location = new System.Drawing.Point(213, 330);
            this.btnXemGioHang.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXemGioHang.Name = "btnXemGioHang";
            this.btnXemGioHang.Size = new System.Drawing.Size(160, 49);
            this.btnXemGioHang.TabIndex = 14;
            this.btnXemGioHang.Text = "Xem giỏ hàng";
            this.btnXemGioHang.UseVisualStyleBackColor = false;
            this.btnXemGioHang.Click += new System.EventHandler(this.btnXemGioHang_Click);
            // 
            // btnThanhToanVNPay
            // 
            this.btnThanhToanVNPay.BackColor = System.Drawing.Color.Green;
            this.btnThanhToanVNPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToanVNPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToanVNPay.ForeColor = System.Drawing.Color.White;
            this.btnThanhToanVNPay.Location = new System.Drawing.Point(400, 330);
            this.btnThanhToanVNPay.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnThanhToanVNPay.Name = "btnThanhToanVNPay";
            this.btnThanhToanVNPay.Size = new System.Drawing.Size(200, 49);
            this.btnThanhToanVNPay.TabIndex = 15;
            this.btnThanhToanVNPay.Text = "Thanh toán VNPay";
            this.btnThanhToanVNPay.UseVisualStyleBackColor = false;
            this.btnThanhToanVNPay.Click += new System.EventHandler(this.btnThanhToanTrucTiep_Click);
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.Gray;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(627, 330);
            this.btnDong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(133, 49);
            this.btnDong.TabIndex = 16;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvGhe);
            this.panel1.Location = new System.Drawing.Point(27, 390);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 246);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(27, 246);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 74);
            this.panel2.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblTieuDe);
            this.panel3.Controls.Add(this.lblChuyenTau);
            this.panel3.Controls.Add(this.cboChuyenTau);
            this.panel3.Controls.Add(this.lblThongTinHanhKhach);
            this.panel3.Controls.Add(this.lblHoTen);
            this.panel3.Controls.Add(this.txtHoTen);
            this.panel3.Controls.Add(this.lblGioiTinh);
            this.panel3.Controls.Add(this.cboGioiTinh);
            this.panel3.Controls.Add(this.lblNgaySinh);
            this.panel3.Controls.Add(this.dtpNgaySinh);
            this.panel3.Controls.Add(this.lblSoGiayTo);
            this.panel3.Controls.Add(this.txtSoGiayTo);
            this.panel3.Location = new System.Drawing.Point(27, 25);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 295);
            this.panel3.TabIndex = 18;
            // 
            // FormDatVeGioHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(853, 700);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnThemVaoGio);
            this.Controls.Add(this.btnXemGioHang);
            this.Controls.Add(this.btnThanhToanVNPay);
            this.Controls.Add(this.btnDong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDatVeGioHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Đặt vé - Giỏ hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgvGhe)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblChuyenTau;
        private System.Windows.Forms.ComboBox cboChuyenTau;
        private System.Windows.Forms.DataGridView dgvGhe;
        private System.Windows.Forms.Label lblThongTinHanhKhach;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.Label lblGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.Label lblSoGiayTo;
        private System.Windows.Forms.TextBox txtSoGiayTo;
        private System.Windows.Forms.Button btnThemVaoGio;
        private System.Windows.Forms.Button btnXemGioHang;
        private System.Windows.Forms.Button btnThanhToanVNPay;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}
