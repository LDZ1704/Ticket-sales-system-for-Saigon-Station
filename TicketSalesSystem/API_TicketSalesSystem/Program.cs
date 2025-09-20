using Microsoft.Owin.Hosting;
using System;

namespace API_TicketSalesSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:8080/";

            // Start OWIN host
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Console.WriteLine("VNPay Callback API is running on: " + baseAddress);
                Console.WriteLine("Press any key to stop the server...");
                Console.ReadKey();
            }
        }
    }
}
