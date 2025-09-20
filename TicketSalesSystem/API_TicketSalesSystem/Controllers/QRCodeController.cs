using System;
using System.Web.Http;
using API_TicketSalesSystem.Utils;

namespace API_TicketSalesSystem.Controllers
{
    [RoutePrefix("api/qrcode")]
    public class QRCodeController : ApiController
    {
        [HttpGet]
        [Route("generate")]
        public IHttpActionResult GenerateQRCode(string data, string format = "base64")
        {
            try
            {
                if (string.IsNullOrEmpty(data))
                {
                    return BadRequest("Data parameter is required");
                }

                string result;
                switch (format.ToLower())
                {
                    case "svg":
                        result = QRCodeGenerator.GenerateQRCodeSVG(data);
                        return Ok(new { format = "svg", data = result });
                    
                    case "text":
                    case "ascii":
                        result = QRCodeGenerator.GenerateQRCodeText(data);
                        return Ok(new { format = "text", data = result });
                    
                    case "base64":
                    default:
                        result = QRCodeGenerator.GenerateQRCode(data);
                        return Ok(new { format = "base64", data = result });
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("generate")]
        public IHttpActionResult GenerateQRCodePost([FromBody] QRCodeRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrEmpty(request.Data))
                {
                    return BadRequest("Data is required");
                }

                string result;
                string format = request.Format?.ToLower() ?? "base64";
                
                switch (format)
                {
                    case "svg":
                        result = QRCodeGenerator.GenerateQRCodeSVG(request.Data);
                        break;
                    
                    case "text":
                    case "ascii":
                        result = QRCodeGenerator.GenerateQRCodeText(request.Data);
                        break;
                    
                    case "base64":
                    default:
                        result = QRCodeGenerator.GenerateQRCode(request.Data);
                        break;
                }

                return Ok(new { 
                    format = format, 
                    data = result,
                    originalData = request.Data,
                    timestamp = DateTime.Now
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("test")]
        public IHttpActionResult TestQRCode()
        {
            try
            {
                string testData = $"TEST_QR_{DateTime.Now:yyyyMMddHHmmss}";
                
                var result = new
                {
                    testData = testData,
                    base64 = QRCodeGenerator.GenerateQRCode(testData),
                    svg = QRCodeGenerator.GenerateQRCodeSVG(testData),
                    text = QRCodeGenerator.GenerateQRCodeText(testData),
                    timestamp = DateTime.Now
                };

                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }

    public class QRCodeRequest
    {
        public string Data { get; set; }
        public string Format { get; set; } = "base64";
    }
}
