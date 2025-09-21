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
        private readonly DAL_ToaTau dalToa = new DAL_ToaTau();
        private readonly DAL_ChuyenTau dalChuyenTau = new DAL_ChuyenTau();

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

        //Lấy giá vé từ ghế được chọn
        private decimal LayGiaVeTuGhe(int maGhe)
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
        }
    }
}
