using DTO_TicketSalesSystem.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using static DTO_TicketSalesSystem.DTO_QuanLy;

namespace DAL_TicketSalesSystem
{
    public class DAL_QuanLy
    {
        public class DAL_ThongKe
        {
            //Lấy thống kê doanh thu theo ngày
            public List<DTO_ThongKeDoanhThu> LayThongKeDoanhThuTheoNgay(DateTime tuNgay, DateTime denNgay)
            {
                using (var ctx = new TicketSalesContext())
                {
                    var query = from v in ctx.Ves
                                join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                where th.NgayThanhToan >= tuNgay && th.NgayThanhToan <= denNgay
                                    && v.TrangThai == "DATHANHTOAN"
                                    && th.TrangThai == "THANHCONG"
                                group new { v, th } by DbFunctions.TruncateTime(th.NgayThanhToan) into g
                                orderby g.Key
                                select new
                                {
                                    NgayBaoCao = g.Key,
                                    TongDoanhThu = g.Sum(x => x.v.GiaVe ?? 0),
                                    SoVeBan = g.Count()
                                };

                    return query.ToList().Select(x => new DTO_ThongKeDoanhThu
                    {
                        NgayBaoCao = x.NgayBaoCao.Value,
                        TongDoanhThu = x.TongDoanhThu,
                        SoVeBan = x.SoVeBan,
                        DoanhThuTheoNgay = x.TongDoanhThu
                    }).ToList();
                }
            }

            //Lấy thống kê doanh thu theo tháng
            public List<DTO_ThongKeDoanhThu> LayThongKeDoanhThuTheoThang(int nam)
            {
                using (var ctx = new TicketSalesContext())
                {
                    var query = from v in ctx.Ves
                                join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                where th.NgayThanhToan.Value.Year == nam
                                    && v.TrangThai == "DATHANHTOAN"
                                    && th.TrangThai == "THANHCONG"
                                group new { v, th } by th.NgayThanhToan.Value.Month into g
                                orderby g.Key
                                select new DTO_ThongKeDoanhThu
                                {
                                    NgayBaoCao = new DateTime(nam, g.Key, 1),
                                    TongDoanhThu = g.Sum(x => x.v.GiaVe ?? 0),
                                    SoVeBan = g.Count(),
                                    DoanhThuTheoThang = g.Sum(x => x.v.GiaVe ?? 0)
                                };

                    return query.ToList();
                }
            }

            //Lấy thống kê vé theo trạng thái
            public List<DTO_ThongKeVe> LayThongKeVeTheoTrangThai(DateTime tuNgay, DateTime denNgay)
            {
                using (var ctx = new TicketSalesContext())
                {
                    var query = from v in ctx.Ves
                                join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                where th.NgayThanhToan >= tuNgay && th.NgayThanhToan <= denNgay
                                group v by v.TrangThai into g
                                select new DTO_ThongKeVe
                                {
                                    TrangThai = g.Key,
                                    SoLuong = g.Count(),
                                    NgayThongKe = DateTime.Now
                                };

                    var result = query.ToList();
                    var tongSoVe = result.Sum(x => x.SoLuong);

                    foreach (var item in result)
                    {
                        item.TiLe = tongSoVe > 0 ? (decimal)item.SoLuong / tongSoVe * 100 : 0;
                    }

                    return result;
                }
            }

            //Lấy thống kê theo tuyến tàu
            public List<DTO_ThongKeTuyen> LayThongKeTuyen(DateTime tuNgay, DateTime denNgay)
            {
                using (var ctx = new TicketSalesContext())
                {
                    var query = from v in ctx.Ves
                                join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                join ct in ctx.ChuyenTaus on v.MaChuyen equals ct.MaChuyen
                                join td in ctx.TuyenDuongs on ct.MaTuyen equals td.MaTuyen
                                join gdi in ctx.GaTaus on td.MaGaDi equals gdi.MaGaTau
                                join gden in ctx.GaTaus on td.MaGaDen equals gden.MaGaTau
                                where th.NgayThanhToan >= tuNgay && th.NgayThanhToan <= denNgay
                                    && v.TrangThai == "DATHANHTOAN"
                                    && th.TrangThai == "THANHCONG"
                                group new { v, td, gdi, gden } by new { td.MaTuyen, TenGaDi = gdi.TenGa, TenGaDen = gden.TenGa } into g
                                orderby g.Sum(x => x.v.GiaVe ?? 0) descending
                                select new DTO_ThongKeTuyen
                                {
                                    MaTuyen = g.Key.MaTuyen,
                                    TenTuyen = g.Key.TenGaDi + " - " + g.Key.TenGaDen,
                                    GaDi = g.Key.TenGaDi,
                                    GaDen = g.Key.TenGaDen,
                                    SoVeBan = g.Count(),
                                    DoanhThu = g.Sum(x => x.v.GiaVe ?? 0),
                                    DoanhThuTrungBinh = g.Average(x => x.v.GiaVe ?? 0)
                                };

                    var result = query.ToList();
                    for (int i = 0; i < result.Count; i++)
                    {
                        result[i].XepHang = i + 1;
                    }

                    return result;
                }
            }

