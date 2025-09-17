using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem
{
    partial class FormTraCuu
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
            this.cboGaDi = new System.Windows.Forms.ComboBox();
            this.cboGaDen = new System.Windows.Forms.ComboBox();
            this.dtpNgayDi = new System.Windows.Forms.DateTimePicker();
            this.btnTraCuu = new System.Windows.Forms.Button();
            this.dgvKetQua = new System.Windows.Forms.DataGridView();
            this.lblGaDi = new System.Windows.Forms.Label();
            this.lblGaDen = new System.Windows.Forms.Label();
            this.lblNgayDi = new System.Windows.Forms.Label();
            this.btnDatVe = new System.Windows.Forms.Button();
            this.btnChiTietGiaVe = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnLocTheoGia = new System.Windows.Forms.Button();
            this.dgvMaChuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTenTau = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTenTuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGiaVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGioKhoiHanh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGioDen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGhiChu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).BeginInit();
            this.SuspendLayout();
            // 
            // cboGaDi
            // 
            this.cboGaDi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGaDi.Location = new System.Drawing.Point(90, 20);
            this.cboGaDi.Name = "cboGaDi";
            this.cboGaDi.Size = new System.Drawing.Size(458, 32);
            this.cboGaDi.TabIndex = 1;
            // 
            // cboGaDen
            // 
            this.cboGaDen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGaDen.Location = new System.Drawing.Point(90, 60);
            this.cboGaDen.Name = "cboGaDen";
            this.cboGaDen.Size = new System.Drawing.Size(458, 32);
            this.cboGaDen.TabIndex = 3;
            // 
            // dtpNgayDi
            // 
            this.dtpNgayDi.Location = new System.Drawing.Point(90, 100);
            this.dtpNgayDi.MinDate = new System.DateTime(2025, 9, 4, 0, 0, 0, 0);
            this.dtpNgayDi.Name = "dtpNgayDi";
            this.dtpNgayDi.Size = new System.Drawing.Size(458, 29);
            this.dtpNgayDi.TabIndex = 5;
            // 
            // btnTraCuu
            // 
            this.btnTraCuu.Location = new System.Drawing.Point(563, 19);
            this.btnTraCuu.Name = "btnTraCuu";
            this.btnTraCuu.Size = new System.Drawing.Size(156, 30);
            this.btnTraCuu.TabIndex = 6;
            this.btnTraCuu.Text = "Tra cứu";
            this.btnTraCuu.Click += new System.EventHandler(this.btnTraCuu_Click);
            // 
            // dgvKetQua
            // 
            this.dgvKetQua.AllowUserToAddRows = false;
            this.dgvKetQua.AllowUserToDeleteRows = false;
            this.dgvKetQua.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvKetQua.ColumnHeadersHeight = 35;
            this.dgvKetQua.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvMaChuyen,
            this.dgvTenTau,
            this.dgvTenTuyen,
            this.dgvTrangThai,
            this.dgvGiaVe,
            this.dgvGioKhoiHanh,
            this.dgvGioDen,
            this.dgvGhiChu});
            this.dgvKetQua.Location = new System.Drawing.Point(6, 149);
            this.dgvKetQua.Name = "dgvKetQua";
            this.dgvKetQua.ReadOnly = true;
            this.dgvKetQua.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKetQua.Size = new System.Drawing.Size(1457, 400);
            this.dgvKetQua.TabIndex = 7;
            // 
            // lblGaDi
            // 
            this.lblGaDi.Location = new System.Drawing.Point(20, 20);
            this.lblGaDi.Name = "lblGaDi";
            this.lblGaDi.Size = new System.Drawing.Size(50, 23);
            this.lblGaDi.TabIndex = 0;
            this.lblGaDi.Text = "Ga đi:";
            // 
            // lblGaDen
            // 
            this.lblGaDen.Location = new System.Drawing.Point(20, 60);
            this.lblGaDen.Name = "lblGaDen";
            this.lblGaDen.Size = new System.Drawing.Size(50, 23);
            this.lblGaDen.TabIndex = 2;
            this.lblGaDen.Text = "Ga đến:";
            // 
            // lblNgayDi
            // 
            this.lblNgayDi.Location = new System.Drawing.Point(20, 100);
            this.lblNgayDi.Name = "lblNgayDi";
            this.lblNgayDi.Size = new System.Drawing.Size(60, 23);
            this.lblNgayDi.TabIndex = 4;
            this.lblNgayDi.Text = "Ngày đi:";
            // 
            // btnDatVe
            // 
            this.btnDatVe.Location = new System.Drawing.Point(563, 60);
            this.btnDatVe.Name = "btnDatVe";
            this.btnDatVe.Size = new System.Drawing.Size(156, 30);
            this.btnDatVe.TabIndex = 6;
            this.btnDatVe.Text = "Đặt vé";
            this.btnDatVe.Click += new System.EventHandler(this.btnDatVe_Click);
            // 
            // btnChiTietGiaVe
            // 
            this.btnChiTietGiaVe.Location = new System.Drawing.Point(563, 99);
            this.btnChiTietGiaVe.Name = "btnChiTietGiaVe";
            this.btnChiTietGiaVe.Size = new System.Drawing.Size(156, 30);
            this.btnChiTietGiaVe.TabIndex = 6;
            this.btnChiTietGiaVe.Text = "Chi tiết giá vé";
            this.btnChiTietGiaVe.Click += new System.EventHandler(this.btnChiTietGiaVe_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(736, 19);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(156, 30);
            this.btnLamMoi.TabIndex = 6;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnLocTheoGia
            // 
            this.btnLocTheoGia.Location = new System.Drawing.Point(736, 99);
            this.btnLocTheoGia.Name = "btnLocTheoGia";
            this.btnLocTheoGia.Size = new System.Drawing.Size(156, 30);
            this.btnLocTheoGia.TabIndex = 6;
            this.btnLocTheoGia.Text = "Lọc theo giá";
            this.btnLocTheoGia.Click += new System.EventHandler(this.btnLocTheoGia_Click);
            // 
            // dgvMaChuyen
            // 
            this.dgvMaChuyen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvMaChuyen.HeaderText = "Mã chuyến";
            this.dgvMaChuyen.Name = "dgvMaChuyen";
            this.dgvMaChuyen.ReadOnly = true;
            this.dgvMaChuyen.Width = 129;
            // 
            // dgvTenTau
            // 
            this.dgvTenTau.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTenTau.HeaderText = "Tên tàu";
            this.dgvTenTau.Name = "dgvTenTau";
            this.dgvTenTau.ReadOnly = true;
            this.dgvTenTau.Width = 99;
            // 
            // dgvTenTuyen
            // 
            this.dgvTenTuyen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTenTuyen.HeaderText = "Tên tuyến";
            this.dgvTenTuyen.Name = "dgvTenTuyen";
            this.dgvTenTuyen.ReadOnly = true;
            this.dgvTenTuyen.Width = 120;
            // 
            // dgvTrangThai
            // 
            this.dgvTrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTrangThai.HeaderText = "Trạng thái";
            this.dgvTrangThai.Name = "dgvTrangThai";
            this.dgvTrangThai.ReadOnly = true;
            this.dgvTrangThai.Width = 119;
            // 
            // dgvGiaVe
            // 
            this.dgvGiaVe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvGiaVe.HeaderText = "Giá vé";
            this.dgvGiaVe.Name = "dgvGiaVe";
            this.dgvGiaVe.ReadOnly = true;
            this.dgvGiaVe.Width = 88;
            // 
            // dgvGioKhoiHanh
            // 
            this.dgvGioKhoiHanh.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvGioKhoiHanh.HeaderText = "Giờ khởi hành";
            this.dgvGioKhoiHanh.Name = "dgvGioKhoiHanh";
            this.dgvGioKhoiHanh.ReadOnly = true;
            this.dgvGioKhoiHanh.Width = 152;
            // 
            // dgvGioDen
            // 
            this.dgvGioDen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvGioDen.HeaderText = "Giờ đến";
            this.dgvGioDen.Name = "dgvGioDen";
            this.dgvGioDen.ReadOnly = true;
            this.dgvGioDen.Width = 103;
            // 
            // dgvGhiChu
            // 
            this.dgvGhiChu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvGhiChu.HeaderText = "Ghi chú";
            this.dgvGhiChu.Name = "dgvGhiChu";
            this.dgvGhiChu.ReadOnly = true;
            // 
            // FormTraCuu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1465, 553);
            this.Controls.Add(this.lblGaDi);
            this.Controls.Add(this.cboGaDi);
            this.Controls.Add(this.lblGaDen);
            this.Controls.Add(this.cboGaDen);
            this.Controls.Add(this.lblNgayDi);
            this.Controls.Add(this.dtpNgayDi);
            this.Controls.Add(this.btnLocTheoGia);
            this.Controls.Add(this.btnChiTietGiaVe);
            this.Controls.Add(this.btnDatVe);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnTraCuu);
            this.Controls.Add(this.dgvKetQua);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.Name = "FormTraCuu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống bán vé ga Sài Gòn - Tra cứu lịch chạy tàu";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormTraCuu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvKetQua)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cboGaDi;
        private ComboBox cboGaDen;
        private DateTimePicker dtpNgayDi;
        private Button btnTraCuu;
        private DataGridView dgvKetQua;
        private Label lblGaDi;
        private Label lblGaDen;
        private Label lblNgayDi;
        private Button btnDatVe;
        private Button btnChiTietGiaVe;
        private Button btnLamMoi;
        private Button btnLocTheoGia;
        private DataGridViewTextBoxColumn dgvMaChuyen;
        private DataGridViewTextBoxColumn dgvTenTau;
        private DataGridViewTextBoxColumn dgvTenTuyen;
        private DataGridViewTextBoxColumn dgvTrangThai;
        private DataGridViewTextBoxColumn dgvGiaVe;
        private DataGridViewTextBoxColumn dgvGioKhoiHanh;
        private DataGridViewTextBoxColumn dgvGioDen;
        private DataGridViewTextBoxColumn dgvGhiChu;
    }
}