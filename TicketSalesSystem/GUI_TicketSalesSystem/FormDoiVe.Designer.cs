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
            this.label1 = new System.Windows.Forms.Label();
            this.cboChuyenMoi = new System.Windows.Forms.ComboBox();
            this.cboGheMoi = new System.Windows.Forms.ComboBox();
            this.lbChuyenMoi = new System.Windows.Forms.Label();
            this.lbGheMoi = new System.Windows.Forms.Label();
            this.lbGiaVeMoi = new System.Windows.Forms.Label();
            this.txtGiaVeMoi = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.lbTau = new System.Windows.Forms.Label();
            this.lbTuyen = new System.Windows.Forms.Label();
            this.txtTuyen = new System.Windows.Forms.TextBox();
            this.txtTau = new System.Windows.Forms.TextBox();
            this.cboToaMoi = new System.Windows.Forms.ComboBox();
            this.lbToa = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(175, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đổi vé";
            // 
            // cboChuyenMoi
            // 
            this.cboChuyenMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChuyenMoi.FormattingEnabled = true;
            this.cboChuyenMoi.Location = new System.Drawing.Point(149, 57);
            this.cboChuyenMoi.Name = "cboChuyenMoi";
            this.cboChuyenMoi.Size = new System.Drawing.Size(300, 33);
            this.cboChuyenMoi.TabIndex = 1;
            this.cboChuyenMoi.SelectedIndexChanged += new System.EventHandler(this.cboChuyenMoi_SelectedIndexChanged);
            // 
            // cboGheMoi
            // 
            this.cboGheMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGheMoi.FormattingEnabled = true;
            this.cboGheMoi.Location = new System.Drawing.Point(149, 249);
            this.cboGheMoi.Name = "cboGheMoi";
            this.cboGheMoi.Size = new System.Drawing.Size(300, 33);
            this.cboGheMoi.TabIndex = 1;
            this.cboGheMoi.SelectedIndexChanged += new System.EventHandler(this.cboChuyenMoi_SelectedIndexChanged);
            // 
            // lbChuyenMoi
            // 
            this.lbChuyenMoi.AutoSize = true;
            this.lbChuyenMoi.Location = new System.Drawing.Point(12, 60);
            this.lbChuyenMoi.Name = "lbChuyenMoi";
            this.lbChuyenMoi.Size = new System.Drawing.Size(132, 25);
            this.lbChuyenMoi.TabIndex = 2;
            this.lbChuyenMoi.Text = "Chuyến mới:";
            // 
            // lbGheMoi
            // 
            this.lbGheMoi.AutoSize = true;
            this.lbGheMoi.Location = new System.Drawing.Point(12, 252);
            this.lbGheMoi.Name = "lbGheMoi";
            this.lbGheMoi.Size = new System.Drawing.Size(98, 25);
            this.lbGheMoi.TabIndex = 2;
            this.lbGheMoi.Text = "Ghế mới:";
            // 
            // lbGiaVeMoi
            // 
            this.lbGiaVeMoi.AutoSize = true;
            this.lbGiaVeMoi.Location = new System.Drawing.Point(12, 300);
            this.lbGiaVeMoi.Name = "lbGiaVeMoi";
            this.lbGiaVeMoi.Size = new System.Drawing.Size(120, 25);
            this.lbGiaVeMoi.TabIndex = 2;
            this.lbGiaVeMoi.Text = "Giá vé mới:";
            // 
            // txtGiaVeMoi
            // 
            this.txtGiaVeMoi.Location = new System.Drawing.Point(149, 300);
            this.txtGiaVeMoi.Name = "txtGiaVeMoi";
            this.txtGiaVeMoi.Size = new System.Drawing.Size(300, 31);
            this.txtGiaVeMoi.TabIndex = 3;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(321, 350);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(128, 37);
            this.btnXacNhan.TabIndex = 4;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // lbTau
            // 
            this.lbTau.AutoSize = true;
            this.lbTau.Location = new System.Drawing.Point(12, 152);
            this.lbTau.Name = "lbTau";
            this.lbTau.Size = new System.Drawing.Size(95, 25);
            this.lbTau.TabIndex = 2;
            this.lbTau.Text = "Tàu mới:";
            // 
            // lbTuyen
            // 
            this.lbTuyen.AutoSize = true;
            this.lbTuyen.Location = new System.Drawing.Point(12, 106);
            this.lbTuyen.Name = "lbTuyen";
            this.lbTuyen.Size = new System.Drawing.Size(118, 25);
            this.lbTuyen.TabIndex = 2;
            this.lbTuyen.Text = "Tuyến mới:";
            // 
            // txtTuyen
            // 
            this.txtTuyen.Location = new System.Drawing.Point(149, 106);
            this.txtTuyen.Name = "txtTuyen";
            this.txtTuyen.Size = new System.Drawing.Size(300, 31);
            this.txtTuyen.TabIndex = 3;
            // 
            // txtTau
            // 
            this.txtTau.Location = new System.Drawing.Point(149, 152);
            this.txtTau.Name = "txtTau";
            this.txtTau.Size = new System.Drawing.Size(300, 31);
            this.txtTau.TabIndex = 3;
            // 
            // cboToaMoi
            // 
            this.cboToaMoi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToaMoi.FormattingEnabled = true;
            this.cboToaMoi.Location = new System.Drawing.Point(149, 200);
            this.cboToaMoi.Name = "cboToaMoi";
            this.cboToaMoi.Size = new System.Drawing.Size(300, 33);
            this.cboToaMoi.TabIndex = 1;
            this.cboToaMoi.SelectedIndexChanged += new System.EventHandler(this.cboToaMoi_SelectedIndexChanged);
            // 
            // lbToa
            // 
            this.lbToa.AutoSize = true;
            this.lbToa.Location = new System.Drawing.Point(12, 203);
            this.lbToa.Name = "lbToa";
            this.lbToa.Size = new System.Drawing.Size(95, 25);
            this.lbToa.TabIndex = 2;
            this.lbToa.Text = "Toa mới:";
            // 
            // FormDoiVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 399);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtTau);
            this.Controls.Add(this.txtTuyen);
            this.Controls.Add(this.txtGiaVeMoi);
            this.Controls.Add(this.lbGiaVeMoi);
            this.Controls.Add(this.lbToa);
            this.Controls.Add(this.lbGheMoi);
            this.Controls.Add(this.lbTuyen);
            this.Controls.Add(this.lbTau);
            this.Controls.Add(this.lbChuyenMoi);
            this.Controls.Add(this.cboToaMoi);
            this.Controls.Add(this.cboGheMoi);
            this.Controls.Add(this.cboChuyenMoi);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "FormDoiVe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống bán vé ga Sài Gòn - Đổi vé";
            this.Load += new System.EventHandler(this.FormDoiVe_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboChuyenMoi;
        private System.Windows.Forms.ComboBox cboGheMoi;
        private System.Windows.Forms.Label lbChuyenMoi;
        private System.Windows.Forms.Label lbGheMoi;
        private System.Windows.Forms.Label lbGiaVeMoi;
        private System.Windows.Forms.TextBox txtGiaVeMoi;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Label lbTau;
        private System.Windows.Forms.Label lbTuyen;
        private System.Windows.Forms.TextBox txtTuyen;
        private System.Windows.Forms.TextBox txtTau;
        private System.Windows.Forms.ComboBox cboToaMoi;
        private System.Windows.Forms.Label lbToa;
    }
}