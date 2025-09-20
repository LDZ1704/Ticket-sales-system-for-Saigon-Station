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

        public bool HuyVe(int maVe)
        {
            try
            {
                if (maVe <= 0)
                    throw new ArgumentException("Mã vé không hợp lệ");

                // Lấy mã ghế từ vé
                int maGhe = dalVe.LayMaGheBangVe(maVe);
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

        public bool ThemDanhSachVe(List<DTO_Ve> danhSachVe)
        {
            return dalVe.ThemDanhSachVe(danhSachVe);
        }

        public bool KiemTraVeCoTheHuy(string trangThai)
        {
            return trangThai == "Đã thanh toán";
        }
    }
}