            //Lấy dashboard tổng quan
            public DTO_Dashboard LayDashboard()
            {
                using (var ctx = new TicketSalesContext())
                {
                    var homNay = DateTime.Today;
                    var thangNay = new DateTime(homNay.Year, homNay.Month, 1);
                    var namNay = new DateTime(homNay.Year, 1, 1);

                    var dashboard = new DTO_Dashboard();

                    // Doanh thu hôm nay
                    var doanhThuHomNay = (from v in ctx.Ves
                                          join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                          where th.NgayThanhToan.HasValue
                                              && DbFunctions.TruncateTime(th.NgayThanhToan) == homNay
                                              && v.TrangThai == "DATHANHTOAN"
                                              && th.TrangThai == "THANHCONG"
                                          select v.GiaVe ?? 0).DefaultIfEmpty(0).Sum();

                    // Doanh thu tháng này
                    var doanhThuThangNay = (from v in ctx.Ves
                                            join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                            where th.NgayThanhToan >= thangNay
                                                && v.TrangThai == "DATHANHTOAN"
                                                && th.TrangThai == "THANHCONG"
                                            select v.GiaVe ?? 0).Sum();

                    // Doanh thu năm nay
                    var doanhThuNamNay = (from v in ctx.Ves
                                          join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                          where th.NgayThanhToan >= namNay
                                              && v.TrangThai == "DATHANHTOAN"
                                              && th.TrangThai == "THANHCONG"
                                          select v.GiaVe ?? 0).Sum();

                    // Số vé hôm nay
                    var soVeHomNay = (from v in ctx.Ves
                                      join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                      where th.NgayThanhToan.HasValue
                                          && DbFunctions.TruncateTime(th.NgayThanhToan) == homNay
                                          && v.TrangThai == "DATHANHTOAN"
                                      select v).Count();

                    // Số vé tháng này
                    var soVeThangNay = (from v in ctx.Ves
                                        join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                        where th.NgayThanhToan >= thangNay
                                            && v.TrangThai == "DATHANHTOAN"
                                        select v).Count();

                    // Số vé năm nay
                    var soVeNamNay = (from v in ctx.Ves
                                      join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                      where th.NgayThanhToan >= namNay
                                          && v.TrangThai == "DATHANHTOAN"
                                      select v).Count();

                    // Tổng người dùng
                    var tongNguoiDung = ctx.NguoiDungs.Count();

                    // Người dùng mới tháng này
                    var nguoiDungMoiThangNay = ctx.NguoiDungs.Where(n => n.NgayTao >= thangNay).Count();

                    // Số chuyến đang chạy
                    var soChuyenDangChay = ctx.ChuyenTaus.Where(c => c.TrangThai == "MOBAN").Count();

                    // Tỷ lệ ghế trống
                    var tongGhe = ctx.Ghes.Count();
                    var gheTrong = ctx.Ghes.Where(g => g.TrangThai == "TRONG").Count();
                    var tiLeGheTrong = tongGhe > 0 ? (decimal)gheTrong / tongGhe * 100 : 0;

                    dashboard.DoanhThuHomNay = doanhThuHomNay;
                    dashboard.DoanhThuThangNay = doanhThuThangNay;
                    dashboard.DoanhThuNamNay = doanhThuNamNay;
                    dashboard.SoVeHomNay = soVeHomNay;
                    dashboard.SoVeThangNay = soVeThangNay;
                    dashboard.SoVeNamNay = soVeNamNay;
                    dashboard.TongNguoiDung = tongNguoiDung;
                    dashboard.NguoiDungMoiThangNay = nguoiDungMoiThangNay;
                    dashboard.SoChuyenDangChay = soChuyenDangChay;
                    dashboard.TiLeGheTrong = tiLeGheTrong;

                    // Top 5 tuyến bán chạy
                    dashboard.Top5TuyenBanChay = LayThongKeTuyen(thangNay, DateTime.Now).Take(5).ToList();

                    // Doanh thu 7 ngày gần nhất
                    dashboard.DoanhThu7NgayGanNhat = LayThongKeDoanhThuTheoNgay(homNay.AddDays(-6), homNay);

                    return dashboard;
                }
            }

