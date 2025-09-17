using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TicketSalesSystem
{
    public class DAL_ToaTau
    {
        public DTO_ToaTau LayToaBangId(int maToa)
        {
            using (var ctx = new TicketSalesContext())
            {
                var toa = ctx.ToaTaus.FirstOrDefault(t => t.MaToa == maToa);
                if (toa == null) return null;

                var dto = new DTO_ToaTau
                {
                    MaToa = toa.MaToa,
                    TenToa = toa.TenToa,
                    LoaiGhe = toa.LoaiGhe,
                    GiaVe = toa.GiaVe ?? 0,
                    ViTri = toa.ViTri ?? 0,
                    MaTau = toa.MaTau ?? 0
                };

                dto.DisplayText = $"{dto.TenToa} - {dto.LoaiGhe} ({dto.GiaVe:N0} VND)";

                return dto;
            }
        }

        public List<DTO_ToaTau> LayToaBangChuyenTau(int maChuyen)
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = from ct in ctx.ChuyenTaus
                            join t in ctx.Taus on ct.MaTau equals t.MaTau
                            join toa in ctx.ToaTaus on t.MaTau equals toa.MaTau
                            where ct.MaChuyen == maChuyen
                            orderby toa.ViTri
                            select new DTO_ToaTau
                            {
                                MaToa = toa.MaToa,
                                TenToa = toa.TenToa,
                                LoaiGhe = toa.LoaiGhe,
                                GiaVe = toa.GiaVe ?? 0,
                                ViTri = toa.ViTri ?? 0,
                                MaTau = toa.MaTau ?? 0
                            };

                var list = query.ToList();

                foreach (var item in list)
                {
                    item.DisplayText = $"{item.TenToa} - {item.LoaiGhe} ({item.GiaVe:N0} VND)";
                }
                return list;
            }
        }

        public List<DTO_ToaTau> LayToaBangTau(int maTau)
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = ctx.ToaTaus
                    .Where(toa => toa.MaTau == maTau)
                    .OrderBy(toa => toa.ViTri)
                    .Select(toa => new DTO_ToaTau
                    {
                        MaToa = toa.MaToa,
                        TenToa = toa.TenToa,
                        LoaiGhe = toa.LoaiGhe,
                        GiaVe = toa.GiaVe ?? 0,
                        ViTri = toa.ViTri ?? 0,
                        MaTau = toa.MaTau ?? 0
                    });

                var list = query.ToList();

                foreach (var item in list)
                {
                    item.DisplayText = $"{item.TenToa} - {item.LoaiGhe} ({item.GiaVe:N0} VND)";
                }
                return list;
            }
        }

        public int LaySoChoTrongBangToa(int maToa)
        {
            using (var ctx = new TicketSalesContext())
            {
                return ctx.Ghes.Count(g => g.MaToa == maToa && g.TrangThai == "TRONG");
            }
        }

        public decimal LayGiaVeBangMaToa(int maToa)
        {
            using (var ctx = new TicketSalesContext())
            {
                var toa = ctx.ToaTaus.FirstOrDefault(t => t.MaToa == maToa);
                return toa?.GiaVe ?? 0;
            }
        }

        public string LayThongTinToaBangMaToa(int maToa)
        {
            using (var ctx = new TicketSalesContext())
            {
                var toa = ctx.ToaTaus.FirstOrDefault(t => t.MaToa == maToa);
                if (toa == null) return string.Empty;

                return $"{toa.TenToa} - {toa.LoaiGhe}";
            }
        }

        public List<DTO_ToaTau> LayTatCaToa()
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = ctx.ToaTaus
                    .OrderBy(toa => toa.MaTau)
                    .ThenBy(toa => toa.ViTri)
                    .Select(toa => new DTO_ToaTau
                    {
                        MaToa = toa.MaToa,
                        TenToa = toa.TenToa,
                        LoaiGhe = toa.LoaiGhe,
                        GiaVe = toa.GiaVe ?? 0,
                        ViTri = toa.ViTri ?? 0,
                        MaTau = toa.MaTau ?? 0
                    });

                var list = query.ToList();

                foreach (var item in list)
                {
                    item.DisplayText = $"{item.TenToa} - {item.LoaiGhe} ({item.GiaVe:N0} VND)";
                }

                return list;
            }
        }
    }
}
