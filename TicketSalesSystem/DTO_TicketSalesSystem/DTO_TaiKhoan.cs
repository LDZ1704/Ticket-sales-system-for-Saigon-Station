using DTO_TicketSalesSystem.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TicketSalesSystem
{
    public class DTO_TaiKhoan
    {
        public int? MaTaiKhoan { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public TrangThai TrangThai { get; set; } = TrangThai.HOATDONG;
        public int MaNguoiDung { get; set; }
    }
}
