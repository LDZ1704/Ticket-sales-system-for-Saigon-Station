using System;
using System.Web.Http;
using DAL_TicketSalesSystem;

namespace API_TicketSalesSystem.Controllers
{
    [RoutePrefix("api/giave")]
    public class GiaVeController : ApiController
    {
        private readonly DAL_TinhGiaVe _dalTinhGiaVe;

        public GiaVeController()
        {
            _dalTinhGiaVe = new DAL_TinhGiaVe();
        }

        [HttpGet]
        [Route("tinh")]
        public IHttpActionResult TinhGiaVe(int maChuyen, int maGhe)
        {
            try
            {
                var giaVeInfo = _dalTinhGiaVe.LayThongTinGiaVe(maChuyen, maGhe);
                
                if (giaVeInfo == null)
                {
                    return NotFound();
                }

                return Ok(new
                {
                    success = true,
                    data = new
                    {
                        maGhe = giaVeInfo.MaGhe,
                        soHieu = giaVeInfo.SoHieu,
                        tenToa = giaVeInfo.TenToa,
                        loaiGhe = giaVeInfo.LoaiGhe,
                        giaVeCoBan = giaVeInfo.GiaVeCoBan,
                        khoangCach = giaVeInfo.KhoangCach,
                        gaDi = giaVeInfo.GaDi,
                        gaDen = giaVeInfo.GaDen,
                        giaVeCuoiCung = giaVeInfo.GiaVeCuoiCung
                    }
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("coban")]
        public IHttpActionResult LayGiaVeCoBan(int maGhe)
        {
            try
            {
                decimal giaVeCoBan = _dalTinhGiaVe.LayGiaVeCoBan(maGhe);
                
                return Ok(new
                {
                    success = true,
                    data = new
                    {
                        maGhe = maGhe,
                        giaVeCoBan = giaVeCoBan
                    }
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("test")]
        public IHttpActionResult TestTinhGiaVe()
        {
            try
            {
                // Test với dữ liệu mẫu
                var testCases = new[]
                {
                    new { maChuyen = 1, maGhe = 1 },
                    new { maChuyen = 1, maGhe = 5 },
                    new { maChuyen = 2, maGhe = 10 }
                };

                var results = new System.Collections.Generic.List<object>();

                foreach (var testCase in testCases)
                {
                    try
                    {
                        var giaVeInfo = _dalTinhGiaVe.LayThongTinGiaVe(testCase.maChuyen, testCase.maGhe);
                        if (giaVeInfo != null)
                        {
                            results.Add(new
                            {
                                maChuyen = testCase.maChuyen,
                                maGhe = testCase.maGhe,
                                success = true,
                                data = giaVeInfo
                            });
                        }
                        else
                        {
                            results.Add(new
                            {
                                maChuyen = testCase.maChuyen,
                                maGhe = testCase.maGhe,
                                success = false,
                                message = "Không tìm thấy thông tin ghế/chuyến tàu"
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        results.Add(new
                        {
                            maChuyen = testCase.maChuyen,
                            maGhe = testCase.maGhe,
                            success = false,
                            error = ex.Message
                        });
                    }
                }

                return Ok(new
                {
                    success = true,
                    message = "Test tính giá vé",
                    results = results
                });
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
