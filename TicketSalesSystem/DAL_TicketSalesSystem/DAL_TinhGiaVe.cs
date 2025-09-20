using DTO_TicketSalesSystem;
using System;
using System.Linq;

namespace DAL_TicketSalesSystem
{
    public class DAL_TinhGiaVe
    {
        /// <summary>
        /// Lấy giá vé từ toa tàu (không tính toán phức tạp)
        /// </summary>
        /// <param name="maChuyen">Mã chuyến tàu</param>
        /// <param name="maGhe">Mã ghế</param>
        /// <returns>Giá vé</returns>
        public decimal TinhGiaVe(int maChuyen, int maGhe)
        {
            using (var ctx = new TicketSalesContext())
            {
                // Lấy giá vé trực tiếp từ toa tàu
                var query = from g in ctx.Ghes
                           join tt in ctx.ToaTaus on g.MaToa equals tt.MaToa
                           join ct in ctx.ChuyenTaus on tt.MaTau equals ct.MaTau
                           where g.MaGhe == maGhe && ct.MaChuyen == maChuyen
                           select tt.GiaVe;

                return query.FirstOrDefault() ?? 100000; // Giá mặc định nếu null
            }
        }

        /// <summary>
        /// Lấy giá vé từ toa tàu (giá cơ bản)
        /// </summary>
        /// <param name="maGhe">Mã ghế</param>
        /// <returns>Giá vé cơ bản</returns>
        public decimal LayGiaVeCoBan(int maGhe)
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = from g in ctx.Ghes
                           join tt in ctx.ToaTaus on g.MaToa equals tt.MaToa
                           where g.MaGhe == maGhe
                           select tt.GiaVe;

                return query.FirstOrDefault() ?? 100000;
            }
        }

        /// <summary>
        /// Lấy thông tin giá vé chi tiết
        /// </summary>
        /// <param name="maChuyen">Mã chuyến tàu</param>
        /// <param name="maGhe">Mã ghế</param>
        /// <returns>Thông tin giá vé</returns>
        public GiaVeInfo LayThongTinGiaVe(int maChuyen, int maGhe)
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = from g in ctx.Ghes
                           join tt in ctx.ToaTaus on g.MaToa equals tt.MaToa
                           join ct in ctx.ChuyenTaus on tt.MaTau equals ct.MaTau
                           join td in ctx.TuyenDuongs on ct.MaTuyen equals td.MaTuyen
                           join gdi in ctx.GaTaus on td.MaGaDi equals gdi.MaGaTau
                           join gden in ctx.GaTaus on td.MaGaDen equals gden.MaGaTau
                           where g.MaGhe == maGhe && ct.MaChuyen == maChuyen
                           select new GiaVeInfo
                           {
                               MaGhe = g.MaGhe,
                               SoHieu = g.SoHieu,
                               TenToa = tt.TenToa,
                               LoaiGhe = tt.LoaiGhe,
                               GiaVeCoBan = tt.GiaVe ?? 100000,
                               KhoangCach = td.KhoangCach ?? 0,
                               GaDi = gdi.TenGa,
                               GaDen = gden.TenGa,
                               GiaVeCuoiCung = tt.GiaVe ?? 100000
                           };

                return query.FirstOrDefault();
            }
        }
    }

    public class GiaVeInfo
    {
        public int MaGhe { get; set; }
        public string SoHieu { get; set; }
        public string TenToa { get; set; }
        public string LoaiGhe { get; set; }
        public decimal GiaVeCoBan { get; set; }
        public int KhoangCach { get; set; }
        public string GaDi { get; set; }
        public string GaDen { get; set; }
        public decimal GiaVeCuoiCung { get; set; }
    }
}
