using System;
using System.Collections.Generic;
using System.Linq;

namespace DTO_TicketSalesSystem
{
    public class DTO_GioHang
    {
        public int MaNguoiDung { get; set; }
        public List<DTO_VeTrongGio> DanhSachVe { get; set; } = new List<DTO_VeTrongGio>();
        public decimal TongTien => DanhSachVe.Sum(v => v.GiaVe);
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public int MaThanhToan { get; set; }
    }

    public class DTO_VeTrongGio
    {
        public int MaChuyen { get; set; }
        public int MaGhe { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoGiayTo { get; set; }
        public decimal GiaVe { get; set; }
        public string TenGaDi { get; set; }
        public string TenGaDen { get; set; }
        public string TenTau { get; set; }
        public string SoHieuGhe { get; set; }
        public string TenToa { get; set; }
        public DateTime GioKhoiHanh { get; set; }
    }
}
