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
    }
}
