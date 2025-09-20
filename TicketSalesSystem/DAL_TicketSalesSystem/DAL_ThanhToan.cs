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

        public bool CapNhatTrangThaiThanhToan(int maThanhToan, string trangThai)
        {
            using (var ctx = new TicketSalesContext())
            {
                var thanhToan = ctx.ThanhToans.Find(maThanhToan);
                if (thanhToan != null)
                {
                    thanhToan.TrangThai = trangThai;
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        public DTO_ThanhToan LayThanhToanTheoId(int maThanhToan)
        {
            using (var ctx = new TicketSalesContext())
            {
                var entity = ctx.ThanhToans.Find(maThanhToan);
                if (entity == null) return null;

                return new DTO_ThanhToan
                {
                    MaThanhToan = entity.MaThanhToan,
                    MaNguoiDung = (int)entity.MaNguoiDung,
                    HinhThuc = entity.HinhThuc,
                    ThoiDiem = (DateTime)entity.ThoiDiem,
                    TrangThai = entity.TrangThai,
                    NgayThanhToan = (DateTime)entity.NgayThanhToan
                };
            }
        }
    }
}
