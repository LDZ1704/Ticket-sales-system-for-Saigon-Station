using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TicketSalesSystem
{
    public class DAL_TraCuu
    {
        public List<DTO_GaTau> LayDanhSachGaTau()
        {
            using (var ctx = new TicketSalesContext())
            {
                return ctx.GaTaus.Select(g => new DTO_GaTau
                {
                    MaGaTau = g.MaGaTau,
                    TenGa = g.TenGa,
                    DiaChi = g.DiaChi,
                    Mien = g.Mien,
                    GhiChu = g.GhiChu
                }).ToList();
            }
        }
        public List<DTO_ChuyenTau> TraCuuLichChayTau(int maGaDi, int maGaDen, DateTime ngayDi)
        {
            using (var ctx = new TicketSalesContext())
            {
                DateTime startDate = ngayDi.Date;
                DateTime endDate = ngayDi.Date.AddDays(1);

                var ketQua = (from ct in ctx.ChuyenTaus
                              join tuyen in ctx.TuyenDuongs on ct.MaTuyen equals tuyen.MaTuyen
                              where tuyen.MaGaDi == maGaDi
                                    && tuyen.MaGaDen == maGaDen
                                    && ct.GioKhoiHanh >= startDate
                                    && ct.GioKhoiHanh < endDate
                                    && ct.TrangThai == "MOBAN"
                              select new DTO_ChuyenTau
                              {
                                  MaChuyen = ct.MaChuyen,
                                  MaTau = ct.MaTau ?? 0,
                                  MaTuyen = ct.MaTuyen ?? 0,
                                  TrangThai = ct.TrangThai,
                                  GioKhoiHanh = ct.GioKhoiHanh ?? DateTime.MinValue,
                                  GioDen = ct.GioDen ?? DateTime.MinValue,
                                  GhiChu = ct.GhiChu
                              }).OrderBy(x => x.GioKhoiHanh).ToList();

                return ketQua;
            }
        }
        public List<DTO_ChuyenTau> LayTatCaChuyenTau()
        {
            using (var ctx = new TicketSalesContext())
            {
                return ctx.ChuyenTaus.Where(ct => ct.TrangThai == "MOBAN").Select(ct => new DTO_ChuyenTau
                {
                    MaChuyen = ct.MaChuyen,
                    MaTau = ct.MaTau ?? 0,
                    MaTuyen = ct.MaTuyen ?? 0,
                    GioKhoiHanh = ct.GioKhoiHanh ?? DateTime.MinValue,
                    GioDen = ct.GioDen ?? DateTime.MinValue,
                    TrangThai = ct.TrangThai,
                    GhiChu = ct.GhiChu
                }).OrderBy(x => x.GioKhoiHanh).ToList();
            }
        }
        public DTO_Tau LayThongTinTau(int maTau)
        {
            using (var ctx = new TicketSalesContext())
            {
                return ctx.Taus.Where(t => t.MaTau == maTau).Select(t => new DTO_Tau
                {
                    MaTau = t.MaTau,
                    TenTau = t.TenTau,
                    MoTa = t.MoTa
                }).FirstOrDefault();
            }
        }
        public DTO_TuyenDuong LayThongTinTuyen(int maTuyen)
        {
            using (var ctx = new TicketSalesContext())
            {
                return ctx.TuyenDuongs.Where(td => td.MaTuyen == maTuyen).Select(td => new DTO_TuyenDuong
                {
                    MaTuyen = td.MaTuyen,
                    MaGaDi = td.MaGaDi ?? 0,
                    MaGaDen = td.MaGaDen ?? 0,
                    KhoangCach = td.KhoangCach ?? 0,
                    ThoiGianDuKien = td.ThoiGianDuKien ?? new TimeSpan(0, 0, 0),
                    MoTa = td.MoTa
                }).FirstOrDefault();
            }
        }
    }
}
