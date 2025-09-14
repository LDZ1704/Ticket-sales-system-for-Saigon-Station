using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TicketSalesSystem
{
    public class DTO_ThanhToan
    {
        public int? MaThanhToan { get; set; }
        public int MaNguoiDung { get; set; }
        public string HinhThuc { get; set; }
        public DateTime ThoiDiem { get; set; }
        public string TrangThai { get; set; }
        public DateTime NgayThanhToan { get; set; }
    }
}
