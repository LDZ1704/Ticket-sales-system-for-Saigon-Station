using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TicketSalesSystem
{
    public class DAL_GaTau
    {
        public List<DTO_GaTau> LayTatCaGaTau()
        {
            using (var ctx = new TicketSalesContext())
            {
                return ctx.GaTaus
                    .Select(g => new DTO_GaTau
                    {
                        MaGaTau = g.MaGaTau,
                        TenGa = g.TenGa,
                        DiaChi = g.DiaChi,
                        Mien = g.Mien,
                        GhiChu = g.GhiChu
                    }).OrderBy(g => g.TenGa).ToList();
            }
        }
    }
}
