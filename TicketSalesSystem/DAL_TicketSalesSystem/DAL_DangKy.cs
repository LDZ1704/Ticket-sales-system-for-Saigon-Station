using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TicketSalesSystem
{
    public class DAL_DangKy
    {
        private DAL_TaiKhoan dal_TaiKhoan = new DAL_TaiKhoan();
        private DAL_NguoiDung dal_NguoiDung = new DAL_NguoiDung();

        public bool ThemNguoiDungVaTaiKhoan(NguoiDung entity_NguoiDung, TaiKhoan entity_TaiKhoan)
        {
            using (var ctx = new TicketSalesContext())
            using (var transaction = ctx.Database.BeginTransaction())
            {
                try
                {
                    bool okNguoiDung = dal_NguoiDung.ThemNguoiDung(entity_NguoiDung, ctx);
                    if (!okNguoiDung)
                        throw new Exception("Thêm người dùng thất bại!");

                    entity_TaiKhoan.MaNguoiDung = entity_NguoiDung.MaNguoiDung;
                    bool okTaiKhoan = dal_TaiKhoan.ThemTaiKhoan(entity_TaiKhoan, ctx);
                    if (!okTaiKhoan)
                        throw new Exception("Thêm tài khoản thất bại!");

                    transaction.Commit();
                    return true;
                }
            }
    }
}
