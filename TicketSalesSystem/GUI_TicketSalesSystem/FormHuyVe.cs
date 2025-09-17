using BUS_TicketSalesSystem;
using DTO_TicketSalesSystem;
using DTO_TicketSalesSystem.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem
{
    public partial class FormHuyVe : Form
    {
        private readonly int _maVe;
        private readonly DTO_Ve dtoVe;
        private readonly BUS_Ve busVe = new BUS_Ve();
        private readonly BUS_ThanhToan busThanhToan = new BUS_ThanhToan();
        private readonly BUS_ChuyenTau busChuyenTau = new BUS_ChuyenTau();
        public FormHuyVe(int maVe, DTO_Ve thongTinVe)
        {
            InitializeComponent();
            _maVe = maVe;
            dtoVe = thongTinVe;
        }

        private void FormHuyVe_Load(object sender, EventArgs e)
        {
            try
            {
                HienThiThongTinVe();
                TinhToanVaHienThiHoanTien();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải thông tin: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiThongTinVe()
        {
            lblMaVe.Text = $"Mã vé: {dtoVe.MaVe}";
            lblHanhKhach.Text = $"Hành khách: {dtoVe.HanhKhach}";
            lblTuyen.Text = $"Tuyến: {dtoVe.Tuyen}";
            lblToaGhe.Text = $"Toa - Ghế: {dtoVe.ToaGhe}";
            lblNgayKhoiHanh.Text = $"Ngày khởi hành: {dtoVe.NgayKhoiHanh:dd/MM/yyyy HH:mm}";
            lblGiaVe.Text = $"Giá vé: {dtoVe.GiaVe:N0} VND";
        }

        private void TinhToanVaHienThiHoanTien()
        {
            try
            {
                DateTime ngayHienTai = DateTime.Now;

                // Kiểm tra thời gian cho phép hủy
                bool coTheHuy = busThanhToan.KiemTraThoiGianChoPhep(dtoVe.NgayKhoiHanh, ngayHienTai);

                if (!coTheHuy)
                {
                    lblChinhSach.Text = "Không thể hủy vé trong vòng 24h trước khởi hành";
                    lblChinhSach.ForeColor = Color.Red;
                    lblTienHoan.Text = "Số tiền hoàn: 0 VND";
                    lblTienHoan.ForeColor = Color.Red;
                    btnXacNhanHuy.Enabled = false;
                    btnXacNhanHuy.Text = "Không thể hủy";
                    return;
                }

                // Tính tiền hoàn
                decimal tienHoan = busThanhToan.TinhTienHoanKhiHuyVe(dtoVe.GiaVe, dtoVe.NgayKhoiHanh, ngayHienTai);

                // Hiển thị chính sách
                string chinhSach = busThanhToan.LayThongBaoChinhSachHoanTien(dtoVe.NgayKhoiHanh, ngayHienTai);
                lblChinhSach.Text = chinhSach;
                lblChinhSach.ForeColor = Color.Blue;

                // Hiển thị số tiền hoàn
                lblTienHoan.Text = $"Số tiền hoàn: {tienHoan:N0} VND";
                lblTienHoan.ForeColor = tienHoan > 0 ? Color.Green : Color.Red;

                // Tính số giờ còn lại
                var soGioConLai = (dtoVe.NgayKhoiHanh - ngayHienTai).TotalHours;
                lblThoiGianConLai.Text = $"Thời gian còn lại: {Math.Floor(soGioConLai)}h {Math.Floor((soGioConLai % 1) * 60)}p";

                btnXacNhanHuy.Enabled = true;
                btnXacNhanHuy.Text = "Xác nhận hủy vé";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tính toán hoàn tiền: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXacNhanHuy_Click(object sender, EventArgs e)
        {
            try
            {
                // Xác nhận lần cuối
                var confirmResult = MessageBox.Show(
                    "Bạn có chắc chắn muốn hủy vé này?\n\nHành động này không thể hoàn tác!", "Xác nhận hủy vé", MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                );

                if (confirmResult != DialogResult.Yes)
                    return;

                // Thực hiện hủy vé
                bool ketQua = busVe.HuyVe(_maVe, UserSession.UserId);

                if (ketQua)
                {
                    // Tính tiền hoàn để tạo giao dịch hoàn tiền (nếu có)
                    DateTime ngayHienTai = DateTime.Now;
                    decimal tienHoan = busThanhToan.TinhTienHoanKhiHuyVe(dtoVe.GiaVe, dtoVe.NgayKhoiHanh, ngayHienTai);

                    if (tienHoan > 0)
                    {
                        // Tạo giao dịch hoàn tiền
                        try
                        {
                            int maGiaoDichHoan = busThanhToan.TaoThanhToanHoanTien(UserSession.UserId, tienHoan);
                            MessageBox.Show(
                                $"Hủy vé thành công!\n\nSố tiền hoàn: {tienHoan:N0} VND\nMã giao dịch: {maGiaoDichHoan}\n\nTiền sẽ được hoàn về tài khoản trong 3-5 ngày làm việc.", "Hủy vé thành công", MessageBoxButtons.OK, MessageBoxIcon.Information
                            );
                        }
                        catch
                        {
                            MessageBox.Show(
                                $"Hủy vé thành công!\n\nSố tiền hoàn: {tienHoan:N0} VND\n\nTiền sẽ được hoàn về tài khoản trong 3-5 ngày làm việc.", "Hủy vé thành công", MessageBoxButtons.OK, MessageBoxIcon.Information
                            );
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "Hủy vé thành công!\n\nKhông có tiền hoàn lại do hủy trong thời gian quy định.", "Hủy vé thành công", MessageBoxButtons.OK, MessageBoxIcon.Information
                        );
                    }

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Không thể hủy vé. Vui lòng thử lại sau.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi hủy vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
