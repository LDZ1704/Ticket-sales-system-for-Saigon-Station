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
        public bool ThemTaiKhoan(DTO_TaiKhoan dto)
        {
            using (var ctx = new TicketSalesContext())
            {
                try
                {
                    var tk = new TaiKhoan
                    {
                        TenDangNhap = dto.TenDangNhap,
                        MatKhau = PasswordHasher.Hash(dto.MatKhau), // băm mật khẩu
                        NgayTao = dto.NgayTao,
                        TrangThai = dto.TrangThai.ToString(),
                        MaNguoiDung = dto.MaNguoiDung
                    };

                    ctx.TaiKhoans.Add(tk);
                    ctx.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi khi thêm tài khoản: " + ex.Message);
                    return false;
                }
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
    }
}
