using System.Drawing;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem
{
    partial class FormCapQuyen
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
            this.lblNguoiDung = new System.Windows.Forms.Label();
            this.grpQuyen = new System.Windows.Forms.GroupBox();
            this.rbKhachHang = new System.Windows.Forms.RadioButton();
            this.rbNhanVien = new System.Windows.Forms.RadioButton();
            this.rbQuanTriVien = new System.Windows.Forms.RadioButton();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.grpQuyen.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.Blue;
            this.lblTieuDe.Location = new System.Drawing.Point(99, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(280, 25);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "CẤP QUYỀN NGƯỜI DÙNG";
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblNguoiDung.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblNguoiDung.Location = new System.Drawing.Point(30, 60);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(422, 25);
            this.lblNguoiDung.TabIndex = 1;
            // 
            // grpQuyen
            // 
            this.grpQuyen.Controls.Add(this.rbKhachHang);
            this.grpQuyen.Controls.Add(this.rbNhanVien);
            this.grpQuyen.Controls.Add(this.rbQuanTriVien);
            this.grpQuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.grpQuyen.Location = new System.Drawing.Point(30, 100);
            this.grpQuyen.Name = "grpQuyen";
            this.grpQuyen.Size = new System.Drawing.Size(422, 173);
            this.grpQuyen.TabIndex = 2;
            this.grpQuyen.TabStop = false;
            this.grpQuyen.Text = "Chọn quyền mới";
            // 
            // rbKhachHang
            // 
            this.rbKhachHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.rbKhachHang.Location = new System.Drawing.Point(20, 25);
            this.rbKhachHang.Name = "rbKhachHang";
            this.rbKhachHang.Size = new System.Drawing.Size(373, 45);
            this.rbKhachHang.TabIndex = 0;
            this.rbKhachHang.Text = "Khách hàng - Chỉ đặt vé";
            // 
            // rbNhanVien
            // 
            this.rbNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.rbNhanVien.Location = new System.Drawing.Point(20, 76);
            this.rbNhanVien.Name = "rbNhanVien";
            this.rbNhanVien.Size = new System.Drawing.Size(373, 43);
            this.rbNhanVien.TabIndex = 1;
            this.rbNhanVien.Text = "Nhân viên - Hỗ trợ khách hàng";
            // 
            // rbQuanTriVien
            // 
            this.rbQuanTriVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.rbQuanTriVien.ForeColor = System.Drawing.Color.Red;
            this.rbQuanTriVien.Location = new System.Drawing.Point(20, 125);
            this.rbQuanTriVien.Name = "rbQuanTriVien";
            this.rbQuanTriVien.Size = new System.Drawing.Size(373, 42);
            this.rbQuanTriVien.TabIndex = 2;
            this.rbQuanTriVien.Text = "Quản trị viên - Toàn quyền";
            // 
            // lblMoTa
            // 
            this.lblMoTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMoTa.ForeColor = System.Drawing.Color.Red;
            this.lblMoTa.Location = new System.Drawing.Point(27, 286);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(320, 20);
            this.lblMoTa.TabIndex = 3;
            this.lblMoTa.Text = "Lưu ý: Thay đổi quyền sẽ có hiệu lực ngay lập tức!";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.Green;
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(180, 321);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(160, 47);
            this.btnXacNhan.TabIndex = 4;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(362, 321);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(90, 47);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // FormCapQuyen
            // 
            this.ClientSize = new System.Drawing.Size(474, 380);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblNguoiDung);
            this.Controls.Add(this.grpQuyen);
            this.Controls.Add(this.lblMoTa);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.btnHuy);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCapQuyen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cấp quyền người dùng";
            this.Load += new System.EventHandler(this.FormCapQuyen_Load);
            this.grpQuyen.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private Label lblTieuDe;
        private Label lblNguoiDung;
        private GroupBox grpQuyen;
        private RadioButton rbKhachHang;
        private RadioButton rbNhanVien;
        private RadioButton rbQuanTriVien;
        private Label lblMoTa;
        private Button btnXacNhan;
        private Button btnHuy;

        #endregion
    }
}