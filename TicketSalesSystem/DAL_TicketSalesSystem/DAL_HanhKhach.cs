using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TicketSalesSystem
{
    public class DAL_HanhKhach
    {
        public DTO_HanhKhach LayHanhKhachBangSoGiayTo(string soGiayTo)
        {
            using (var ctx = new TicketSalesContext())
            {
                var hanhKhach = ctx.HanhKhaches.FirstOrDefault(h => h.SoGiayTo == soGiayTo);
                if (hanhKhach == null) return null;

                return new DTO_HanhKhach
                {
                    MaHanhKhach = hanhKhach.MaHanhKhach,
                    HoTen = hanhKhach.HoTen,
                    GioiTinh = hanhKhach.GioiTinh,
                    NgaySinh = hanhKhach.NgaySinh,
                    LoaiGiayTo = hanhKhach.LoaiGiayTo,
                    SoGiayTo = hanhKhach.SoGiayTo,
                    QuocTich = hanhKhach.QuocTich,
                    Email = hanhKhach.Email,
                    SoDienThoai = hanhKhach.SoDienThoai,
                    GhiChu = hanhKhach.GhiChu
                };
            }
        }

        public DTO_HanhKhach LayHanhKhachBangEmailHoacSDT(string email, string sdt)
        {
            using (var ctx = new TicketSalesContext())
            {
                var hanhKhach = ctx.HanhKhaches.FirstOrDefault(h =>
                    (h.Email == email && !string.IsNullOrEmpty(email)) ||
                    (h.SoDienThoai == sdt && !string.IsNullOrEmpty(sdt))
                );

                if (hanhKhach == null) return null;

                return new DTO_HanhKhach
                {
                    MaHanhKhach = hanhKhach.MaHanhKhach,
                    HoTen = hanhKhach.HoTen,
                    GioiTinh = hanhKhach.GioiTinh,
                    NgaySinh = hanhKhach.NgaySinh,
                    LoaiGiayTo = hanhKhach.LoaiGiayTo,
                    SoGiayTo = hanhKhach.SoGiayTo,
                    QuocTich = hanhKhach.QuocTich,
                    Email = hanhKhach.Email,
                    SoDienThoai = hanhKhach.SoDienThoai,
                    GhiChu = hanhKhach.GhiChu
                };
            }
        }

        public int ThemHanhKhach(DTO_HanhKhach dto)
        {
            using (var ctx = new TicketSalesContext())
            {
                var hanhKhach = new HanhKhach
                {
                    HoTen = dto.HoTen,
                    GioiTinh = dto.GioiTinh,
                    NgaySinh = dto.NgaySinh,
                    LoaiGiayTo = dto.LoaiGiayTo,
                    SoGiayTo = dto.SoGiayTo,
                    QuocTich = dto.QuocTich,
                    Email = dto.Email,
                    SoDienThoai = dto.SoDienThoai,
                    GhiChu = dto.GhiChu
                };

                ctx.HanhKhaches.Add(hanhKhach);
                ctx.SaveChanges();
                return hanhKhach.MaHanhKhach;
            }
        }

        public bool CapNhatHanhKhach(DTO_HanhKhach dto)
        {
            using (var ctx = new TicketSalesContext())
            {
                var hanhKhach = ctx.HanhKhaches.FirstOrDefault(h => h.MaHanhKhach == dto.MaHanhKhach);
                if (hanhKhach == null) return false;

                hanhKhach.HoTen = dto.HoTen;
                hanhKhach.GioiTinh = dto.GioiTinh;
                hanhKhach.NgaySinh = dto.NgaySinh;
                hanhKhach.LoaiGiayTo = dto.LoaiGiayTo;
                hanhKhach.SoGiayTo = dto.SoGiayTo;
                hanhKhach.QuocTich = dto.QuocTich;
                hanhKhach.Email = dto.Email;
                hanhKhach.SoDienThoai = dto.SoDienThoai;
                hanhKhach.GhiChu = dto.GhiChu;

                return ctx.SaveChanges() > 0;
            }
        }
    }
}
