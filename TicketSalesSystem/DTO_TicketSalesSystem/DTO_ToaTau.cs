using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TicketSalesSystem
{
    public class DTO_ToaTau
    {
        public int? MaToa { get; set; }
        public string TenToa { get; set; }
        public string LoaiGhe { get; set; }
        public decimal? GiaVe { get; set; }
        public int? ViTri { get; set; }
        public int MaTau { get; set; }

        //thêm thông tin hiển thị
        public string DisplayText { get; set; }
        public int SoChoTrong { get; set; }
    }
}
