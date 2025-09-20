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
<<<<<<< HEAD
        private readonly DAL_ToaTau dalToa = new DAL_ToaTau();
        private readonly DAL_ChuyenTau dalChuyenTau = new DAL_ChuyenTau();
=======
        private readonly DTO_VNPayConfig vnpayConfig = new DTO_VNPayConfig();
>>>>>>> c6748c47e9d8cb80444f49ab33d2a8edf2fe47b7

        // Phương thức đặt vé đơn lẻ (giữ nguyên để tương thích)
        public bool DatVe(DTO_DatVe datVeInput)
        {
            try
            {
                if (!ValidateInput(datVeInput))
                    return false;

                // Lấy giá vé từ toa
                decimal giaVeThucTe = LayGiaVeTuGhe(datVeInput.MaGhe);
                if (giaVeThucTe <= 0)
                    throw new Exception("Không thể xác định giá vé");

                // Tạo hoặc lấy hành khách
                int maHanhKhach = TaoHoacLayHanhKhach(datVeInput);
                if (maHanhKhach <= 0)
                    throw new Exception("Không thể tạo thông tin hành khách");

                // Tạo thanh toán
                int maThanhToan = TaoThanhToan(datVeInput.MaNguoiDung, giaVeThucTe);
                if (maThanhToan <= 0)
                    throw new Exception("Không thể tạo giao dịch thanh toán");

                // Cập nhật trạng thái ghế trước khi đặt vé
                bool capNhatGhe = dalGhe.ChinhSuaTrangThaiGhe(datVeInput.MaGhe, "DADAT");
                if (!capNhatGhe)
                    throw new Exception("Không thể đặt ghế");

                // Tạo vé
                string maQR = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 12).ToUpper();
                bool taoVe = dalVe.ThemVe(
                    maHanhKhach,
                    datVeInput.MaChuyen,
                    datVeInput.MaGhe,
                    maThanhToan,
                    giaVeThucTe,  // Sử dụng giá vé từ toa
                    maQR
                );

                if (!taoVe)
                {
                    //Rollback
                    dalGhe.ChinhSuaTrangThaiGhe(datVeInput.MaGhe, "TRONG");
                    throw new Exception("Không thể tạo vé");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi đặt vé: {ex.Message}");
            }
        }

<<<<<<< HEAD
        //Lấy giá vé từ ghế được chọn
        private decimal LayGiaVeTuGhe(int maGhe)
=======
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
>>>>>>> c6748c47e9d8cb80444f49ab33d2a8edf2fe47b7
        {
            try
            {
                return dalVe.LayGiaVeTuGhe(maGhe);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy giá vé từ ghế: {ex.Message}");
            }
        }

        //Lấy thông tin giá vé cho form hiển thị
        public decimal LayGiaVeChoHienThi(int maGhe)
        {
            try
            {
                return LayGiaVeTuGhe(maGhe);
            }
            catch
            {
                return 0;
            }
        }

        //Lấy thông tin giá vé từ toa
        public decimal LayGiaVeTuToa(int maToa)
        {
            try
            {
                return dalToa.LayGiaVeBangMaToa(maToa);
            }
            catch
            {
                return 0;
            }
        }

        private bool ValidateInput(DTO_DatVe input)
        {
            if (input == null)
                throw new ArgumentNullException("Thông tin đặt vé không hợp lệ");
            if (input.MaChuyen <= 0)
                throw new ArgumentException("Mã chuyến không hợp lệ");
            if (input.MaGhe <= 0)
                throw new ArgumentException("Mã ghế không hợp lệ");
            if (string.IsNullOrWhiteSpace(input.HoTen))
                throw new ArgumentException("Họ tên không được để trống");
            if (input.HoTen.Trim().Length < 2)
                throw new ArgumentException("Họ tên phải có ít nhất 2 ký tự");
            if (string.IsNullOrWhiteSpace(input.SoGiayTo))
                throw new ArgumentException("Số giấy tờ không được để trống");
            if (input.SoGiayTo.Trim().Length < 9)
                throw new ArgumentException("Số giấy tờ không hợp lệ");
            if (string.IsNullOrWhiteSpace(input.GioiTinh))
                throw new ArgumentException("Giới tính không được để trống");
            if (input.NgaySinh >= DateTime.Now.AddYears(-16))
                throw new ArgumentException("Hành khách phải từ 16 tuổi trở lên");
            if (input.MaNguoiDung <= 0)
                throw new ArgumentException("Mã người dùng không hợp lệ");

            return true;
        }

