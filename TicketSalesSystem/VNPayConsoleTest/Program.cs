using System;
using BUS_TicketSalesSystem;

namespace VNPayConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== VNPAY SIGNATURE TEST ===");
            Console.WriteLine();

            try
            {
                // Test 1: HMAC SHA512 cơ bản
                Console.WriteLine("1. Testing HMAC SHA512...");
                VNPayTest.TestHMAC();
                Console.WriteLine("HMAC Test completed.");
                Console.WriteLine();

                // Test 2: Simple Signature
                Console.WriteLine("2. Testing Simple Signature...");
                VNPayTest.TestSimpleSignature();
                Console.WriteLine("Simple Test completed.");
                Console.WriteLine();

                // Test 3: VNPay Library
                Console.WriteLine("3. Testing VNPay Signature...");
                VNPayTest.TestVNPaySignature();
                Console.WriteLine("VNPay Test completed.");
                Console.WriteLine();

                Console.WriteLine("=== ALL TESTS COMPLETED ===");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine($"Stack Trace: {ex.StackTrace}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
