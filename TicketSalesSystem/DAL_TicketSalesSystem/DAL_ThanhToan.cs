using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TicketSalesSystem
{
    public class DAL_ThanhToan
    {
        public int ThemThanhToan(DTO_ThanhToan dto)
        {
            using (var ctx = new TicketSalesContext())
            {
                var thanhToan = new ThanhToan
                {
                    MaNguoiDung = dto.MaNguoiDung,
                    HinhThuc = dto.HinhThuc,
                    ThoiDiem = dto.ThoiDiem,
                    TrangThai = dto.TrangThai,
                    NgayThanhToan = dto.NgayThanhToan
                };

                ctx.ThanhToans.Add(thanhToan);
                ctx.SaveChanges();
                return thanhToan.MaThanhToan;
            }
        }
    }
}
