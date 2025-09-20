using API_TicketSalesSystem.Utils;
using DAL_TicketSalesSystem;
using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TicketSalesSystem
{
    public class BUS_DatVe
    {
        private readonly DAL_HanhKhach dalHanhKhach = new DAL_HanhKhach();
        private readonly DAL_ThanhToan dalThanhToan = new DAL_ThanhToan();
        private readonly DAL_Ve dalVe = new DAL_Ve();
        private readonly DAL_Ghe dalGhe = new DAL_Ghe();
        private readonly DTO_VNPayConfig vnpayConfig = new DTO_VNPayConfig();

        // Phương thức đặt vé đơn lẻ (giữ nguyên để tương thích)
        public bool DatVe(DTO_DatVe datVeInput)
        {
            try
            {
                // Validate input
                if (!ValidateDatVe(datVeInput))
                    return false;

                // Kiểm tra ghế có trống không
                var ghe = dalGhe.LayGheBangId(datVeInput.MaGhe);
                if (ghe == null || ghe.TrangThai != "TRONG")
                    throw new Exception("Ghế đã được đặt hoặc không tồn tại");

                // Tạo hoặc lấy hành khách
                var hanhKhach = dalHanhKhach.LayHanhKhachBangSoGiayTo(datVeInput.SoGiayTo);
                int maHanhKhach;

                if (hanhKhach == null)
                {
                    var dtoHanhKhach = new DTO_HanhKhach
                    {
                        HoTen = datVeInput.HoTen,
                        GioiTinh = datVeInput.GioiTinh,
                        NgaySinh = datVeInput.NgaySinh,
                        LoaiGiayTo = "CCCD",
                        SoGiayTo = datVeInput.SoGiayTo,
                        QuocTich = "Việt Nam"
                    };
                    maHanhKhach = dalHanhKhach.ThemHanhKhach(dtoHanhKhach);
                }
                else
                {
                    maHanhKhach = hanhKhach.MaHanhKhach ?? 0;
                }

                // Tạo thanh toán
                var dtoThanhToan = new DTO_ThanhToan
                {
                    MaNguoiDung = datVeInput.MaNguoiDung,
                    HinhThuc = "VNPAY",
                    ThoiDiem = DateTime.Now,
                    TrangThai = "THANHCONG",
                    NgayThanhToan = DateTime.Now
                };
                int maThanhToan = dalThanhToan.ThemThanhToan(dtoThanhToan);

                // Tạo vé
                string maQR = Guid.NewGuid().ToString();
                bool insertVe = dalVe.ThemVe(maHanhKhach, datVeInput.MaChuyen, datVeInput.MaGhe, maThanhToan, datVeInput.GiaVe, maQR);

                if (!insertVe)
                    throw new Exception("Không thể tạo vé");

                // Cập nhật trạng thái ghế
                bool updateGhe = dalGhe.ChinhSuaTrangThaiGhe(datVeInput.MaGhe, "DADAT");
                if (!updateGhe)
                    throw new Exception("Không thể cập nhật trạng thái ghế");

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi đặt vé: {ex.Message}");
            }
        }

        // Phương thức tạo URL thanh toán VNPay cho giỏ hàng
        public string TaoUrlThanhToanVNPay(DTO_GioHang gioHang)
        {
            try
            {
                if (gioHang == null || !gioHang.DanhSachVe.Any())
                    throw new ArgumentException("Giỏ hàng không hợp lệ");

                foreach (var ve in gioHang.DanhSachVe)
                {
                    if (!ValidateVeTrongGio(ve))
                        throw new ArgumentException($"Vé không hợp lệ: {ve.HoTen}");
                }

                // Tạo thanh toán tạm thời
                var dtoThanhToan = new DTO_ThanhToan
                {
                    MaNguoiDung = gioHang.MaNguoiDung,
                    HinhThuc = "VNPAY",
                    ThoiDiem = DateTime.Now,
                    TrangThai = "DANGXULY",
                    NgayThanhToan = DateTime.Now
                };
                int maThanhToan = dalThanhToan.ThemThanhToan(dtoThanhToan);
                gioHang.MaThanhToan = maThanhToan;

                // Vòng lặp hành khách + vé
                List<DTO_Ve> danhSachVe = new List<DTO_Ve>();
                foreach (var ve in gioHang.DanhSachVe)
                {
                    // 1. Tạo hành khách mới
                    var dtoHK = new DTO_HanhKhach
                    {
                        HoTen = ve.HoTen,
                        GioiTinh = ve.GioiTinh,
                        NgaySinh = ve.NgaySinh,
                        LoaiGiayTo = "CCCD",
                        SoGiayTo = ve.SoGiayTo,
                        QuocTich = "Vietnamese",
                        SoDienThoai = "0123456789"
                    };
                    int maHanhKhach = dalHanhKhach.ThemHanhKhach(dtoHK);
                  
                    string maQR = Guid.NewGuid().ToString();

                    // 3. Tạo vé
                    danhSachVe.Add(new DTO_Ve
                    {
                        MaHanhKhach = maHanhKhach,
                        MaChuyen = ve.MaChuyen,
                        MaGhe = ve.MaGhe,
                        MaThanhToan = maThanhToan,
                        GiaVe = ve.GiaVe,
                        TrangThai = "DATHANHTOAN", 
                        MaQR = maQR
                    });
                }

                // Thêm toàn bộ vé
                dalVe.ThemDanhSachVe(danhSachVe);

                // Tạo VNPay request
                var vnp = new VnpayLibrary();
                vnp.AddRequestData("vnp_Version", VnpayLibrary.VERSION);
                vnp.AddRequestData("vnp_Command", "pay");
                vnp.AddRequestData("vnp_TmnCode", "LJOV7890");
                vnp.AddRequestData("vnp_Amount", ((int)(gioHang.TongTien * 100)).ToString());
                vnp.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
                vnp.AddRequestData("vnp_CurrCode", "VND");
                vnp.AddRequestData("vnp_IpAddr", "127.0.0.1");
                vnp.AddRequestData("vnp_Locale", "vn");
                vnp.AddRequestData("vnp_OrderInfo", $"Dat{gioHang.DanhSachVe.Count} ve tau - Ma TT {maThanhToan}");
                vnp.AddRequestData("vnp_OrderType", "other");
                vnp.AddRequestData("vnp_ReturnUrl", "http://localhost:8080/api/vnpay/callback");
                vnp.AddRequestData("vnp_TxnRef", maThanhToan.ToString());

                string url = vnp.CreateRequestUrl(
                    "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html",
                    "00ABBP3B3DHPXAW8GR1UUY95P2HUPLWE");

                return url;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tạo URL thanh toán: {ex.Message}");
            }
        }


        // Phương thức xử lý thanh toán thành công
        public bool XuLyThanhToanThanhCong(int maThanhToan, DTO_GioHang gioHang)
        {
            try
            {
                // Cập nhật trạng thái thanh toán
                bool updateThanhToan = dalThanhToan.CapNhatTrangThaiThanhToan(maThanhToan, "THANHCONG");
                if (!updateThanhToan)
                    throw new Exception("Không thể cập nhật trạng thái thanh toán");

                // Tạo vé cho từng hành khách
                foreach (var veTrongGio in gioHang.DanhSachVe)
                {
                    // Tạo hoặc lấy hành khách
                    var hanhKhach = dalHanhKhach.LayHanhKhachBangSoGiayTo(veTrongGio.SoGiayTo);
                    int maHanhKhach;

                    if (hanhKhach == null)
                    {
                        var dtoHanhKhach = new DTO_HanhKhach
                        {
                            HoTen = veTrongGio.HoTen,
                            GioiTinh = veTrongGio.GioiTinh,
                            NgaySinh = veTrongGio.NgaySinh,
                            LoaiGiayTo = "CCCD",
                            SoGiayTo = veTrongGio.SoGiayTo,
                            QuocTich = "Việt Nam"
                        };
                        maHanhKhach = dalHanhKhach.ThemHanhKhach(dtoHanhKhach);
                    }
                    else
                    {
                        maHanhKhach = hanhKhach.MaHanhKhach ?? 0;
                    }

                    // Tạo vé
                    string maQR = Guid.NewGuid().ToString();
                    bool insertVe = dalVe.ThemVe(maHanhKhach, veTrongGio.MaChuyen, veTrongGio.MaGhe, maThanhToan, veTrongGio.GiaVe, maQR);

                    if (!insertVe)
                        throw new Exception($"Không thể tạo vé cho {veTrongGio.HoTen}");

                    // Cập nhật trạng thái ghế
                    bool updateGhe = dalGhe.ChinhSuaTrangThaiGhe(veTrongGio.MaGhe, "DADAT");
                    if (!updateGhe)
                        throw new Exception($"Không thể cập nhật trạng thái ghế cho {veTrongGio.HoTen}");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xử lý thanh toán: {ex.Message}");
            }
        }

        // Phương thức xử lý thanh toán thất bại
        public bool XuLyThanhToanThatBai(int maThanhToan)
        {
            try
            {
                bool updateThanhToan = dalThanhToan.CapNhatTrangThaiThanhToan(maThanhToan, "THATBAI");
                return updateThanhToan;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xử lý thanh toán thất bại: {ex.Message}");
            }
        }

        private bool ValidateDatVe(DTO_DatVe input)
        {
            if (input.MaChuyen <= 0)
                throw new ArgumentException("Mã chuyến không hợp lệ");
            if (input.MaGhe <= 0)
                throw new ArgumentException("Mã ghế không hợp lệ");
            if (string.IsNullOrEmpty(input.HoTen))
                throw new ArgumentException("Họ tên không được rỗng");
            if (string.IsNullOrEmpty(input.SoGiayTo))
                throw new ArgumentException("Số giấy tờ không được rỗng");
            if (string.IsNullOrEmpty(input.GioiTinh))
                throw new ArgumentException("Giới tính không được rỗng");
            if (input.NgaySinh >= DateTime.Now)
                throw new ArgumentException("Ngày sinh không hợp lệ");
            if (input.GiaVe <= 0)
                throw new ArgumentException("Giá vé không hợp lệ");
            if (input.MaNguoiDung <= 0)
                throw new ArgumentException("Mã người dùng không hợp lệ");

            return true;
        }

        private bool ValidateVeTrongGio(DTO_VeTrongGio ve)
        {
            if (ve.MaChuyen <= 0)
                throw new ArgumentException("Mã chuyến không hợp lệ");
            if (ve.MaGhe <= 0)
                throw new ArgumentException("Mã ghế không hợp lệ");
            if (string.IsNullOrEmpty(ve.HoTen))
                throw new ArgumentException("Họ tên không được rỗng");
            if (string.IsNullOrEmpty(ve.SoGiayTo))
                throw new ArgumentException("Số giấy tờ không được rỗng");
            if (string.IsNullOrEmpty(ve.GioiTinh))
                throw new ArgumentException("Giới tính không được rỗng");
            if (ve.NgaySinh >= DateTime.Now)
                throw new ArgumentException("Ngày sinh không hợp lệ");
            if (ve.GiaVe <= 0)
                throw new ArgumentException("Giá vé không hợp lệ");

            return true;
        }
    }
}
