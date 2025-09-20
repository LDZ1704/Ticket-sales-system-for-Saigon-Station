using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using API_TicketSalesSystem.Utils;
using BUS_TicketSalesSystem;
using DAL_TicketSalesSystem;
using DTO_TicketSalesSystem;



namespace API_TicketSalesSystem.Controllers
{
    [RoutePrefix("api/vnpay")]
    public class VNPayCallbackController : ApiController
    {
        private readonly DAL_ThanhToan _dalThanhToan;
        private readonly DAL_HanhKhach _dalHanhKhach;
        private readonly DAL_Ve _dalVe;
        private readonly DAL_Ghe _dalGhe;
        private readonly DAL_TinhGiaVe _dalTinhGiaVe;
        private readonly string _hashSecret;

        public VNPayCallbackController()
        {
            _dalThanhToan = new DAL_ThanhToan();
            _dalHanhKhach = new DAL_HanhKhach();
            _dalVe = new DAL_Ve();
            _dalGhe = new DAL_Ghe();
            _dalTinhGiaVe = new DAL_TinhGiaVe();
            _hashSecret = ConfigurationManager.AppSettings["VNPay_HashSecret"];
        }

        [HttpPost]
        [Route("callback")]
        public IHttpActionResult ProcessCallback()
        {
            try
            {
                // Lấy tất cả parameters từ request
                var requestParams = Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);

                var vnpay = new VnpayLibrary();
                foreach (var param in requestParams)
                {
                    vnpay.AddResponseData(param.Key, param.Value);
                }

                string vnp_SecureHash = vnpay.GetResponseData("vnp_SecureHash");
                string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
                string vnp_TxnRef = vnpay.GetResponseData("vnp_TxnRef");

                // Validate signature
                bool isValidSignature = vnpay.ValidateSignature(vnp_SecureHash, "00ABBP3B3DHPXAW8GR1UUY95P2HUPLWE");
                if (!isValidSignature)
                    return BadRequest("Invalid signature");

                int maThanhToan = int.Parse(vnp_TxnRef);
                var thanhToan = _dalThanhToan.LayThanhToanTheoId(maThanhToan);
                if (thanhToan == null)
                    return BadRequest("Payment record not found");

                if (vnp_ResponseCode == "00") // ✅ Thành công
                {
                    // Update trạng thái thanh toán
                    bool updateThanhToan = _dalThanhToan.CapNhatTrangThaiThanhToan(maThanhToan, "THANHCONG");

                    if (!updateThanhToan)
                        return BadRequest("Failed to update records");

                    return Ok(new
                    {
                        success = true,
                        message = "Payment successful",
                        maThanhToan = maThanhToan
                    });
                }
                else 
                {
                    _dalThanhToan.CapNhatTrangThaiThanhToan(maThanhToan, "THATBAI");
                    return Ok(new
                    {
                        success = false,
                        message = "Payment failed",
                        responseCode = vnp_ResponseCode
                    });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("callback")]
        public IHttpActionResult ProcessCallbackGet()
        {
            // Xử lý GET request tương tự POST
            return ProcessCallback();
        }
    }
}
  