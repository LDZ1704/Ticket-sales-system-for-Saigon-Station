using DAL_TicketSalesSystem;
using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TicketSalesSystem
{
    public class BUS_ThanhToan
    {
        private DAL_ThanhToan dalThanhToan = new DAL_ThanhToan();

        public DTO_ThanhToan LayThanhToanTheoId(int maThanhToan)
        {
            return dalThanhToan.LayThanhToanTheoId(maThanhToan);
        }
    }
}
