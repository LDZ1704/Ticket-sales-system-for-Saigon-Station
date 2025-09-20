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
    public partial class FormLichSuHoatDong : Form
    {
        private readonly string hoTen;
        private readonly List<DTO_QuanLy.DTO_LichSuHoatDong> lichSu;

        public FormLichSuHoatDong(string hoTen, List<DTO_QuanLy.DTO_LichSuHoatDong> lichSu)
        {
            InitializeComponent();
            this.hoTen = hoTen;
            this.lichSu = lichSu;
        }

        private void FormLichSuHoatDong_Load(object sender, EventArgs e)
        {
            lblNguoiDung.Text = $"Lịch sử hoạt động của: {hoTen}";
            LoadLichSu();
        }

        private void LoadLichSu()
        {
            try
            {
                dgvLichSu.Rows.Clear();

                if (lichSu == null || lichSu.Count == 0)
                {
                    var row = dgvLichSu.Rows.Add("N/A", "N/A", "N/A", "N/A", "N/A", "N/A");
                    dgvLichSu.Rows[row].Cells[1].Value = "Chưa có hoạt động nào";
                    dgvLichSu.Rows[row].DefaultCellStyle.ForeColor = Color.Gray;
                    return;
                }

                foreach (var item in lichSu)
                {
                    string ngayGiaoDich = ((DateTime)item.NgayGiaoDich).ToString("dd/MM/yyyy HH:mm");
                    string loaiGiaoDich = item.LoaiGiaoDich.ToString();
                    string tuyen = item.Tuyen.ToString();
                    string soTien = ((decimal)item.SoTien).ToString("N0") + " VND";
                    string trangThai = ChuyenDoiTrangThai(item.TrangThai.ToString());
                    string maVe = item.MaVe.ToString();

                    int rowIndex = dgvLichSu.Rows.Add(
                        ngayGiaoDich,
                        loaiGiaoDich,
                        tuyen,
                        soTien,
                        trangThai,
                        maVe
                    );

                    // Đổi màu theo loại giao dịch
                    var row = dgvLichSu.Rows[rowIndex];
                    switch (item.TrangThai.ToString())
                    {
                        case "DATHANHTOAN":
                            row.DefaultCellStyle.ForeColor = Color.Green;
                            break;
                        case "DAHUY":
                            row.DefaultCellStyle.ForeColor = Color.Red;
                            break;
                        case "DADOI":
                            row.DefaultCellStyle.ForeColor = Color.Orange;
                            break;
                    }
                }

                lblTongSo.Text = $"Tổng số giao dịch: {lichSu.Count}";

                // Tính tổng chi tiêu
                decimal tongChiTieu = lichSu
                    .Where(x => x.TrangThai.ToString() == "DATHANHTOAN")
                    .Sum(x => (decimal)x.SoTien);

                lblTongChiTieu.Text = $"Tổng chi tiêu: {tongChiTieu:N0} VND";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi load lịch sử: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ChuyenDoiTrangThai(string trangThai)
        {
            switch(trangThai)
            {
                case "DATHANHTOAN":
                    return "Đã thanh toán";
                case "DAHUY":
                    return "Đã hủy";
                case "DADOI":
                    return "Đã đổi";
                default:
                    return trangThai;
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (lichSu == null || lichSu.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "CSV files (*.csv)|*.csv|Text files (*.txt)|*.txt";
                    saveDialog.FileName = $"LichSu_{hoTen}_{DateTime.Now:yyyyMMdd}.csv";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        var csv = new StringBuilder();
                        csv.AppendLine($"Lịch sử hoạt động của {hoTen}");
                        csv.AppendLine($"Xuất ngày: {DateTime.Now:dd/MM/yyyy HH:mm}");
                        csv.AppendLine();
                        csv.AppendLine("Ngày giao dịch,Loại giao dịch,Tuyến,Số tiền,Trạng thái,Mã vé");

                        foreach (var item in lichSu)
                        {
                            csv.AppendLine($"{((DateTime)item.NgayGiaoDich):dd/MM/yyyy HH:mm}," +
                                         $"{item.LoaiGiaoDich}," +
                                         $"{item.Tuyen}," +
                                         $"{item.SoTien}," +
                                         $"{ChuyenDoiTrangThai(item.TrangThai.ToString())}," +
                                         $"{item.MaVe}");
                        }

                        System.IO.File.WriteAllText(saveDialog.FileName, csv.ToString(), Encoding.UTF8);
                        MessageBox.Show("Đã xuất file thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
