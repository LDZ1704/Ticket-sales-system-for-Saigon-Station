using BUS_TicketSalesSystem;
using DTO_TicketSalesSystem;
using GUI_TicketSalesSystem.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI_TicketSalesSystem
{
    public partial class FormRegister : Form
    {
        private readonly BUS_DangKy bus_DangKy = new BUS_DangKy();
        private readonly BUS_TaiKhoan bus_TaiKhoan = new BUS_TaiKhoan();
        private readonly BUS_NguoiDung bus_NguoiDung = new BUS_NguoiDung();

        // Debounce manager cho mọi input
        private readonly Dictionary<Control, Debounce> _debouncers = new Dictionary<Control, Debounce>();

        // Trạng thái hợp lệ của từng field
        private bool _okUsername, _okPassword, _okConfirmPassword, _okLastName, _okFirstName, _okDob, _okEmail, _okPhone;

        public FormRegister()
        {
            InitializeComponent();
        }

        #region ====== Helpers ======

        private static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            // Regex email đơn giản, đủ dùng WinForms
            var rx = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return rx.IsMatch(email);
        }

        private static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            // Cho phép 9-11 chữ số (phổ biến VN)
            var rx = new Regex(@"^\d{9,11}$");
            return rx.IsMatch(phone);
        }

        private void SetError(Label lbl, string message)
        {
            lbl.Text = message;
            lbl.Visible = !string.IsNullOrEmpty(message);
        }

        private void UpdateRegisterButton()
        {
            bool allOk = _okUsername && _okPassword && _okConfirmPassword &&
                         _okLastName && _okFirstName && _okDob && _okEmail && _okPhone;

            btnRegister.Enabled = allOk;
        }

        private void DebounceFor(Control control, Action action, int delayMs = 500)
        {
            if (!_debouncers.TryGetValue(control, out var debounce))
            {
                debounce = new Debounce(delayMs);
                _debouncers[control] = debounce;
            }
            debounce.Execute(action);
        }

        #endregion

        #region ====== Validation Rules (debounced) ======

        private void ValidateUsername()
        {
            DebounceFor(txtUsername, () =>
            {
                string value = txtUsername.Text?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(value))
                {
                    SetError(lblUsernameError, "Không được bỏ trống tên đăng nhập");
                    _okUsername = false;
                }
                else if (value.Length < 6)
                {
                    SetError(lblUsernameError, "Tên đăng nhập phải dài hơn 6 ký tự");
                    _okUsername = false;
                }
                else if (bus_TaiKhoan.KiemTraTenDangNhapTrung(value))
                {
                    SetError(lblUsernameError, "Tên đăng nhập bị trùng");
                    _okUsername = false;
                }
                else
                {
                    SetError(lblUsernameError, "");
                    _okUsername = true;
                }
                UpdateRegisterButton();
            });
        }

        private void ValidatePassword()
        {
            DebounceFor(txtPassword, () =>
            {
                string value = txtPassword.Text ?? "";
                if (string.IsNullOrWhiteSpace(value))
                {
                    SetError(lblPasswordError, "Không được bỏ trống mật khẩu");
                    _okPassword = false;
                }
                else if (value.Length < 6)
                {
                    SetError(lblPasswordError, "Mật khẩu phải từ 6 ký tự trở lên");
                    _okPassword = false;
                }
                else
                {
                    SetError(lblPasswordError, "");
                    _okPassword = true;
                }

                // Khi password đổi, cần re-check confirm
                ValidateConfirmPassword();
                UpdateRegisterButton();
            });
        }

        private void ValidateConfirmPassword()
        {
            DebounceFor(txtConfirmPassword, () =>
            {
                string pw = txtPassword.Text ?? "";
                string cf = txtConfirmPassword.Text ?? "";
                if (string.IsNullOrWhiteSpace(cf))
                {
                    SetError(lblConfirmPasswordError, "Hãy xác nhận mật khẩu");
                    _okConfirmPassword = false;
                }
                else if (!string.Equals(pw, cf))
                {
                    SetError(lblConfirmPasswordError, "Mật khẩu xác nhận không khớp");
                    _okConfirmPassword = false;
                }
                else
                {
                    SetError(lblConfirmPasswordError, "");
                    _okConfirmPassword = true;
                }
                UpdateRegisterButton();
            });
        }

        private void ValidateLastName()
        {
            DebounceFor(txtLastName, () =>
            {
                string value = txtLastName.Text?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(value))
                {
                    SetError(lblLastNameError, "Không được bỏ trống Họ");
                    _okLastName = false;
                }
                else
                {
                    SetError(lblLastNameError, "");
                    _okLastName = true;
                }
                UpdateRegisterButton();
            });
        }

        private void btnBackLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormLogin loginForm = new FormLogin();
            loginForm.ShowDialog(); 
            this.Close();
        }

        private void ValidateFirstName()
        {
            DebounceFor(txtFirstName, () =>
            {
                string value = txtFirstName.Text?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(value))
                {
                    SetError(lblFirstNameError, "Không được bỏ trống Tên");
                    _okFirstName = false;
                }
                else
                {
                    SetError(lblFirstNameError, "");
                    _okFirstName = true;
                }
                UpdateRegisterButton();
            });
        }

        private void ValidateDob()
        {
            // DateTimePicker không có TextChanged, dùng ValueChanged và vẫn debounce
            DebounceFor(dateNgaySinh, () =>
            {
                var dob = dateNgaySinh.Value.Date;
                if (dob > DateTime.Today)
                {
                    SetError(lblNgaySinhError, "Ngày sinh không hợp lệ");
                    _okDob = false;
                }
                else
                {
                    // Optional: kiểm tra >= 13 tuổi
                    var age = DateTime.Today.Year - dob.Year;
                    if (dob > DateTime.Today.AddYears(-age)) age--;
                    if (age < 13)
                    {
                        SetError(lblNgaySinhError, "Bạn phải từ 13 tuổi trở lên");
                        _okDob = false;
                    }
                    else
                    {
                        SetError(lblNgaySinhError, "");
                        _okDob = true;
                    }
                }
                UpdateRegisterButton();
            });
        }

        private void ValidateEmail()
        {
            DebounceFor(txtEmail, () =>
            {
                string value = txtEmail.Text?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(value))
                {
                    SetError(lblEmailError, "Không được bỏ trống email");
                    _okEmail = false;
                }
                else if (!IsValidEmail(value))
                {
                    SetError(lblEmailError, "Email không hợp lệ");
                    _okEmail = false;
                }
                else if (bus_NguoiDung.KiemTraEmailTrung(value))
                {
                    SetError(lblEmailError, "Email đã tồn tại");
                    _okEmail = false;
                }
                else
                {
                    SetError(lblEmailError, "");
                    _okEmail = true;
                }
                UpdateRegisterButton();
            });
        }


        private void ValidatePhone()
        {
            DebounceFor(txtPhone, () =>
            {
                string value = txtPhone.Text?.Trim() ?? "";
                if (string.IsNullOrWhiteSpace(value))
                {
                    SetError(lblPhoneError, "Không được bỏ trống số điện thoại");
                    _okPhone = false;
                }
                else if (!IsValidPhone(value))
                {
                    SetError(lblPhoneError, "Số điện thoại không hợp lệ (9-11 số)");
                    _okPhone = false;
                }
                else if (bus_NguoiDung.KiemTraSoDienThoaiTrung(value))
                {
                    SetError(lblPhoneError, "Số điện thoại đã tồn tại");
                    _okPhone = false;
                }
                else
                {
                    SetError(lblPhoneError, "");
                    _okPhone = true;
                }
                UpdateRegisterButton();
            });
        }


        #endregion

        #region ====== Form lifecycle & events ======

        private void FormRegister_Load(object sender, EventArgs e)
        {
            // Đặt text rỗng & hiển thị/ẩn
            foreach (var lbl in new[] { lblUsernameError, lblPasswordError, lblConfirmPasswordError, lblLastNameError, lblFirstNameError, lblNgaySinhError, lblEmailError, lblPhoneError })
            {
                lbl.Text = "";
                lbl.Visible = false;
            }

            // Gắn events một lần
            txtUsername.TextChanged += (s, ev) => ValidateUsername();
            txtPassword.TextChanged += (s, ev) => ValidatePassword();
            txtConfirmPassword.TextChanged += (s, ev) => ValidateConfirmPassword();
            txtLastName.TextChanged += (s, ev) => ValidateLastName();
            txtFirstName.TextChanged += (s, ev) => ValidateFirstName();
            dateNgaySinh.ValueChanged += (s, ev) => ValidateDob();
            txtEmail.TextChanged += (s, ev) => ValidateEmail();
            txtPhone.TextChanged += (s, ev) => ValidatePhone();

            // Trigger validate ban đầu (nếu cần)
            ValidateUsername();
            ValidatePassword();
            ValidateConfirmPassword();
            ValidateLastName();
            ValidateFirstName();
            ValidateDob();
            ValidateEmail();
            ValidatePhone();

            UpdateRegisterButton();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            // Dọn debouncer
            foreach (var d in _debouncers.Values) d.Dispose();
            _debouncers.Clear();
        }

        #endregion

        #region ====== Đăng ký (ví dụ) ======
        private void btnRegister_Click(object sender, EventArgs e)
        {
            // 1. Thu thập dữ liệu từ form
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;
            string lastName = txtLastName.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            DateTime dob = dateNgaySinh.Value.Date;
            string email = txtEmail.Text.Trim();
            string phone = txtPhone.Text.Trim();

            // 2. Tạo DTO cho người dùng
            var dtoNguoiDung = new DTO_NguoiDung
            {
                Ho = lastName,
                Ten = firstName,
                NgaySinh = dob,
                Email = email,
                SoDienThoai = phone,
                LoaiNguoiDung = LoaiNguoiDung.KHACH
            };

            // 3. Tạo DTO cho tài khoản
            var dtoTaiKhoan = new DTO_TaiKhoan
            {
                TenDangNhap = username,
                MatKhau = password,
                TrangThai = DTO_TicketSalesSystem.enums.TrangThai.HOATDONG
            };

            // 4. Gọi BUS đăng ký
            string result = bus_DangKy.DangKyNguoiDungVaTaiKhoan(dtoNguoiDung, dtoTaiKhoan);

            // 5. Thông báo
            if (result.Contains("Lỗi"))
            {
                MessageBox.Show(result, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(result, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide(); // Ẩn Form đăng ký
                FormLogin loginForm = new FormLogin();
                loginForm.ShowDialog(); // Show login (blocking)
                this.Close(); // Đóng form đăng ký sau khi login form được đóng
            }

        }
        #endregion
    }
}
