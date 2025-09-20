using BUS_TicketSalesSystem;
using DTO_TicketSalesSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem
{
    public partial class FormTraCuu : Form
    {
        private List<DTO_GaTau> danhSachGa;
        private BUS_GaTau busGaTau = new BUS_GaTau();
        private BUS_ChuyenTau busChuyenTau = new BUS_ChuyenTau();
        private BUS_Toa busToa = new BUS_Toa();
        public FormTraCuu()
        {
            InitializeComponent();
        }

        private void FormTraCuu_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDanhSachGa();
                LoadTatCaChuyenTau();
                dtpNgayDi.Value = DateTime.Today;
                dtpNgayDi.MinDate = DateTime.Today;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDanhSachGa()
        {
            danhSachGa = busGaTau.LayDanhSachGaTau();

            cboGaDi.DisplayMember = "TenGa";
            cboGaDi.ValueMember = "MaGaTau";
            cboGaDi.DataSource = danhSachGa.ToList();
            cboGaDi.SelectedIndex = -1;

            cboGaDen.DisplayMember = "TenGa";
            cboGaDen.ValueMember = "MaGaTau";
            cboGaDen.DataSource = danhSachGa.ToList();
            cboGaDen.SelectedIndex = -1;
        }
        private void LoadTatCaChuyenTau()
        {
            var danhSach = busChuyenTau.LayTatCaChuyenTau();
            HienThiKetQua(danhSach);
        }
        private void HienThiKetQua(List<DTO_ChuyenTau> ketQua)
        {
            dgvKetQua.Rows.Clear();

            foreach (var item in ketQua)
            {
                string tenTau = "";
                string tenTuyen = "";

                if (!string.IsNullOrEmpty(item.GhiChu))
                {
                    var parts = item.GhiChu.Split('|');
                    tenTau = parts.Length > 0 ? parts[0] : "N/A";
                    tenTuyen = parts.Length > 1 ? parts[1] : "N/A";
                }

                // Lấy giá vé cơ bản của chuyến tàu
                string giaVeHienThi = LayGiaVeHienThiChoChuyenTau(item.MaChuyen ?? 0);

                dgvKetQua.Rows.Add(
                    item.MaChuyen,
                    tenTau,
                    tenTuyen,
                    item.TrangThai,
                    giaVeHienThi,
                    item.GioKhoiHanh.ToString("dd/MM/yyyy HH:mm"),
                    item.GioDen.ToString("dd/MM/yyyy HH:mm"),
                    item.GhiChu
                );
            }
        }
        private string LayGiaVeHienThiChoChuyenTau(int maChuyen)
        {
            try
            {
                var dsToa = busToa.LayToaBangChuyenTau(maChuyen);
                if (dsToa.Count == 0)
                    return "N/A";

                var giaMin = dsToa.Min(t => t.GiaVe);
                var giaMax = dsToa.Max(t => t.GiaVe);

                if (giaMin == giaMax)
                {
                    return $"{giaMin:N0} VND";
                }
                else
                {
                    return $"{giaMin:N0} - {giaMax:N0} VND";
                }
            }
            catch
            {
                return "N/A";
            }
        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboGaDi.SelectedIndex == -1 || cboGaDen.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn ga đi và ga đến!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cboGaDi.SelectedValue.Equals(cboGaDen.SelectedValue))
                {
                    MessageBox.Show("Ga đi và ga đến không thể giống nhau!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int maGaDi = (int)cboGaDi.SelectedValue;
                int maGaDen = (int)cboGaDen.SelectedValue;
                DateTime ngayDi = dtpNgayDi.Value;

                var ketQua = busChuyenTau.TraCuuChuyenTau(maGaDi, maGaDen, ngayDi);

                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy chuyến tàu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTatCaChuyenTau();
                }
                else
                {
                    HienThiKetQua(ketQua);
                    MessageBox.Show($"Tìm thấy {ketQua.Count} chuyến tàu!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDatVe_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvKetQua.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn chuyến tàu để đặt vé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dgvKetQua.SelectedRows[0];
                int maChuyen = (int)selectedRow.Cells["dgvMaChuyen"].Value;
                string trangThai = selectedRow.Cells["dgvTrangThai"].Value.ToString();

                if (trangThai != "MOBAN")
                {
                    MessageBox.Show("Chuyến tàu này hiện không mở bán vé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var formDatVe = new FormDatVe(maChuyen);
                formDatVe.ShowDialog();

                // Refresh lại danh sách sau khi đặt vé
                if (cboGaDi.SelectedIndex != -1 && cboGaDen.SelectedIndex != -1)
                {
                    btnTraCuu_Click(sender, e);
                }
                else
                {
                    LoadTatCaChuyenTau();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChiTietGiaVe_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvKetQua.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn chuyến tàu để xem chi tiết giá vé!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedRow = dgvKetQua.SelectedRows[0];
                int maChuyen = (int)selectedRow.Cells["dgvMaChuyen"].Value;
                string tenTau = selectedRow.Cells["dgvTenTau"].Value.ToString();

                HienThiChiTietGiaVe(maChuyen, tenTau);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi xem chi tiết giá vé: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void HienThiChiTietGiaVe(int maChuyen, string tenTau)
        {
            try
            {
                var dsToa = busToa.LayToaBangChuyenTau(maChuyen);
                if (dsToa.Count == 0)
                {
                    MessageBox.Show("Không có thông tin toa cho chuyến tàu này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var chiTiet = new StringBuilder();
                chiTiet.AppendLine($"CHI TIẾT GIÁ VÉ - {tenTau}");
                chiTiet.AppendLine(new string('=', 30));

                foreach (var toa in dsToa.OrderBy(t => t.ViTri))
                {
                    chiTiet.AppendLine($"{toa.TenToa} - {toa.LoaiGhe}: {toa.GiaVe:N0} VND");
                }

                chiTiet.AppendLine();
                chiTiet.AppendLine($"Giá từ: {dsToa.Min(t => t.GiaVe):N0} VND");
                chiTiet.AppendLine($"Giá đến: {dsToa.Max(t => t.GiaVe):N0} VND");

                MessageBox.Show(chiTiet.ToString(), "Chi tiết giá vé", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi hiển thị chi tiết: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            try
            {
                cboGaDi.SelectedIndex = -1;
                cboGaDen.SelectedIndex = -1;
                dtpNgayDi.Value = DateTime.Today;
                LoadTatCaChuyenTau();
                MessageBox.Show("Đã làm mới dữ liệu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi làm mới: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLocTheoGia_Click(object sender, EventArgs e)
        {
            try
            {
                using (var filterForm = new FormLocGiaVe())
                {
                    if (filterForm.ShowDialog() == DialogResult.OK)
                    {
                        decimal giaMin = filterForm.GiaMin;
                        decimal giaMax = filterForm.GiaMax;

                        var tatCaChuyen = busChuyenTau.LayTatCaChuyenTau();
                        var chuyenLoc = new List<DTO_ChuyenTau>();

                        foreach (var chuyen in tatCaChuyen)
                        {
                            var dsToa = busToa.LayToaBangChuyenTau(chuyen.MaChuyen ?? 0);
                            if (dsToa.Any(t => t.GiaVe >= giaMin && t.GiaVe <= giaMax))
                            {
                                chuyenLoc.Add(chuyen);
                            }
                        }

                        HienThiKetQua(chuyenLoc);
                        MessageBox.Show($"Tìm thấy {chuyenLoc.Count} chuyến tàu trong khoảng giá {giaMin:N0} - {giaMax:N0} VND",
                            "Kết quả lọc", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi lọc theo giá: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// Form nhỏ để nhập khoảng giá lọc
    /// </summary>
    public partial class FormLocGiaVe : Form
    {
        public decimal GiaMin { get; private set; }
        public decimal GiaMax { get; private set; }

        public FormLocGiaVe()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.txtGiaMin = new TextBox();
            this.txtGiaMax = new TextBox();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.lblGiaMin = new Label();
            this.lblGiaMax = new Label();
            this.lblTitle = new Label();

            // Font chung
            var font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular);

            // Form
            this.Text = "Lọc theo giá vé";
            this.Size = new Size(400, 250);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Font = font;

            // Title
            this.lblTitle.Text = "NHẬP KHOẢNG GIÁ VÉ";
            this.lblTitle.Location = new Point(80, 20);
            this.lblTitle.Size = new Size(240, 30);
            this.lblTitle.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Blue;

            // Labels
            this.lblGiaMin.Text = "Giá từ (VND):";
            this.lblGiaMin.Location = new Point(30, 70);
            this.lblGiaMin.Size = new Size(120, 25);
            this.lblGiaMin.Font = font;

            this.lblGiaMax.Text = "Giá đến (VND):";
            this.lblGiaMax.Location = new Point(30, 110);
            this.lblGiaMax.Size = new Size(120, 25);
            this.lblGiaMax.Font = font;

            // TextBoxes
            this.txtGiaMin.Location = new Point(160, 70);
            this.txtGiaMin.Size = new Size(180, 30);
            this.txtGiaMin.Text = "0";
            this.txtGiaMin.Font = font;

            this.txtGiaMax.Location = new Point(160, 110);
            this.txtGiaMax.Size = new Size(180, 30);
            this.txtGiaMax.Text = "2,000,000";
            this.txtGiaMax.Font = font;

            // Buttons
            this.btnOK.Text = "Lọc";
            this.btnOK.Location = new Point(160, 150);
            this.btnOK.Size = new Size(80, 35);
            this.btnOK.Font = font;
            this.btnOK.BackColor = Color.Green;
            this.btnOK.ForeColor = Color.White;
            this.btnOK.DialogResult = DialogResult.OK;
            this.btnOK.Click += BtnOK_Click;

            this.btnCancel.Text = "Hủy";
            this.btnCancel.Location = new Point(260, 150);
            this.btnCancel.Size = new Size(80, 35);
            this.btnCancel.Font = font;
            this.btnCancel.DialogResult = DialogResult.Cancel;

            // Add controls
            this.Controls.AddRange(new Control[] {
                this.lblTitle,
                this.lblGiaMin, this.txtGiaMin,
                this.lblGiaMax, this.txtGiaMax,
                this.btnOK, this.btnCancel
            });

            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                GiaMin = decimal.Parse(txtGiaMin.Text.Replace(",", "").Replace(".", ""));
                GiaMax = decimal.Parse(txtGiaMax.Text.Replace(",", "").Replace(".", ""));

                if (GiaMin < 0 || GiaMax < 0)
                {
                    MessageBox.Show("Giá vé không thể âm!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (GiaMin > GiaMax)
                {
                    MessageBox.Show("Giá từ không thể lớn hơn giá đến!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Vui lòng nhập giá vé hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private TextBox txtGiaMin;
        private TextBox txtGiaMax;
        private Button btnOK;
        private Button btnCancel;
        private Label lblGiaMin;
        private Label lblGiaMax;
        private Label lblTitle;
    }
}
