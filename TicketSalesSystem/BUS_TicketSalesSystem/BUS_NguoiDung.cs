using DAL_TicketSalesSystem;
using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TicketSalesSystem
{
    public class BUS_NguoiDung
    {
        private DAL_NguoiDung dal = new DAL_NguoiDung();

        // Xử lý đăng ký người dùng mới
        public string DangKyNguoiDung(DTO_NguoiDung dto)
        {
            if (dto == null)
                return "Dữ liệu không hợp lệ.";

            if (string.IsNullOrWhiteSpace(dto.Email) || string.IsNullOrWhiteSpace(dto.SoDienThoai))
                return "Email và số điện thoại là bắt buộc.";

            // Map DTO → Entity
            var entity = new NguoiDung
            {
                Ho = dto.Ho,
                Ten = dto.Ten,
                NgaySinh = dto.NgaySinh,
                Email = dto.Email,
                SoDienThoai = dto.SoDienThoai,
                NgayTao = dto.NgayTao,
                LoaiNguoiDung = dto.LoaiNguoiDung.ToString()
            };

            bool result = dal.ThemNguoiDung(entity);
            return result ? "Đăng ký thành công." : "Lỗi khi đăng ký.";
        }

        // Fix for CS0136: Rename the local variable in LayNguoiDungTheoID to avoid name conflict
        public DTO_NguoiDung LayNguoiDungTheoID(int id)
        {
            var nguoiDungEntity = dal.LayNguoiDungTheoID(id);
            if (nguoiDungEntity == null) return null;

            Enum.TryParse(nguoiDungEntity.LoaiNguoiDung, true, out LoaiNguoiDung loaiNguoiDungParsed);

            return new DTO_NguoiDung
            {
                MaNguoiDung = nguoiDungEntity.MaNguoiDung,
                Ho = nguoiDungEntity.Ho,
                Ten = nguoiDungEntity.Ten,
                NgaySinh = (DateTime)nguoiDungEntity.NgaySinh,
                Email = nguoiDungEntity.Email,
                SoDienThoai = nguoiDungEntity.SoDienThoai,
                NgayTao = (DateTime)nguoiDungEntity.NgayTao,
                LoaiNguoiDung = loaiNguoiDungParsed
            };
        }

        //Lấy mã người dùng theo số điện thoại
        public int? LayMaNguoiDungTheoSoDienThoai(string soDienThoai)
        {
            return dal.LayMaNguoiDungTheoSoDienThoai(soDienThoai);
        }

        // Kiểm tra số điện thoại có trùng không

        public bool KiemTraSoDienThoaiTrung(string soDienThoai)
        {
            return dal.KiemTraSoDienThoaiTrung(soDienThoai);
        }

        public bool KiemTraEmailTrung(string email)
        {
            return dal.KiemTraEmailTrung(email);
        }

        // Cập nhật người dùng
        public bool CapNhatNguoiDung(DTO_NguoiDung dto)
        {
            return dal.CapNhatNguoiDung(dto);
        }

        // Xóa người dùng
        public bool XoaNguoiDung(int id)
        {
            return dal.XoaNguoiDung(id);
        }

        // Lấy tất cả người dùng
        public List<DTO_NguoiDung> LayTatCaNguoiDung()
        {
            var ds = dal.LayTatCaNguoiDung();
            var result = new List<DTO_NguoiDung>();

            foreach (var entity in ds)
            {
                Enum.TryParse(entity.LoaiNguoiDung, true, out LoaiNguoiDung loaiNguoiDungParsed);
                result.Add(new DTO_NguoiDung
                {
                    MaNguoiDung = entity.MaNguoiDung,
                    Ho = entity.Ho,
                    Ten = entity.Ten,
                    NgaySinh = (DateTime)entity.NgaySinh,
                    Email = entity.Email,
                    SoDienThoai = entity.SoDienThoai,
                    NgayTao = (DateTime)entity.NgayTao,
                    LoaiNguoiDung = loaiNguoiDungParsed
                });
            }

            return result;
        }
    }
}

