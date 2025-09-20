using BUS_TicketSalesSystem;
using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem
{
    public partial class FormVNPayCallback : Form
    {
        private BUS_DatVe busDatVe;
        private DTO_GioHang gioHang;
        private int maNguoiDung;

        public FormVNPayCallback(DTO_GioHang gioHang, int maNguoiDung, string vnpResponseCode, string vnpTransactionStatus)
        {
            InitializeComponent();
            this.gioHang = gioHang;
            this.maNguoiDung = maNguoiDung;
            this.busDatVe = new BUS_DatVe();
            
            ProcessPaymentResult(vnpResponseCode, vnpTransactionStatus);
        }

        private void ProcessPaymentResult(string vnpResponseCode, string vnpTransactionStatus)
        {
            try
            {
                if (vnpResponseCode == "00" && vnpTransactionStatus == "00")
                {
                    // Thanh toán thành công
                    lblStatus.Text = "THANH TOÁN THÀNH CÔNG";
                    lblStatus.ForeColor = Color.Green;
                    lblMessage.Text = $"Bạn đã thanh toán thành công {gioHang.DanhSachVe.Count} vé với tổng tiền {gioHang.TongTien:N0} VNĐ.\n\nVé sẽ được gửi qua email của bạn trong vài phút tới.";
                    
                    // Xử lý thanh toán thành công
                    bool success = busDatVe.XuLyThanhToanThanhCong(GetMaThanhToanFromGioHang(), gioHang);
                    
                    if (success)
                    {
                        btnAction.Text = "Hoàn tất";
                        btnAction.BackColor = Color.Green;
                    }
                    else
                    {
                        lblMessage.Text += "\n\nLưu ý: Có lỗi xảy ra khi xử lý vé. Vui lòng liên hệ hỗ trợ.";
                    }
                }
                else
                {
                    // Thanh toán thất bại
                    lblStatus.Text = "THANH TOÁN THẤT BẠI";
                    lblStatus.ForeColor = Color.Red;
                    lblMessage.Text = "Thanh toán không thành công. Vui lòng thử lại hoặc liên hệ hỗ trợ.";
                    
                    btnAction.Text = "Thử lại";
                    btnAction.BackColor = Color.Orange;
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "LỖI XỬ LÝ";
                lblStatus.ForeColor = Color.Red;
                lblMessage.Text = $"Có lỗi xảy ra: {ex.Message}";
                btnAction.Text = "Đóng";
            }
        }

        private int GetMaThanhToanFromGioHang()
        {
            // Lấy mã thanh toán từ giỏ hàng
            return gioHang.MaThanhToan;
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (btnAction.Text == "Hoàn tất")
            {
                this.DialogResult = DialogResult.OK;
            }
            else if (btnAction.Text == "Thử lại")
            {
                this.DialogResult = DialogResult.Retry;
            }
            
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
