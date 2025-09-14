using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TicketSalesSystem
{
    public class DTO_HanhKhach
    {
        public int? MaHanhKhach { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string LoaiGiayTo { get; set; }
        public string SoGiayTo { get; set; }
        public string QuocTich { get; set; }
        public string Email { get; set; }
        public string SoDienThoai { get; set; }
        public string GhiChu { get; set; }
    }
}
