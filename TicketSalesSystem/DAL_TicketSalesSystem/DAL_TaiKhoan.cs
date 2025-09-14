using DTO_TicketSalesSystem;
using DTO_TicketSalesSystem.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TicketSalesSystem
{
    public class DAL_TaiKhoan
    {
        // Thêm tài khoản mới với mật khẩu được băm
        public bool ThemTaiKhoan(TaiKhoan entity)
        {
            using (var ctx = new TicketSalesContext())
            {
                try
                {
                    ctx.TaiKhoans.Add(entity);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
        public bool ThemTaiKhoan(TaiKhoan entity, TicketSalesContext ctx)
        {
            try
            {
                ctx.TaiKhoans.Add(entity);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        // Đăng nhập với kiểm tra mật khẩu băm
        public TaiKhoan DangNhap(string tenDangNhap, string matKhau)
        {
            using (var ctx = new TicketSalesContext())
            {
                string hashedPassword = PasswordHasher.Hash(matKhau); // băm mật khẩu người nhập

                return ctx.TaiKhoans
                          .FirstOrDefault(tk =>
                              tk.TenDangNhap == tenDangNhap &&
                              tk.MatKhau == hashedPassword &&
                              tk.TrangThai == "HOATDONG");
            }
        }

        // Kiểm tra tên đăng nhập có trùng không
        public bool KiemTraTenDangNhapTrung(string tenDangNhap)
        {
            using (var ctx = new TicketSalesContext())
            {
                return ctx.TaiKhoans.Any(tk => tk.TenDangNhap == tenDangNhap);
            }
        }

        public bool KiemTraDaCoTaiKhoan(int maNguoiDung)
        {
            using (var ctx = new TicketSalesContext())
            {
                return ctx.TaiKhoans.Any(tk => tk.MaNguoiDung == maNguoiDung);
            }
        }

        //Đổi mật khẩu
        public bool KiemTraMatKhauCu(string tenDangNhap, string matKhauCu)
        {
            using (var ctx = new TicketSalesContext())
            {
                var taiKhoan = ctx.TaiKhoans.FirstOrDefault(tk => tk.TenDangNhap == tenDangNhap);
                if (taiKhoan == null) return false;

                return PasswordHasher.Verify(matKhauCu, taiKhoan.MatKhau);
            }
        }
        public bool DoiMatKhau(string tenDangNhap, string matKhauMoi)
        {
            using (var ctx = new TicketSalesContext())
            {
                var taiKhoan = ctx.TaiKhoans.FirstOrDefault(tk => tk.TenDangNhap == tenDangNhap);
                if (taiKhoan == null) return false;

                taiKhoan.MatKhau = PasswordHasher.Hash(matKhauMoi);
                return ctx.SaveChanges() > 0;
            }
        }
        public bool KiemTraTaiKhoanHopLe(string tenDangNhap)
        {
            using (var ctx = new TicketSalesContext())
            {
                var taiKhoan = ctx.TaiKhoans.FirstOrDefault(tk => tk.TenDangNhap == tenDangNhap);
                return taiKhoan != null && taiKhoan.TrangThai == "HOATDONG";
            }
        }

        //Lấy tài khoản theo tên
        public TaiKhoan LayTaiKhoanTheoTen(string tenDangNhap)
        {
            using (var context = new TicketSalesContext())
            {
                return context.TaiKhoans.FirstOrDefault(tk => tk.TenDangNhap == tenDangNhap);
            }
        }

        //Lấy mã người dùng theo tên
        public int? LayMaNguoiDungTheoUsername(string tenDangNhap)
        {
            using (var ctx = new TicketSalesContext())
            {
                var taiKhoan = ctx.TaiKhoans.FirstOrDefault(tk => tk.TenDangNhap == tenDangNhap);
                return taiKhoan?.MaNguoiDung;
            }
        }
    }
}
