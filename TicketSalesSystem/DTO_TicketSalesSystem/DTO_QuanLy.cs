using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TicketSalesSystem
{
    public class DTO_QuanLy
    {
        // Thống kê doanh thu
        public class DTO_ThongKeDoanhThu
        {
            public DateTime NgayBaoCao { get; set; }
            public decimal TongDoanhThu { get; set; }
            public int SoVeBan { get; set; }
            public decimal DoanhThuTheoNgay { get; set; }
            public decimal DoanhThuTheoThang { get; set; }
            public decimal DoanhThuTheoNam { get; set; }
            public string TenTuyen { get; set; }
            public int MaTuyen { get; set; }
            public string TenTau { get; set; }
            public decimal TiLeThayDoi { get; set; } // % thay đổi so với kỳ trước
        }

        // Thống kê vé bán ra
        public class DTO_ThongKeVe
        {
            public string TrangThai { get; set; }
            public int SoLuong { get; set; }
            public decimal TiLe { get; set; }
            public string Thang { get; set; }
            public string Nam { get; set; }
            public string TenTuyen { get; set; }
            public int MaTuyen { get; set; }
            public string LoaiGhe { get; set; }
            public decimal GiaTrungBinh { get; set; }
            public DateTime NgayThongKe { get; set; }
        }

        // Thống kê theo tuyến tàu
        public class DTO_ThongKeTuyen
        {
            public int MaTuyen { get; set; }
            public string TenTuyen { get; set; }
            public string GaDi { get; set; }
            public string GaDen { get; set; }
            public int SoVeBan { get; set; }
            public decimal DoanhThu { get; set; }
            public int SoChuyenChay { get; set; }
            public decimal TiLeLapDay { get; set; } // % ghế được đặt
            public int XepHang { get; set; }
            public decimal DoanhThuTrungBinh { get; set; }
        }

        // Quản lý người dùng
        public class DTO_QuanLyNguoiDung
        {
            public int MaNguoiDung { get; set; }
            public string Ho { get; set; }
            public string Ten { get; set; }
            public string GetHoTen()
            {
                return $"{Ho} {Ten}";
            }
            public DateTime? NgaySinh { get; set; }
            public string Email { get; set; }
            public string SoDienThoai { get; set; }
            public string LoaiNguoiDung { get; set; }
            public string TrangThaiTaiKhoan { get; set; }
            public DateTime NgayTao { get; set; }
            public int SoVeDaDat { get; set; }
            public decimal TongChiTieu { get; set; }
            public DateTime? LanDangNhapCuoi { get; set; }
            public string TenDangNhap { get; set; }
            public bool DangHoatDong { get; set; }
        }

        // Cấu hình hệ thống
        public class DTO_CauHinhHeThong
        {
            public string TenCauHinh { get; set; }
            public string GiaTri { get; set; }
            public string GiaTriCu { get; set; }
            public string MoTa { get; set; }
            public string LoaiCauHinh { get; set; } // TIME, MONEY, TEXT, BOOLEAN, NUMBER
            public DateTime NgayCapNhat { get; set; }
            public string NguoiCapNhat { get; set; }
            public string DonVi { get; set; } // giờ, VND, %
            public string NhomCauHinh { get; set; } // VE, THANHTOAN, HETHONG
            public bool KichHoat { get; set; }
        }

        // Báo cáo tổng hợp
        public class DTO_BaoCaoTongHop
        {
            public string TieuDe { get; set; }
            public DateTime TuNgay { get; set; }
            public DateTime DenNgay { get; set; }
            public decimal TongDoanhThu { get; set; }
            public int TongSoVe { get; set; }
            public int SoVeHuy { get; set; }
            public int SoVeDoi { get; set; }
            public int SoNguoiDungMoi { get; set; }
            public int SoNguoiDungHoatDong { get; set; }
            public string TuyenBanChayNhat { get; set; }
            public string LoaiGheBanChayNhat { get; set; }
            public decimal DoanhThuTrungBinhTheoNgay { get; set; }
            public decimal TiLeHuyVe { get; set; }
            public decimal TiLeDoiVe { get; set; }
            public List<DTO_ThongKeDoanhThu> ChiTietDoanhThu { get; set; }
            public List<DTO_ThongKeTuyen> ChiTietTuyen { get; set; }
        }

        // Thống kê theo thời gian
        public class DTO_ThongKeThoiGian
        {
            public DateTime Ngay { get; set; }
            public string Thang { get; set; }
            public string Nam { get; set; }
            public string Quy { get; set; }
            public decimal DoanhThu { get; set; }
            public int SoVeBan { get; set; }
            public int SoNguoiDungMoi { get; set; }
            public decimal DoanhThuLuyKe { get; set; }
            public decimal TangTruongDoanhThu { get; set; } // % so với kỳ trước
            public decimal TangTruongSoVe { get; set; }
        }

        // Dashboard tổng quan
        public class DTO_Dashboard
        {
            public decimal DoanhThuHomNay { get; set; }
            public decimal DoanhThuThangNay { get; set; }
            public decimal DoanhThuNamNay { get; set; }
            public int SoVeHomNay { get; set; }
            public int SoVeThangNay { get; set; }
            public int SoVeNamNay { get; set; }
            public int TongNguoiDung { get; set; }
            public int NguoiDungMoiThangNay { get; set; }
            public int SoChuyenDangChay { get; set; }
            public decimal TiLeGheTrong { get; set; }
            public List<DTO_ThongKeTuyen> Top5TuyenBanChay { get; set; }
            public List<DTO_ThongKeDoanhThu> DoanhThu7NgayGanNhat { get; set; }
        }

        public class DTO_LichSuHoatDong
        {
            public DateTime? NgayGiaoDich { get; set; }
            public string LoaiGiaoDich { get; set; }
            public string Tuyen { get; set; }
            public decimal SoTien { get; set; }
            public string TrangThai { get; set; }
            public int MaVe { get; set; }
        }
    }
}
