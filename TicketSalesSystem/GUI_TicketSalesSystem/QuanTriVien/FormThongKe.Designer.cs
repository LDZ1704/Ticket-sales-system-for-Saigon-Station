using System;
using System.Drawing;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem
{
    partial class FormThongKe
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
            this.tabThongKe = new System.Windows.Forms.TabControl();
            this.tabDoanhThu = new System.Windows.Forms.TabPage();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.btnXuatBaoCao = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.lblSoVe = new System.Windows.Forms.Label();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.dgvNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSoVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabVe = new System.Windows.Forms.TabPage();
            this.dgvVe = new System.Windows.Forms.DataGridView();
            this.dgvTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTiLe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbDaDoi = new System.Windows.Forms.Label();
            this.lbDaHuy = new System.Windows.Forms.Label();
            this.lbDaThanhToan = new System.Windows.Forms.Label();
            this.lbTongVe = new System.Windows.Forms.Label();
            this.tabTuyen = new System.Windows.Forms.TabPage();
            this.lbTuyenBanChayNhat = new System.Windows.Forms.Label();
            this.lbTuyen = new System.Windows.Forms.Label();
            this.dgvTuyen = new System.Windows.Forms.DataGridView();
            this.dgvXepHang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTenTuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSoVeBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDoanhThu2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDoanhThuTB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabThongKe.SuspendLayout();
            this.tabDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.tabVe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).BeginInit();
            this.tabTuyen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTuyen)).BeginInit();
            this.SuspendLayout();
            // 
            // tabThongKe
            // 
            this.tabThongKe.Controls.Add(this.tabDoanhThu);
            this.tabThongKe.Controls.Add(this.tabVe);
            this.tabThongKe.Controls.Add(this.tabTuyen);
            this.tabThongKe.Location = new System.Drawing.Point(2, 13);
            this.tabThongKe.Name = "tabThongKe";
            this.tabThongKe.SelectedIndex = 0;
            this.tabThongKe.Size = new System.Drawing.Size(1141, 620);
            this.tabThongKe.TabIndex = 0;
            this.tabThongKe.SelectedIndexChanged += new System.EventHandler(this.TabThongKe_SelectedIndexChanged);
            // 
            // tabDoanhThu
            // 
            this.tabDoanhThu.Controls.Add(this.lblTuNgay);
            this.tabDoanhThu.Controls.Add(this.dtpTuNgay);
            this.tabDoanhThu.Controls.Add(this.lblDenNgay);
            this.tabDoanhThu.Controls.Add(this.dtpDenNgay);
            this.tabDoanhThu.Controls.Add(this.btnXuatBaoCao);
            this.tabDoanhThu.Controls.Add(this.btnLamMoi);
            this.tabDoanhThu.Controls.Add(this.btnThongKe);
            this.tabDoanhThu.Controls.Add(this.lblDoanhThu);
            this.tabDoanhThu.Controls.Add(this.lblSoVe);
            this.tabDoanhThu.Controls.Add(this.dgvDoanhThu);
            this.tabDoanhThu.Location = new System.Drawing.Point(4, 33);
            this.tabDoanhThu.Name = "tabDoanhThu";
            this.tabDoanhThu.Size = new System.Drawing.Size(1133, 583);
            this.tabDoanhThu.TabIndex = 0;
            this.tabDoanhThu.Text = "Doanh thu";
            this.tabDoanhThu.UseVisualStyleBackColor = true;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.Location = new System.Drawing.Point(24, 20);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(60, 23);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dtpTuNgay
            // 
            this.dtpTuNgay.Location = new System.Drawing.Point(90, 20);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(318, 29);
            this.dtpTuNgay.TabIndex = 1;
            this.dtpTuNgay.Value = new System.DateTime(2025, 8, 4, 0, 0, 0, 0);
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.Location = new System.Drawing.Point(24, 70);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(60, 23);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dtpDenNgay
            // 
            this.dtpDenNgay.Location = new System.Drawing.Point(90, 70);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(318, 29);
            this.dtpDenNgay.TabIndex = 3;
            this.dtpDenNgay.Value = new System.DateTime(2025, 9, 4, 0, 0, 0, 0);
            // 
            // btnXuatBaoCao
            // 
            this.btnXuatBaoCao.Location = new System.Drawing.Point(740, 64);
            this.btnXuatBaoCao.Name = "btnXuatBaoCao";
            this.btnXuatBaoCao.Size = new System.Drawing.Size(149, 36);
            this.btnXuatBaoCao.TabIndex = 4;
            this.btnXuatBaoCao.Text = "Xuất báo cáo";
            this.btnXuatBaoCao.Click += new System.EventHandler(this.btnXuatBaoCao_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(585, 64);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(149, 36);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(430, 64);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(149, 36);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.Click += new System.EventHandler(this.BtnThongKe_Click);
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThu.ForeColor = System.Drawing.Color.Green;
            this.lblDoanhThu.Location = new System.Drawing.Point(910, 73);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(214, 30);
            this.lblDoanhThu.TabIndex = 5;
            this.lblDoanhThu.Text = "Tổng doanh thu: 0 VND";
            // 
            // lblSoVe
            // 
            this.lblSoVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblSoVe.ForeColor = System.Drawing.Color.Blue;
            this.lblSoVe.Location = new System.Drawing.Point(910, 27);
            this.lblSoVe.Name = "lblSoVe";
            this.lblSoVe.Size = new System.Drawing.Size(200, 30);
            this.lblSoVe.TabIndex = 6;
            this.lblSoVe.Text = "Tổng số vé: 0";
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AllowUserToAddRows = false;
            this.dgvDoanhThu.AllowUserToDeleteRows = false;
            this.dgvDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvDoanhThu.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDoanhThu.ColumnHeadersHeight = 35;
            this.dgvDoanhThu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvNgay,
            this.dgvSoVe,
            this.dgvThu});
            this.dgvDoanhThu.Location = new System.Drawing.Point(20, 120);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.ReadOnly = true;
            this.dgvDoanhThu.Size = new System.Drawing.Size(1090, 400);
            this.dgvDoanhThu.TabIndex = 7;
            // 
            // dgvNgay
            // 
            this.dgvNgay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvNgay.HeaderText = "Ngày";
            this.dgvNgay.Name = "dgvNgay";
            this.dgvNgay.ReadOnly = true;
            this.dgvNgay.Width = 79;
            // 
            // dgvSoVe
            // 
            this.dgvSoVe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvSoVe.HeaderText = "Số vé";
            this.dgvSoVe.Name = "dgvSoVe";
            this.dgvSoVe.ReadOnly = true;
            this.dgvSoVe.Width = 83;
            // 
            // dgvThu
            // 
            this.dgvThu.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvThu.HeaderText = "Doanh thu";
            this.dgvThu.Name = "dgvThu";
            this.dgvThu.ReadOnly = true;
            // 
            // tabVe
            // 
            this.tabVe.Controls.Add(this.dgvVe);
            this.tabVe.Controls.Add(this.lbDaDoi);
            this.tabVe.Controls.Add(this.lbDaHuy);
            this.tabVe.Controls.Add(this.lbDaThanhToan);
            this.tabVe.Controls.Add(this.lbTongVe);
            this.tabVe.Location = new System.Drawing.Point(4, 33);
            this.tabVe.Name = "tabVe";
            this.tabVe.Size = new System.Drawing.Size(1133, 583);
            this.tabVe.TabIndex = 1;
            this.tabVe.Text = "Thống kê vé";
            this.tabVe.UseVisualStyleBackColor = true;
            // 
            // dgvVe
            // 
            this.dgvVe.AllowUserToAddRows = false;
            this.dgvVe.AllowUserToDeleteRows = false;
            this.dgvVe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvVe.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvVe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvTrangThai,
            this.dgvSoLuong,
            this.dgvTiLe});
            this.dgvVe.Location = new System.Drawing.Point(15, 137);
            this.dgvVe.Name = "dgvVe";
            this.dgvVe.Size = new System.Drawing.Size(1099, 428);
            this.dgvVe.TabIndex = 1;
            // 
            // dgvTrangThai
            // 
            this.dgvTrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTrangThai.HeaderText = "Trạng thái";
            this.dgvTrangThai.Name = "dgvTrangThai";
            this.dgvTrangThai.Width = 119;
            // 
            // dgvSoLuong
            // 
            this.dgvSoLuong.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvSoLuong.HeaderText = "Số lượng";
            this.dgvSoLuong.Name = "dgvSoLuong";
            this.dgvSoLuong.Width = 111;
            // 
            // dgvTiLe
            // 
            this.dgvTiLe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTiLe.HeaderText = "Tỉ lệ (%)";
            this.dgvTiLe.Name = "dgvTiLe";
            this.dgvTiLe.Width = 103;
            // 
            // lbDaDoi
            // 
            this.lbDaDoi.AutoSize = true;
            this.lbDaDoi.ForeColor = System.Drawing.Color.DarkOrange;
            this.lbDaDoi.Location = new System.Drawing.Point(365, 89);
            this.lbDaDoi.Name = "lbDaDoi";
            this.lbDaDoi.Size = new System.Drawing.Size(85, 24);
            this.lbDaDoi.TabIndex = 0;
            this.lbDaDoi.Text = "Đã đổi: 0";
            // 
            // lbDaHuy
            // 
            this.lbDaHuy.AutoSize = true;
            this.lbDaHuy.ForeColor = System.Drawing.Color.Red;
            this.lbDaHuy.Location = new System.Drawing.Point(81, 89);
            this.lbDaHuy.Name = "lbDaHuy";
            this.lbDaHuy.Size = new System.Drawing.Size(89, 24);
            this.lbDaHuy.TabIndex = 0;
            this.lbDaHuy.Text = "Đã hủy: 0";
            // 
            // lbDaThanhToan
            // 
            this.lbDaThanhToan.AutoSize = true;
            this.lbDaThanhToan.ForeColor = System.Drawing.Color.Green;
            this.lbDaThanhToan.Location = new System.Drawing.Point(304, 40);
            this.lbDaThanhToan.Name = "lbDaThanhToan";
            this.lbDaThanhToan.Size = new System.Drawing.Size(146, 24);
            this.lbDaThanhToan.TabIndex = 0;
            this.lbDaThanhToan.Text = "Đã thanh toán: 0";
            // 
            // lbTongVe
            // 
            this.lbTongVe.AutoSize = true;
            this.lbTongVe.ForeColor = System.Drawing.Color.Blue;
            this.lbTongVe.Location = new System.Drawing.Point(45, 40);
            this.lbTongVe.Name = "lbTongVe";
            this.lbTongVe.Size = new System.Drawing.Size(125, 24);
            this.lbTongVe.TabIndex = 0;
            this.lbTongVe.Text = "Tổng số vé: 0";
            // 
            // tabTuyen
            // 
            this.tabTuyen.Controls.Add(this.dgvTuyen);
            this.tabTuyen.Controls.Add(this.lbTuyen);
            this.tabTuyen.Controls.Add(this.lbTuyenBanChayNhat);
            this.tabTuyen.Location = new System.Drawing.Point(4, 33);
            this.tabTuyen.Name = "tabTuyen";
            this.tabTuyen.Size = new System.Drawing.Size(1133, 583);
            this.tabTuyen.TabIndex = 2;
            this.tabTuyen.Text = "Thống kê tuyến";
            this.tabTuyen.UseVisualStyleBackColor = true;
            // 
            // lbTuyenBanChayNhat
            // 
            this.lbTuyenBanChayNhat.AutoSize = true;
            this.lbTuyenBanChayNhat.ForeColor = System.Drawing.Color.Blue;
            this.lbTuyenBanChayNhat.Location = new System.Drawing.Point(53, 31);
            this.lbTuyenBanChayNhat.Name = "lbTuyenBanChayNhat";
            this.lbTuyenBanChayNhat.Size = new System.Drawing.Size(197, 24);
            this.lbTuyenBanChayNhat.TabIndex = 0;
            this.lbTuyenBanChayNhat.Text = "Tuyến bán chạy nhất: ";
            // 
            // lbTuyen
            // 
            this.lbTuyen.AutoSize = true;
            this.lbTuyen.ForeColor = System.Drawing.Color.Green;
            this.lbTuyen.Location = new System.Drawing.Point(53, 79);
            this.lbTuyen.Name = "lbTuyen";
            this.lbTuyen.Size = new System.Drawing.Size(136, 24);
            this.lbTuyen.TabIndex = 0;
            this.lbTuyen.Text = "Tổng số tuyến:";
            // 
            // dgvTuyen
            // 
            this.dgvTuyen.AllowUserToAddRows = false;
            this.dgvTuyen.AllowUserToDeleteRows = false;
            this.dgvTuyen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvTuyen.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvTuyen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTuyen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvXepHang,
            this.dgvTenTuyen,
            this.dgvSoVeBan,
            this.dgvDoanhThu2,
            this.dgvDoanhThuTB});
            this.dgvTuyen.Location = new System.Drawing.Point(20, 117);
            this.dgvTuyen.Name = "dgvTuyen";
            this.dgvTuyen.Size = new System.Drawing.Size(1092, 448);
            this.dgvTuyen.TabIndex = 1;
            // 
            // dgvXepHang
            // 
            this.dgvXepHang.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvXepHang.HeaderText = "Xếp hạng";
            this.dgvXepHang.Name = "dgvXepHang";
            this.dgvXepHang.Width = 109;
            // 
            // dgvTenTuyen
            // 
            this.dgvTenTuyen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTenTuyen.HeaderText = "Tên tuyến";
            this.dgvTenTuyen.Name = "dgvTenTuyen";
            this.dgvTenTuyen.Width = 110;
            // 
            // dgvSoVeBan
            // 
            this.dgvSoVeBan.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvSoVeBan.HeaderText = "Số vé bán";
            this.dgvSoVeBan.Name = "dgvSoVeBan";
            this.dgvSoVeBan.Width = 110;
            // 
            // dgvDoanhThu2
            // 
            this.dgvDoanhThu2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvDoanhThu2.HeaderText = "Doanh thu";
            this.dgvDoanhThu2.Name = "dgvDoanhThu2";
            this.dgvDoanhThu2.Width = 112;
            // 
            // dgvDoanhThuTB
            // 
            this.dgvDoanhThuTB.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvDoanhThuTB.HeaderText = "Doanh thu trung bình";
            this.dgvDoanhThuTB.Name = "dgvDoanhThuTB";
            this.dgvDoanhThuTB.Width = 160;
            // 
            // FormThongKe
            // 
            this.ClientSize = new System.Drawing.Size(1143, 635);
            this.Controls.Add(this.tabThongKe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống bán vé ga Sài Gòn - Thống kê báo cáo";
            this.Load += new System.EventHandler(this.FormThongKe_Load);
            this.tabThongKe.ResumeLayout(false);
            this.tabDoanhThu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.tabVe.ResumeLayout(false);
            this.tabVe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVe)).EndInit();
            this.tabTuyen.ResumeLayout(false);
            this.tabTuyen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTuyen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabThongKe;
        private TabPage tabDoanhThu;
        private TabPage tabVe;
        private TabPage tabTuyen;
        private DateTimePicker dtpTuNgay;
        private DateTimePicker dtpDenNgay;
        private Button btnThongKe;
        private Label lblDoanhThu;
        private Label lblSoVe;
        private DataGridView dgvDoanhThu;
        private Label lblTuNgay;
        private Label lblDenNgay;
        private Button btnXuatBaoCao;
        private Button btnLamMoi;
        private DataGridViewTextBoxColumn dgvNgay;
        private DataGridViewTextBoxColumn dgvSoVe;
        private DataGridViewTextBoxColumn dgvThu;
        private Label lbDaHuy;
        private Label lbTongVe;
        private Label lbDaDoi;
        private Label lbDaThanhToan;
        private DataGridView dgvVe;
        private DataGridViewTextBoxColumn dgvTrangThai;
        private DataGridViewTextBoxColumn dgvSoLuong;
        private DataGridViewTextBoxColumn dgvTiLe;
        private Label lbTuyenBanChayNhat;
        private Label lbTuyen;
        private DataGridView dgvTuyen;
        private DataGridViewTextBoxColumn dgvXepHang;
        private DataGridViewTextBoxColumn dgvTenTuyen;
        private DataGridViewTextBoxColumn dgvSoVeBan;
        private DataGridViewTextBoxColumn dgvDoanhThu2;
        private DataGridViewTextBoxColumn dgvDoanhThuTB;
    }
}