using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TicketSalesSystem
{
    public class DAL_Ghe
    {
        public List<DTO_Ghe> LayGheBangToa(int maToa)
        {
            using (var ctx = new TicketSalesContext())
            {
                var ghes = ctx.Ghes
                .Where(g => g.MaToa == maToa)
                .OrderBy(g => g.SoHieu)
                .Select(g => new DTO_Ghe
                {
                    MaGhe = g.MaGhe,
                    SoHieu = g.SoHieu,
                    ViTri = g.ViTri,
                    TrangThai = g.TrangThai,
                    MaToa = g.MaToa ?? 0
                })
                .ToList();

                return ghes;
            }
        }

        public bool ChinhSuaTrangThaiGhe(int maGhe, string trangThai)
        {
            using (var ctx = new TicketSalesContext())
            {
                var ghe = ctx.Ghes.FirstOrDefault(g => g.MaGhe == maGhe);
                if (ghe == null) return false;

                ghe.TrangThai = trangThai;
                return ctx.SaveChanges() > 0;
            }
        }

        public DTO_Ghe LayGheBangId(int maGhe)
        {
            using ( var ctx = new TicketSalesContext())
            {
                var ghe = ctx.Ghes.FirstOrDefault(g => g.MaGhe == maGhe);
                if (ghe == null) return null;

                return new DTO_Ghe
                {
                    MaGhe = ghe.MaGhe,
                    SoHieu = ghe.SoHieu,
                    ViTri = ghe.ViTri,
                    TrangThai = ghe.TrangThai,
                    MaToa = ghe.MaToa ?? 0
                };
            }
        }
    }
}
