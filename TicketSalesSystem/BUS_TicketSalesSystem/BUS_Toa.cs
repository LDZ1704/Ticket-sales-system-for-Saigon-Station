using DAL_TicketSalesSystem;
using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TicketSalesSystem
{
    public class BUS_Toa
    {
        private readonly DAL_ToaTau dalToaTau = new DAL_ToaTau();

        public List<DTO_ToaTau> LayToaBangChuyenTau(int maChuyenTau)
        {
            try
            {
                if (maChuyenTau <= 0)
                    throw new ArgumentException("Mã chuyến tàu không hợp lệ");

                return dalToaTau.LayToaBangChuyenTau(maChuyenTau);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách toa: {ex.Message}");
            }
        }

        public List<DTO_ToaTau> LayToaBangTau(int maTau)
        {
            try
            {
                if (maTau <= 0)
                    throw new ArgumentException("Mã tàu không hợp lệ");

                return dalToaTau.LayToaBangTau(maTau);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách toa theo tàu: {ex.Message}");
            }
        }

        public DTO_ToaTau LayToaBangId(int maToa)
        {
            try
            {
                if (maToa <= 0)
                    throw new ArgumentException("Mã toa không hợp lệ");

                return dalToaTau.LayToaBangId(maToa);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy thông tin toa: {ex.Message}");
            }
        }

        public decimal LayGiaVeBangMaToa(int maToa)
        {
            try
            {
                if (maToa <= 0)
                    throw new ArgumentException("Mã toa không hợp lệ");

                return dalToaTau.LayGiaVeBangMaToa(maToa);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy giá vé toa: {ex.Message}");
            }
        }

        public string LayThongTinToaBangMaToa(int maToa)
        {
            try
            {
                if (maToa <= 0)
                    throw new ArgumentException("Mã toa không hợp lệ");

                return dalToaTau.LayThongTinToaBangMaToa(maToa);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy thông tin toa: {ex.Message}");
            }
        }

        public List<DTO_ToaTau> LayTatCaToa()
        {
            try
            {
                return dalToaTau.LayTatCaToa();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách tất cả toa: {ex.Message}");
            }
        }

        //Validate giá vé có hợp lệ không
        public bool KiemTraGiaVeHopLe(decimal giaVe)
        {
            return giaVe > 0 && giaVe <= 5000000; // Giới hạn từ 0 đến 5 triệu
        }

        //Lấy thông tin toa với format hiển thị
        public string LayThongTinToaFormatted(int maToa)
        {
            try
            {
                var toa = LayToaBangId(maToa);
                if (toa == null) return string.Empty;
                return $"{toa.TenToa} - {toa.LoaiGhe} ({toa.GiaVe:N0} VND)";
            }
            catch
            {
                return string.Empty;
            }
        }

        //Lấy danh sách toa theo khoảng giá
        public List<DTO_ToaTau> LayToaBangKhoangGia(decimal giaMin, decimal giaMax)
        {
            try
            {
                var tatCaToa = LayTatCaToa();
                return tatCaToa.Where(t => t.GiaVe >= giaMin && t.GiaVe <= giaMax).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy toa theo khoảng giá: {ex.Message}");
            }
        }

        //Lấy danh sách toa theo loại ghế
        public List<DTO_ToaTau> LayToaBangLoaiGhe(string loaiGhe)
        {
            try
            {
                if (string.IsNullOrEmpty(loaiGhe))
                    throw new ArgumentException("Loại ghế không hợp lệ");

                var tatCaToa = LayTatCaToa();
                return tatCaToa.Where(t => t.LoaiGhe.ToLower().Contains(loaiGhe.ToLower())).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy toa theo loại ghế: {ex.Message}");
            }
        }
    }
}