            //Lấy thống kê theo thời gian tùy chỉnh
            public List<DTO_ThongKeThoiGian> LayThongKeThoiGian(DateTime tuNgay, DateTime denNgay, string groupBy)
            {
                using (var ctx = new TicketSalesContext())
                {
                    var query = from v in ctx.Ves
                                join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                where th.NgayThanhToan >= tuNgay && th.NgayThanhToan <= denNgay
                                    && v.TrangThai == "DATHANHTOAN"
                                    && th.TrangThai == "THANHCONG"
                                select new { v, th };

                    var data = query.ToList();
                    var result = new List<DTO_ThongKeThoiGian>();

                    switch (groupBy.ToUpper())
                    {
                        case "NGAY":
                            result = data.GroupBy(x => x.th.NgayThanhToan.Value.Date)
                                        .Select(g => new DTO_ThongKeThoiGian
                                        {
                                            Ngay = g.Key,
                                            DoanhThu = g.Sum(x => x.v.GiaVe ?? 0),
                                            SoVeBan = g.Count()
                                        })
                                        .OrderBy(x => x.Ngay)
                                        .ToList();
                            break;

                        case "THANG":
                            result = data.GroupBy(x => new { x.th.NgayThanhToan.Value.Year, x.th.NgayThanhToan.Value.Month })
                                        .Select(g => new DTO_ThongKeThoiGian
                                        {
                                            Thang = $"{g.Key.Month:00}/{g.Key.Year}",
                                            Ngay = new DateTime(g.Key.Year, g.Key.Month, 1),
                                            DoanhThu = g.Sum(x => x.v.GiaVe ?? 0),
                                            SoVeBan = g.Count()
                                        })
                                        .OrderBy(x => x.Ngay)
                                        .ToList();
                            break;

                        case "NAM":
                            result = data.GroupBy(x => x.th.NgayThanhToan.Value.Year)
                                        .Select(g => new DTO_ThongKeThoiGian
                                        {
                                            Nam = g.Key.ToString(),
                                            Ngay = new DateTime(g.Key, 1, 1),
                                            DoanhThu = g.Sum(x => x.v.GiaVe ?? 0),
                                            SoVeBan = g.Count()
                                        })
                                        .OrderBy(x => x.Ngay)
                                        .ToList();
                            break;
                    }

                    return result;
                }
            }

