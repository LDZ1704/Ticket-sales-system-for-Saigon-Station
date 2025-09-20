using BUS_TicketSalesSystem;
using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TicketSalesSystem
{
    /// <summary>
    /// Demo class để test VNPay integration
    /// </summary>
    public class VNPay_Demo
    {
        public static void TestVNPayIntegration()
        {
            Console.WriteLine("=== VNPay Integration Demo ===");
            
            try
            {
                // Tạo giỏ hàng mẫu
                var gioHang = new DTO_GioHang
                {
                    MaNguoiDung = 1,
                    DanhSachVe = new List<DTO_VeTrongGio>
                    {
                        new DTO_VeTrongGio
                        {
                            MaChuyen = 1,
                            MaGhe = 5,
                            HoTen = "Nguyễn Văn A",
                            GioiTinh = "Nam",
                            NgaySinh = DateTime.Now.AddYears(-25),
                            SoGiayTo = "123456789",
                            GiaVe = 500000,
                            TenGaDi = "Ga Sài Gòn",
                            TenGaDen = "Ga Hà Nội",
                            TenTau = "SE1",
                            SoHieuGhe = "01A",
                            TenToa = "A1",
                            GioKhoiHanh = DateTime.Now.AddDays(1)
                        },
                        new DTO_VeTrongGio
                        {
                            MaChuyen = 1,
                            MaGhe = 6,
                            HoTen = "Trần Thị B",
                            GioiTinh = "Nữ",
                            NgaySinh = DateTime.Now.AddYears(-30),
                            SoGiayTo = "987654321",
                            GiaVe = 500000,
                            TenGaDi = "Ga Sài Gòn",
                            TenGaDen = "Ga Hà Nội",
                            TenTau = "SE1",
                            SoHieuGhe = "01B",
                            TenToa = "A1",
                            GioKhoiHanh = DateTime.Now.AddDays(1)
                        }
                    }
                };

                Console.WriteLine($"Giỏ hàng có {gioHang.DanhSachVe.Count} vé");
                Console.WriteLine($"Tổng tiền: {gioHang.TongTien:N0} VNĐ");

                // Tạo URL thanh toán VNPay
                var busDatVe = new BUS_DatVe();
                string paymentUrl = busDatVe.TaoUrlThanhToanVNPay(gioHang);
                
                Console.WriteLine("\n=== VNPay Payment URL ===");
                Console.WriteLine(paymentUrl);
                
                Console.WriteLine("\n=== Demo hoàn thành ===");
                Console.WriteLine("Bạn có thể copy URL trên và mở trong trình duyệt để test thanh toán VNPay");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi: {ex.Message}");
            }
        }

        public static void TestVnpayLibrary()
        {
            Console.WriteLine("\n=== VnpayLibrary Test ===");
            
            try
            {
                var vnp = new VnpayLibrary();
                vnp.AddRequestData("vnp_Version", "2.1.0");
                vnp.AddRequestData("vnp_Command", "pay");
                vnp.AddRequestData("vnp_TmnCode", "2QXUI4J4");
                vnp.AddRequestData("vnp_Amount", "100000");
                vnp.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
                vnp.AddRequestData("vnp_CurrCode", "VND");
                vnp.AddRequestData("vnp_IpAddr", "127.0.0.1");
                vnp.AddRequestData("vnp_Locale", "vn");
                vnp.AddRequestData("vnp_OrderInfo", "Test payment");
                vnp.AddRequestData("vnp_OrderType", "other");
                vnp.AddRequestData("vnp_ReturnUrl", "http://localhost:5111/api/vnpay-return");
                vnp.AddRequestData("vnp_TxnRef", "12345");

                string baseUrl = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
                string secretKey = "RAOEXHYVSDDIIENYWSLGIAUNYWKGQZP";
                
                string paymentUrl = vnp.CreateRequestUrl(baseUrl, secretKey);
                
                Console.WriteLine("VNPay Library hoạt động bình thường!");
                Console.WriteLine($"Generated URL: {paymentUrl}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi VnpayLibrary: {ex.Message}");
            }
        }
    }
}
