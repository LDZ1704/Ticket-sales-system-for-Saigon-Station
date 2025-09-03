using DAL_TicketSalesSystem;
using DTO_TicketSalesSystem;
using DTO_TicketSalesSystem.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DTO_TicketSalesSystem.enums;

namespace BUS_TicketSalesSystem
{
    public class BUS_TaiKhoan
    {
        private DAL_TaiKhoan dal_TaiKhoan = new DAL_TaiKhoan();

        public bool KiemTraTenDangNhapTrung(string tenDangNhap)
        {
            return dal_TaiKhoan.KiemTraTenDangNhapTrung(tenDangNhap);
        }

        // Đăng nhập
        public DTO_TaiKhoan DangNhap(string tenDangNhap, string matKhau)
        {
            var entity = dal_TaiKhoan.DangNhap(tenDangNhap, matKhau);
            if (entity == null) return null;

            return new DTO_TaiKhoan
            {
                MaTaiKhoan = entity.MaTaiKhoan,
                TenDangNhap = entity.TenDangNhap,
                MaNguoiDung = (int)entity.MaNguoiDung,
                TrangThai = entity.TrangThai == "HOATDONG"
                    ? TrangThai.HOATDONG
                    : TrangThai.KHOA
            };
        }
    }
}
