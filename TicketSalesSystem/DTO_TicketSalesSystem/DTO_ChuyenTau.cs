using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TicketSalesSystem
{
    public class DTO_ChuyenTau
    {
        public int? MaChuyen { get; set; }
        public int MaTau { get; set; }
        public int MaTuyen { get; set; }
        public DateTime GioKhoiHanh { get; set; }
        public DateTime GioDen { get; set; }
        public string TrangThai { get; set; }
        public string GhiChu { get; set; }

        //Thêm thông tin hiển thị
        public string TenTau { get; set; }
        public string Tuyen { get; set; }
        public int SoChoTrong { get; set; }
        public string TenGaDi { get; set; }
        public string TenGaDen { get; set; }
        public decimal GiaVe { get; set; }

    }
}
