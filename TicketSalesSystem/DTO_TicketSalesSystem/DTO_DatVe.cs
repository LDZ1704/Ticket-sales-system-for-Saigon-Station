using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TicketSalesSystem
{
    public class DTO_DatVe
    {
        public int MaChuyen { get; set; }
        public int MaToa { get; set; }
        public int MaGhe { get; set; }
        public string HoTen { get; set; }
        public string SoGiayTo { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public decimal GiaVe { get; set; }
        public int MaNguoiDung { get; set; }
    }
}