            //Lấy báo cáo tổng hợp
            public DTO_BaoCaoTongHop LayBaoCaoTongHop(DateTime tuNgay, DateTime denNgay)
            {
                using (var ctx = new TicketSalesContext())
                {
                    var baoCao = new DTO_BaoCaoTongHop
                    {
                        TieuDe = $"Báo cáo tổng hợp từ {tuNgay:dd/MM/yyyy} đến {denNgay:dd/MM/yyyy}",
                        TuNgay = tuNgay,
                        DenNgay = denNgay
                    };

                    // Tổng doanh thu
                    baoCao.TongDoanhThu = (from v in ctx.Ves
                                           join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                           where th.NgayThanhToan >= tuNgay && th.NgayThanhToan <= denNgay
                                               && v.TrangThai == "DATHANHTOAN"
                                               && th.TrangThai == "THANHCONG"
                                           select v.GiaVe ?? 0).Sum();

                    // Tổng số vé
                    baoCao.TongSoVe = (from v in ctx.Ves
                                       join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                       where th.NgayThanhToan >= tuNgay && th.NgayThanhToan <= denNgay
                                           && v.TrangThai == "DATHANHTOAN"
                                       select v).Count();

                    // Số vé hủy
                    baoCao.SoVeHuy = (from v in ctx.Ves
                                      join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                      where th.NgayThanhToan >= tuNgay && th.NgayThanhToan <= denNgay
                                          && v.TrangThai == "DAHUY"
                                      select v).Count();

                    // Số vé đổi
                    baoCao.SoVeDoi = (from v in ctx.Ves
                                      join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                      where th.NgayThanhToan >= tuNgay && th.NgayThanhToan <= denNgay
                                          && v.TrangThai == "DADOI"
                                      select v).Count();

                    // Số người dùng mới
                    baoCao.SoNguoiDungMoi = ctx.NguoiDungs.Where(n => n.NgayTao >= tuNgay && n.NgayTao <= denNgay).Count();

                    // Tỷ lệ hủy vé, đổi vé
                    var tongVeCoGiaoDich = baoCao.TongSoVe + baoCao.SoVeHuy + baoCao.SoVeDoi;
                    baoCao.TiLeHuyVe = tongVeCoGiaoDich > 0 ? (decimal)baoCao.SoVeHuy / tongVeCoGiaoDich * 100 : 0;
                    baoCao.TiLeDoiVe = tongVeCoGiaoDich > 0 ? (decimal)baoCao.SoVeDoi / tongVeCoGiaoDich * 100 : 0;

                    // Doanh thu trung bình theo ngày
                    var soNgay = (denNgay - tuNgay).Days + 1;
                    baoCao.DoanhThuTrungBinhTheoNgay = soNgay > 0 ? baoCao.TongDoanhThu / soNgay : 0;

                    // Chi tiết
                    baoCao.ChiTietDoanhThu = LayThongKeDoanhThuTheoNgay(tuNgay, denNgay);
                    baoCao.ChiTietTuyen = LayThongKeTuyen(tuNgay, denNgay);

                    // Tuyến bán chạy nhất
                    baoCao.TuyenBanChayNhat = baoCao.ChiTietTuyen.FirstOrDefault()?.TenTuyen ?? "N/A";

                    return baoCao;
                }
            }
        }

        public class DAL_QuanLyNguoiDung
        {
            //Lấy danh sách tất cả người dùng với thông tin tài khoản
            public List<DTO_QuanLyNguoiDung> LayTatCaNguoiDung()
            {
                using (var ctx = new TicketSalesContext())
                {
                    var query = from nd in ctx.NguoiDungs
                                join tk in ctx.TaiKhoans on nd.MaNguoiDung equals tk.MaNguoiDung into tkGroup
                                from tk in tkGroup.DefaultIfEmpty()
                                select new DTO_QuanLyNguoiDung
                                {
                                    MaNguoiDung = nd.MaNguoiDung,
                                    Ho = nd.Ho,
                                    Ten = nd.Ten,
                                    NgaySinh = nd.NgaySinh,
                                    Email = nd.Email,
                                    SoDienThoai = nd.SoDienThoai,
                                    LoaiNguoiDung = nd.LoaiNguoiDung,
                                    NgayTao = nd.NgayTao ?? DateTime.MinValue,
                                    TenDangNhap = tk != null ? tk.TenDangNhap : "",
                                    TrangThaiTaiKhoan = tk != null ? tk.TrangThai : "CHUA_CO_TK",
                                    DangHoatDong = tk != null && tk.TrangThai == "HOATDONG"
                                };

                    var result = query.ToList();

                    // Tính số vé đã đặt và tổng chi tiêu cho mỗi người dùng
                    foreach (var user in result)
                    {
                        var thongKe = (from v in ctx.Ves
                                       join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                       where th.MaNguoiDung == user.MaNguoiDung && v.TrangThai == "DATHANHTOAN"
                                       group v by th.MaNguoiDung into g
                                       select new
                                       {
                                           SoVe = g.Count(),
                                           TongTien = g.Sum(x => x.GiaVe ?? 0)
                                       }).FirstOrDefault();

                        user.SoVeDaDat = thongKe?.SoVe ?? 0;
                        user.TongChiTieu = thongKe?.TongTien ?? 0;
                    }

                    return result.OrderByDescending(x => x.NgayTao).ToList();
                }
            }

