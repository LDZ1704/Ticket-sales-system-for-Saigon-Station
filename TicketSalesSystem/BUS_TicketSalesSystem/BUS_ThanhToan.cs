using DAL_TicketSalesSystem;
using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TicketSalesSystem
{
    public class BUS_ThanhToan
    {
        private readonly DAL_ThanhToan dalThanhToan = new DAL_ThanhToan();

        /// <summary>
        /// Tạo thanh toán cho việc đổi vé
        /// </summary>
        /// <param name="maNguoiDung">Mã người dùng</param>
        /// <param name="hinhThuc">Hình thức thanh toán (VNPAY, MOMO)</param>
        /// <param name="soTien">Số tiền cần thanh toán thêm (có thể âm nếu hoàn lại)</param>
        /// <returns>Mã thanh toán mới được tạo</returns>
        public int TaoThanhToanDoiVe(int maNguoiDung, string hinhThuc, decimal soTien)
        {
            try
            {
                if (maNguoiDung <= 0)
                    throw new ArgumentException("Mã người dùng không hợp lệ");

                if (string.IsNullOrEmpty(hinhThuc))
                    hinhThuc = "VNPAY"; // Mặc định

                // Validate hình thức thanh toán
                if (hinhThuc != "VNPAY" && hinhThuc != "MOMO")
                    throw new ArgumentException("Hình thức thanh toán không hợp lệ");

                var dto = new DTO_ThanhToan
                {
                    MaNguoiDung = maNguoiDung,
                    HinhThuc = hinhThuc,
                    ThoiDiem = DateTime.Now,
                    TrangThai = "THANHCONG", // Giả lập thanh toán thành công
                    NgayThanhToan = DateTime.Now
                };

                return dalThanhToan.ThemThanhToan(dto);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tạo thanh toán đổi vé: {ex.Message}");
            }
        }

        /// <summary>
        /// Tạo thanh toán cho việc hủy vé (để ghi nhận hoàn tiền nếu có)
        /// </summary>
        /// <param name="maNguoiDung">Mã người dùng</param>
        /// <param name="soTienHoan">Số tiền hoàn lại</param>
        /// <returns>Mã thanh toán hoàn tiền</returns>
        public int TaoThanhToanHoanTien(int maNguoiDung, decimal soTienHoan)
        {
            try
            {
                if (maNguoiDung <= 0)
                    throw new ArgumentException("Mã người dùng không hợp lệ");

                if (soTienHoan <= 0)
                    return 0; // Không hoàn tiền

                var dto = new DTO_ThanhToan
                {
                    MaNguoiDung = maNguoiDung,
                    HinhThuc = "VNPAY",
                    ThoiDiem = DateTime.Now,
                    TrangThai = "THANHCONG",
                    NgayThanhToan = DateTime.Now
                };

                return dalThanhToan.ThemThanhToan(dto);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tạo thanh toán hoàn tiền: {ex.Message}");
            }
        }

        /// <summary>
        /// Tính chênh lệch giá vé khi đổi
        /// </summary>
        /// <param name="giaVeCu">Giá vé cũ</param>
        /// <param name="giaVeMoi">Giá vé mới</param>
        /// <returns>Số tiền chênh lệch (dương = phải trả thêm, âm = được hoàn)</returns>
        public decimal TinhChenhLechGiaVe(decimal giaVeCu, decimal giaVeMoi)
        {
            return giaVeMoi - giaVeCu;
        }

        /// <summary>
        /// Tính tiền hoàn khi hủy vé
        /// </summary>
        /// <param name="giaVe">Giá vé gốc</param>
        /// <param name="ngayKhoiHanh">Ngày khởi hành của chuyến tàu</param>
        /// <param name="ngayHuy">Ngày hủy vé</param>
        /// <returns>Số tiền được hoàn</returns>
        public decimal TinhTienHoanKhiHuyVe(decimal giaVe, DateTime ngayKhoiHanh, DateTime ngayHuy)
        {
            try
            {
                // Tính số giờ còn lại trước khi khởi hành
                var soGioConLai = (ngayKhoiHanh - ngayHuy).TotalHours;

                if (soGioConLai < 24)
                {
                    // Hủy trong vòng 24h: không hoàn tiền
                    return 0;
                }
                else if (soGioConLai >= 24 && soGioConLai < 48)
                {
                    // Hủy từ 24-48h trước: hoàn 50%
                    return giaVe * 0.5m;
                }
                else if (soGioConLai >= 48 && soGioConLai < 72)
                {
                    // Hủy từ 48-72h trước: hoàn 70%
                    return giaVe * 0.7m;
                }
                else
                {
                    // Hủy trên 72h trước: hoàn 90%
                    return giaVe * 0.9m;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tính tiền hoàn: {ex.Message}");
            }
        }

        /// <summary>
        /// Kiểm tra có thể hủy/đổi vé không (theo quy định 24h)
        /// </summary>
        /// <param name="ngayKhoiHanh">Ngày khởi hành</param>
        /// <param name="ngayHienTai">Ngày hiện tại</param>
        /// <returns>True nếu còn đủ thời gian</returns>
        public bool KiemTraThoiGianChoPhep(DateTime ngayKhoiHanh, DateTime ngayHienTai)
        {
            var soGioConLai = (ngayKhoiHanh - ngayHienTai).TotalHours;
            return soGioConLai >= 24;
        }

        /// <summary>
        /// Lấy thông báo về chính sách hoàn tiền
        /// </summary>
        /// <param name="ngayKhoiHanh">Ngày khởi hành</param>
        /// <param name="ngayHienTai">Ngày hiện tại</param>
        /// <returns>Chuỗi mô tả chính sách hoàn tiền</returns>
        public string LayThongBaoChinhSachHoanTien(DateTime ngayKhoiHanh, DateTime ngayHienTai)
        {
            var soGioConLai = (ngayKhoiHanh - ngayHienTai).TotalHours;

            if (soGioConLai < 24)
            {
                return "Không thể hủy vé trong vòng 24h trước khởi hành.";
            }
            else if (soGioConLai >= 24 && soGioConLai < 48)
            {
                return "Hủy vé từ 24-48h trước khởi hành: Hoàn lại 50% giá vé.";
            }
            else if (soGioConLai >= 48 && soGioConLai < 72)
            {
                return "Hủy vé từ 48-72h trước khởi hành: Hoàn lại 70% giá vé.";
            }
            else
            {
                return "Hủy vé trên 72h trước khởi hành: Hoàn lại 90% giá vé.";
            }
        }

        /// <summary>
        /// Validate điều kiện đổi vé
        /// </summary>
        /// <param name="ngayKhoiHanhCu">Ngày khởi hành vé cũ</param>
        /// <param name="ngayKhoiHanhMoi">Ngày khởi hành vé mới</param>
        /// <param name="ngayHienTai">Ngày hiện tại</param>
        /// <returns>True nếu thỏa mãn điều kiện đổi</returns>
        public bool KiemTraDieuKienDoiVe(DateTime ngayKhoiHanhCu, DateTime ngayKhoiHanhMoi, DateTime ngayHienTai)
        {
            // Kiểm tra 24h trước chuyến cũ
            if (!KiemTraThoiGianChoPhep(ngayKhoiHanhCu, ngayHienTai))
                return false;

            // Chuyến mới phải trong cùng ngày hoặc sau ngày của chuyến cũ
            // (theo yêu cầu "cùng tuyến, cùng ngày hoặc theo điều kiện")
            return ngayKhoiHanhMoi.Date >= ngayKhoiHanhCu.Date;
        }
    }
}
