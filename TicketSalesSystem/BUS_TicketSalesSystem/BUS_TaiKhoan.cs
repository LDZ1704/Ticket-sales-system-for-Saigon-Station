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

        public bool ThemTaiKhoan(TaiKhoan entity)
        {
            return dal_TaiKhoan.ThemTaiKhoan(entity);
        }

        public string ThemTaiKhoan(DTO_TaiKhoan dto)
        {

            if (dto == null)
                return "Lỗi dữ liệu không hợp lệ.";

            if (string.IsNullOrWhiteSpace(dto.TenDangNhap) || string.IsNullOrWhiteSpace(dto.MatKhau))
                return "Lỗi tên đăng nhập và mật khẩu là bắt buộc";

            // Map DTO → Entity
            var entity = new TaiKhoan
            {
                TenDangNhap = dto.TenDangNhap,
                MatKhau = PasswordHasher.Hash(dto.MatKhau),
                TrangThai = dto.TrangThai.ToString()
            };

            bool result = dal_TaiKhoan.ThemTaiKhoan(entity);
            return result ? "Đăng ký thành công." : "Lỗi khi đăng ký.";
        }

        // Kiểm tra người dùng đã có tài khoản hay chưa
        public bool KiemTraDaCoTaiKhoan(int maNguoiDung)
        {
            return dal_TaiKhoan.KiemTraDaCoTaiKhoan(maNguoiDung);
        }

        //Đổi mật khẩu
        public string DoiMatKhau(string tenDangNhap, string matKhauCu, string matKhauMoi)
        {
            if (string.IsNullOrWhiteSpace(matKhauCu)) return "Vui lòng nhập mật khẩu cũ";
            if (string.IsNullOrWhiteSpace(matKhauMoi)) return "Vui lòng nhập mật khẩu mới";
            if (matKhauMoi.Length < 6) return "Mật khẩu mới phải có ít nhất 6 ký tự";
            if (matKhauCu == matKhauMoi) return "Mật khẩu mới phải khác mật khẩu cũ";

            //Có thể thêm ràng buộc nếu được
            //if (!KiemTraDoManhMatKhau(matKhauMoi))
            //    return "Mật khẩu phải có kí tự chữ và số!";

            try
            {
                if (!dal_TaiKhoan.KiemTraTaiKhoanHopLe(tenDangNhap))
                    return "Tài khoản không tồn tại hoặc đã bị khóa";
                if (!dal_TaiKhoan.KiemTraMatKhauCu(tenDangNhap, matKhauCu))
                    return "Mật khẩu cũ không đúng";
                if (dal_TaiKhoan.DoiMatKhau(tenDangNhap, matKhauMoi))
                    return "Đổi mật khẩu thành công";
                else
                    return "Có lỗi xảy ra, vui lòng thử lại";
            }
            catch (Exception ex)
            {
                return "Lỗi hệ thống: " + ex.Message;
            }
        }

        //private bool KiemTraDoManhMatKhau(string matKhau)
        //{
        //    return matKhau.Any(char.IsLetter) && matKhau.Any(char.IsDigit);
        //}

        //Lấy mã tài khoản theo tên
        public int LayUserIDBangUsername(string username)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                    return 1;

                var userId = dal_TaiKhoan.LayMaNguoiDungTheoUsername(username);
                return userId ?? 1;
            }
            catch
            {
                return 1;
            }
        }
    }
}
