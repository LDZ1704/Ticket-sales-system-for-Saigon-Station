using System.Drawing;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem
{
    partial class FormLichSuHoatDong
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
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.lblTongSo = new System.Windows.Forms.Label();
            this.lblTongChiTieu = new System.Windows.Forms.Label();
            this.btnXuatFile = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.dgvNgayGiaoDich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvLoaiGiaoDich = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTuyen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSoTien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvTrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvMaVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.Blue;
            this.lblTieuDe.Location = new System.Drawing.Point(19, 9);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(360, 40);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "LỊCH SỬ HOẠT ĐỘNG";
            // 
            // lblNguoiDung
            // 
            this.lblNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblNguoiDung.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblNguoiDung.Location = new System.Drawing.Point(20, 49);
            this.lblNguoiDung.Name = "lblNguoiDung";
            this.lblNguoiDung.Size = new System.Drawing.Size(465, 37);
            this.lblNguoiDung.TabIndex = 1;
            // 
            // dgvLichSu
            // 
            this.dgvLichSu.AllowUserToAddRows = false;
            this.dgvLichSu.AllowUserToDeleteRows = false;
            this.dgvLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvLichSu.ColumnHeadersHeight = 40;
            this.dgvLichSu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvNgayGiaoDich,
            this.dgvLoaiGiaoDich,
            this.dgvTuyen,
            this.dgvSoTien,
            this.dgvTrangThai,
            this.dgvMaVe});
            this.dgvLichSu.Location = new System.Drawing.Point(12, 100);
            this.dgvLichSu.MultiSelect = false;
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.ReadOnly = true;
            this.dgvLichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSu.Size = new System.Drawing.Size(1256, 400);
            this.dgvLichSu.TabIndex = 2;
            // 
            // lblTongSo
            // 
            this.lblTongSo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongSo.ForeColor = System.Drawing.Color.Blue;
            this.lblTongSo.Location = new System.Drawing.Point(286, 506);
            this.lblTongSo.Name = "lblTongSo";
            this.lblTongSo.Size = new System.Drawing.Size(315, 39);
            this.lblTongSo.TabIndex = 3;
            // 
            // lblTongChiTieu
            // 
            this.lblTongChiTieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongChiTieu.ForeColor = System.Drawing.Color.Green;
            this.lblTongChiTieu.Location = new System.Drawing.Point(641, 506);
            this.lblTongChiTieu.Name = "lblTongChiTieu";
            this.lblTongChiTieu.Size = new System.Drawing.Size(370, 39);
            this.lblTongChiTieu.TabIndex = 4;
            // 
            // btnXuatFile
            // 
            this.btnXuatFile.Location = new System.Drawing.Point(1017, 506);
            this.btnXuatFile.Name = "btnXuatFile";
            this.btnXuatFile.Size = new System.Drawing.Size(125, 44);
            this.btnXuatFile.TabIndex = 5;
            this.btnXuatFile.Text = "Xuất file";
            this.btnXuatFile.Click += new System.EventHandler(this.btnXuatFile_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(1148, 506);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 44);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // dgvNgayGiaoDich
            // 
            this.dgvNgayGiaoDich.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvNgayGiaoDich.HeaderText = "Ngày giao dịch";
            this.dgvNgayGiaoDich.Name = "dgvNgayGiaoDich";
            this.dgvNgayGiaoDich.ReadOnly = true;
            this.dgvNgayGiaoDich.Width = 181;
            // 
            // dgvLoaiGiaoDich
            // 
            this.dgvLoaiGiaoDich.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvLoaiGiaoDich.HeaderText = "Loại giao dịch";
            this.dgvLoaiGiaoDich.Name = "dgvLoaiGiaoDich";
            this.dgvLoaiGiaoDich.ReadOnly = true;
            this.dgvLoaiGiaoDich.Width = 171;
            // 
            // dgvTuyen
            // 
            this.dgvTuyen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTuyen.HeaderText = "Tuyến";
            this.dgvTuyen.Name = "dgvTuyen";
            this.dgvTuyen.ReadOnly = true;
            this.dgvTuyen.Width = 96;
            // 
            // dgvSoTien
            // 
            this.dgvSoTien.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvSoTien.HeaderText = "Số tiền";
            this.dgvSoTien.Name = "dgvSoTien";
            this.dgvSoTien.ReadOnly = true;
            this.dgvSoTien.Width = 105;
            // 
            // dgvTrangThai
            // 
            this.dgvTrangThai.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvTrangThai.HeaderText = "Trạng thái";
            this.dgvTrangThai.Name = "dgvTrangThai";
            this.dgvTrangThai.ReadOnly = true;
            this.dgvTrangThai.Width = 133;
            // 
            // dgvMaVe
            // 
            this.dgvMaVe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvMaVe.HeaderText = "Mã vé";
            this.dgvMaVe.Name = "dgvMaVe";
            this.dgvMaVe.ReadOnly = true;
            // 
            // FormLichSuHoatDong
            // 
            this.ClientSize = new System.Drawing.Size(1280, 561);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.lblNguoiDung);
            this.Controls.Add(this.dgvLichSu);
            this.Controls.Add(this.lblTongSo);
            this.Controls.Add(this.lblTongChiTieu);
            this.Controls.Add(this.btnXuatFile);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.MaximizeBox = false;
            this.Name = "FormLichSuHoatDong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch sử hoạt động";
            this.Load += new System.EventHandler(this.FormLichSuHoatDong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.ResumeLayout(false);

        }

        private Label lblTieuDe;
        private Label lblNguoiDung;
        private DataGridView dgvLichSu;
        private Label lblTongSo;
        private Label lblTongChiTieu;
        private Button btnXuatFile;
        private Button btnDong;

        #endregion

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dgvNgayGiaoDich;
        private DataGridViewTextBoxColumn dgvLoaiGiaoDich;
        private DataGridViewTextBoxColumn dgvTuyen;
        private DataGridViewTextBoxColumn dgvSoTien;
        private DataGridViewTextBoxColumn dgvTrangThai;
        private DataGridViewTextBoxColumn dgvMaVe;
    }
}