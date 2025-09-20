using System;
using Net.Codecrete.QrCodeGenerator;

namespace API_TicketSalesSystem.Utils
{
    public static class QRCodeGenerator
    {
        public static string GenerateQRCode(string data)
        {
            try
            {
                // Sử dụng thư viện Net.Codecrete.QrCodeGenerator
                var qr = QrCode.EncodeText(data, QrCode.Ecc.Medium);
                
                // Trả về SVG string thay vì base64 bitmap
                return qr.ToSvgString(4);
            }
            catch (Exception ex)
            {
                // Fallback: trả về text nếu có lỗi
                Console.WriteLine($"Error generating QR code: {ex.Message}");
                return $"QR_{data}_{DateTime.Now:yyyyMMddHHmmss}";
            }
        }

        public static string GenerateQRCodeFile(string data, string filePath)
        {
            try
            {
                // Sử dụng thư viện Net.Codecrete.QrCodeGenerator
                var qr = QrCode.EncodeText(data, QrCode.Ecc.Medium);
                
                // Lưu SVG file
                string svgContent = qr.ToSvgString(4);
                System.IO.File.WriteAllText(filePath, svgContent);
                return filePath;
            }
            catch (Exception ex)
            {
                // Fallback: trả về null nếu có lỗi
                Console.WriteLine($"Error generating QR code file: {ex.Message}");
                return null;
            }
        }

        // Thêm method để tạo QR code dạng SVG (không cần System.Drawing)
        public static string GenerateQRCodeSVG(string data)
        {
            try
            {
                var qr = QrCode.EncodeText(data, QrCode.Ecc.Medium);
                return qr.ToSvgString(4);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating QR code SVG: {ex.Message}");
                return $"<svg><text>QR_{data}_{DateTime.Now:yyyyMMddHHmmss}</text></svg>";
            }
        }

        // Thêm method để tạo QR code dạng text (ASCII art)
        public static string GenerateQRCodeText(string data)
        {
            try
            {
                var qr = QrCode.EncodeText(data, QrCode.Ecc.Medium);
                // Tạo ASCII art đơn giản
                string result = "";
                for (int y = 0; y < qr.Size; y++)
                {
                    for (int x = 0; x < qr.Size; x++)
                    {
                        result += qr.GetModule(x, y) ? "██" : "  ";
                    }
                    result += "\n";
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating QR code text: {ex.Message}");
                return $"QR_{data}_{DateTime.Now:yyyyMMddHHmmss}";
            }
        }
    }
}