            //Tìm kiếm người dùng theo từ khóa
            public List<DTO_QuanLyNguoiDung> TimKiemNguoiDung(string tuKhoa)
            {
                if (string.IsNullOrEmpty(tuKhoa))
                    return LayTatCaNguoiDung();

                using (var ctx = new TicketSalesContext())
                {
                    var query = from nd in ctx.NguoiDungs
                                join tk in ctx.TaiKhoans on nd.MaNguoiDung equals tk.MaNguoiDung into tkGroup
                                from tk in tkGroup.DefaultIfEmpty()
                                where nd.Ho.Contains(tuKhoa) ||
                                      nd.Ten.Contains(tuKhoa) ||
                                      nd.Email.Contains(tuKhoa) ||
                                      nd.SoDienThoai.Contains(tuKhoa) ||
                                      (tk != null && tk.TenDangNhap.Contains(tuKhoa))
                                select new DTO_QuanLyNguoiDung
                                {
                                    MaNguoiDung = nd.MaNguoiDung,
                                    Ho = nd.Ho,
                                    Ten = nd.Ten,
                                    NgaySinh = nd.NgaySinh,
                                    Email = nd.Email,
                                    SoDienThoai = nd.SoDienThoai,
                                    LoaiNguoiDung = nd.LoaiNguoiDung,
                                    NgayTao = nd.NgayTao ?? DateTime.MinValue,
                                    TenDangNhap = tk != null ? tk.TenDangNhap : "",
                                    TrangThaiTaiKhoan = tk != null ? tk.TrangThai : "CHUA_CO_TK",
                                    DangHoatDong = tk != null && tk.TrangThai == "HOATDONG"
                                };

                    return query.ToList();
                }
            }

            //Lọc người dùng theo loại
            public List<DTO_QuanLyNguoiDung> LocNguoiDungTheoLoai(string loaiNguoiDung)
            {
                using (var ctx = new TicketSalesContext())
                {
                    var query = from nd in ctx.NguoiDungs
                                join tk in ctx.TaiKhoans on nd.MaNguoiDung equals tk.MaNguoiDung into tkGroup
                                from tk in tkGroup.DefaultIfEmpty()
                                where nd.LoaiNguoiDung == loaiNguoiDung
                                select new DTO_QuanLyNguoiDung
                                {
                                    MaNguoiDung = nd.MaNguoiDung,
                                    Ho = nd.Ho,
                                    Ten = nd.Ten,
                                    NgaySinh = nd.NgaySinh,
                                    Email = nd.Email,
                                    SoDienThoai = nd.SoDienThoai,
                                    LoaiNguoiDung = nd.LoaiNguoiDung,
                                    NgayTao = nd.NgayTao ?? DateTime.MinValue,
                                    TenDangNhap = tk != null ? tk.TenDangNhap : "",
                                    TrangThaiTaiKhoan = tk != null ? tk.TrangThai : "CHUA_CO_TK",
                                    DangHoatDong = tk != null && tk.TrangThai == "HOATDONG"
                                };

                    return query.ToList();
                }
            }

            //Khóa hoặc mở khóa tài khoản
            public bool ThayDoiTrangThaiTaiKhoan(int maNguoiDung, string trangThaiMoi)
            {
                using (var ctx = new TicketSalesContext())
                {
                    var taiKhoan = ctx.TaiKhoans.FirstOrDefault(tk => tk.MaNguoiDung == maNguoiDung);
                    if (taiKhoan == null) return false;

                    taiKhoan.TrangThai = trangThaiMoi;
                    return ctx.SaveChanges() > 0;
                }
            }

            //Cấp quyền cho người dùng
            public bool CapQuyenNguoiDung(int maNguoiDung, string quyenMoi)
            {
                using (var ctx = new TicketSalesContext())
                {
                    var nguoiDung = ctx.NguoiDungs.Find(maNguoiDung);
                    if (nguoiDung == null) return false;

                    nguoiDung.LoaiNguoiDung = quyenMoi;
                    return ctx.SaveChanges() > 0;
                }
            }

            //Đặt lại mật khẩu
            public bool DatLaiMatKhau(int maNguoiDung, string matKhauMoi)
            {
                using (var ctx = new TicketSalesContext())
                {
                    var taiKhoan = ctx.TaiKhoans.FirstOrDefault(tk => tk.MaNguoiDung == maNguoiDung);
                    if (taiKhoan == null) return false;

                    taiKhoan.MatKhau = PasswordHasher.Hash(matKhauMoi);
                    return ctx.SaveChanges() > 0;
                }
            }

