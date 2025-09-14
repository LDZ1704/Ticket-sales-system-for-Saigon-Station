using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_TicketSalesSystem;

namespace DTO_TicketSalesSystem.utils
{
    public static class UserSession
    {
        public static string Username { get; set; }
        public static int UserId { get; set; }
        public static LoaiNguoiDung LoaiNguoiDung { get; set; }
        public static bool IsAdmin => LoaiNguoiDung == LoaiNguoiDung.QUANTRI;

        public static void Clear()
        {
            Username = null;
            UserId = 0;
            LoaiNguoiDung = LoaiNguoiDung.KHACH;
        }
    }
}
