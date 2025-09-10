using DAL_TicketSalesSystem;
using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TicketSalesSystem
{
    public class BUS_TraCuu
    {
        private DAL_TraCuu dalTraCuu = new DAL_TraCuu();

        public List<DTO_GaTau> LayDanhSachGaTau()
        {
            try
            {
                return dalTraCuu.LayDanhSachGaTau();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách ga tàu: " + ex.Message);
            }
        }

        public List<DTO_ChuyenTau> TraCuuLichChayTau(int maGaDi, int maGaDen, DateTime ngayDi)
        {
            try
            {
                if (maGaDi == maGaDen)
                    throw new Exception("Ga đi và ga đến không được giống nhau");

                if (ngayDi.Date < DateTime.Today)
                    throw new Exception("Ngày đi không được nhỏ hơn ngày hiện tại");

                return dalTraCuu.TraCuuLichChayTau(maGaDi, maGaDen, ngayDi);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tra cứu: " + ex.Message);
            }
        }

        public List<DTO_ChuyenTau> LayTatCaChuyenTau()
        {
            try
            {
                return dalTraCuu.LayTatCaChuyenTau();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách chuyến tàu: " + ex.Message);
            }
        }

        public string LayTenTauTheoMa(int maTau)
        {
            try
            {
                var tau = dalTraCuu.LayThongTinTau(maTau);
                return tau?.TenTau ?? "";
            }
            catch
            {
                return "";
            }
        }

        public string LayTenTuyenTheoMa(int maTuyen)
        {
            try
            {
                var tuyen = dalTraCuu.LayThongTinTuyen(maTuyen);
                if (tuyen == null) return "Không xác định";

                var danhSachGa = dalTraCuu.LayDanhSachGaTau();
                var gaDi = danhSachGa.FirstOrDefault(g => g.MaGaTau == tuyen.MaGaDi);
                var gaDen = danhSachGa.FirstOrDefault(g => g.MaGaTau == tuyen.MaGaDen);

                string tenTuyen = $"{gaDi?.TenGa ?? "N/A"} - {gaDen?.TenGa ?? "N/A"}";
                return tenTuyen;
            }
            catch
            {
                return "Lỗi";
            }
        }
    }
}