            //Lấy thống kê người dùng tổng quan
            public Dictionary<string, int> LayThongKeNguoiDung()
            {
                using (var ctx = new TicketSalesContext())
                {
                    var thongKe = new Dictionary<string, int>();

                    thongKe["TongNguoiDung"] = ctx.NguoiDungs.Count();
                    thongKe["KhachHang"] = ctx.NguoiDungs.Where(nd => nd.LoaiNguoiDung == "KHACH").Count();
                    thongKe["NhanVien"] = ctx.NguoiDungs.Where(nd => nd.LoaiNguoiDung == "NHANVIEN").Count();
                    thongKe["QuanTriVien"] = ctx.NguoiDungs.Where(nd => nd.LoaiNguoiDung == "QUANTRI").Count();

                    thongKe["TaiKhoanHoatDong"] = ctx.TaiKhoans.Where(tk => tk.TrangThai == "HOATDONG").Count();
                    thongKe["TaiKhoanBiKhoa"] = ctx.TaiKhoans.Where(tk => tk.TrangThai == "KHOA").Count();

                    var homNay = DateTime.Today;
                    var thangNay = new DateTime(homNay.Year, homNay.Month, 1);

                    thongKe["NguoiDungMoiHomNay"] = ctx.NguoiDungs.Where(nd => nd.NgayTao >= homNay).Count();
                    thongKe["NguoiDungMoiThangNay"] = ctx.NguoiDungs.Where(nd => nd.NgayTao >= thangNay).Count();

                    return thongKe;
                }
            }

            //Lấy lịch sử hoạt động của người dùng
            public List<DTO_LichSuHoatDong> LayLichSuHoatDong(int maNguoiDung, int top = 10)
            {
                using (var ctx = new TicketSalesContext())
                {
                    var query = from v in ctx.Ves
                                join th in ctx.ThanhToans on v.MaThanhToan equals th.MaThanhToan
                                join ct in ctx.ChuyenTaus on v.MaChuyen equals ct.MaChuyen
                                join td in ctx.TuyenDuongs on ct.MaTuyen equals td.MaTuyen
                                join gdi in ctx.GaTaus on td.MaGaDi equals gdi.MaGaTau
                                join gden in ctx.GaTaus on td.MaGaDen equals gden.MaGaTau
                                where th.MaNguoiDung == maNguoiDung
                                orderby th.NgayThanhToan descending
                                select new
                                {
                                    NgayThanhToan = th.NgayThanhToan,
                                    ThoiDiem = th.ThoiDiem,
                                    TrangThaiVe = v.TrangThai,
                                    TenGaDi = gdi.TenGa,
                                    TenGaDen = gden.TenGa,
                                    GiaVe = v.GiaVe,
                                    MaVe = v.MaVe
                                };

                    return query.Take(top).ToList().Select(x => new DTO_LichSuHoatDong
                    {
                        NgayGiaoDich = x.NgayThanhToan ?? x.ThoiDiem,
                        LoaiGiaoDich = x.TrangThaiVe == "DATHANHTOAN" ? "Đặt vé" :
                                      x.TrangThaiVe == "DAHUY" ? "Hủy vé" : "Đổi vé",
                        Tuyen = x.TenGaDi + " - " + x.TenGaDen,
                        SoTien = x.GiaVe ?? 0,
                        TrangThai = x.TrangThaiVe,
                        MaVe = x.MaVe
                    }).ToList();
                }
            }

            //Xóa người dùng
            public bool XoaNguoiDung(int maNguoiDung)
            {
                using (var ctx = new TicketSalesContext())
                {
                    using (var transaction = ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            // 1. Trả ghế về trạng thái TRONG
                            var ves = (from v in ctx.Ves
                                       join tt in ctx.ThanhToans on v.MaThanhToan equals tt.MaThanhToan
                                       where tt.MaNguoiDung == maNguoiDung
                                       select v).ToList();

                            foreach (var ve in ves)
                            {
                                if (ve.MaGhe.HasValue)
                                {
                                    var ghe = ctx.Ghes.Find(ve.MaGhe.Value);
                                    if (ghe != null)
                                    {
                                        ghe.TrangThai = "TRONG";
                                    }
                                }
                            }

                            // 2. Lấy danh sách hành khách từ vé
                            var hanhKhachIds = ves.Where(v => v.MaHanhKhach.HasValue).Select(v => v.MaHanhKhach.Value).Distinct().ToList();

                            // 3. Xóa vé
                            ctx.Ves.RemoveRange(ves);
                            ctx.SaveChanges();

                            // 4. Xóa hành khách
                            var hanhKhachs = ctx.HanhKhaches.Where(hk => hanhKhachIds.Contains(hk.MaHanhKhach)).ToList();
                            ctx.HanhKhaches.RemoveRange(hanhKhachs);
                            ctx.SaveChanges();

                            // 5. Xóa thanh toán
                            var thanhToans = ctx.ThanhToans.Where(tt => tt.MaNguoiDung == maNguoiDung).ToList();
                            ctx.ThanhToans.RemoveRange(thanhToans);
                            ctx.SaveChanges();

                            // 6. Xóa tài khoản
                            var taiKhoan = ctx.TaiKhoans.FirstOrDefault(tk => tk.MaNguoiDung == maNguoiDung);
                            if (taiKhoan != null)
                            {
                                ctx.TaiKhoans.Remove(taiKhoan);
                                ctx.SaveChanges();
                            }

                            // 7. Xóa người dùng
                            var nguoiDung = ctx.NguoiDungs.Find(maNguoiDung);
                            if (nguoiDung != null)
                            {
                                ctx.NguoiDungs.Remove(nguoiDung);
                                ctx.SaveChanges();
                            }

                            ctx.SaveChanges();
                            transaction.Commit();
                            return true;
                        }
                        catch
                        {
                            transaction.Rollback();
                            return false;
                        }
                    }
                }
            }
        }

