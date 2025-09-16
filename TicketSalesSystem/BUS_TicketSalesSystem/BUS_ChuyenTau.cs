using DAL_TicketSalesSystem;
using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TicketSalesSystem
{
    public class BUS_ChuyenTau
    {
        private readonly DAL_ChuyenTau dalChuyenTau = new DAL_ChuyenTau();
        public List<DTO_ChuyenTau> LayTatCaChuyenTau()
        {
            try
            {
                var list = dalChuyenTau.LayTatCaChuyenTau();
                foreach (var item in list)
                {
                    //Thêm thông tin tên tàu, tuyến đường vào GhiChu để GUI hiển thị
                    var tenTau = dalChuyenTau.LayTenTauBangChuyen(item.MaChuyen ?? 0);
                    var tuyen = dalChuyenTau.LayTuyenBangChuyen(item.MaChuyen ?? 0);
                    item.GhiChu = $"{tenTau}|{tuyen}";
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách chuyến tàu: {ex.Message}");
            }
        }

        public DTO_ChuyenTau LayChuyenTauBangId(int maChuyen)
        {
            try
            {
                if (maChuyen <= 0)
                    throw new ArgumentException("Mã chuyến không hợp lệ");

                var dto = dalChuyenTau.LayChuyenTauBangId(maChuyen);
                if (dto == null) return null;

                //Bổ sung thông tin hiển thị
                var tenTau = dalChuyenTau.LayTenTauBangChuyen(dto.MaChuyen ?? 0);
                var tuyen = dalChuyenTau.LayTuyenBangChuyen(dto.MaChuyen ?? 0);
                dto.GhiChu = $"{tenTau}|{tuyen}";
                return dto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy thông tin chuyến tàu: {ex.Message}");
            }
        }

        public string LayTuyenBangChuyen(int maChuyen)
        {
            try
            {
                if (maChuyen <= 0)
                    throw new ArgumentException("Mã chuyến không hợp lệ");

                return dalChuyenTau.LayTuyenBangChuyen(maChuyen);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy thông tin tuyến: {ex.Message}");
            }
        }

        public List<DTO_ChuyenTau> LayDanhSachChuyenTauMoBan()
        {
            try
            {
                var list = dalChuyenTau.LayDanhSachChuyenTauMoBan();

                foreach (var item in list)
                {
                    var tenTau = dalChuyenTau.LayTenTauBangChuyen(item.MaChuyen ?? 0);
                    var tuyen = dalChuyenTau.LayTuyenBangChuyen(item.MaChuyen ?? 0);
                    item.GhiChu = $"{tenTau}|{tuyen}";
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách chuyến mở bán: {ex.Message}");
            }
        }

        public List<DTO_Ghe> LayDanhSachGheTrongBangMaToa(int maToa)
        {
            return dalChuyenTau.LayDanhSachGheTrongBangMaToa(maToa);
        }

        public List<DTO_ChuyenTau> TraCuuChuyenTau(int maGaDi, int maGaDen, DateTime ngayDi)
        {
            try
            {
                var ketQua = new List<DTO_ChuyenTau>();
                var tatCaChuyen = LayTatCaChuyenTau();

                foreach (var chuyen in tatCaChuyen)
                {
                    // Lấy thông tin tuyến đường của chuyến tàu
                    var infoTuyen = dalChuyenTau.LayThongTinTuyenBangChuyen(chuyen.MaChuyen ?? 0);

                    if (infoTuyen != null &&
                        infoTuyen.MaGaDi == maGaDi &&
                        infoTuyen.MaGaDen == maGaDen &&
                        chuyen.GioKhoiHanh.Date == ngayDi.Date)
                    {
                        ketQua.Add(chuyen);
                    }
                }
                return ketQua.OrderBy(c => c.GioKhoiHanh).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi tra cứu chuyến tàu: {ex.Message}");
            }
        }
    }
}
