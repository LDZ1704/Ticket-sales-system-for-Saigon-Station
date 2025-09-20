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
    public partial class FormGioHang : Form
    {
        private DTO_GioHang gioHang;
        private BUS_DatVe busDatVe;
        private int maNguoiDung;

        public FormGioHang(int maNguoiDung)
        {
            InitializeComponent();
            this.maNguoiDung = maNguoiDung;
            this.gioHang = new DTO_GioHang { MaNguoiDung = maNguoiDung };
            this.busDatVe = new BUS_DatVe();
        }

        public void ThemVeVaoGio(DTO_VeTrongGio ve)
        {
            gioHang.DanhSachVe.Add(ve);
            LoadGioHang();
        }

        public DTO_GioHang GetGioHang()
        {
            return gioHang;
        }

        public void LoadGioHang()
        {
            // Hiển thị thông tin giỏ hàng
            lblTongTien.Text = $"Tổng tiền: {gioHang.TongTien:N0} VNĐ";
            lblSoVe.Text = $"Số vé: {gioHang.DanhSachVe.Count}";

            // Load danh sách vé vào DataGridView
            dgvGioHang.DataSource = gioHang.DanhSachVe.Select((v, index) => new
            {
                STT = index + 1,
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
            
            // Cập nhật trạng thái nút
            btnThanhToan.Enabled = gioHang.DanhSachVe.Any();
            btnXoaVe.Enabled = gioHang.DanhSachVe.Any();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (!gioHang.DanhSachVe.Any())
            {
                MessageBox.Show("Giỏ hàng trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Mở form thanh toán VNPay
                using (var formThanhToan = new FormThanhToanVNPay(gioHang, maNguoiDung))
                {
                    if (formThanhToan.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Thanh toán thành công! Vui lòng kiểm tra email để xem vé.", 
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        // Xóa giỏ hàng sau khi thanh toán thành công
                        gioHang.DanhSachVe.Clear();
                        LoadGioHang();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi thanh toán: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaVe_Click(object sender, EventArgs e)
        {
            if (dgvGioHang.SelectedRows.Count > 0)
            {
                var selectedIndex = dgvGioHang.SelectedRows[0].Index;
                if (selectedIndex >= 0 && selectedIndex < gioHang.DanhSachVe.Count)
                {
                    gioHang.DanhSachVe.RemoveAt(selectedIndex);
                    LoadGioHang();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn vé cần xóa!", "Thông báo", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvGioHang_SelectionChanged(object sender, EventArgs e)
        {
            btnXoaVe.Enabled = dgvGioHang.SelectedRows.Count > 0;
        }
    }
}
