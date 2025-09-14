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

        public List<DTO_ToaTau> LayToaBangChuyenTau(int maChuyen)
        {
            try
            {
                if (maChuyen <= 0)
                    throw new ArgumentException("Mã chuyến không hợp lệ");

                var list = dalToaTau.LayToaBangChuyenTau(maChuyen);
                foreach (var item in list)
                {
                    int soChoTrong = dalToaTau.LaySoChoTrongBangToa(item.MaToa ?? 0);
                    item.SoChoTrong = soChoTrong;
                    item.DisplayText = $"{item.TenToa} - {item.LoaiGhe} ({soChoTrong} chỗ trống)";
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách toa: {ex.Message}");
            }
        }
    }
}
