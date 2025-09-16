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
                var toa = ctx.ToaTaus
                    .Where(t => t.MaToa == maToa)
                    .Select(t => new DTO_ToaTau
                    {
                        MaToa = t.MaToa,
                        TenToa = t.TenToa,
                        LoaiGhe = t.LoaiGhe,
                        ViTri = t.ViTri,
                        MaTau = t.MaTau ?? 0,
                        //thêm hiển thị
                        DisplayText = t.TenToa + " - " + t.LoaiGhe,
                        SoChoTrong = t.Ghes.Count(g => g.TrangThai == "TRONG")
                    })
                    .FirstOrDefault();

                return toa;
            }
        }

        public List<DTO_ToaTau> LayToaBangChuyenTau(int maChuyen)
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = from ct in ctx.ChuyenTaus
                            join tt in ctx.ToaTaus on ct.MaTau equals tt.MaTau
                            where ct.MaChuyen == maChuyen
                            orderby tt.ViTri
                            select new DTO_ToaTau
                            {
                                MaToa = tt.MaToa,
                                TenToa = tt.TenToa,
                                LoaiGhe = tt.LoaiGhe,
                                ViTri = tt.ViTri,
                                MaTau = tt.MaTau ?? 0
                            };

                return query.ToList();
            }
        }

        public int LaySoChoTrongBangToa(int maToa)
        {
            using (var ctx = new TicketSalesContext())
            {
                return ctx.Ghes.Count(g => g.MaToa == maToa && g.TrangThai == "TRONG");
            }
        }
    }
}
