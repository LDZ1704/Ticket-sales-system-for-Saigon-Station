using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DAL_TicketSalesSystem.DAL_QuanLy;
using static DTO_TicketSalesSystem.DTO_QuanLy;

namespace BUS_TicketSalesSystem
{
    public class BUS_QuanLy
    {
        private readonly DAL_ThongKe dalThongKe = new DAL_ThongKe();
        private readonly DAL_QuanLyNguoiDung dalQuanLyNguoiDung = new DAL_QuanLyNguoiDung();
        private readonly DAL_CauHinh dalCauHinh = new DAL_CauHinh();

        #region Thống kê báo cáo

        //Lấy dashboard tổng quan cho admin
        public DTO_Dashboard LayDashboard()
        {
            try
            {
                return dalThongKe.LayDashboard();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy dashboard: {ex.Message}");
            }
        }

        //Lấy thống kê doanh thu theo khoảng thời gian
        public List<DTO_ThongKeDoanhThu> LayThongKeDoanhThu(DateTime tuNgay, DateTime denNgay, string loaiThongKe = "NGAY")
        {
            try
            {
                if (tuNgay > denNgay)
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc");

                var khoangCach = (denNgay - tuNgay).TotalDays;
                if (khoangCach > 365)
                    throw new ArgumentException("Khoảng thời gian thống kê không được quá 1 năm");

                switch (loaiThongKe.ToUpper())
                {
                    case "NGAY":
                        return dalThongKe.LayThongKeDoanhThuTheoNgay(tuNgay, denNgay);
                    case "THANG":
                        return dalThongKe.LayThongKeDoanhThuTheoThang(tuNgay.Year);
                    default:
                        return dalThongKe.LayThongKeDoanhThuTheoNgay(tuNgay, denNgay);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi thống kê doanh thu: {ex.Message}");
            }
        }

        //Lấy thống kê vé theo trạng thái
        public List<DTO_ThongKeVe> LayThongKeVe(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                if (tuNgay > denNgay)
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc");

                return dalThongKe.LayThongKeVeTheoTrangThai(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi thống kê vé: {ex.Message}");
            }
        }

        //Lấy thống kê theo tuyến tàu
        public List<DTO_ThongKeTuyen> LayThongKeTuyen(DateTime tuNgay, DateTime denNgay, int top = 0)
        {
            try
            {
                if (tuNgay > denNgay)
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc");

                var result = dalThongKe.LayThongKeTuyen(tuNgay, denNgay);
                return top > 0 ? result.Take(top).ToList() : result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi thống kê tuyến: {ex.Message}");
            }
        }

        //Lấy thống kê theo thời gian tùy chỉnh
        public List<DTO_ThongKeThoiGian> LayThongKeThoiGian(DateTime tuNgay, DateTime denNgay, string groupBy)
        {
            try
            {
                if (tuNgay > denNgay)
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc");

                if (!new[] { "NGAY", "THANG", "NAM" }.Contains(groupBy.ToUpper()))
                    throw new ArgumentException("Loại group by không hợp lệ");

                return dalThongKe.LayThongKeThoiGian(tuNgay, denNgay, groupBy);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi thống kê thời gian: {ex.Message}");
            }
        }

        //Lấy báo cáo tổng hợp
        public DTO_BaoCaoTongHop LayBaoCaoTongHop(DateTime tuNgay, DateTime denNgay)
        {
            try
            {
                if (tuNgay > denNgay)
                    throw new ArgumentException("Ngày bắt đầu không được lớn hơn ngày kết thúc");

                return dalThongKe.LayBaoCaoTongHop(tuNgay, denNgay);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tạo báo cáo: {ex.Message}");
            }
        }

        #endregion

        #region Quản lý người dùng

        //Lấy danh sách tất cả người dùng
        public List<DTO_QuanLyNguoiDung> LayDanhSachNguoiDung()
        {
            try
            {
                return dalQuanLyNguoiDung.LayTatCaNguoiDung();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách người dùng: {ex.Message}");
            }
        }

        //Tìm kiếm người dùng
        public List<DTO_QuanLyNguoiDung> TimKiemNguoiDung(string tuKhoa)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(tuKhoa))
                    return LayDanhSachNguoiDung();

                return dalQuanLyNguoiDung.TimKiemNguoiDung(tuKhoa.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tìm kiếm người dùng: {ex.Message}");
            }
        }

        //Lọc người dùng theo loại
        public List<DTO_QuanLyNguoiDung> LocNguoiDung(string loaiNguoiDung)
        {
            try
            {
                if (string.IsNullOrEmpty(loaiNguoiDung) || loaiNguoiDung == "ALL")
                    return LayDanhSachNguoiDung();

                if (!new[] { "KHACH", "NHANVIEN", "QUANTRI" }.Contains(loaiNguoiDung.ToUpper()))
                    throw new ArgumentException("Loại người dùng không hợp lệ");

                return dalQuanLyNguoiDung.LocNguoiDungTheoLoai(loaiNguoiDung.ToUpper());
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lọc người dùng: {ex.Message}");
            }
        }

