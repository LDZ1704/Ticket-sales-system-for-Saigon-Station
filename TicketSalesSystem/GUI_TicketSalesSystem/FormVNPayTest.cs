using System;
using System.Windows.Forms;
using BUS_TicketSalesSystem;

namespace GUI_TicketSalesSystem
{
    public partial class FormVNPayTest : Form
    {
        public FormVNPayTest()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Form properties
            this.Text = "VNPay Test";
            this.Size = new System.Drawing.Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // TextBox for output
            var txtOutput = new TextBox();
            txtOutput.Multiline = true;
            txtOutput.ScrollBars = ScrollBars.Vertical;
            txtOutput.Location = new System.Drawing.Point(20, 20);
            txtOutput.Size = new System.Drawing.Size(750, 500);
            txtOutput.ReadOnly = true;
            txtOutput.Font = new System.Drawing.Font("Consolas", 9);
            this.Controls.Add(txtOutput);

            // Button to run test
            var btnTest = new Button();
            btnTest.Text = "Chạy Test VNPay";
            btnTest.Location = new System.Drawing.Point(20, 540);
            btnTest.Size = new System.Drawing.Size(150, 40);
            btnTest.BackColor = System.Drawing.Color.Blue;
            btnTest.ForeColor = System.Drawing.Color.White;
            btnTest.Click += (s, e) => RunTest(txtOutput);
            this.Controls.Add(btnTest);

            // Button to close
            var btnClose = new Button();
            btnClose.Text = "Đóng";
            btnClose.Location = new System.Drawing.Point(620, 540);
            btnClose.Size = new System.Drawing.Size(150, 40);
            btnClose.BackColor = System.Drawing.Color.Gray;
            btnClose.ForeColor = System.Drawing.Color.White;
            btnClose.Click += (s, e) => this.Close();
            this.Controls.Add(btnClose);

            this.ResumeLayout(false);
        }

        private void RunTest(TextBox txtOutput)
        {
            txtOutput.Clear();
            txtOutput.AppendText("=== VNPAY SIGNATURE TEST ===\r\n\r\n");
            
            try
            {
                // Test HMAC SHA512
                txtOutput.AppendText("1. Testing HMAC SHA512...\r\n");
                VNPayTest.TestHMAC();
                txtOutput.AppendText("HMAC Test completed.\r\n\r\n");
                
                // Test Simple Signature
                txtOutput.AppendText("2. Testing Simple Signature...\r\n");
                VNPayTest.TestSimpleSignature();
                txtOutput.AppendText("Simple Test completed.\r\n\r\n");
                
                // Test VNPay signature
                txtOutput.AppendText("3. Testing VNPay Signature...\r\n");
                VNPayTest.TestVNPaySignature();
                txtOutput.AppendText("VNPay Test completed.\r\n\r\n");
                
                txtOutput.AppendText("=== TEST COMPLETED ===\r\n");
                txtOutput.AppendText("Check Console output for detailed debug info.\r\n");
            }
            catch (Exception ex)
            {
                txtOutput.AppendText($"Error: {ex.Message}\r\n");
                txtOutput.AppendText($"Stack Trace: {ex.StackTrace}\r\n");
            }
        }
    }
}
