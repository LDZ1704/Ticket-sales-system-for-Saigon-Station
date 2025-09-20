using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace VNPayDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== VNPAY DEBUG - So sánh với Java Sample ===");
            Console.WriteLine();

            // Test với dữ liệu từ Java sample
            TestWithJavaSample();
            
            Console.WriteLine();
            Console.WriteLine("=== Test với dữ liệu thực tế ===");
            TestWithRealData();
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        static void TestWithJavaSample()
        {
            Console.WriteLine("--- JAVA SAMPLE TEST ---");
            
            // Dữ liệu từ Java sample
            var params_java = new Dictionary<string, string>
            {
                {"vnp_Amount", "10000000"},
                {"vnp_Command", "pay"},
                {"vnp_CreateDate", "20250920111057"},
                {"vnp_CurrCode", "VND"},
                {"vnp_IpAddr", "127.0.0.1"},
                {"vnp_Locale", "vn"},
                {"vnp_OrderInfo", "Dat 1 ve tau - MaTT: 1"},
                {"vnp_OrderType", "billpayment"},
                {"vnp_ReturnUrl", "http://localhost:5111/api/vnpay-return"},
                {"vnp_TmnCode", "2QXUI4J4"},
                {"vnp_TxnRef", "1"},
                {"vnp_Version", "2.1.0"}
            };

            string secretKey = "RAOEXHYVSDDIIENYWSLGIAUNYWKGQZP";
            
            // Tạo hash data theo thứ tự alphabet
            var sortedParams = params_java.OrderBy(x => x.Key).ToList();
            StringBuilder hashData = new StringBuilder();
            
            for (int i = 0; i < sortedParams.Count; i++)
            {
                var kv = sortedParams[i];
                hashData.Append(kv.Key).Append("=").Append(kv.Value);
                if (i < sortedParams.Count - 1)
                {
                    hashData.Append("&");
                }
            }
            
            string hashDataStr = hashData.ToString();
            string signature = HmacSHA512(secretKey, hashDataStr);
            
            Console.WriteLine("HashData: " + hashDataStr);
            Console.WriteLine("Signature: " + signature);
            Console.WriteLine("Expected: 670f841380a4c750db62396ac80153354a5a12e392d62afeaa90c9a7b6972ae253915b73e5f3b278d7b8ede62e4b916a3bd7b6973b6d9d381adf3dc55eff95d0");
            Console.WriteLine("Match: " + (signature == "670f841380a4c750db62396ac80153354a5a12e392d62afeaa90c9a7b6972ae253915b73e5f3b278d7b8ede62e4b916a3bd7b6973b6d9d381adf3dc55eff95d0"));
        }

        static void TestWithRealData()
        {
            Console.WriteLine("--- REAL DATA TEST ---");
            
            // Dữ liệu thực tế từ giao dịch
            var params_real = new Dictionary<string, string>
            {
                {"vnp_Amount", "10000000"},
                {"vnp_Command", "pay"},
                {"vnp_CreateDate", "20250920113117"}, // Thời gian thực tế
                {"vnp_CurrCode", "VND"},
                {"vnp_IpAddr", "127.0.0.1"},
                {"vnp_Locale", "vn"},
                {"vnp_OrderInfo", "Dat 1 ve tau - MaTT: 1"},
                {"vnp_OrderType", "billpayment"},
                {"vnp_ReturnUrl", "http://localhost:5111/api/vnpay-return"},
                {"vnp_TmnCode", "2QXUI4J4"},
                {"vnp_TxnRef", "1"},
                {"vnp_Version", "2.1.0"}
            };

            string secretKey = "RAOEXHYVSDDIIENYWSLGIAUNYWKGQZP";
            
            // Tạo hash data theo thứ tự alphabet
            var sortedParams = params_real.OrderBy(x => x.Key).ToList();
            StringBuilder hashData = new StringBuilder();
            
            for (int i = 0; i < sortedParams.Count; i++)
            {
                var kv = sortedParams[i];
                hashData.Append(kv.Key).Append("=").Append(kv.Value);
                if (i < sortedParams.Count - 1)
                {
                    hashData.Append("&");
                }
            }
            
            string hashDataStr = hashData.ToString();
            string signature = HmacSHA512(secretKey, hashDataStr);
            
            Console.WriteLine("HashData: " + hashDataStr);
            Console.WriteLine("Signature: " + signature);
        }

        static string HmacSHA512(string key, string inputData)
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(inputData))
                throw new ArgumentNullException();

            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] inputBytes = Encoding.UTF8.GetBytes(inputData);

            using (var hmac = new HMACSHA512(keyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder(2 * hashValue.Length);
                foreach (byte b in hashValue)
                {
                    sb.AppendFormat("{0:x2}", b);
                }
                return sb.ToString();
            }
        }
    }
}
