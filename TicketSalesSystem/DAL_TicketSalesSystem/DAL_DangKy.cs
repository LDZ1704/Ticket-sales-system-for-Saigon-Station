using System;

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
                    // Dùng cùng context để thêm người dùng
                    bool okNguoiDung = dal_NguoiDung.ThemNguoiDung(entity_NguoiDung, ctx);
                    if (!okNguoiDung)
                        throw new Exception("Thêm người dùng thất bại.");

                    // Lấy MaNguoiDung sau khi thêm
                    entity_TaiKhoan.MaNguoiDung = entity_NguoiDung.MaNguoiDung;

                    // Dùng cùng context để thêm tài khoản
                    bool okTaiKhoan = dal_TaiKhoan.ThemTaiKhoan(entity_TaiKhoan, ctx);
                    if (!okTaiKhoan)
                        throw new Exception("Thêm tài khoản thất bại.");

                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Lỗi đăng ký: " + ex.Message);
                    return false;
                }
            }
        }
    }
}
