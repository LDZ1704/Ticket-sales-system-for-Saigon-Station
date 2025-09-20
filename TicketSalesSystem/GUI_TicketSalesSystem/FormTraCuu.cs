using BUS_TicketSalesSystem;
using DTO_TicketSalesSystem;
using DTO_TicketSalesSystem.utils;
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
        //private BUS_TraCuu busTraCuu = new BUS_TraCuu();
        private List<DTO_GaTau> danhSachGa;
        private BUS_GaTau busGaTau = new BUS_GaTau();
        private BUS_ChuyenTau busChuyenTau = new BUS_ChuyenTau();
        public FormTraCuu(string username = "")
        {
            InitializeComponent();
            this.Load += FormTraCuu_Load;
            this.btnTraCuu.Click += btnTraCuu_Click;
            this.btnDatVe.Click += btnDatVe_Click;
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

                // Mở form đặt vé mới với giỏ hàng và thanh toán VNPay
                var formDatVeGioHang = new FormDatVeGioHang(UserSession.UserId);
                formDatVeGioHang.ShowDialog();

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
    }
}
