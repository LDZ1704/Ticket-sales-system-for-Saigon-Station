using DAL_TicketSalesSystem;
using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_TicketSalesSystem
{
    public class BUS_Ghe
    {
        private readonly DAL_Ghe dalGhe = new DAL_Ghe();

        public List<DTO_Ghe> LayGheBangToa(int maToa)
        {
            try
            {
                if (maToa <= 0) throw new ArgumentException("Mã toa không hợp lệ");
                return dalGhe.LayGheBangToa(maToa);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách ghế: {ex.Message}");
            }
        }

        public bool ChinhSuaTrangThaiGhe(int maGhe, string trangThai)
        {
            try
            {
                if (maGhe <= 0)
                    throw new ArgumentException("Mã ghế không hợp lệ");
                if (string.IsNullOrEmpty(trangThai))
                    throw new ArgumentException("Trạng thái không được rỗng");
                return dalGhe.ChinhSuaTrangThaiGhe(maGhe, trangThai);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi cập nhật trạng thái ghế: {ex.Message}");
            }
        }

        public DTO_Ghe LayGheBangId(int maGhe)
        {
            try
            {
                if (maGhe <= 0)
                    throw new ArgumentException("Mã ghế không hợp lệ");
                return dalGhe.LayGheBangId(maGhe);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy thông tin ghế: {ex.Message}");
            }
        }

        public List<DTO_Ghe> LayGheTheoChuyen(int maChuyen)
        {
            try
            {
                if (maChuyen <= 0)
                    throw new ArgumentException("Mã chuyến không hợp lệ");
                return dalGhe.LayGheBangChuyen(maChuyen);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi lấy danh sách ghế theo chuyến: {ex.Message}");
            }
        }
    }
}