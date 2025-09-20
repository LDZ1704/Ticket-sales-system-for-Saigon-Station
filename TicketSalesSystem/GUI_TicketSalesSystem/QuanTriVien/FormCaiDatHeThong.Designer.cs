namespace GUI_TicketSalesSystem
{
    partial class FormCaiDatHeThong
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
            this.cboNhomCauHinh = new System.Windows.Forms.ComboBox();
            this.dgvCauHinh = new System.Windows.Forms.DataGridView();
            this.txtTenCauHinh = new System.Windows.Forms.TextBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.txtDonVi = new System.Windows.Forms.TextBox();
            this.btnCapNhat = new System.Windows.Forms.Button();
            this.btnKhoiPhucMacDinh = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.lblTongCauHinh = new System.Windows.Forms.Label();
            this.grpChiTiet = new System.Windows.Forms.GroupBox();
            this.lblTenCauHinh = new System.Windows.Forms.Label();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblGiaTri = new System.Windows.Forms.Label();
            this.lblDonVi = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblNhom = new System.Windows.Forms.Label();
            this.dgvTenCauHinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMoTa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGiaTri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDonVi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNhom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNgayCapNhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNguoiCapNhat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHinh)).BeginInit();
            this.grpChiTiet.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboNhomCauHinh
            // 
            this.cboNhomCauHinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhomCauHinh.Location = new System.Drawing.Point(196, 70);
            this.cboNhomCauHinh.Margin = new System.Windows.Forms.Padding(4);
            this.cboNhomCauHinh.Name = "cboNhomCauHinh";
            this.cboNhomCauHinh.Size = new System.Drawing.Size(224, 33);
            this.cboNhomCauHinh.TabIndex = 2;
            this.cboNhomCauHinh.SelectedIndexChanged += new System.EventHandler(this.CboNhomCauHinh_SelectedIndexChanged);
            // 
            // dgvCauHinh
            // 
            this.dgvCauHinh.AllowUserToAddRows = false;
            this.dgvCauHinh.AllowUserToDeleteRows = false;
            this.dgvCauHinh.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvCauHinh.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvCauHinh.ColumnHeadersHeight = 40;
            this.dgvCauHinh.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvTenCauHinh,
            this.dgvMoTa,
            this.dgvGiaTri,
            this.dgvDonVi,
            this.dgvNhom,
            this.dgvNgayCapNhat,
            this.dgvNguoiCapNhat});
            this.dgvCauHinh.Location = new System.Drawing.Point(13, 112);
            this.dgvCauHinh.Margin = new System.Windows.Forms.Padding(4);
            this.dgvCauHinh.MultiSelect = false;
            this.dgvCauHinh.Name = "dgvCauHinh";
            this.dgvCauHinh.ReadOnly = true;
            this.dgvCauHinh.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCauHinh.Size = new System.Drawing.Size(1289, 326);
            this.dgvCauHinh.TabIndex = 4;
            this.dgvCauHinh.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCauHinh_CellClick);
            this.dgvCauHinh.SelectionChanged += new System.EventHandler(this.DgvCauHinh_SelectionChanged);
            // 
            // txtTenCauHinh
            // 
            this.txtTenCauHinh.BackColor = System.Drawing.Color.LightGray;
            this.txtTenCauHinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenCauHinh.Location = new System.Drawing.Point(217, 38);
            this.txtTenCauHinh.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenCauHinh.Name = "txtTenCauHinh";
            this.txtTenCauHinh.ReadOnly = true;
            this.txtTenCauHinh.Size = new System.Drawing.Size(473, 31);
            this.txtTenCauHinh.TabIndex = 1;
            // 
            // txtMoTa
            // 
            this.txtMoTa.BackColor = System.Drawing.Color.LightGray;
            this.txtMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoTa.Location = new System.Drawing.Point(791, 35);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(4);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.ReadOnly = true;
            this.txtMoTa.Size = new System.Drawing.Size(448, 31);
            this.txtMoTa.TabIndex = 3;
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaTri.Location = new System.Drawing.Point(217, 104);
            this.txtGiaTri.Margin = new System.Windows.Forms.Padding(4);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(473, 31);
            this.txtGiaTri.TabIndex = 5;
            // 
            // txtDonVi
            // 
            this.txtDonVi.BackColor = System.Drawing.Color.LightGray;
            this.txtDonVi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDonVi.Location = new System.Drawing.Point(794, 104);
            this.txtDonVi.Margin = new System.Windows.Forms.Padding(4);
            this.txtDonVi.Name = "txtDonVi";
            this.txtDonVi.ReadOnly = true;
            this.txtDonVi.Size = new System.Drawing.Size(67, 31);
            this.txtDonVi.TabIndex = 7;
            // 
            // btnCapNhat
            // 
            this.btnCapNhat.BackColor = System.Drawing.Color.Green;
            this.btnCapNhat.Enabled = false;
            this.btnCapNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhat.ForeColor = System.Drawing.Color.White;
            this.btnCapNhat.Location = new System.Drawing.Point(726, 165);
            this.btnCapNhat.Margin = new System.Windows.Forms.Padding(4);
            this.btnCapNhat.Name = "btnCapNhat";
            this.btnCapNhat.Size = new System.Drawing.Size(186, 46);
            this.btnCapNhat.TabIndex = 8;
            this.btnCapNhat.Text = "Cập nhật";
            this.btnCapNhat.UseVisualStyleBackColor = false;
            this.btnCapNhat.Click += new System.EventHandler(this.BtnCapNhat_Click);
            // 
            // btnKhoiPhucMacDinh
            // 
            this.btnKhoiPhucMacDinh.BackColor = System.Drawing.Color.Orange;
            this.btnKhoiPhucMacDinh.Enabled = false;
            this.btnKhoiPhucMacDinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKhoiPhucMacDinh.ForeColor = System.Drawing.Color.White;
            this.btnKhoiPhucMacDinh.Location = new System.Drawing.Point(920, 165);
            this.btnKhoiPhucMacDinh.Margin = new System.Windows.Forms.Padding(4);
            this.btnKhoiPhucMacDinh.Name = "btnKhoiPhucMacDinh";
            this.btnKhoiPhucMacDinh.Size = new System.Drawing.Size(186, 46);
            this.btnKhoiPhucMacDinh.TabIndex = 9;
            this.btnKhoiPhucMacDinh.Text = "Mặc định";
            this.btnKhoiPhucMacDinh.UseVisualStyleBackColor = false;
            this.btnKhoiPhucMacDinh.Click += new System.EventHandler(this.BtnKhoiPhucMacDinh_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Blue;
            this.btnLamMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Location = new System.Drawing.Point(1114, 165);
            this.btnLamMoi.Margin = new System.Windows.Forms.Padding(4);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(172, 46);
            this.btnLamMoi.TabIndex = 10;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            this.btnLamMoi.Click += new System.EventHandler(this.BtnLamMoi_Click);
            // 
            // lblTongCauHinh
            // 
            this.lblTongCauHinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongCauHinh.ForeColor = System.Drawing.Color.Blue;
            this.lblTongCauHinh.Location = new System.Drawing.Point(448, 70);
            this.lblTongCauHinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTongCauHinh.Name = "lblTongCauHinh";
            this.lblTongCauHinh.Size = new System.Drawing.Size(300, 38);
            this.lblTongCauHinh.TabIndex = 3;
            this.lblTongCauHinh.Text = "Tổng số cấu hình: 0";
            // 
            // grpChiTiet
            // 
            this.grpChiTiet.Controls.Add(this.lblTenCauHinh);
            this.grpChiTiet.Controls.Add(this.txtTenCauHinh);
            this.grpChiTiet.Controls.Add(this.lblMoTa);
            this.grpChiTiet.Controls.Add(this.txtMoTa);
            this.grpChiTiet.Controls.Add(this.lblGiaTri);
            this.grpChiTiet.Controls.Add(this.txtGiaTri);
            this.grpChiTiet.Controls.Add(this.lblDonVi);
            this.grpChiTiet.Controls.Add(this.txtDonVi);
            this.grpChiTiet.Controls.Add(this.btnCapNhat);
            this.grpChiTiet.Controls.Add(this.btnKhoiPhucMacDinh);
            this.grpChiTiet.Controls.Add(this.btnLamMoi);
            this.grpChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChiTiet.Location = new System.Drawing.Point(13, 446);
            this.grpChiTiet.Margin = new System.Windows.Forms.Padding(4);
            this.grpChiTiet.Name = "grpChiTiet";
            this.grpChiTiet.Padding = new System.Windows.Forms.Padding(4);
            this.grpChiTiet.Size = new System.Drawing.Size(1289, 235);
            this.grpChiTiet.TabIndex = 5;
            this.grpChiTiet.TabStop = false;
            this.grpChiTiet.Text = "Chi tiết cấu hình";
            // 
            // lblTenCauHinh
            // 
            this.lblTenCauHinh.Location = new System.Drawing.Point(30, 46);
            this.lblTenCauHinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenCauHinh.Name = "lblTenCauHinh";
            this.lblTenCauHinh.Size = new System.Drawing.Size(160, 38);
            this.lblTenCauHinh.TabIndex = 0;
            this.lblTenCauHinh.Text = "Tên cấu hình:";
            // 
            // lblMoTa
            // 
            this.lblMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.Location = new System.Drawing.Point(698, 38);
            this.lblMoTa.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(85, 38);
            this.lblMoTa.TabIndex = 2;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // lblGiaTri
            // 
            this.lblGiaTri.Location = new System.Drawing.Point(30, 110);
            this.lblGiaTri.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGiaTri.Name = "lblGiaTri";
            this.lblGiaTri.Size = new System.Drawing.Size(150, 38);
            this.lblGiaTri.TabIndex = 4;
            this.lblGiaTri.Text = "Giá trị:";
            // 
            // lblDonVi
            // 
            this.lblDonVi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDonVi.Location = new System.Drawing.Point(698, 104);
            this.lblDonVi.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDonVi.Name = "lblDonVi";
            this.lblDonVi.Size = new System.Drawing.Size(88, 38);
            this.lblDonVi.TabIndex = 6;
            this.lblDonVi.Text = "Đơn vị:";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(12, 25);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(736, 45);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CÀI ĐẶT HỆ THỐNG";
            // 
            // lblNhom
            // 
            this.lblNhom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNhom.Location = new System.Drawing.Point(21, 70);
            this.lblNhom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNhom.Name = "lblNhom";
            this.lblNhom.Size = new System.Drawing.Size(167, 38);
            this.lblNhom.TabIndex = 1;
            this.lblNhom.Text = "Nhóm cấu hình:";
            // 
            // dgvTenCauHinh
            // 
            this.dgvTenCauHinh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTenCauHinh.HeaderText = "Tên cấu hình";
            this.dgvTenCauHinh.Name = "dgvTenCauHinh";
            this.dgvTenCauHinh.ReadOnly = true;
            this.dgvTenCauHinh.Width = 162;
            // 
            // dgvMoTa
            // 
            this.dgvMoTa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvMoTa.HeaderText = "Mô tả";
            this.dgvMoTa.Name = "dgvMoTa";
            this.dgvMoTa.ReadOnly = true;
            this.dgvMoTa.Width = 91;
            // 
            // dgvGiaTri
            // 
            this.dgvGiaTri.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvGiaTri.HeaderText = "Giá trị";
            this.dgvGiaTri.Name = "dgvGiaTri";
            this.dgvGiaTri.ReadOnly = true;
            this.dgvGiaTri.Width = 94;
            // 
            // dgvDonVi
            // 
            this.dgvDonVi.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvDonVi.HeaderText = "Đơn vị";
            this.dgvDonVi.Name = "dgvDonVi";
            this.dgvDonVi.ReadOnly = true;
            this.dgvDonVi.Width = 98;
            // 
            // dgvNhom
            // 
            this.dgvNhom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvNhom.HeaderText = "Nhóm";
            this.dgvNhom.Name = "dgvNhom";
            this.dgvNhom.ReadOnly = true;
            this.dgvNhom.Width = 93;
            // 
            // dgvNgayCapNhat
            // 
            this.dgvNgayCapNhat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvNgayCapNhat.HeaderText = "Ngày cập nhật";
            this.dgvNgayCapNhat.Name = "dgvNgayCapNhat";
            this.dgvNgayCapNhat.ReadOnly = true;
            this.dgvNgayCapNhat.Width = 176;
            // 
            // dgvNguoiCapNhat
            // 
            this.dgvNguoiCapNhat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvNguoiCapNhat.HeaderText = "Người cập nhật";
            this.dgvNguoiCapNhat.Name = "dgvNguoiCapNhat";
            this.dgvNguoiCapNhat.ReadOnly = true;
            this.dgvNguoiCapNhat.Width = 182;
            // 
            // FormCaiDatHeThong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1311, 691);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblNhom);
            this.Controls.Add(this.cboNhomCauHinh);
            this.Controls.Add(this.lblTongCauHinh);
            this.Controls.Add(this.dgvCauHinh);
            this.Controls.Add(this.grpChiTiet);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormCaiDatHeThong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cài đặt Hệ thống";
            this.Load += new System.EventHandler(this.FormCaiDatHeThong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCauHinh)).EndInit();
            this.grpChiTiet.ResumeLayout(false);
            this.grpChiTiet.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.ComboBox cboNhomCauHinh;
        private System.Windows.Forms.DataGridView dgvCauHinh;
        private System.Windows.Forms.TextBox txtTenCauHinh;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.TextBox txtDonVi;
        private System.Windows.Forms.Button btnCapNhat;
        private System.Windows.Forms.Button btnKhoiPhucMacDinh;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.Label lblTongCauHinh;
        private System.Windows.Forms.GroupBox grpChiTiet;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Label lblTenCauHinh;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Label lblGiaTri;
        private System.Windows.Forms.Label lblDonVi;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNhom;

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn dgvTenCauHinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvMoTa;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvGiaTri;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDonVi;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNhom;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNgayCapNhat;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNguoiCapNhat;
    }
}