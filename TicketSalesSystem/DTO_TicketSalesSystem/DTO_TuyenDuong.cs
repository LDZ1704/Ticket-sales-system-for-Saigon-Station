using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TicketSalesSystem
{
    public class DTO_TuyenDuong
    {
        public int? MaTuyen { get; set; }
        public int MaGaDi { get; set; }
        public int MaGaDen { get; set; }
        public int KhoangCach { get; set; }
        public TimeSpan ThoiGianDuKien { get; set; }
        public string MoTa { get; set; }
    }
}
