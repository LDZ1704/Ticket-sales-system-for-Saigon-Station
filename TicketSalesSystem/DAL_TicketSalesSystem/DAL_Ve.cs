using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TicketSalesSystem
{
    public class DAL_Ve
    {
        private DAL_Ghe dalGhe = new DAL_Ghe();

        public bool ThemVe(int maHanhKhach, int maChuyen, int maGhe, int maThanhToan, decimal giaVe, string maQR)
        {
            using (var ctx = new TicketSalesContext())
            {
                var ve = new Ve
                {
                    MaHanhKhach = maHanhKhach,
                    MaChuyen = maChuyen,
                    MaGhe = maGhe,
                    MaThanhToan = maThanhToan,
                    GiaVe = giaVe,
                    TrangThai = "DATHANHTOAN",
                    MaQR = maQR
                };

                ctx.Ves.Add(ve);
                return ctx.SaveChanges() > 0;
            }
        }

        public int ThemVe(DTO_Ve dto)
        {
            using (var ctx = new TicketSalesContext())
            {
                var ve = new Ve
                {
                    MaHanhKhach = dto.MaHanhKhach,
                    MaChuyen = dto.MaChuyen,
                    MaGhe = dto.MaGhe,
                    MaThanhToan = dto.MaThanhToan,
                    GiaVe = dto.GiaVe,
                    TrangThai = dto.TrangThai,
                    MaQR = dto.MaQR
                };

                ctx.Ves.Add(ve);
                ctx.SaveChanges();
                return ve.MaVe;
            }
        }

        public bool ThemDanhSachVe(List<DTO_Ve> danhSachVe)
        {
            try
            {
                using (var db = new TicketSalesContext())
                {
                    foreach (var ve in danhSachVe)
                    {
                        db.Ves.Add(new Ve
                        {
                            MaHanhKhach = ve.MaHanhKhach,
                            MaChuyen = ve.MaChuyen,
                            MaGhe = ve.MaGhe,
                            MaThanhToan = ve.MaThanhToan,
                            GiaVe = ve.GiaVe,
                            TrangThai = ve.TrangThai,
                            MaQR = ve.MaQR
                        });

                        // cập nhật trạng thái ghế bằng chính context này
                        var ghe = db.Ghes.Find(ve.MaGhe);
                        if (ghe != null)
                        {
                            Console.WriteLine($"[INFO] Update Ghế {ve.MaGhe} -> DADAT");
                            ghe.TrangThai = "DADAT";
                        }
                    }

                    int rows = db.SaveChanges();
                    Console.WriteLine($"[INFO] SaveChanges thành công, {rows} bản ghi bị ảnh hưởng.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[ERROR] ThemDanhSachVe thất bại: " + ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("[INNER] " + ex.InnerException.Message);
                if (ex.InnerException?.InnerException != null)
                    Console.WriteLine("[INNER2] " + ex.InnerException.InnerException.Message);
                return false;
            }
        }

        public List<DTO_Ve> LayVeBangNguoiDung(int maNguoiDung)
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = from v in ctx.Ves
                            join hk in ctx.HanhKhaches on v.MaHanhKhach equals hk.MaHanhKhach
                            join ct in ctx.ChuyenTaus on v.MaChuyen equals ct.MaChuyen
                            join td in ctx.TuyenDuongs on ct.MaTuyen equals td.MaTuyen
                            join gdi in ctx.GaTaus on td.MaGaDi equals gdi.MaGaTau
                            join gden in ctx.GaTaus on td.MaGaDen equals gden.MaGaTau
                            join g in ctx.Ghes on v.MaGhe equals g.MaGhe
                            join tt in ctx.ToaTaus on g.MaToa equals tt.MaToa
                            join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                            where th.MaNguoiDung == maNguoiDung
                            orderby th.NgayThanhToan descending
                            select new DTO_Ve
                            {
                                MaVe = v.MaVe,
                                MaHanhKhach = v.MaHanhKhach ?? 0,
                                MaChuyen = v.MaChuyen ?? 0,
                                MaGhe = v.MaGhe ?? 0,
                                MaThanhToan = v.MaThanhToan ?? 0,
                                GiaVe = v.GiaVe ?? 0,
                                TrangThai = v.TrangThai,
                                MaQR = v.MaQR
                            };
                return query.ToList();
            }
        }

        public bool ChinhSuaTrangThaiVe(int maVe, string trangThai)
        {
            using (var ctx = new TicketSalesContext())
            {
                var ve = ctx.Ves.FirstOrDefault(v => v.MaVe == maVe);
                if (ve == null) return false;

                ve.TrangThai = trangThai;
                return ctx.SaveChanges() > 0;
            }
        }

        public int LayMaGheBangVe(int maVe)
        {
            using (var ctx = new TicketSalesContext())
            {
                var ve = ctx.Ves.FirstOrDefault(v => v.MaVe == maVe);
                return ve?.MaGhe ?? 0;
            }
        }

        public string LayTenHanhKhachBangVe(int maVe)
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = from v in ctx.Ves
                            join hk in ctx.HanhKhaches on v.MaHanhKhach equals hk.MaHanhKhach
                            where v.MaVe == maVe
                            select hk.HoTen;
                return query.FirstOrDefault();
            }
        }

        public string LayTuyenBangVe(int maVe)
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = from v in ctx.Ves
                            join ct in ctx.ChuyenTaus on v.MaChuyen equals ct.MaChuyen
                            join td in ctx.TuyenDuongs on ct.MaTuyen equals td.MaTuyen
                            join gdi in ctx.GaTaus on td.MaGaDi equals gdi.MaGaTau
                            join gden in ctx.GaTaus on td.MaGaDen equals gden.MaGaTau
                            where v.MaVe == maVe
                            select new { GaDi = gdi.TenGa, GaDen = gden.TenGa };

                var result = query.FirstOrDefault();
                return result != null ? $"{result.GaDi} - {result.GaDen}" : string.Empty;
            }
        }

        public string LayToaGheBangVe(int maVe)
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = from v in ctx.Ves
                            join g in ctx.Ghes on v.MaGhe equals g.MaGhe
                            join tt in ctx.ToaTaus on g.MaToa equals tt.MaToa
                            where v.MaVe == maVe
                            select new { TenToa = tt.TenToa, SoHieu = g.SoHieu };

                var result = query.FirstOrDefault();
                return result != null ? $"{result.TenToa} - {result.SoHieu}" : string.Empty;
            }
        }

        public DateTime LayNgayKhoiHanhBangVe(int maVe)
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = from v in ctx.Ves
                            join ct in ctx.ChuyenTaus on v.MaChuyen equals ct.MaChuyen
                            where v.MaVe == maVe
                            select ct.GioKhoiHanh;
                return query.FirstOrDefault() ?? DateTime.MinValue;
            }
        }

        public DateTime LayNgayDatBangVe(int maVe)
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = from v in ctx.Ves
                            join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                            where v.MaVe == maVe
                            select th.NgayThanhToan;
                return query.FirstOrDefault() ?? DateTime.MinValue;
            }
        }
    }
}
