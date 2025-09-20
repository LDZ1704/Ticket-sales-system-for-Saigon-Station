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
<<<<<<< HEAD
        public decimal GiaVe { get; set; }
=======
        public decimal? GiaVe { get; set; }
>>>>>>> c6748c47e9d8cb80444f49ab33d2a8edf2fe47b7
        public int? ViTri { get; set; }
        public int MaTau { get; set; }

        //thêm thông tin hiển thị
        public string DisplayText { get; set; }
        public int SoChoTrong { get; set; }
    }
}
