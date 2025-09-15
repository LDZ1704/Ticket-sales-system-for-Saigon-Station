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
    public partial class FormDoiVe : Form
    {
        private int _maVeCu;
        private readonly BUS_Ve busVe = new BUS_Ve();
        private readonly BUS_ChuyenTau busChuyenTau = new BUS_ChuyenTau();
        private readonly BUS_Toa busToa = new BUS_Toa();
        public FormDoiVe(int maVeCu)
        {
            InitializeComponent();
            _maVeCu = maVeCu;
        }

        private void cboChuyenMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChuyenMoi.SelectedItem is DTO_ChuyenTau chuyen)
            {
                txtTuyen.Text = chuyen.Tuyen;
                txtTau.Text = chuyen.TenTau;

                // Load toa theo tàu
                var dsToa = busToa.LayToaBangChuyenTau(chuyen.MaTau);
                cboToaMoi.DataSource = dsToa;
                cboToaMoi.DisplayMember = "TenToa";
                cboToaMoi.ValueMember = "MaToa";
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (cboChuyenMoi.SelectedValue == null || cboGheMoi.SelectedValue == null || cboToaMoi.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn chuyến và ghế mới!", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                return;
            }

            int maChuyenMoi = (int)cboChuyenMoi.SelectedValue;
            int maGheMoi = (int)cboGheMoi.SelectedValue;
            decimal giaVeMoi = decimal.Parse(txtGiaVeMoi.Text);

            bool result = busVe.DoiVe(_maVeCu, maChuyenMoi, maGheMoi, giaVeMoi, UserSession.UserId);
            if (result)
            {
                MessageBox.Show("Đổi vé thành công!", "Xác nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Không thể đổi vé!", "Lỗi", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
        }

        private void FormDoiVe_Load(object sender, EventArgs e)
        {
            var dsChuyen = busChuyenTau.LayTatCaChuyenTau();
            cboChuyenMoi.DataSource = dsChuyen;
            cboChuyenMoi.DisplayMember = "TenChuyen";
            cboChuyenMoi.ValueMember = "MaChuyen";

            txtGiaVeMoi.Text = "350,000 VND";
            txtGiaVeMoi.ReadOnly = true;
            txtTuyen.ReadOnly = true;
            txtTau.ReadOnly = true;
        }

        private void cboToaMoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboToaMoi.SelectedValue == null) return;

            int maToa;
            if (!int.TryParse(cboToaMoi.SelectedValue.ToString(), out maToa))
                return;
            var dsGhe = busChuyenTau.LayDanhSachGheTrongBangMaToa(maToa);

            cboGheMoi.DataSource = dsGhe;
            cboGheMoi.DisplayMember = "SoHieu";
            cboGheMoi.ValueMember = "MaGhe";
        }
    }
}
