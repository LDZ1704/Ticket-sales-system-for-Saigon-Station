using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TicketSalesSystem
{
    public class DAL_ChuyenTau
    {
        public List<DTO_ChuyenTau> LayTatCaChuyenTau()
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = from ct in ctx.ChuyenTaus
                            join t in ctx.Taus on ct.MaTau equals t.MaTau
                            join td in ctx.TuyenDuongs on ct.MaTuyen equals td.MaTuyen
                            join gdi in ctx.GaTaus on td.MaGaDi equals gdi.MaGaTau
                            join gden in ctx.GaTaus on td.MaGaDen equals gden.MaGaTau
                            where ct.TrangThai == "MOBAN"
                            select new DTO_ChuyenTau
                            {
                                MaChuyen = ct.MaChuyen,
                                MaTau = ct.MaTau ?? 0,
                                MaTuyen = ct.MaTuyen ?? 0,
                                GioKhoiHanh = ct.GioKhoiHanh ?? DateTime.MinValue,
                                GioDen = ct.GioDen ?? DateTime.MinValue,
                                TrangThai = ct.TrangThai,
                                GhiChu = ct.GhiChu,
                                TenTau = t.TenTau,
                                TenGaDi = gdi.TenGa,
                                TenGaDen = gden.TenGa,
                                GiaVe = 100000 // Default price, should be calculated based on route and seat type
                            };
                return query.ToList();
            }
        }

        public DTO_ChuyenTau LayChuyenTauBangId(int maChuyen)
        {
            using (var ctx = new TicketSalesContext())
            {
                var chuyen = ctx.ChuyenTaus.FirstOrDefault(c => c.MaChuyen == maChuyen);
                if (chuyen == null) return null;

                return new DTO_ChuyenTau
                {
                    MaChuyen = chuyen.MaChuyen,
                    MaTau = chuyen.MaTau ?? 0,
                    MaTuyen = chuyen.MaTuyen ?? 0,
                    GioKhoiHanh = chuyen.GioKhoiHanh ?? DateTime.MinValue,
                    GioDen = chuyen.GioDen ?? DateTime.MinValue,
                    TrangThai = chuyen.TrangThai,
                    GhiChu = chuyen.GhiChu
                };
            }
        }

        public string LayTenTauBangChuyen(int maChuyen)
        {
            using (var ctx = new TicketSalesContext())
            {
                var result = from ct in ctx.ChuyenTaus
                             join t in ctx.Taus on ct.MaTau equals t.MaTau
                             where ct.MaChuyen == maChuyen
                             select t.TenTau;
                return result.FirstOrDefault();
            }
        }

        public string LayTuyenBangChuyen(int maChuyen)
        {
            using(var ctx = new TicketSalesContext())
            {
                var result = from ct in ctx.ChuyenTaus
                             join td in ctx.TuyenDuongs on ct.MaTuyen equals td.MaTuyen
                             join gdi in ctx.GaTaus on td.MaGaDi equals gdi.MaGaTau
                             join gden in ctx.GaTaus on td.MaGaDen equals gden.MaGaTau
                             where ct.MaChuyen == maChuyen
                             select new { GaDi = gdi.TenGa, GaDen = gden.TenGa };

                var data = result.FirstOrDefault();
                return data != null ? $"{data.GaDi} - {data.GaDen}" : "";
            }
        }

        public int LaySoChoTrongBangChuyen(int maChuyen)
        {
            using (var ctx = new TicketSalesContext())
            {
                var result = from ct in ctx.ChuyenTaus
                             join tt in ctx.ToaTaus on ct.MaTau equals tt.MaTau
                             join g in ctx.Ghes on tt.MaToa equals g.MaToa
                             where ct.MaChuyen == maChuyen && g.TrangThai == "TRONG"
                             select g.MaGhe;

                return result.Count();
            }
            
        }

        public DTO_TuyenDuong LayThongTinTuyenBangChuyen(int maChuyen)
        {
            using (var ctx = new TicketSalesContext())
            {
                var result = from ct in ctx.ChuyenTaus
                             join td in ctx.TuyenDuongs on ct.MaTuyen equals td.MaTuyen
                             where ct.MaChuyen == maChuyen
                             select new DTO_TuyenDuong
                             {
                                 MaTuyen = td.MaTuyen,
                                 MaGaDi = td.MaGaDi ?? 0,
                                 MaGaDen = td.MaGaDen ?? 0,
                                 KhoangCach = td.KhoangCach ?? 0,
                                 ThoiGianDuKien = td.ThoiGianDuKien ?? new TimeSpan(0, 0, 0),
                                 MoTa = td.MoTa
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
