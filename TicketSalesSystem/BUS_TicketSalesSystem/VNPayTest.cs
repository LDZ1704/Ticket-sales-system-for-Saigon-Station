using System;
using System.Security.Cryptography;
using System.Text;

namespace BUS_TicketSalesSystem
{
    public class VNPayTest
    {
        public static void TestHMAC()
        {
            string key = "RAOEXHYVSDDIIENYWSLGIAUNYWKGQZP";
            string data = "vnp_Amount=10000000&vnp_Command=pay&vnp_CreateDate=20250920111057&vnp_CurrCode=VND&vnp_IpAddr=127.0.0.1&vnp_Locale=vn&vnp_OrderInfo=Dat%201%20ve%20tau%20-%20MaTT%3A%201&vnp_OrderType=billpayment&vnp_ReturnUrl=http%3A//localhost%3A5111/api/vnpay-return&vnp_TmnCode=2QXUI4J4&vnp_TxnRef=1&vnp_Version=2.1.0";
            
            Console.WriteLine("--- HMAC SHA512 TEST ---");
            Console.WriteLine("Key: " + key);
            Console.WriteLine("Data: " + data);
            Console.WriteLine("Hash: " + Utils.HmacSHA512(key, data));
            Console.WriteLine("--- END TEST ---");
        }
        
        public static void TestVNPaySignature()
        {
            var vnp = new VnpayLibrary();
            vnp.AddRequestData("vnp_Version", "2.1.0");
            vnp.AddRequestData("vnp_Command", "pay");
            vnp.AddRequestData("vnp_TmnCode", "2QXUI4J4");
            vnp.AddRequestData("vnp_Amount", "10000000");
            vnp.AddRequestData("vnp_CurrCode", "VND");
            vnp.AddRequestData("vnp_TxnRef", "1");
            vnp.AddRequestData("vnp_OrderInfo", "Dat 1 ve tau - MaTT: 1");
            vnp.AddRequestData("vnp_OrderType", "billpayment");
            vnp.AddRequestData("vnp_Locale", "vn");
            vnp.AddRequestData("vnp_IpAddr", "127.0.0.1");
            vnp.AddRequestData("vnp_ReturnUrl", "http://localhost:5111/api/vnpay-return");
            vnp.AddRequestData("vnp_CreateDate", "20250920111057");
            
            string url = vnp.CreateRequestUrl("https://sandbox.vnpayment.vn/paymentv2/vpcpay.html", "RAOEXHYVSDDIIENYWSLGIAUNYWKGQZP");
            Console.WriteLine("Final URL: " + url);
        }
        
        public static void TestSimpleSignature()
        {
            // Test với dữ liệu đơn giản
            string key = "RAOEXHYVSDDIIENYWSLGIAUNYWKGQZP";
            string data = "vnp_Amount=10000000&vnp_Command=pay&vnp_CreateDate=20250920111057&vnp_CurrCode=VND&vnp_IpAddr=127.0.0.1&vnp_Locale=vn&vnp_OrderInfo=Dat 1 ve tau - MaTT: 1&vnp_OrderType=billpayment&vnp_ReturnUrl=http://localhost:5111/api/vnpay-return&vnp_TmnCode=2QXUI4J4&vnp_TxnRef=1&vnp_Version=2.1.0";
            
            Console.WriteLine("--- SIMPLE HMAC SHA512 TEST ---");
            Console.WriteLine("Key: " + key);
            Console.WriteLine("Data: " + data);
            Console.WriteLine("Hash: " + Utils.HmacSHA512(key, data));
            Console.WriteLine("--- END SIMPLE TEST ---");
        }
    }
}
