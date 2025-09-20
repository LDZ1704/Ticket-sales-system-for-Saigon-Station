using BUS_TicketSalesSystem;
using DTO_TicketSalesSystem;
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
    public partial class FormThanhToanVNPay : Form
    {
        private DTO_GioHang gioHang;
        private BUS_DatVe busDatVe;
        private int maNguoiDung;

        public FormThanhToanVNPay(DTO_GioHang gioHang, int maNguoiDung)
        {
            InitializeComponent();
            this.gioHang = gioHang;
            this.maNguoiDung = maNguoiDung;
            this.busDatVe = new BUS_DatVe();
            LoadGioHang();
        }

        private void LoadGioHang()
        {
            // Hiển thị thông tin giỏ hàng
            lblTongTien.Text = $"Tổng tiền: {gioHang.TongTien:N0} VNĐ";
            lblSoVe.Text = $"Số vé: {gioHang.DanhSachVe.Count}";

            // Load danh sách vé vào DataGridView
            dgvGioHang.DataSource = gioHang.DanhSachVe.Select(v => new
            {
                v.HoTen,
                v.SoGiayTo,
                v.GioiTinh,
                NgaySinh = v.NgaySinh.ToString("dd/MM/yyyy"),
                v.TenGaDi,
                v.TenGaDen,
                v.TenTau,
                v.SoHieuGhe,
                v.TenToa,
                GioKhoiHanh = v.GioKhoiHanh.ToString("dd/MM/yyyy HH:mm"),
                GiaVe = v.GiaVe.ToString("N0") + " VNĐ"
            }).ToList();

            // Điều chỉnh cột
            dgvGioHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnThanhToanVNPay_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra giỏ hàng
                if (gioHang == null || !gioHang.DanhSachVe.Any())
                {
                    MessageBox.Show("Giỏ hàng trống! Vui lòng thêm vé vào giỏ hàng trước khi thanh toán.", 
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Xác nhận thanh toán
                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn thanh toán {gioHang.DanhSachVe.Count} vé với tổng tiền {gioHang.TongTien:N0} VNĐ?\n\n" +
                    "Sau khi xác nhận, hệ thống sẽ mở trang thanh toán VNPay.",
                    "Xác nhận thanh toán", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                    return;

                // Tạo URL thanh toán VNPay
                string paymentUrl = busDatVe.TaoUrlThanhToanVNPay(gioHang);

                // Mở trình duyệt để thanh toán
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = paymentUrl,
                    UseShellExecute = true
                });

                MessageBox.Show(
                    "Đã mở trang thanh toán VNPay.\n\n" +
                    "Vui lòng hoàn tất thanh toán trong trình duyệt.\n" +
                    "Sau khi thanh toán thành công, vé sẽ được gửi qua email của bạn.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Đóng form
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tạo thanh toán: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
