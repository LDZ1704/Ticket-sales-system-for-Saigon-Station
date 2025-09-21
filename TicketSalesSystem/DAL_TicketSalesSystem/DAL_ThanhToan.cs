using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TicketSalesSystem
{
    public class DAL_ThanhToan
    {
        public int ThemThanhToan(DTO_ThanhToan dto)
        {
            using (var ctx = new TicketSalesContext())
            {
                var thanhToan = new ThanhToan
                {
                    MaNguoiDung = dto.MaNguoiDung,
                    HinhThuc = dto.HinhThuc,
                    ThoiDiem = dto.ThoiDiem,
                    TrangThai = dto.TrangThai,
                    NgayThanhToan = dto.NgayThanhToan
                };

                ctx.ThanhToans.Add(thanhToan);
                ctx.SaveChanges();
                return thanhToan.MaThanhToan;
            }
        }

        public bool CapNhatTrangThaiThanhToan(int maThanhToan, string trangThaiMoi)
        {
            try
            {
                using (var db = new TicketSalesContext())
                {
                    var thanhToan = db.ThanhToans.Find(maThanhToan);
                    if (thanhToan == null)
                        return false;

                    thanhToan.TrangThai = trangThaiMoi;
                    thanhToan.NgayThanhToan = DateTime.Now;

                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] CapNhatTrangThaiThanhToan: " + ex.Message);
                return false;
            }
        }

        // Gợi ý: có thể viết thêm hàm lấy ra nếu chưa có
        public ThanhToan LayThanhToanTheoId(int maThanhToan)
        {
            using (var db = new TicketSalesContext())
            {
                return db.ThanhToans.Find(maThanhToan);
            }
        }
    }
}
