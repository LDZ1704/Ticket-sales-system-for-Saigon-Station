using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TicketSalesSystem
{
    public class DTO_Ve
    {
        public int? MaVe { get; set; }
        public int MaHanhKhach { get; set; }
        public int MaChuyen { get; set; }
        public int MaGhe { get; set; }
        public int MaThanhToan { get; set; }
        public decimal GiaVe { get; set; }
        public string TrangThai { get; set; }
        public string MaQR { get; set; }

        //Thêm các thuộc tính để hiển thị(không map với database)
        public string HanhKhach { get; set; }
        public string Tuyen { get; set; }
        public string ToaGhe { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public DateTime NgayDat { get; set; }
    }
}