<<<<<<< HEAD
        private int TaoHoacLayHanhKhach(DTO_DatVe input)
        {
            try
            {
                // Kiểm tra xem hành khách đã tồn tại chưa
                var existingHanhKhach = dalHanhKhach.LayHanhKhachBangSoGiayTo(input.SoGiayTo);

                if (existingHanhKhach != null)
                {
                    // Cập nhật thông tin nếu cần
                    var updatedHanhKhach = new DTO_HanhKhach
                    {
                        MaHanhKhach = existingHanhKhach.MaHanhKhach,
                        HoTen = input.HoTen.Trim(),
                        GioiTinh = input.GioiTinh,
                        NgaySinh = input.NgaySinh,
                        LoaiGiayTo = "CCCD", // Mặc định
                        SoGiayTo = input.SoGiayTo.Trim(),
                        QuocTich = "Việt Nam" // Mặc định
                    };

                    dalHanhKhach.CapNhatHanhKhach(updatedHanhKhach);
                    return existingHanhKhach.MaHanhKhach ?? 0;
                }
                else
                {
                    // Tạo mới hành khách
                    var newHanhKhach = new DTO_HanhKhach
                    {
                        HoTen = input.HoTen.Trim(),
                        GioiTinh = input.GioiTinh,
                        NgaySinh = input.NgaySinh,
                        LoaiGiayTo = "CCCD", // Mặc định
                        SoGiayTo = input.SoGiayTo.Trim(),
                        QuocTich = "Việt Nam" // Mặc định
                    };

                    return dalHanhKhach.ThemHanhKhach(newHanhKhach);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi xử lý thông tin hành khách: {ex.Message}");
            }
        }

        private int TaoThanhToan(int maNguoiDung, decimal soTien)
        {
            try
            {
                var thanhToan = new DTO_ThanhToan
                {
                    MaNguoiDung = maNguoiDung,
                    HinhThuc = "VNPAY", // Mặc định
                    ThoiDiem = DateTime.Now,
                    TrangThai = "THANHCONG", // Giả lập thanh toán thành công
                    NgayThanhToan = DateTime.Now
                };

                return dalThanhToan.ThemThanhToan(thanhToan);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tạo thanh toán: {ex.Message}");
            }
        }

        //Kiểm tra ghế có khả dụng để đặt không
        public bool KiemTraGheKhaDung(int maGhe)
        {
            try
            {
                var ghe = dalGhe.LayGheBangId(maGhe);
                return ghe != null && ghe.TrangThai == "TRONG";
            }
            catch
            {
                return false;
            }
        }

        //Lấy thông tin đầy đủ về ghế và giá vé
        public dynamic LayThongTinGheVaGiaVe(int maGhe)
        {
            try
            {
                return dalChuyenTau.LayThongTinToaVaGiaVeTuGhe(maGhe);
            }
            catch
            {
                return null;
            }
        }

        //Estimate giá vé cho preview
        public decimal EstimateGiaVe(int maToa)
        {
            try
            {
                return dalToa.LayGiaVeBangMaToa(maToa);
            }
            catch
            {
                return 0;
            }
=======
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
>>>>>>> c6748c47e9d8cb80444f49ab33d2a8edf2fe47b7
        }
    }
}
