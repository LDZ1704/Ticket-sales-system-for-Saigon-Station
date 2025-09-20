using System;
using System.Windows.Forms;
using DTO_TicketSalesSystem;

namespace GUI_TicketSalesSystem
{
    public partial class FormVNPayConfig : Form
    {
        public FormVNPayConfig()
        {
            InitializeComponent();
            LoadCurrentConfig();
        }

        private void LoadCurrentConfig()
        {
            var config = new DTO_VNPayConfig();
            txtTmnCode.Text = config.TmnCode;
            txtSecretKey.Text = config.SecretKey;
            txtReturnUrl.Text = config.ReturnUrl;
            txtVnpUrl.Text = config.VnpUrl;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            
            // Form properties
            this.Text = "Cấu hình VNPay";
            this.Size = new System.Drawing.Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Labels
            var lblTmnCode = new Label();
            lblTmnCode.Text = "TMN Code:";
            lblTmnCode.Location = new System.Drawing.Point(20, 20);
            lblTmnCode.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(lblTmnCode);

            var lblSecretKey = new Label();
            lblSecretKey.Text = "Secret Key:";
            lblSecretKey.Location = new System.Drawing.Point(20, 60);
            lblSecretKey.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(lblSecretKey);

            var lblReturnUrl = new Label();
            lblReturnUrl.Text = "Return URL:";
            lblReturnUrl.Location = new System.Drawing.Point(20, 100);
            lblReturnUrl.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(lblReturnUrl);

            var lblVnpUrl = new Label();
            lblVnpUrl.Text = "VNPay URL:";
            lblVnpUrl.Location = new System.Drawing.Point(20, 140);
            lblVnpUrl.Size = new System.Drawing.Size(100, 20);
            this.Controls.Add(lblVnpUrl);

            // TextBoxes
            txtTmnCode = new TextBox();
            txtTmnCode.Location = new System.Drawing.Point(130, 17);
            txtTmnCode.Size = new System.Drawing.Size(400, 23);
            this.Controls.Add(txtTmnCode);

            txtSecretKey = new TextBox();
            txtSecretKey.Location = new System.Drawing.Point(130, 57);
            txtSecretKey.Size = new System.Drawing.Size(400, 23);
            this.Controls.Add(txtSecretKey);

            txtReturnUrl = new TextBox();
            txtReturnUrl.Location = new System.Drawing.Point(130, 97);
            txtReturnUrl.Size = new System.Drawing.Size(400, 23);
            this.Controls.Add(txtReturnUrl);

            txtVnpUrl = new TextBox();
            txtVnpUrl.Location = new System.Drawing.Point(130, 137);
            txtVnpUrl.Size = new System.Drawing.Size(400, 23);
            this.Controls.Add(txtVnpUrl);

            // Buttons
            var btnSave = new Button();
            btnSave.Text = "Lưu cấu hình";
            btnSave.Location = new System.Drawing.Point(200, 200);
            btnSave.Size = new System.Drawing.Size(120, 40);
            btnSave.BackColor = System.Drawing.Color.Green;
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);

            var btnCancel = new Button();
            btnCancel.Text = "Hủy";
            btnCancel.Location = new System.Drawing.Point(340, 200);
            btnCancel.Size = new System.Drawing.Size(120, 40);
            btnCancel.BackColor = System.Drawing.Color.Gray;
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Click += (s, e) => this.Close();
            this.Controls.Add(btnCancel);

            // Info label
            var lblInfo = new Label();
            lblInfo.Text = "Lưu ý: Cập nhật thông tin VNPay từ tài khoản của bạn để tránh lỗi 'Sai chữ ký'";
            lblInfo.Location = new System.Drawing.Point(20, 260);
            lblInfo.Size = new System.Drawing.Size(550, 40);
            lblInfo.ForeColor = System.Drawing.Color.Red;
            this.Controls.Add(lblInfo);

            this.ResumeLayout(false);
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtTmnCode.Text) || string.IsNullOrEmpty(txtSecretKey.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ TMN Code và Secret Key!", "Lỗi", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Cập nhật cấu hình VNPay
                UpdateVNPayConfig(txtTmnCode.Text, txtSecretKey.Text, txtReturnUrl.Text, txtVnpUrl.Text);
                
                MessageBox.Show("Đã cập nhật cấu hình VNPay thành công!", "Thành công", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi cập nhật cấu hình: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateVNPayConfig(string tmnCode, string secretKey, string returnUrl, string vnpUrl)
        {
            // Cập nhật file DTO_VNPayConfig
            var configContent = $@"using System;

namespace DTO_TicketSalesSystem
{{
    public class DTO_ThanhToanVNPay
    {{
        public int MaThanhToan {{ get; set; }}
        public int MaNguoiDung {{ get; set; }}
        public decimal TongTien {{ get; set; }}
        public string VnpTxnRef {{ get; set; }}
        public string VnpOrderInfo {{ get; set; }}
        public string VnpReturnUrl {{ get; set; }}
        public string VnpPaymentUrl {{ get; set; }}
        public DateTime ThoiDiem {{ get; set; }} = DateTime.Now;
        public string TrangThai {{ get; set; }} = ""DANGXULY"";
        public string VnpResponseCode {{ get; set; }}
        public string VnpTransactionStatus {{ get; set; }}
        public string VnpSecureHash {{ get; set; }}
    }}

    public class DTO_VNPayConfig
    {{
        public string VnpUrl {{ get; set; }} = ""{vnpUrl}"";
        public string TmnCode {{ get; set; }} = ""{tmnCode}"";
        public string SecretKey {{ get; set; }} = ""{secretKey}"";
        public string ReturnUrl {{ get; set; }} = ""{returnUrl}"";
        public string Version {{ get; set; }} = ""2.1.0"";
        public string Command {{ get; set; }} = ""pay"";
        public string CurrCode {{ get; set; }} = ""VND"";
        public string Locale {{ get; set; }} = ""vn"";
        public string OrderType {{ get; set; }} = ""other"";
    }}
}}";

            System.IO.File.WriteAllText("DTO_TicketSalesSystem/DTO_ThanhToanVNPay.cs", configContent);
        }

        private TextBox txtTmnCode;
        private TextBox txtSecretKey;
        private TextBox txtReturnUrl;
        private TextBox txtVnpUrl;
    }
}
