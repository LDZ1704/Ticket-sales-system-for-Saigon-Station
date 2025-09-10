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
    public partial class FormTraCuu : Form
    {
        private BUS_TraCuu busTraCuu = new BUS_TraCuu();
        private List<DTO_GaTau> danhSachGa;
        public FormTraCuu()
        {
            InitializeComponent();
            this.Load += FormTraCuu_Load;
            this.btnTraCuu.Click += btnTraCuu_Click;
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
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadDanhSachGa()
        {
            danhSachGa = busTraCuu.LayDanhSachGaTau();

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
            var danhSach = busTraCuu.LayTatCaChuyenTau();
            HienThiKetQua(danhSach);
        }
        private void HienThiKetQua(List<DTO_ChuyenTau> ketQua)
        {
            dgvKetQua.Rows.Clear();

            foreach (var item in ketQua)
            {
                string tenTau = busTraCuu.LayTenTauTheoMa(item.MaTau);
                string tenTuyen = busTraCuu.LayTenTuyenTheoMa(item.MaTuyen);

                dgvKetQua.Rows.Add(
                    item.MaChuyen,
                    tenTau,
                    tenTuyen,
                    item.TrangThai,
                    item.GioKhoiHanh.ToString("dd/MM/yyyy HH:mm"),
                    item.GioDen.ToString("dd/MM/yyyy HH:mm"),
                    item.GhiChu
                );
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

                int maGaDi = (int)cboGaDi.SelectedValue;
                int maGaDen = (int)cboGaDen.SelectedValue;
                DateTime ngayDi = dtpNgayDi.Value;

                var ketQua = busTraCuu.TraCuuLichChayTau(maGaDi, maGaDen, ngayDi);

                if (ketQua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy chuyến tàu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                HienThiKetQua(ketQua);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
