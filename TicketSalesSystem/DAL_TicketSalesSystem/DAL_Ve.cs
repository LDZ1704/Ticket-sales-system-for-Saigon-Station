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
        //Thêm vé
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
                            select new { gdi.TenGa, GaDen = gden.TenGa };

                var result = query.FirstOrDefault();
                return result != null ? $"{result.TenGa} - {result.GaDen}" : string.Empty;
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
                            select new { tt.TenToa, g.SoHieu, tt.LoaiGhe, tt.GiaVe };

                var result = query.FirstOrDefault();
                return result != null ? $"{result.TenToa} - {result.SoHieu} ({result.LoaiGhe})" : string.Empty;
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

        //Lấy thông tin chi tiết vé theo ID (dùng cho kiểm tra điều kiện hủy/đổi)
        public DTO_Ve LayVeChiTietBangId(int maVe)
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
                            where v.MaVe == maVe
                            select new DTO_Ve
                            {
                                MaVe = v.MaVe,
                                MaHanhKhach = v.MaHanhKhach ?? 0,
                                MaChuyen = v.MaChuyen ?? 0,
                                MaGhe = v.MaGhe ?? 0,
                                MaThanhToan = v.MaThanhToan ?? 0,
                                GiaVe = v.GiaVe ?? 0,
                                TrangThai = v.TrangThai,
                                MaQR = v.MaQR,
                                HanhKhach = hk.HoTen,
                                Tuyen = gdi.TenGa + " - " + gden.TenGa,
                                ToaGhe = tt.TenToa + " - " + g.SoHieu + " (" + tt.LoaiGhe + ")",
                                NgayKhoiHanh = ct.GioKhoiHanh ?? DateTime.MinValue,
                                NgayDat = th.NgayThanhToan ?? DateTime.MinValue
                            };

                return query.FirstOrDefault();
            }
        }

        // Lấy thông tin chuyến tàu từ vé (để kiểm tra điều kiện thời gian)
        public DTO_ChuyenTau LayChuyenTauBangVe(int maVe)
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = from v in ctx.Ves
                            join ct in ctx.ChuyenTaus on v.MaChuyen equals ct.MaChuyen
                            join t in ctx.Taus on ct.MaTau equals t.MaTau
                            join td in ctx.TuyenDuongs on ct.MaTuyen equals td.MaTuyen
                            where v.MaVe == maVe
                            select new DTO_ChuyenTau
                            {
                                MaChuyen = ct.MaChuyen,
                                MaTau = ct.MaTau ?? 0,
                                MaTuyen = ct.MaTuyen ?? 0,
                                GioKhoiHanh = ct.GioKhoiHanh ?? DateTime.MinValue,
                                GioDen = ct.GioDen ?? DateTime.MinValue,
                                TrangThai = ct.TrangThai,
                                GhiChu = ct.GhiChu,
                                TenTau = t.TenTau
                            };

                return query.FirstOrDefault();
            }
        }

        //Kiểm tra vé có tồn tại và thuộc về người dùng không
        public bool KiemTraVeThuocVeNguoiDung(int maVe, int maNguoiDung)
        {
            using (var ctx = new TicketSalesContext())
            {
                var exists = (from v in ctx.Ves
                              join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                              where v.MaVe == maVe && th.MaNguoiDung == maNguoiDung
                              select v.MaVe).Any();

                return exists;
            }
        }

        //Lấy danh sách vé có thể đổi (chỉ vé đã thanh toán và còn thời gian)
        public List<DTO_Ve> LayDanhSachVeCoTheDoi(int maNguoiDung)
        {
            using (var ctx = new TicketSalesContext())
            {
                var currentTime = DateTime.Now.AddHours(24); // Cộng 24h để lọc

                var query = from v in ctx.Ves
                            join hk in ctx.HanhKhaches on v.MaHanhKhach equals hk.MaHanhKhach
                            join ct in ctx.ChuyenTaus on v.MaChuyen equals ct.MaChuyen
                            join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                            where th.MaNguoiDung == maNguoiDung
                                && v.TrangThai == "DATHANHTOAN"
                                && ct.GioKhoiHanh > currentTime
                            orderby ct.GioKhoiHanh
                            select new DTO_Ve
                            {
                                MaVe = v.MaVe,
                                MaHanhKhach = v.MaHanhKhach ?? 0,
                                MaChuyen = v.MaChuyen ?? 0,
                                MaGhe = v.MaGhe ?? 0,
                                MaThanhToan = v.MaThanhToan ?? 0,
                                GiaVe = v.GiaVe ?? 0,
                                TrangThai = v.TrangThai,
                                MaQR = v.MaQR,
                                NgayKhoiHanh = ct.GioKhoiHanh ?? DateTime.MinValue
                            };

                return query.ToList();
            }
        }

        //Đổi vé
        public bool DoiVe(int maVeCu, int maGheMoi, int maChuyenMoi, int maThanhToan, decimal giaVe, string maQR, int maHanhKhach)
        {
            using (var ctx = new TicketSalesContext())
            {
                using (var transaction = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        // Cập nhật vé cũ
                        var veCu = ctx.Ves.FirstOrDefault(v => v.MaVe == maVeCu);
                        if (veCu == null)
                            throw new Exception("Không tìm thấy vé cũ");

                        veCu.TrangThai = "DADOI";

                        // Giải phóng ghế cũ
                        var gheCu = ctx.Ghes.FirstOrDefault(g => g.MaGhe == veCu.MaGhe);
                        if (gheCu != null)
                            gheCu.TrangThai = "TRONG";

                        // Kiểm tra ghế mới có trống không
                        var gheMoi = ctx.Ghes.FirstOrDefault(g => g.MaGhe == maGheMoi);
                        if (gheMoi == null)
                            throw new Exception("Không tìm thấy ghế mới");

                        if (gheMoi.TrangThai != "TRONG")
                            throw new Exception("Ghế đã được đặt");

                        // Đặt ghế mới
                        gheMoi.TrangThai = "DADAT";

                        // Tạo vé mới với giá vé từ toa
                        var veMoi = new Ve
                        {
                            MaHanhKhach = maHanhKhach,
                            MaChuyen = maChuyenMoi,
                            MaGhe = maGheMoi,
                            MaThanhToan = maThanhToan,
                            GiaVe = giaVe,
                            TrangThai = "DATHANHTOAN",
                            MaQR = maQR
                        };
                        ctx.Ves.Add(veMoi);

                        ctx.SaveChanges();
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        //Lấy thống kê vé theo trạng thái của người dùng
        public Dictionary<string, int> LayThongKeVeTheoTrangThai(int maNguoiDung)
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = from v in ctx.Ves
                            join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                            where th.MaNguoiDung == maNguoiDung
                            group v by v.TrangThai into g
                            select new { TrangThai = g.Key, SoLuong = g.Count() };

                return query.ToDictionary(x => x.TrangThai ?? "Unknown", x => x.SoLuong);
            }
        }

        // Lấy giá vé từ toa theo ghế
        public decimal LayGiaVeTuGhe(int maGhe)
        {
            using (var ctx = new TicketSalesContext())
            {
                var query = from g in ctx.Ghes
                            join tt in ctx.ToaTaus on g.MaToa equals tt.MaToa
                            where g.MaGhe == maGhe
                            select tt.GiaVe;

                return query.FirstOrDefault() ?? 0;
            }
        }

        // Lấy giá vé từ toa theo mã toa
        public decimal LayGiaVeTuToa(int maToa)
        {
            using (var ctx = new TicketSalesContext())
            {
                var toa = ctx.ToaTaus.FirstOrDefault(t => t.MaToa == maToa);
                return toa?.GiaVe ?? 0;
            }
        }
    }
}
