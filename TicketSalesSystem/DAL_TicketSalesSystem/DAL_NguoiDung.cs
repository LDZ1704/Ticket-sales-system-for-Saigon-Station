using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TicketSalesSystem
{
    public class DAL_NguoiDung
    {
        // Thêm người dùng mới vào cơ sở dữ liệu
        public bool ThemNguoiDung(NguoiDung entity)
        {
            using (var ctx = new TicketSalesContext())
            {
                try
                {
                    ctx.NguoiDungs.Add(entity);
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
        public bool ThemNguoiDung(NguoiDung entity, TicketSalesContext ctx)
        {
            try
            {
                ctx.NguoiDungs.Add(entity);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        //Lấy người dùng theo ID
        public NguoiDung LayNguoiDungTheoID(int id)
        {
            using (var ctx = new TicketSalesContext())
            {
                return ctx.NguoiDungs.Find(id);
            }
        }

        //Lấy người dùng theo số điện thoại
        public NguoiDung LayNguoiDungTheoSoDienThoai(string soDienThoai)
        {
            using (var ctx = new TicketSalesContext())
            {
                return ctx.NguoiDungs.FirstOrDefault(nd => nd.SoDienThoai == soDienThoai);
            }
        }

        //Lấy mã người dùng theo số điện thoại
        public int? LayMaNguoiDungTheoSoDienThoai(string soDienThoai)
        {
            using (var ctx = new TicketSalesContext())
            {
                var nguoiDung = ctx.NguoiDungs.FirstOrDefault(nd => nd.SoDienThoai == soDienThoai);
                return nguoiDung?.MaNguoiDung;
            }
        }

        // Kiểm tra tên đăng nhập có trùng không
        public bool KiemTraSoDienThoaiTrung(string soDienThoai)
        {
            using (var ctx = new TicketSalesContext())
            {
                return ctx.NguoiDungs.Any(nd => nd.SoDienThoai == soDienThoai);
            }
        }

        // Kiêm tra email có trùng không
        public bool KiemTraEmailTrung(string email)
        {
            using (var ctx = new TicketSalesContext())
            {
                return ctx.NguoiDungs.Any(nd => nd.Email == email);
            }
        }

        // Lấy tất cả người dùng
        public List<NguoiDung> LayTatCaNguoiDung()
        {
            using (var ctx = new TicketSalesContext())
            {
                return ctx.NguoiDungs.ToList();
            }
        }

        // Xóa người dùng theo ID
        public bool XoaNguoiDung(int id)
        {
            using (var ctx = new TicketSalesContext())
            {
                var user = ctx.NguoiDungs.Find(id);
                if (user != null)
                {
                    ctx.NguoiDungs.Remove(user);
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }

        // Cập nhật thông tin người dùng
        public bool CapNhatNguoiDung(DTO_NguoiDung dto)
        {
            if (dto == null || dto.MaNguoiDung == null)
                return false;
            using (var ctx = new TicketSalesContext())
            {
                var user = ctx.NguoiDungs.Find(dto.MaNguoiDung);
                if (user != null)
                {
                    user.Ho = dto.Ho;
                    user.Ten = dto.Ten;
                    user.NgaySinh = dto.NgaySinh;
                    user.Email = dto.Email;
                    user.SoDienThoai = dto.SoDienThoai;
                    user.NgayTao = dto.NgayTao;
                    user.LoaiNguoiDung = dto.LoaiNguoiDung.ToString();
                    ctx.SaveChanges();
                    return true;
                }
                return false;
            }
        }
    }
}
