using DAL_TicketSalesSystem;
using DTO_TicketSalesSystem;
using DTO_TicketSalesSystem.utils;
using System;

namespace BUS_TicketSalesSystem
{
    public class BUS_DangKy
    {

        private readonly DAL_DangKy dal_DangKy = new DAL_DangKy();
        private readonly BUS_NguoiDung busNguoiDung = new BUS_NguoiDung();
        private readonly BUS_TaiKhoan busTaiKhoan = new BUS_TaiKhoan();

        public string DangKyNguoiDungVaTaiKhoan(DTO_NguoiDung dtoNguoiDung, DTO_TaiKhoan dtoTaiKhoan)
        {
            // Kiểm tra đầu vào
            if (dtoNguoiDung == null || dtoTaiKhoan == null)
                return "Lỗi dữ liệu không hợp lệ.";
            if (string.IsNullOrWhiteSpace(dtoTaiKhoan.TenDangNhap) || string.IsNullOrWhiteSpace(dtoTaiKhoan.MatKhau))
                return "Lỗi tên đăng nhập và mật khẩu là bắt buộc.";
            if (string.IsNullOrWhiteSpace(dtoNguoiDung.Email) || string.IsNullOrWhiteSpace(dtoNguoiDung.SoDienThoai))
                return "Lỗi email và số điện thoại là bắt buộc.";

            // Kiểm tra số điện thoại đã có người dùng chưa
            int? maNguoiDung = busNguoiDung.LayMaNguoiDungTheoSoDienThoai(dtoNguoiDung.SoDienThoai);

            if (maNguoiDung.HasValue)
            {
                // Đã có người dùng → kiểm tra đã có tài khoản chưa
                bool daCoTaiKhoan = busTaiKhoan.KiemTraDaCoTaiKhoan(maNguoiDung.Value);
                if (daCoTaiKhoan)
                {
                    return "Lỗi người dùng này đã có tài khoản.";
                }

                // Chưa có tài khoản → thêm tài khoản mới
                var entityTaiKhoan = new TaiKhoan
                {
                    TenDangNhap = dtoTaiKhoan.TenDangNhap,
                    MatKhau = PasswordHasher.Hash(dtoTaiKhoan.MatKhau),
                    TrangThai = dtoTaiKhoan.TrangThai.ToString(),
                    MaNguoiDung = maNguoiDung.Value
                };

                bool result = busTaiKhoan.ThemTaiKhoan(entityTaiKhoan); // bạn nên viết thêm overload nhận Entity
                return result ? "Tạo tài khoản thành công." : "Lỗi khi tạo tài khoản.";
            }
            else
            {
                // Chưa có người dùng → thêm người dùng và tài khoản cùng lúc
                var entityNguoiDung = new NguoiDung
                {
                    Ho = dtoNguoiDung.Ho,
                    Ten = dtoNguoiDung.Ten,
                    NgaySinh = dtoNguoiDung.NgaySinh,
                    Email = dtoNguoiDung.Email,
                    SoDienThoai = dtoNguoiDung.SoDienThoai,
                    NgayTao = dtoNguoiDung.NgayTao,
                    LoaiNguoiDung = dtoNguoiDung.LoaiNguoiDung.ToString()
                };

                var entityTaiKhoan = new TaiKhoan
                {
                    TenDangNhap = dtoTaiKhoan.TenDangNhap,
                    MatKhau = PasswordHasher.Hash(dtoTaiKhoan.MatKhau),
                    TrangThai = dtoTaiKhoan.TrangThai.ToString(),
                    NgayTao = dtoTaiKhoan.NgayTao
                    // MaNguoiDung sẽ được gán sau khi thêm
                };

                bool result = dal_DangKy.ThemNguoiDungVaTaiKhoan(entityNguoiDung, entityTaiKhoan);
                return result ? "Đăng ký người dùng và tài khoản thành công." : "Lỗi khi đăng ký.";
            }
        }
    }
}
