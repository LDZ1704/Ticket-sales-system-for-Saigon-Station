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
            this.btnThongKe = new System.Windows.Forms.Button();
            this.lblDoanhThu = new System.Windows.Forms.Label();
            this.lblSoVe = new System.Windows.Forms.Label();
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.dgvNgay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSoVe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvThu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabVe = new System.Windows.Forms.TabPage();
            this.tabTuyen = new System.Windows.Forms.TabPage();
            this.tabThongKe.SuspendLayout();
            this.tabDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
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
            // 
            // tabDoanhThu
            // 
            this.tabDoanhThu.Controls.Add(this.lblTuNgay);
            this.tabDoanhThu.Controls.Add(this.dtpTuNgay);
            this.tabDoanhThu.Controls.Add(this.lblDenNgay);
            this.tabDoanhThu.Controls.Add(this.dtpDenNgay);
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
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(430, 64);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(149, 36);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống kê";
            // 
            // lblDoanhThu
            // 
            this.lblDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblDoanhThu.ForeColor = System.Drawing.Color.Green;
            this.lblDoanhThu.Location = new System.Drawing.Point(810, 77);
            this.lblDoanhThu.Name = "lblDoanhThu";
            this.lblDoanhThu.Size = new System.Drawing.Size(300, 30);
            this.lblDoanhThu.TabIndex = 5;
            this.lblDoanhThu.Text = "Tổng doanh thu: 0 VND";
            // 
            // lblSoVe
            // 
            this.lblSoVe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblSoVe.ForeColor = System.Drawing.Color.Blue;
            this.lblSoVe.Location = new System.Drawing.Point(810, 27);
            this.lblSoVe.Name = "lblSoVe";
            this.lblSoVe.Size = new System.Drawing.Size(200, 30);
            this.lblSoVe.TabIndex = 6;
            this.lblSoVe.Text = "Tổng số vé: 0";
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AllowUserToAddRows = false;
            this.dgvDoanhThu.AllowUserToDeleteRows = false;
            this.dgvDoanhThu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dgvNgay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvNgay.HeaderText = "Ngày";
            this.dgvNgay.Name = "dgvNgay";
            this.dgvNgay.ReadOnly = true;
            // 
            // dgvSoVe
            // 
            this.dgvSoVe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvSoVe.HeaderText = "Số vé";
            this.dgvSoVe.Name = "dgvSoVe";
            this.dgvSoVe.ReadOnly = true;
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
            this.tabVe.Location = new System.Drawing.Point(4, 22);
            this.tabVe.Name = "tabVe";
            this.tabVe.Size = new System.Drawing.Size(1133, 594);
            this.tabVe.TabIndex = 1;
            this.tabVe.Text = "Thống kê vé";
            this.tabVe.UseVisualStyleBackColor = true;
            // 
            // tabTuyen
            // 
            this.tabTuyen.Location = new System.Drawing.Point(4, 22);
            this.tabTuyen.Name = "tabTuyen";
            this.tabTuyen.Size = new System.Drawing.Size(1133, 594);
            this.tabTuyen.TabIndex = 2;
            this.tabTuyen.Text = "Thống kê tuyến";
            this.tabTuyen.UseVisualStyleBackColor = true;
            // 
            // FormThongKe
            // 
            this.ClientSize = new System.Drawing.Size(1143, 635);
            this.Controls.Add(this.tabThongKe);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormThongKe";
            this.Text = "Hệ thống bán vé ga Sài Gòn - Thống kê báo cáo";
            this.tabThongKe.ResumeLayout(false);
            this.tabDoanhThu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
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
        private DataGridViewTextBoxColumn dgvNgay;
        private DataGridViewTextBoxColumn dgvSoVe;
        private DataGridViewTextBoxColumn dgvThu;
    }
}