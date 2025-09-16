namespace GUI_TicketSalesSystem
{
    partial class FormDoiVe
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpVeCu = new System.Windows.Forms.GroupBox();
            this.lblVeCuInfo = new System.Windows.Forms.Label();
            this.grpVeMoi = new System.Windows.Forms.GroupBox();
            this.lblThongBao = new System.Windows.Forms.Label();
            this.txtChenhLech = new System.Windows.Forms.TextBox();
            this.lblChenhLech = new System.Windows.Forms.Label();
            this.cboToaMoi = new System.Windows.Forms.ComboBox();
            this.lblToa = new System.Windows.Forms.Label();
            this.txtTau = new System.Windows.Forms.TextBox();
            this.txtTuyen = new System.Windows.Forms.TextBox();
            this.txtGiaVeMoi = new System.Windows.Forms.TextBox();
            this.lblGiaVeMoi = new System.Windows.Forms.Label();
            this.lblGheMoi = new System.Windows.Forms.Label();
            this.lblTuyen = new System.Windows.Forms.Label();
            this.lblTau = new System.Windows.Forms.Label();
            this.lblChuyenMoi = new System.Windows.Forms.Label();
            this.cboGheMoi = new System.Windows.Forms.ComboBox();
            this.cboChuyenMoi = new System.Windows.Forms.ComboBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.grpVeCu.SuspendLayout();
            this.grpVeMoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Blue;
            this.lblTitle.Location = new System.Drawing.Point(220, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(156, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐỔI VÉ TÀU";
            // 
            // grpVeCu
            // 
            this.grpVeCu.Controls.Add(this.lblVeCuInfo);
            this.grpVeCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpVeCu.ForeColor = System.Drawing.Color.DarkBlue;
            this.grpVeCu.Location = new System.Drawing.Point(12, 57);
            this.grpVeCu.Name = "grpVeCu";
            this.grpVeCu.Size = new System.Drawing.Size(540, 120);
            this.grpVeCu.TabIndex = 1;
            this.grpVeCu.TabStop = false;
            this.grpVeCu.Text = "Thông tin vé cũ";
            // 
            // lblVeCuInfo
            // 
            this.lblVeCuInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVeCuInfo.ForeColor = System.Drawing.Color.Black;
            this.lblVeCuInfo.Location = new System.Drawing.Point(15, 25);
            this.lblVeCuInfo.Name = "lblVeCuInfo";
            this.lblVeCuInfo.Size = new System.Drawing.Size(510, 85);
            this.lblVeCuInfo.TabIndex = 0;
            this.lblVeCuInfo.Text = "Thông tin vé sẽ được hiển thị ở đây...";
            // 
            // grpVeMoi
            // 
            this.grpVeMoi.Controls.Add(this.lblThongBao);
            this.grpVeMoi.Controls.Add(this.txtChenhLech);
            this.grpVeMoi.Controls.Add(this.lblChenhLech);
            this.grpVeMoi.Controls.Add(this.cboToaMoi);
            this.grpVeMoi.Controls.Add(this.lblToa);
            this.grpVeMoi.Controls.Add(this.txtTau);
            this.grpVeMoi.Controls.Add(this.txtTuyen);
            this.grpVeMoi.Controls.Add(this.txtGiaVeMoi);
            this.grpVeMoi.Controls.Add(this.lblGiaVeMoi);
            this.grpVeMoi.Controls.Add(this.lblGheMoi);
            this.grpVeMoi.Controls.Add(this.lblTuyen);
            this.grpVeMoi.Controls.Add(this.lblTau);
            this.grpVeMoi.Controls.Add(this.lblChuyenMoi);
            this.grpVeMoi.Controls.Add(this.cboGheMoi);
            this.grpVeMoi.Controls.Add(this.cboChuyenMoi);
            this.grpVeMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpVeMoi.ForeColor = System.Drawing.Color.DarkGreen;
            this.grpVeMoi.Location = new System.Drawing.Point(12, 193);
            this.grpVeMoi.Name = "grpVeMoi";
            this.grpVeMoi.Size = new System.Drawing.Size(540, 320);
            this.grpVeMoi.TabIndex = 2;
            this.grpVeMoi.TabStop = false;
            this.grpVeMoi.Text = "Chọn thông tin vé mới";
            // 
            // lblThongBao
            // 
            this.lblThongBao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongBao.Location = new System.Drawing.Point(20, 285);
            this.lblThongBao.Name = "lblThongBao";
            this.lblThongBao.Size = new System.Drawing.Size(500, 25);
            this.lblThongBao.TabIndex = 14;
            this.lblThongBao.Text = "Thông báo sẽ hiển thị ở đây";
            this.lblThongBao.Visible = false;
            // 
            // txtChenhLech
            // 
            this.txtChenhLech.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChenhLech.Location = new System.Drawing.Point(150, 250);
            this.txtChenhLech.Name = "txtChenhLech";
            this.txtChenhLech.ReadOnly = true;
            this.txtChenhLech.Size = new System.Drawing.Size(200, 23);
            this.txtChenhLech.TabIndex = 13;
            this.txtChenhLech.Visible = false;
            // 
            // lblChenhLech
            // 
            this.lblChenhLech.AutoSize = true;
            this.lblChenhLech.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChenhLech.ForeColor = System.Drawing.Color.Black;
            this.lblChenhLech.Location = new System.Drawing.Point(20, 253);
            this.lblChenhLech.Name = "lblChenhLech";
            this.lblChenhLech.Size = new System.Drawing.Size(83, 17);
            this.lblChenhLech.TabIndex = 12;
            this.lblChenhLech.Text = "Chênh lệch:";
            this.lblChenhLech.Visible = false;
            // 
            // cboToaMoi
            // 
            this.cboToaMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToaMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboToaMoi.FormattingEnabled = true;
            this.cboToaMoi.Location = new System.Drawing.Point(150, 150);
            this.cboToaMoi.Name = "cboToaMoi";
            this.cboToaMoi.Size = new System.Drawing.Size(200, 25);
            this.cboToaMoi.TabIndex = 11;
            this.cboToaMoi.SelectedIndexChanged += new System.EventHandler(this.cboToaMoi_SelectedIndexChanged);
            // 
            // lblToa
            // 
            this.lblToa.AutoSize = true;
            this.lblToa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToa.ForeColor = System.Drawing.Color.Black;
            this.lblToa.Location = new System.Drawing.Point(20, 153);
            this.lblToa.Name = "lblToa";
            this.lblToa.Size = new System.Drawing.Size(37, 17);
            this.lblToa.TabIndex = 10;
            this.lblToa.Text = "Toa:";
            // 
            // txtTau
            // 
            this.txtTau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTau.Location = new System.Drawing.Point(150, 115);
            this.txtTau.Name = "txtTau";
            this.txtTau.ReadOnly = true;
            this.txtTau.Size = new System.Drawing.Size(200, 23);
            this.txtTau.TabIndex = 9;
            // 
            // txtTuyen
            // 
            this.txtTuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTuyen.Location = new System.Drawing.Point(150, 80);
            this.txtTuyen.Name = "txtTuyen";
            this.txtTuyen.ReadOnly = true;
            this.txtTuyen.Size = new System.Drawing.Size(350, 23);
            this.txtTuyen.TabIndex = 8;
            // 
            // txtGiaVeMoi
            // 
            this.txtGiaVeMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaVeMoi.ForeColor = System.Drawing.Color.Blue;
            this.txtGiaVeMoi.Location = new System.Drawing.Point(150, 215);
            this.txtGiaVeMoi.Name = "txtGiaVeMoi";
            this.txtGiaVeMoi.ReadOnly = true;
            this.txtGiaVeMoi.Size = new System.Drawing.Size(200, 23);
            this.txtGiaVeMoi.TabIndex = 7;
            // 
            // lblGiaVeMoi
            // 
            this.lblGiaVeMoi.AutoSize = true;
            this.lblGiaVeMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaVeMoi.ForeColor = System.Drawing.Color.Black;
            this.lblGiaVeMoi.Location = new System.Drawing.Point(20, 218);
            this.lblGiaVeMoi.Name = "lblGiaVeMoi";
            this.lblGiaVeMoi.Size = new System.Drawing.Size(79, 17);
            this.lblGiaVeMoi.TabIndex = 6;
            this.lblGiaVeMoi.Text = "Giá vé mới:";
            // 
            // lblGheMoi
            // 
            this.lblGheMoi.AutoSize = true;
            this.lblGheMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGheMoi.ForeColor = System.Drawing.Color.Black;
            this.lblGheMoi.Location = new System.Drawing.Point(20, 188);
            this.lblGheMoi.Name = "lblGheMoi";
            this.lblGheMoi.Size = new System.Drawing.Size(39, 17);
            this.lblGheMoi.TabIndex = 5;
            this.lblGheMoi.Text = "Ghế:";
            // 
            // lblTuyen
            // 
            this.lblTuyen.AutoSize = true;
            this.lblTuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuyen.ForeColor = System.Drawing.Color.Black;
            this.lblTuyen.Location = new System.Drawing.Point(20, 83);
            this.lblTuyen.Name = "lblTuyen";
            this.lblTuyen.Size = new System.Drawing.Size(52, 17);
            this.lblTuyen.TabIndex = 4;
            this.lblTuyen.Text = "Tuyến:";
            // 
            // lblTau
            // 
            this.lblTau.AutoSize = true;
            this.lblTau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTau.ForeColor = System.Drawing.Color.Black;
            this.lblTau.Location = new System.Drawing.Point(20, 118);
            this.lblTau.Name = "lblTau";
            this.lblTau.Size = new System.Drawing.Size(37, 17);
            this.lblTau.TabIndex = 3;
            this.lblTau.Text = "Tàu:";
            // 
            // lblChuyenMoi
            // 
            this.lblChuyenMoi.AutoSize = true;
            this.lblChuyenMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChuyenMoi.ForeColor = System.Drawing.Color.Black;
            this.lblChuyenMoi.Location = new System.Drawing.Point(20, 48);
            this.lblChuyenMoi.Name = "lblChuyenMoi";
            this.lblChuyenMoi.Size = new System.Drawing.Size(84, 17);
            this.lblChuyenMoi.TabIndex = 2;
            this.lblChuyenMoi.Text = "Chuyến tàu:";
            // 
            // cboGheMoi
            // 
            this.cboGheMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGheMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGheMoi.FormattingEnabled = true;
            this.cboGheMoi.Location = new System.Drawing.Point(150, 185);
            this.cboGheMoi.Name = "cboGheMoi";
            this.cboGheMoi.Size = new System.Drawing.Size(200, 25);
            this.cboGheMoi.TabIndex = 1;
            this.cboGheMoi.SelectedIndexChanged += new System.EventHandler(this.cboGheMoi_SelectedIndexChanged);
            // 
            // cboChuyenMoi
            // 
            this.cboChuyenMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuyenMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboChuyenMoi.FormattingEnabled = true;
            this.cboChuyenMoi.Location = new System.Drawing.Point(150, 45);
            this.cboChuyenMoi.Name = "cboChuyenMoi";
            this.cboChuyenMoi.Size = new System.Drawing.Size(350, 25);
            this.cboChuyenMoi.TabIndex = 0;
            this.cboChuyenMoi.SelectedIndexChanged += new System.EventHandler(this.cboChuyenMoi_SelectedIndexChanged);
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.Green;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(350, 530);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(120, 40);
            this.btnXacNhan.TabIndex = 3;
            this.btnXacNhan.Text = "Xác nhận đổi";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(480, 530);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(80, 40);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy bỏ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FormDoiVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 582);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.grpVeMoi);
            this.Controls.Add(this.grpVeCu);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDoiVe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống bán vé ga Sài Gòn - Đổi vé";
            this.Load += new System.EventHandler(this.FormDoiVe_Load);
            this.grpVeCu.ResumeLayout(false);
            this.grpVeMoi.ResumeLayout(false);
            this.grpVeMoi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpVeCu;
        private System.Windows.Forms.Label lblVeCuInfo;
        private System.Windows.Forms.GroupBox grpVeMoi;
        private System.Windows.Forms.Label lblThongBao;
        private System.Windows.Forms.TextBox txtChenhLech;
        private System.Windows.Forms.Label lblChenhLech;
        private System.Windows.Forms.ComboBox cboToaMoi;
        private System.Windows.Forms.Label lblToa;
        private System.Windows.Forms.TextBox txtTau;
        private System.Windows.Forms.TextBox txtTuyen;
        private System.Windows.Forms.TextBox txtGiaVeMoi;
        private System.Windows.Forms.Label lblGiaVeMoi;
        private System.Windows.Forms.Label lblGheMoi;
        private System.Windows.Forms.Label lblTuyen;
        private System.Windows.Forms.Label lblTau;
        private System.Windows.Forms.Label lblChuyenMoi;
        private System.Windows.Forms.ComboBox cboGheMoi;
        private System.Windows.Forms.ComboBox cboChuyenMoi;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuy;
    }
}