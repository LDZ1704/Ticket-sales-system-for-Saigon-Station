using DAL_TicketSalesSystem;
using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TicketSalesSystem
{
    public class BUS_Ve
    {
        private readonly DAL_Ve dalVe = new DAL_Ve();
        private readonly DAL_Ghe dalGhe = new DAL_Ghe();

        public List<DTO_Ve> LayVeBangNguoiDung(int maNguoiDung)
        {
            try
            {
                if (maNguoiDung <= 0)
                    throw new ArgumentException("Mã người dùng không hợp lệ");

                var list = dalVe.LayVeBangNguoiDung(maNguoiDung);
                var result = new List<DTO_Ve>();

                foreach (var item in list)
                {
                    var dto = new DTO_Ve
                    {
                        // Map từ database
                        MaVe = item.MaVe,
                        MaHanhKhach = item.MaHanhKhach,
                        MaChuyen = item.MaChuyen,
                        MaGhe = item.MaGhe,
                        MaThanhToan = item.MaThanhToan,
                        GiaVe = item.GiaVe,
                        TrangThai = ChuyenDoiTrangThai(item.TrangThai),
                        MaQR = item.MaQR,

                        // Lấy thông tin bổ sung từ DAL
                        HanhKhach = dalVe.LayTenHanhKhachBangVe(item.MaVe.Value),
                        Tuyen = dalVe.LayTuyenBangVe(item.MaVe.Value),
                        ToaGhe = dalVe.LayToaGheBangVe(item.MaVe.Value),
                        NgayKhoiHanh = dalVe.LayNgayKhoiHanhBangVe(item.MaVe.Value),
                        NgayDat = dalVe.LayNgayDatBangVe(item.MaVe.Value)
                    };
                    result.Add(dto);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách vé: {ex.Message}");
            }
        }

        //Hủy vé
        public bool HuyVe(int maVe, int maNguoiDung)
        {
            try
            {
                if (maVe <= 0)
                    throw new ArgumentException("Mã vé không hợp lệ");

                // Kiểm tra vé có thuộc về người dùng không
                if (!dalVe.KiemTraVeThuocVeNguoiDung(maVe, maNguoiDung))
                    throw new Exception("Vé không thuộc về người dùng này");

                // Lấy thông tin chi tiết vé
                var veInfo = dalVe.LayVeChiTietBangId(maVe);
                if (veInfo == null)
                    throw new Exception("Không tìm thấy thông tin vé");

                if (veInfo.TrangThai != "DATHANHTOAN")
                    throw new Exception("Chỉ có thể hủy vé đã thanh toán");

                // Kiểm tra điều kiện thời gian 24h
                var busThanhToan = new BUS_ThanhToan();
                if (!busThanhToan.KiemTraThoiGianChoPhep(veInfo.NgayKhoiHanh, DateTime.Now))
                    throw new Exception("Không thể hủy vé trong vòng 24h trước khởi hành");

                // Lấy mã ghế từ vé
                int maGhe = veInfo.MaGhe;
                if (maGhe <= 0)
                    throw new Exception("Không tìm thấy ghế của vé");

                // Cập nhật trạng thái vé
                bool updateVe = dalVe.ChinhSuaTrangThaiVe(maVe, "DAHUY");
                if (!updateVe)
                    throw new Exception("Không thể hủy vé");

                // Cập nhật trạng thái ghế về trống
                bool updateGhe = dalGhe.ChinhSuaTrangThaiGhe(maGhe, "TRONG");
                if (!updateGhe)
                    throw new Exception("Không thể cập nhật trạng thái ghế");

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi hủy vé: {ex.Message}");
            }
        }

        //Đổi vé với kiểm tra đầy đủ điều kiện
        public bool DoiVe(int maVeCu, int maChuyenMoi, int maGheMoi, int maNguoiDung)
        {
            try
            {
                if (maVeCu <= 0 || maChuyenMoi <= 0 || maGheMoi <= 0)
                    throw new ArgumentException("Thông tin không hợp lệ");

                // Kiểm tra vé có thuộc về người dùng không
                if (!dalVe.KiemTraVeThuocVeNguoiDung(maVeCu, maNguoiDung))
                    throw new Exception("Vé không thuộc về người dùng này");

                // Lấy thông tin vé cũ để kiểm tra
                var veCu = dalVe.LayVeChiTietBangId(maVeCu);
                if (veCu == null)
                    throw new Exception("Không tìm thấy vé cũ");

                if (veCu.TrangThai != "DATHANHTOAN")
                    throw new Exception("Chỉ có thể đổi vé đã thanh toán");

                // Kiểm tra điều kiện 24h
                var busThanhToan = new BUS_ThanhToan();
                if (!busThanhToan.KiemTraThoiGianChoPhep(veCu.NgayKhoiHanh, DateTime.Now))
                    throw new Exception("Không thể đổi vé trong vòng 24h trước khởi hành");

                // Lấy thông tin chuyến mới để kiểm tra điều kiện đổi
                var dalChuyenTau = new DAL_ChuyenTau();
                var chuyenMoi = dalChuyenTau.LayChuyenTauBangId(maChuyenMoi);
                if (chuyenMoi == null)
                    throw new Exception("Không tìm thấy chuyến tàu mới");

                if (!busThanhToan.KiemTraDieuKienDoiVe(veCu.NgayKhoiHanh, chuyenMoi.GioKhoiHanh, DateTime.Now))
                    throw new Exception("Chuyến tàu mới không thỏa mãn điều kiện đổi vé");

                // Lấy giá vé mới từ toa
                decimal giaVeMoi = dalVe.LayGiaVeTuGhe(maGheMoi);
                if (giaVeMoi <= 0)
                    throw new Exception("Không thể xác định giá vé mới");

                // Tính chênh lệch giá vé
                decimal chenhLech = busThanhToan.TinhChenhLechGiaVe(veCu.GiaVe, giaVeMoi);

                // Tạo thanh toán cho chênh lệch (nếu có)
                int maThanhToan = 0;
                if (chenhLech != 0)
                {
                    maThanhToan = busThanhToan.TaoThanhToanDoiVe(maNguoiDung, "VNPAY", chenhLech);
                }
                else
                {
                    // Tạo thanh toán với số tiền 0 để đánh dấu giao dịch đổi vé
                    var dalThanhToan = new DAL_ThanhToan();
                    maThanhToan = dalThanhToan.ThemThanhToan(new DTO_ThanhToan
                    {
                        MaNguoiDung = maNguoiDung,
                        HinhThuc = "VNPAY",
                        TrangThai = "THANHCONG",
                        ThoiDiem = DateTime.Now,
                        NgayThanhToan = DateTime.Now
                    });
                }

                string maQR = Guid.NewGuid().ToString();
                return dalVe.DoiVe(maVeCu, maGheMoi, maChuyenMoi, maThanhToan, giaVeMoi, maQR, veCu.MaHanhKhach);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi đổi vé: {ex.Message}");
            }
        }

        //Lấy giá vé từ ghế được chọn
        public decimal LayGiaVeTuGhe(int maGhe)
        {
            try
            {
                if (maGhe <= 0)
                    throw new ArgumentException("Mã ghế không hợp lệ");

                return dalVe.LayGiaVeTuGhe(maGhe);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy giá vé từ ghế: {ex.Message}");
            }
        }

        //Lấy giá vé từ toa
        public decimal LayGiaVeTuToa(int maToa)
        {
            try
            {
                if (maToa <= 0)
                    throw new ArgumentException("Mã toa không hợp lệ");

                return dalVe.LayGiaVeTuToa(maToa);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy giá vé từ toa: {ex.Message}");
            }
        }

        //Lấy thông tin chi tiết vé theo ID
        public DTO_Ve LayVeChiTietBangId(int maVe)
        {
            try
            {
                if (maVe <= 0)
                    throw new ArgumentException("Mã vé không hợp lệ");

                var dto = dalVe.LayVeChiTietBangId(maVe);
                if (dto == null) return null;

                // Chuyển đổi trạng thái hiển thị
                dto.TrangThai = ChuyenDoiTrangThai(dto.TrangThai);
                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy thông tin vé: {ex.Message}");
            }
        }

        //Kiểm tra vé có thể hủy/đổi không (24h + trạng thái)
        public bool KiemTraVeCoTheHuyDoi(int maVe, int maNguoiDung)
        {
            try
            {
                // Kiểm tra vé thuộc về user
                if (!dalVe.KiemTraVeThuocVeNguoiDung(maVe, maNguoiDung))
                    return false;

                // Lấy thông tin vé
                var veInfo = dalVe.LayVeChiTietBangId(maVe);
                if (veInfo == null || veInfo.TrangThai != "DATHANHTOAN")
                    return false;

                // Kiểm tra thời gian 24h
                var busThanhToan = new BUS_ThanhToan();
                return busThanhToan.KiemTraThoiGianChoPhep(veInfo.NgayKhoiHanh, DateTime.Now);
            }
            catch
            {
                return false;
            }
        }

        //Lấy thông báo lý do không thể hủy/đổi vé
        public string LayLyDoKhongTheHuyDoi(int maVe, int maNguoiDung)
        {
            try
            {
                if (!dalVe.KiemTraVeThuocVeNguoiDung(maVe, maNguoiDung))
                    return "Vé không thuộc về bạn";

                var veInfo = dalVe.LayVeChiTietBangId(maVe);
                if (veInfo == null)
                    return "Không tìm thấy thông tin vé";

                if (veInfo.TrangThai != "DATHANHTOAN")
                    return "Chỉ có thể hủy/đổi vé đã thanh toán";

                var busThanhToan = new BUS_ThanhToan();
                if (!busThanhToan.KiemTraThoiGianChoPhep(veInfo.NgayKhoiHanh, DateTime.Now))
                {
                    var soGioConLai = (veInfo.NgayKhoiHanh - DateTime.Now).TotalHours;
                    return $"Không thể hủy/đổi vé trong vòng 24h trước khởi hành (còn {Math.Floor(soGioConLai)}h)";
                }

                return "Vé có thể hủy/đổi";
            }
            catch (Exception ex)
            {
                return $"Lỗi kiểm tra: {ex.Message}";
            }
        }

        //Lấy danh sách vé có thể đổi
        public List<DTO_Ve> LayDanhSachVeCoTheDoi(int maNguoiDung)
        {
            try
            {
                var list = dalVe.LayDanhSachVeCoTheDoi(maNguoiDung);
                var result = new List<DTO_Ve>();

                foreach (var item in list)
                {
                    var dto = new DTO_Ve
                    {
                        MaVe = item.MaVe,
                        MaHanhKhach = item.MaHanhKhach,
                        MaChuyen = item.MaChuyen,
                        MaGhe = item.MaGhe,
                        MaThanhToan = item.MaThanhToan,
                        GiaVe = item.GiaVe,
                        TrangThai = ChuyenDoiTrangThai(item.TrangThai),
                        MaQR = item.MaQR,
                        NgayKhoiHanh = item.NgayKhoiHanh,

                        // Lấy thông tin bổ sung
                        HanhKhach = dalVe.LayTenHanhKhachBangVe(item.MaVe.Value),
                        Tuyen = dalVe.LayTuyenBangVe(item.MaVe.Value),
                        ToaGhe = dalVe.LayToaGheBangVe(item.MaVe.Value)
                    };
                    result.Add(dto);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách vé có thể đổi: {ex.Message}");
            }
        }

        //Lấy thống kê vé theo trạng thái
        public Dictionary<string, int> LayThongKeVe(int maNguoiDung)
        {
            try
            {
                return dalVe.LayThongKeVeTheoTrangThai(maNguoiDung);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy thống kê vé: {ex.Message}");
            }
        }

        private string ChuyenDoiTrangThai(string trangThai)
        {
            switch(trangThai)
            {
                case "DATHANHTOAN":
                    return "Đã thanh toán";
                case "DAHUY":
                    return "Đã hủy";
                case "DADOI":
                    return "Đã đổi";
                default:
                    return trangThai;
            }
        }

        public bool KiemTraVeCoTheHuy(string trangThai)
        {
            return trangThai == "Đã thanh toán";
        }
    }
}
