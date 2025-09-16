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
    public partial class FormLogin : Form
    {
        private readonly BUS_TaiKhoan busTaiKhoan = new BUS_TaiKhoan();
        private readonly BUS_NguoiDung busNguoiDung = new BUS_NguoiDung();

        public FormLogin()
        {
            InitializeComponent();
            this.FormClosed += FormLogin_FormClosed;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegister formRegister  = new FormRegister();
            formRegister.ShowDialog(); 
            this.Close(); 
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           
            DTO_TaiKhoan taiKhoan = busTaiKhoan.DangNhap(username, password);

            if (taiKhoan == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (taiKhoan.TrangThai == DTO_TicketSalesSystem.enums.TrangThai.KHOA)
            {
                MessageBox.Show("Tài khoản của bạn đã bị khóa!", "Không thể đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var nguoiDung = busNguoiDung.LayNguoiDungTheoID(taiKhoan.MaNguoiDung);

            //Lưu thông tin vào session
            UserSession.Username = username;
            UserSession.UserId = taiKhoan.MaNguoiDung;
            UserSession.LoaiNguoiDung = nguoiDung?.LoaiNguoiDung ?? LoaiNguoiDung.KHACH;

            // Đăng nhập thành công
            string roleText = UserSession.IsAdmin ? "Quản trị viên" : "Người dùng";
            MessageBox.Show($"Đăng nhập thành công! Vai trò: {roleText}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Hide();
            FormMain formMain = new FormMain(username);
            formMain.ShowDialog();
            this.Close();
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
