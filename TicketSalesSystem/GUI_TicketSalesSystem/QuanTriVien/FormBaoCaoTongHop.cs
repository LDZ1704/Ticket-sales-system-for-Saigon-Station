using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DTO_TicketSalesSystem.DTO_QuanLy;

namespace GUI_TicketSalesSystem
{
    public partial class FormBaoCaoTongHop : Form
    {
        private readonly DTO_BaoCaoTongHop baoCao;

        public FormBaoCaoTongHop(DTO_BaoCaoTongHop baoCao)
        {
            InitializeComponent();
            this.baoCao = baoCao;
        }

        private void FormBaoCaoTongHop_Load(object sender, EventArgs e)
        {
            HienThiBaoCao();
        }

        private void HienThiBaoCao()
        {
            var content = new StringBuilder();
            content.AppendLine("BÁO CÁO TỔNG HỢP HỆ THỐNG BÁN VÉ GA SÀI GÒN");
            content.AppendLine(new string('=', 60));
            content.AppendLine($"Thời gian: {baoCao.TuNgay:dd/MM/yyyy} - {baoCao.DenNgay:dd/MM/yyyy}");
            content.AppendLine($"Ngày xuất báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm}");
            content.AppendLine();

            // Thống kê tổng quan
            content.AppendLine("THỐNG KÊ TỔNG QUAN:");
            content.AppendLine(new string('-', 30));
            content.AppendLine($"• Tổng doanh thu: {baoCao.TongDoanhThu:N0} VND");
            content.AppendLine($"• Tổng số vé bán: {baoCao.TongSoVe:N0} vé");
            content.AppendLine($"• Số vé hủy: {baoCao.SoVeHuy:N0} vé ({baoCao.TiLeHuyVe:N1}%)");
            content.AppendLine($"• Số vé đổi: {baoCao.SoVeDoi:N0} vé ({baoCao.TiLeDoiVe:N1}%)");
            content.AppendLine($"• Doanh thu TB/ngày: {baoCao.DoanhThuTrungBinhTheoNgay:N0} VND");
            content.AppendLine($"• Người dùng mới: {baoCao.SoNguoiDungMoi:N0} người");
            content.AppendLine($"• Tuyến bán chạy nhất: {baoCao.TuyenBanChayNhat}");
            content.AppendLine();

            // Top 5 tuyến bán chạy
            if (baoCao.ChiTietTuyen?.Count > 0)
            {
                content.AppendLine("TOP 5 TUYẾN BÁN CHẠY:");
                content.AppendLine(new string('-', 30));
                var top5 = baoCao.ChiTietTuyen.Take(5);
                foreach (var tuyen in top5)
                {
                    content.AppendLine($"{tuyen.XepHang}. {tuyen.TenTuyen}");
                    content.AppendLine($"   Số vé: {tuyen.SoVeBan:N0} | Doanh thu: {tuyen.DoanhThu:N0} VND");
                }
                content.AppendLine();
            }

            // Chi tiết doanh thu theo ngày (5 ngày gần nhất)
            if (baoCao.ChiTietDoanhThu?.Count > 0)
            {
                content.AppendLine("CHI TIẾT DOANH THU (5 NGÀY GẦN NHẤT):");
                content.AppendLine(new string('-', 30));
                var recent5 = baoCao.ChiTietDoanhThu.Take(5);
                foreach (var ngay in recent5)
                {
                    content.AppendLine($"{ngay.NgayBaoCao:dd/MM/yyyy}: {ngay.SoVeBan:N0} vé - {ngay.DoanhThuTheoNgay:N0} VND");
                }
                content.AppendLine();
            }

            // Footer
            content.AppendLine(new string('=', 60));
            content.AppendLine("Báo cáo được tạo tự động bởi Hệ thống bán vé ga Sài Gòn");

            rtbBaoCao.Text = content.ToString();
        }

        private void btnLuuFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                    saveDialog.FileName = $"BaoCao_{baoCao.TuNgay:yyyyMMdd}_{baoCao.DenNgay:yyyyMMdd}.txt";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        File.WriteAllText(saveDialog.FileName, rtbBaoCao.Text, Encoding.UTF8);
                        MessageBox.Show("Đã lưu báo cáo thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lưu file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            try
            {
                // Simplified print functionality
                MessageBox.Show("Chức năng in sẽ được cập nhật trong phiên bản tiếp theo!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi in: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
