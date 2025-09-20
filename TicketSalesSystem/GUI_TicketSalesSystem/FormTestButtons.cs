using System;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem
{
    public partial class FormTestButtons : Form
    {
        public FormTestButtons()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Tạo các nút test
            var btn1 = new Button();
            btn1.Text = "Thêm vào giỏ";
            btn1.Location = new System.Drawing.Point(20, 20);
            btn1.Size = new System.Drawing.Size(120, 40);
            btn1.BackColor = System.Drawing.Color.Blue;
            btn1.ForeColor = System.Drawing.Color.White;
            this.Controls.Add(btn1);

            var btn2 = new Button();
            btn2.Text = "Xem giỏ hàng";
            btn2.Location = new System.Drawing.Point(160, 20);
            btn2.Size = new System.Drawing.Size(120, 40);
            btn2.BackColor = System.Drawing.Color.Orange;
            btn2.ForeColor = System.Drawing.Color.White;
            this.Controls.Add(btn2);

            var btn3 = new Button();
            btn3.Text = "Thanh toán VNPay";
            btn3.Location = new System.Drawing.Point(300, 20);
            btn3.Size = new System.Drawing.Size(150, 40);
            btn3.BackColor = System.Drawing.Color.Green;
            btn3.ForeColor = System.Drawing.Color.White;
            this.Controls.Add(btn3);

            var btn4 = new Button();
            btn4.Text = "Đóng";
            btn4.Location = new System.Drawing.Point(470, 20);
            btn4.Size = new System.Drawing.Size(100, 40);
            btn4.BackColor = System.Drawing.Color.Gray;
            btn4.ForeColor = System.Drawing.Color.White;
            this.Controls.Add(btn4);

            // Form properties
            this.Text = "Test Buttons";
            this.Size = new System.Drawing.Size(600, 100);
            this.StartPosition = FormStartPosition.CenterScreen;
            
            this.ResumeLayout(false);
        }
    }
}
