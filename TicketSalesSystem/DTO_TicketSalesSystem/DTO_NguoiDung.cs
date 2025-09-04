using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TicketSalesSystem
{
    public class DTO_NguoiDung
    {
        public int? MaNguoiDung { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public LoaiNguoiDung LoaiNguoiDung { get; set; } = LoaiNguoiDung.KHACH;
    }
}