        public class DAL_CauHinh
        {
            // Các cấu hình mặc định được lưu trong code
            private static readonly Dictionary<string, DTO_CauHinhHeThong> DefaultConfigs = new Dictionary<string, DTO_CauHinhHeThong>
            {
                ["HUY_VE_THOI_GIAN_TOI_THIEU"] = new DTO_CauHinhHeThong
                {
                    TenCauHinh = "HUY_VE_THOI_GIAN_TOI_THIEU",
                    GiaTri = "24",
                    MoTa = "Thời gian tối thiểu trước khởi hành để có thể hủy vé (giờ)",
                    LoaiCauHinh = "NUMBER",
                    DonVi = "giờ",
                    NhomCauHinh = "VE",
                    KichHoat = true
                },
                ["DOI_VE_THOI_GIAN_TOI_THIEU"] = new DTO_CauHinhHeThong
                {
                    TenCauHinh = "DOI_VE_THOI_GIAN_TOI_THIEU",
                    GiaTri = "24",
                    MoTa = "Thời gian tối thiểu trước khởi hành để có thể đổi vé (giờ)",
                    LoaiCauHinh = "NUMBER",
                    DonVi = "giờ",
                    NhomCauHinh = "VE",
                    KichHoat = true
                },
                ["HOAN_TIEN_24H_48H"] = new DTO_CauHinhHeThong
                {
                    TenCauHinh = "HOAN_TIEN_24H_48H",
                    GiaTri = "50",
                    MoTa = "Phần trăm hoàn tiền khi hủy vé từ 24-48h trước khởi hành (%)",
                    LoaiCauHinh = "NUMBER",
                    DonVi = "%",
                    NhomCauHinh = "VE",
                    KichHoat = true
                },
                ["HOAN_TIEN_48H_72H"] = new DTO_CauHinhHeThong
                {
                    TenCauHinh = "HOAN_TIEN_48H_72H",
                    GiaTri = "70",
                    MoTa = "Phần trăm hoàn tiền khi hủy vé từ 48-72h trước khởi hành (%)",
                    LoaiCauHinh = "NUMBER",
                    DonVi = "%",
                    NhomCauHinh = "VE",
                    KichHoat = true
                },
                ["HOAN_TIEN_TREN_72H"] = new DTO_CauHinhHeThong
                {
                    TenCauHinh = "HOAN_TIEN_TREN_72H",
                    GiaTri = "90",
                    MoTa = "Phần trăm hoàn tiền khi hủy vé trên 72h trước khởi hành (%)",
                    LoaiCauHinh = "NUMBER",
                    DonVi = "%",
                    NhomCauHinh = "VE",
                    KichHoat = true
                },
                ["CONG_THANH_TOAN_MAC_DINH"] = new DTO_CauHinhHeThong
                {
                    TenCauHinh = "CONG_THANH_TOAN_MAC_DINH",
                    GiaTri = "VNPAY",
                    MoTa = "Cổng thanh toán mặc định",
                    LoaiCauHinh = "TEXT",
                    NhomCauHinh = "THANHTOAN",
                    KichHoat = true
                },
                ["THONG_TIN_NHA_GA"] = new DTO_CauHinhHeThong
                {
                    TenCauHinh = "THONG_TIN_NHA_GA",
                    GiaTri = "Ga Sài Gòn - 01 Nguyễn Thông, Quận 3, TP.HCM",
                    MoTa = "Thông tin nhà ga chính",
                    LoaiCauHinh = "TEXT",
                    NhomCauHinh = "HETHONG",
                    KichHoat = true
                },
                ["EMAIL_LIEN_HE"] = new DTO_CauHinhHeThong
                {
                    TenCauHinh = "EMAIL_LIEN_HE",
                    GiaTri = "support@gasaigon.vn",
                    MoTa = "Email liên hệ hỗ trợ khách hàng",
                    LoaiCauHinh = "TEXT",
                    NhomCauHinh = "HETHONG",
                    KichHoat = true
                },
                ["HOTLINE"] = new DTO_CauHinhHeThong
                {
                    TenCauHinh = "HOTLINE",
                    GiaTri = "1900 1000",
                    MoTa = "Số điện thoại hotline",
                    LoaiCauHinh = "TEXT",
                    NhomCauHinh = "HETHONG",
                    KichHoat = true
                },
                ["SO_VE_TOI_DA_MOT_LAN"] = new DTO_CauHinhHeThong
                {
                    TenCauHinh = "SO_VE_TOI_DA_MOT_LAN",
                    GiaTri = "10",
                    MoTa = "Số vé tối đa có thể đặt trong một lần",
                    LoaiCauHinh = "NUMBER",
                    DonVi = "vé",
                    NhomCauHinh = "VE",
                    KichHoat = true
                }
            };

