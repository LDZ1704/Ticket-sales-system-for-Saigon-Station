using System.Drawing;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem
{
    partial class FormBaoCaoTongHop
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
            this.rtbBaoCao = new System.Windows.Forms.RichTextBox();
            this.btnLuuFile = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtbBaoCao
            // 
            this.rtbBaoCao.BackColor = System.Drawing.Color.White;
            this.rtbBaoCao.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbBaoCao.Location = new System.Drawing.Point(20, 60);
            this.rtbBaoCao.Name = "rtbBaoCao";
            this.rtbBaoCao.ReadOnly = true;
            this.rtbBaoCao.Size = new System.Drawing.Size(740, 450);
            this.rtbBaoCao.TabIndex = 1;
            this.rtbBaoCao.Text = "";
            // 
            // btnLuuFile
            // 
            this.btnLuuFile.Location = new System.Drawing.Point(443, 516);
            this.btnLuuFile.Name = "btnLuuFile";
            this.btnLuuFile.Size = new System.Drawing.Size(106, 34);
            this.btnLuuFile.TabIndex = 2;
            this.btnLuuFile.Text = "Lưu file";
            this.btnLuuFile.Click += new System.EventHandler(this.btnLuuFile_Click);
            // 
            // btnIn
            // 
            this.btnIn.Location = new System.Drawing.Point(555, 516);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(98, 34);
            this.btnIn.TabIndex = 3;
            this.btnIn.Text = "In";
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(659, 516);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(101, 34);
            this.btnDong.TabIndex = 4;
            this.btnDong.Text = "Đóng";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.Blue;
            this.lblTieuDe.Location = new System.Drawing.Point(20, 20);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(300, 30);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "BÁO CÁO TỔNG HỢP";
            // 
            // FormBaoCaoTongHop
            // 
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.rtbBaoCao);
            this.Controls.Add(this.btnLuuFile);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnDong);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.Name = "FormBaoCaoTongHop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Báo cáo tổng hợp";
            this.Load += new System.EventHandler(this.FormBaoCaoTongHop_Load);
            this.ResumeLayout(false);

        }

        private RichTextBox rtbBaoCao;
        private Button btnLuuFile;
        private Button btnIn;
        private Button btnDong;
        private Label lblTieuDe;

    }

        #endregion
}