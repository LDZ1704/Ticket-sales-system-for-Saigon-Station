using DAL_TicketSalesSystem;
using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TicketSalesSystem
{
    public class BUS_GaTau
    {
        private readonly DAL_GaTau dalGaTau = new DAL_GaTau();
        public List<DTO_GaTau> LayDanhSachGaTau()
        {
            try
            {
                return dalGaTau.LayTatCaGaTau();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách ga tàu: {ex.Message}");
            }
        }
    }
}
