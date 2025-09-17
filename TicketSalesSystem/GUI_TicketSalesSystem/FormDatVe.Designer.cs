using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem
{
    partial class FormDatVe
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
            this.lblThongTinChuyen = new System.Windows.Forms.Label();
            this.cboToa = new System.Windows.Forms.ComboBox();
            this.dgvVe = new System.Windows.Forms.DataGridView();
            this.dgvMaChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvViTriGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSoGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLoaiGhe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSoGiayTo = new System.Windows.Forms.TextBox();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtGiaVe = new System.Windows.Forms.TextBox();
            this.btnDatVe = new System.Windows.Forms.Button();
            this.lblToa = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblSoGiayTo = new System.Windows.Forms.Label();
            this.lblGioiTinh = new System.Windows.Forms.Label();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.lblGiaVe = new System.Windows.Forms.Label();
            this.lbSoGheTrong = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).BeginInit();
            this.SuspendLayout();
            // 
            // lblThongTinChuyen
            // 
            this.lblThongTinChuyen.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThongTinChuyen.Location = new System.Drawing.Point(492, 21);
            this.lblThongTinChuyen.Name = "lblThongTinChuyen";
            this.lblThongTinChuyen.Size = new System.Drawing.Size(320, 40);
            this.lblThongTinChuyen.TabIndex = 0;
            this.lblThongTinChuyen.Text = "Thông tin chuyến tàu";
            // 
            // cboToa
            // 
            this.cboToa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboToa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboToa.Location = new System.Drawing.Point(133, 100);
            this.cboToa.Name = "cboToa";
            this.cboToa.Size = new System.Drawing.Size(400, 32);
            this.cboToa.TabIndex = 2;
            this.cboToa.SelectedIndexChanged += new System.EventHandler(this.cboToa_SelectedIndexChanged);
            // 
            // dgvVe
            // 
            this.dgvVe.AllowUserToAddRows = false;
            this.dgvVe.AllowUserToDeleteRows = false;
            this.dgvVe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvVe.ColumnHeadersHeight = 35;
            this.dgvVe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvMaChuyen,
            this.dgvViTriGhe,
            this.dgvSoGhe,
            this.dgvTrangThai,
            this.dgvLoaiGhe});
            this.dgvVe.Location = new System.Drawing.Point(539, 100);
            this.dgvVe.Name = "dgvVe";
            this.dgvVe.ReadOnly = true;
            this.dgvVe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVe.Size = new System.Drawing.Size(736, 300);
            this.dgvVe.TabIndex = 3;
            this.dgvVe.SelectionChanged += new System.EventHandler(this.dgvVe_SelectionChanged);
            // 
            // dgvMaChuyen
            // 
            this.dgvMaChuyen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvMaChuyen.HeaderText = "Mã chuyến";
            this.dgvMaChuyen.Name = "dgvMaChuyen";
            this.dgvMaChuyen.ReadOnly = true;
            this.dgvMaChuyen.Width = 129;
            // 
            // dgvViTriGhe
            // 
            this.dgvViTriGhe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvViTriGhe.HeaderText = "Vị trí ghế";
            this.dgvViTriGhe.Name = "dgvViTriGhe";
            this.dgvViTriGhe.ReadOnly = true;
            this.dgvViTriGhe.Width = 109;
            // 
            // dgvSoGhe
            // 
            this.dgvSoGhe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvSoGhe.HeaderText = "Số ghế";
            this.dgvSoGhe.Name = "dgvSoGhe";
            this.dgvSoGhe.ReadOnly = true;
            this.dgvSoGhe.Width = 96;
            // 
            // dgvTrangThai
            // 
            this.dgvTrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTrangThai.HeaderText = "Trạng thái";
            this.dgvTrangThai.Name = "dgvTrangThai";
            this.dgvTrangThai.ReadOnly = true;
            this.dgvTrangThai.Width = 119;
            // 
            // dgvLoaiGhe
            // 
            this.dgvLoaiGhe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvLoaiGhe.HeaderText = "Loại ghế";
            this.dgvLoaiGhe.Name = "dgvLoaiGhe";
            this.dgvLoaiGhe.ReadOnly = true;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHoTen.Location = new System.Drawing.Point(133, 147);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(400, 29);
            this.txtHoTen.TabIndex = 5;
            // 
            // txtSoGiayTo
            // 
            this.txtSoGiayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoGiayTo.Location = new System.Drawing.Point(133, 187);
            this.txtSoGiayTo.Name = "txtSoGiayTo";
            this.txtSoGiayTo.Size = new System.Drawing.Size(400, 29);
            this.txtSoGiayTo.TabIndex = 7;
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cboGioiTinh.Location = new System.Drawing.Point(133, 227);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(400, 32);
            this.cboGioiTinh.TabIndex = 9;
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgaySinh.Location = new System.Drawing.Point(133, 267);
            this.dtpNgaySinh.MaxDate = new System.DateTime(2024, 9, 4, 0, 0, 0, 0);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(400, 29);
            this.dtpNgaySinh.TabIndex = 11;
            this.dtpNgaySinh.Value = new System.DateTime(2024, 9, 4, 0, 0, 0, 0);
            // 
            // txtGiaVe
            // 
            this.txtGiaVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGiaVe.Location = new System.Drawing.Point(133, 307);
            this.txtGiaVe.Name = "txtGiaVe";
            this.txtGiaVe.ReadOnly = true;
            this.txtGiaVe.Size = new System.Drawing.Size(400, 29);
            this.txtGiaVe.TabIndex = 13;
            this.txtGiaVe.Text = "350,000 VND";
            // 
            // btnDatVe
            // 
            this.btnDatVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDatVe.Location = new System.Drawing.Point(412, 365);
            this.btnDatVe.Name = "btnDatVe";
            this.btnDatVe.Size = new System.Drawing.Size(121, 35);
            this.btnDatVe.TabIndex = 14;
            this.btnDatVe.Text = "Đặt vé";
            this.btnDatVe.Click += new System.EventHandler(this.btnDatVe_Click);
            // 
            // lblToa
            // 
            this.lblToa.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToa.Location = new System.Drawing.Point(20, 103);
            this.lblToa.Name = "lblToa";
            this.lblToa.Size = new System.Drawing.Size(92, 32);
            this.lblToa.TabIndex = 1;
            this.lblToa.Text = "Chọn toa:";
            // 
            // lblHoTen
            // 
            this.lblHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Location = new System.Drawing.Point(20, 147);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(97, 23);
            this.lblHoTen.TabIndex = 4;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // lblSoGiayTo
            // 
            this.lblSoGiayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSoGiayTo.Location = new System.Drawing.Point(20, 187);
            this.lblSoGiayTo.Name = "lblSoGiayTo";
            this.lblSoGiayTo.Size = new System.Drawing.Size(107, 23);
            this.lblSoGiayTo.TabIndex = 6;
            this.lblSoGiayTo.Text = "Số giấy tờ:";
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGioiTinh.Location = new System.Drawing.Point(20, 227);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(97, 23);
            this.lblGioiTinh.TabIndex = 8;
            this.lblGioiTinh.Text = "Giới tính:";
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinh.Location = new System.Drawing.Point(20, 267);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(107, 23);
            this.lblNgaySinh.TabIndex = 10;
            this.lblNgaySinh.Text = "Ngày sinh:";
            // 
            // lblGiaVe
            // 
            this.lblGiaVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGiaVe.Location = new System.Drawing.Point(20, 307);
            this.lblGiaVe.Name = "lblGiaVe";
            this.lblGiaVe.Size = new System.Drawing.Size(87, 23);
            this.lblGiaVe.TabIndex = 12;
            this.lblGiaVe.Text = "Giá vé:";
            // 
            // lbSoGheTrong
            // 
            this.lbSoGheTrong.AutoSize = true;
            this.lbSoGheTrong.ForeColor = System.Drawing.Color.Red;
            this.lbSoGheTrong.Location = new System.Drawing.Point(129, 73);
            this.lbSoGheTrong.Name = "lbSoGheTrong";
            this.lbSoGheTrong.Size = new System.Drawing.Size(119, 24);
            this.lbSoGheTrong.TabIndex = 15;
            this.lbSoGheTrong.Text = "Số ghế trống";
            // 
            // FormDatVe
            // 
            this.ClientSize = new System.Drawing.Size(1280, 406);
            this.Controls.Add(this.lbSoGheTrong);
            this.Controls.Add(this.lblThongTinChuyen);
            this.Controls.Add(this.lblToa);
            this.Controls.Add(this.cboToa);
            this.Controls.Add(this.dgvVe);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblSoGiayTo);
            this.Controls.Add(this.txtSoGiayTo);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.cboGioiTinh);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.lblGiaVe);
            this.Controls.Add(this.txtGiaVe);
            this.Controls.Add(this.btnDatVe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormDatVe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống bán vé ga Sài Gòn - Đặt vé";
            this.Load += new System.EventHandler(this.FormDatVe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblThongTinChuyen;
        private ComboBox cboToa;
        private DataGridView dgvVe;
        private TextBox txtHoTen;
        private TextBox txtSoGiayTo;
        private ComboBox cboGioiTinh;
        private DateTimePicker dtpNgaySinh;
        private TextBox txtGiaVe;
        private Button btnDatVe;
        private Label lblToa;
        private Label lblHoTen;
        private Label lblSoGiayTo;
        private Label lblGioiTinh;
        private Label lblNgaySinh;
        private Label lblGiaVe;
        private DataGridViewTextBoxColumn dgvMaChuyen;
        private DataGridViewTextBoxColumn dgvViTriGhe;
        private DataGridViewTextBoxColumn dgvSoGhe;
        private DataGridViewTextBoxColumn dgvTrangThai;
        private DataGridViewTextBoxColumn dgvLoaiGhe;
        private Label lbSoGheTrong;
    }
}