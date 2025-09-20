using System;

namespace DTO_TicketSalesSystem
{
    public class DTO_ThanhToanVNPay
    {
        public int MaThanhToan { get; set; }
        public int MaNguoiDung { get; set; }
        public decimal TongTien { get; set; }
        public string VnpTxnRef { get; set; }
        public string VnpOrderInfo { get; set; }
        public string VnpReturnUrl { get; set; }
        public string VnpPaymentUrl { get; set; }
        public DateTime ThoiDiem { get; set; } = DateTime.Now;
        public string TrangThai { get; set; } = "DANGXULY";
        public string VnpResponseCode { get; set; }
        public string VnpTransactionStatus { get; set; }
        public string VnpSecureHash { get; set; }
    }

    public class DTO_VNPayConfig
    {
        public string VnpUrl { get; set; } = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
        public string TmnCode { get; set; } = "2QXUI4J4";
        public string SecretKey { get; set; } = "RAOEXHYVSDDIIENYWSLGIAUNYWKGQZP";
        public string ReturnUrl { get; set; } = "http://localhost:8080/api/vnpay-return";
        public string Version { get; set; } = "2.1.0";
        public string Command { get; set; } = "pay";
        public string CurrCode { get; set; } = "VND";
        public string Locale { get; set; } = "vn";
        public string OrderType { get; set; } = "other"; // Sửa từ "other" thành "billpayment"


    }
}