            //Lấy tất cả cấu hình hệ thống
            public List<DTO_CauHinhHeThong> LayTatCaCauHinh()
            {
                var result = DefaultConfigs.Values.ToList();

                foreach (var config in result)
                {
                    config.NgayCapNhat = DateTime.Now;
                    config.NguoiCapNhat = "Hệ thống";
                }

                return result;
            }

            //Lấy cấu hình theo tên
            public DTO_CauHinhHeThong LayCauHinhBangTen(string tenCauHinh)
            {
                if (DefaultConfigs.ContainsKey(tenCauHinh))
                {
                    var config = DefaultConfigs[tenCauHinh];
                    config.NgayCapNhat = DateTime.Now;
                    config.NguoiCapNhat = "Hệ thống";
                    return config;
                }
                return null;
            }

            //Lấy cấu hình theo nhóm
            public List<DTO_CauHinhHeThong> LayCauHinhTheoNhom(string nhomCauHinh)
            {
                return DefaultConfigs.Values
                    .Where(c => c.NhomCauHinh == nhomCauHinh)
                    .ToList();
            }

            //Cập nhật cấu hình
            public bool CapNhatCauHinh(string tenCauHinh, string giaTriMoi, string nguoiCapNhat)
            {
                try
                {
                    if (DefaultConfigs.ContainsKey(tenCauHinh))
                    {
                        //Hard-code
                        var config = DefaultConfigs[tenCauHinh];
                        config.GiaTriCu = config.GiaTri;
                        config.GiaTri = giaTriMoi;
                        config.NgayCapNhat = DateTime.Now;
                        config.NguoiCapNhat = nguoiCapNhat;

                        return true;
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }

            //Lấy giá trị cấu hình dạng số
            public int LayGiaTriSo(string tenCauHinh, int giaTriMacDinh = 0)
            {
                try
                {
                    var config = LayCauHinhBangTen(tenCauHinh);
                    if (config != null && int.TryParse(config.GiaTri, out int result))
                        return result;
                    return giaTriMacDinh;
                }
                catch
                {
                    return giaTriMacDinh;
                }
            }

            //Validate giá trị cấu hình
            public bool ValidateGiaTriCauHinh(string tenCauHinh, string giaTriMoi)
            {
                var config = LayCauHinhBangTen(tenCauHinh);
                if (config == null) return false;

                switch (config.LoaiCauHinh)
                {
                    case "NUMBER":
                        return int.TryParse(giaTriMoi, out int number) && number >= 0;
                    case "MONEY":
                        return decimal.TryParse(giaTriMoi, out decimal money) && money >= 0;
                    case "BOOLEAN":
                        var lowerValue = giaTriMoi.ToLower();
                        return lowerValue == "true" || lowerValue == "false" ||
                               lowerValue == "1" || lowerValue == "0";
                    case "TEXT":
                        return !string.IsNullOrWhiteSpace(giaTriMoi) && giaTriMoi.Length <= 500;
                    case "TIME":
                        return int.TryParse(giaTriMoi, out int time) && time > 0 && time <= 8760; // Tối đa 1 năm
                    default:
                        return true;
                }
            }
        }
    }
}