        //Khóa hoặc mở khóa tài khoản
        public bool KhoaTaiKhoan(int maNguoiDung, bool khoa = true)
        {
            try
            {
                if (maNguoiDung <= 0)
                    throw new ArgumentException("Mã người dùng không hợp lệ");

                string trangThai = khoa ? "KHOA" : "HOATDONG";
                return dalQuanLyNguoiDung.ThayDoiTrangThaiTaiKhoan(maNguoiDung, trangThai);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi thay đổi trạng thái tài khoản: {ex.Message}");
            }
        }

        //Cấp quyền cho người dùng
        public bool CapQuyenNguoiDung(int maNguoiDung, string quyenMoi)
        {
            try
            {
                if (maNguoiDung <= 0)
                    throw new ArgumentException("Mã người dùng không hợp lệ");

                if (!new[] { "KHACH", "NHANVIEN", "QUANTRI" }.Contains(quyenMoi.ToUpper()))
                    throw new ArgumentException("Quyền không hợp lệ");

                return dalQuanLyNguoiDung.CapQuyenNguoiDung(maNguoiDung, quyenMoi.ToUpper());
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi cấp quyền: {ex.Message}");
            }
        }

        //Đặt lại mật khẩu
        public bool DatLaiMatKhau(int maNguoiDung, string matKhauMoi = "123456")
        {
            try
            {
                if (maNguoiDung <= 0)
                    throw new ArgumentException("Mã người dùng không hợp lệ");
                if (string.IsNullOrWhiteSpace(matKhauMoi) || matKhauMoi.Length < 6)
                    throw new ArgumentException("Mật khẩu phải có ít nhất 6 ký tự");

                return dalQuanLyNguoiDung.DatLaiMatKhau(maNguoiDung, matKhauMoi);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi đặt lại mật khẩu: {ex.Message}");
            }
        }

        //Lấy thống kê người dùng
        public Dictionary<string, int> LayThongKeNguoiDung()
        {
            try
            {
                return dalQuanLyNguoiDung.LayThongKeNguoiDung();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi thống kê người dùng: {ex.Message}");
            }
        }

        //Lấy lịch sử hoạt động của người dùng
        public List<DTO_LichSuHoatDong> LayLichSuHoatDong(int maNguoiDung, int top = 10)
        {
            try
            {
                if (maNguoiDung <= 0)
                    throw new ArgumentException("Mã người dùng không hợp lệ");

                return dalQuanLyNguoiDung.LayLichSuHoatDong(maNguoiDung, top);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy lịch sử: {ex.Message}");
            }
        }

        //Xóa người dùng
        public bool XoaNguoiDung(int maNguoiDung)
        {
            try
            {
                if (maNguoiDung <= 0)
                    throw new ArgumentException("Mã người dùng không hợp lệ");

                // Không cho phép xóa admin cuối cùng
                var adminCount = dalQuanLyNguoiDung.LocNguoiDungTheoLoai("QUANTRI").Count;
                var nguoiDung = dalQuanLyNguoiDung.LayTatCaNguoiDung().FirstOrDefault(n => n.MaNguoiDung == maNguoiDung);

                if (nguoiDung?.LoaiNguoiDung == "QUANTRI" && adminCount <= 1)
                    throw new Exception("Không thể xóa admin cuối cùng");

                return dalQuanLyNguoiDung.XoaNguoiDung(maNguoiDung);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xóa người dùng: {ex.Message}");
            }
        }

        #endregion

        #region Cấu hình hệ thống

        //Lấy tất cả cấu hình
        public List<DTO_CauHinhHeThong> LayTatCaCauHinh()
        {
            try
            {
                return dalCauHinh.LayTatCaCauHinh();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy cấu hình: {ex.Message}");
            }
        }

        //Lấy cấu hình theo nhóm
        public List<DTO_CauHinhHeThong> LayCauHinhTheoNhom(string nhom)
        {
            try
            {
                if (string.IsNullOrEmpty(nhom))
                    return LayTatCaCauHinh();

                return dalCauHinh.LayCauHinhTheoNhom(nhom);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy cấu hình theo nhóm: {ex.Message}");
            }
        }

        //Cập nhật cấu hình
        public bool CapNhatCauHinh(string tenCauHinh, string giaTriMoi, string nguoiCapNhat)
        {
            try
            {
                if (string.IsNullOrEmpty(tenCauHinh))
                    throw new ArgumentException("Tên cấu hình không được để trống");
                if (!dalCauHinh.ValidateGiaTriCauHinh(tenCauHinh, giaTriMoi))
                    throw new ArgumentException("Giá trị cấu hình không hợp lệ");

                return dalCauHinh.CapNhatCauHinh(tenCauHinh, giaTriMoi, nguoiCapNhat);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi cập nhật cấu hình: {ex.Message}");
            }
        }

        #endregion

        #region Helper Methods
        //Validate khoảng thời gian hợp lệ
        public bool ValidateKhoangThoiGian(DateTime tuNgay, DateTime denNgay)
        {
            if (tuNgay > denNgay) return false;
            if ((denNgay - tuNgay).TotalDays > 365) return false;
            if (denNgay > DateTime.Now.AddDays(1)) return false;
            return true;
        }

        #endregion
    }
}
