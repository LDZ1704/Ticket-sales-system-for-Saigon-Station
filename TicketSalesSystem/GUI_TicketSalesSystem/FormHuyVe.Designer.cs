namespace GUI_TicketSalesSystem
{
    partial class FormHuyVe
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
            this.grpThongTinVe = new System.Windows.Forms.GroupBox();
            this.lblGiaVe = new System.Windows.Forms.Label();
            this.lblNgayKhoiHanh = new System.Windows.Forms.Label();
            this.lblToaGhe = new System.Windows.Forms.Label();
            this.lblTuyen = new System.Windows.Forms.Label();
            this.lblHanhKhach = new System.Windows.Forms.Label();
            this.lblMaVe = new System.Windows.Forms.Label();
            this.grpChinhSachHuy = new System.Windows.Forms.GroupBox();
            this.lblLuuY = new System.Windows.Forms.Label();
            this.lblTienHoan = new System.Windows.Forms.Label();
            this.lblChinhSach = new System.Windows.Forms.Label();
            this.lblThoiGianConLai = new System.Windows.Forms.Label();
            this.btnXacNhanHuy = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.grpThongTinVe.SuspendLayout();
            this.grpChinhSachHuy.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Red;
            this.lblTitle.Location = new System.Drawing.Point(157, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(164, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "HỦY VÉ TÀU";
            // 
            // grpThongTinVe
            // 
            this.grpThongTinVe.Controls.Add(this.lblGiaVe);
            this.grpThongTinVe.Controls.Add(this.lblNgayKhoiHanh);
            this.grpThongTinVe.Controls.Add(this.lblToaGhe);
            this.grpThongTinVe.Controls.Add(this.lblTuyen);
            this.grpThongTinVe.Controls.Add(this.lblHanhKhach);
            this.grpThongTinVe.Controls.Add(this.lblMaVe);
            this.grpThongTinVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpThongTinVe.Location = new System.Drawing.Point(12, 57);
            this.grpThongTinVe.Name = "grpThongTinVe";
            this.grpThongTinVe.Size = new System.Drawing.Size(445, 200);
            this.grpThongTinVe.TabIndex = 1;
            this.grpThongTinVe.TabStop = false;
            this.grpThongTinVe.Text = "Thông tin vé";
            // 
            // lblGiaVe
            // 
            this.lblGiaVe.AutoSize = true;
            this.lblGiaVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaVe.ForeColor = System.Drawing.Color.Blue;
            this.lblGiaVe.Location = new System.Drawing.Point(15, 155);
            this.lblGiaVe.Name = "lblGiaVe";
            this.lblGiaVe.Size = new System.Drawing.Size(65, 17);
            this.lblGiaVe.TabIndex = 5;
            this.lblGiaVe.Text = "Giá vé: ";
            // 
            // lblNgayKhoiHanh
            // 
            this.lblNgayKhoiHanh.AutoSize = true;
            this.lblNgayKhoiHanh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgayKhoiHanh.Location = new System.Drawing.Point(15, 130);
            this.lblNgayKhoiHanh.Name = "lblNgayKhoiHanh";
            this.lblNgayKhoiHanh.Size = new System.Drawing.Size(115, 17);
            this.lblNgayKhoiHanh.TabIndex = 4;
            this.lblNgayKhoiHanh.Text = "Ngày khởi hành: ";
            // 
            // lblToaGhe
            // 
            this.lblToaGhe.AutoSize = true;
            this.lblToaGhe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToaGhe.Location = new System.Drawing.Point(15, 105);
            this.lblToaGhe.Name = "lblToaGhe";
            this.lblToaGhe.Size = new System.Drawing.Size(81, 17);
            this.lblToaGhe.TabIndex = 3;
            this.lblToaGhe.Text = "Toa - Ghế: ";
            // 
            // lblTuyen
            // 
            this.lblTuyen.AutoSize = true;
            this.lblTuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTuyen.Location = new System.Drawing.Point(15, 80);
            this.lblTuyen.Name = "lblTuyen";
            this.lblTuyen.Size = new System.Drawing.Size(56, 17);
            this.lblTuyen.TabIndex = 2;
            this.lblTuyen.Text = "Tuyến: ";
            // 
            // lblHanhKhach
            // 
            this.lblHanhKhach.AutoSize = true;
            this.lblHanhKhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHanhKhach.Location = new System.Drawing.Point(15, 55);
            this.lblHanhKhach.Name = "lblHanhKhach";
            this.lblHanhKhach.Size = new System.Drawing.Size(92, 17);
            this.lblHanhKhach.TabIndex = 1;
            this.lblHanhKhach.Text = "Hành khách: ";
            // 
            // lblMaVe
            // 
            this.lblMaVe.AutoSize = true;
            this.lblMaVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaVe.Location = new System.Drawing.Point(15, 30);
            this.lblMaVe.Name = "lblMaVe";
            this.lblMaVe.Size = new System.Drawing.Size(54, 17);
            this.lblMaVe.TabIndex = 0;
            this.lblMaVe.Text = "Mã vé: ";
            // 
            // grpChinhSachHuy
            // 
            this.grpChinhSachHuy.Controls.Add(this.lblLuuY);
            this.grpChinhSachHuy.Controls.Add(this.lblTienHoan);
            this.grpChinhSachHuy.Controls.Add(this.lblChinhSach);
            this.grpChinhSachHuy.Controls.Add(this.lblThoiGianConLai);
            this.grpChinhSachHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChinhSachHuy.Location = new System.Drawing.Point(12, 273);
            this.grpChinhSachHuy.Name = "grpChinhSachHuy";
            this.grpChinhSachHuy.Size = new System.Drawing.Size(445, 160);
            this.grpChinhSachHuy.TabIndex = 2;
            this.grpChinhSachHuy.TabStop = false;
            this.grpChinhSachHuy.Text = "Chính sách hủy vé";
            // 
            // lblLuuY
            // 
            this.lblLuuY.AutoSize = true;
            this.lblLuuY.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLuuY.ForeColor = System.Drawing.Color.Red;
            this.lblLuuY.Location = new System.Drawing.Point(15, 130);
            this.lblLuuY.Name = "lblLuuY";
            this.lblLuuY.Size = new System.Drawing.Size(307, 15);
            this.lblLuuY.TabIndex = 3;
            this.lblLuuY.Text = "* Tiền hoàn sẽ được chuyển về tài khoản trong 3-5 ngày";
            // 
            // lblTienHoan
            // 
            this.lblTienHoan.AutoSize = true;
            this.lblTienHoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienHoan.ForeColor = System.Drawing.Color.Green;
            this.lblTienHoan.Location = new System.Drawing.Point(15, 105);
            this.lblTienHoan.Name = "lblTienHoan";
            this.lblTienHoan.Size = new System.Drawing.Size(113, 18);
            this.lblTienHoan.TabIndex = 2;
            this.lblTienHoan.Text = "Số tiền hoàn: ";
            // 
            // lblChinhSach
            // 
            this.lblChinhSach.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChinhSach.ForeColor = System.Drawing.Color.Blue;
            this.lblChinhSach.Location = new System.Drawing.Point(15, 55);
            this.lblChinhSach.Name = "lblChinhSach";
            this.lblChinhSach.Size = new System.Drawing.Size(415, 40);
            this.lblChinhSach.TabIndex = 1;
            this.lblChinhSach.Text = "Chính sách hoàn tiền sẽ được hiển thị ở đây...";
            // 
            // lblThoiGianConLai
            // 
            this.lblThoiGianConLai.AutoSize = true;
            this.lblThoiGianConLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThoiGianConLai.Location = new System.Drawing.Point(15, 30);
            this.lblThoiGianConLai.Name = "lblThoiGianConLai";
            this.lblThoiGianConLai.Size = new System.Drawing.Size(120, 17);
            this.lblThoiGianConLai.TabIndex = 0;
            this.lblThoiGianConLai.Text = "Thời gian còn lại: ";
            // 
            // btnXacNhanHuy
            // 
            this.btnXacNhanHuy.BackColor = System.Drawing.Color.Red;
            this.btnXacNhanHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhanHuy.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanHuy.Location = new System.Drawing.Point(240, 450);
            this.btnXacNhanHuy.Name = "btnXacNhanHuy";
            this.btnXacNhanHuy.Size = new System.Drawing.Size(130, 40);
            this.btnXacNhanHuy.TabIndex = 3;
            this.btnXacNhanHuy.Text = "Xác nhận hủy";
            this.btnXacNhanHuy.UseVisualStyleBackColor = false;
            this.btnXacNhanHuy.Click += new System.EventHandler(this.btnXacNhanHuy_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(380, 450);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(80, 40);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy bỏ";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FormHuyVe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 502);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnXacNhanHuy);
            this.Controls.Add(this.grpChinhSachHuy);
            this.Controls.Add(this.grpThongTinVe);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormHuyVe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống bán vé ga Sài Gòn - Hủy vé";
            this.Load += new System.EventHandler(this.FormHuyVe_Load);
            this.grpThongTinVe.ResumeLayout(false);
            this.grpThongTinVe.PerformLayout();
            this.grpChinhSachHuy.ResumeLayout(false);
            this.grpChinhSachHuy.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grpThongTinVe;
        private System.Windows.Forms.Label lblGiaVe;
        private System.Windows.Forms.Label lblNgayKhoiHanh;
        private System.Windows.Forms.Label lblToaGhe;
        private System.Windows.Forms.Label lblTuyen;
        private System.Windows.Forms.Label lblHanhKhach;
        private System.Windows.Forms.Label lblMaVe;
        private System.Windows.Forms.GroupBox grpChinhSachHuy;
        private System.Windows.Forms.Label lblLuuY;
        private System.Windows.Forms.Label lblTienHoan;
        private System.Windows.Forms.Label lblChinhSach;
        private System.Windows.Forms.Label lblThoiGianConLai;
        private System.Windows.Forms.Button btnXacNhanHuy;
        private System.Windows.Forms.Button btnHuy;
    }
}