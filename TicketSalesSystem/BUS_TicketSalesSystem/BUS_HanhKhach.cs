using DAL_TicketSalesSystem;
using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TicketSalesSystem
{
    public class BUS_HanhKhach
    {
        private readonly DAL_HanhKhach dalHanhKhach = new DAL_HanhKhach();
        public DTO_HanhKhach LayHanhKhachBangSoGiayTo(string soGiayTo)
        {
            return dalHanhKhach.LayHanhKhachBangSoGiayTo(soGiayTo);
        }

        public DTO_HanhKhach TaoHanhKhachTuNguoiDung(DTO_NguoiDung nguoiDung)
        {
            if (nguoiDung == null) return null;

            return new DTO_HanhKhach
            {
                HoTen = $"{nguoiDung.Ho} {nguoiDung.Ten}",
                GioiTinh = "Nam", //chưa xử lý
                NgaySinh = nguoiDung.NgaySinh,
                LoaiGiayTo = "CCCD", //cố định
                SoGiayTo = "", //chưa xử lý
                QuocTich = "Việt Nam",
                Email = nguoiDung.Email,
                SoDienThoai = nguoiDung.SoDienThoai
            };
        }

        public DTO_HanhKhach LayHanhKhachBangEmailHoacSDT(string email, string sdt)
        {
            try
            {
                return dalHanhKhach.LayHanhKhachBangEmailHoacSDT(email, sdt);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tìm hành khách: {ex.Message}");
            }
        }
    }
}
