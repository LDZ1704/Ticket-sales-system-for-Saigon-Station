USE master
GO

CREATE DATABASE BanVeGaSaiGon
GO

USE BanVeGaSaiGon
GO
-- Bảng người dùng
CREATE TABLE NguoiDung (
    MaNguoiDung INT IDENTITY PRIMARY KEY,
    Ho NVARCHAR(100) NOT NULL, --tach fullname
	Ten NVARCHAR(50) NOT NULL, --tach fullname
    NgaySinh DATE,
    Email NVARCHAR(100),
    SoDienThoai NVARCHAR(20),
	NgayTao DATE DEFAULT GETDATE(), --them ngay tao
    LoaiNguoiDung NVARCHAR(20) CHECK (LoaiNguoiDung IN ('KHACH','NHANVIEN','QUANTRI'))
)

-- Bảng tài khoản
CREATE TABLE TaiKhoan (
    MaTaiKhoan INT IDENTITY PRIMARY KEY,
    TenDangNhap NVARCHAR(50) UNIQUE NOT NULL,
    MatKhau NVARCHAR(255) NOT NULL,
    NgayTao DATE DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN ('HOATDONG','KHOA')),
	MaNguoiDung INT FOREIGN KEY REFERENCES NguoiDung(MaNguoiDung) --chuyển mã tài khoản của người dùng thành mã người dùng của tài khoản vì người dùng có thể đc tạo trước
)

-- Bảng hành khách
CREATE TABLE HanhKhach (
    MaHanhKhach INT IDENTITY PRIMARY KEY,
    HoTen NVARCHAR(100),
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    LoaiGiayTo NVARCHAR(20),
    SoGiayTo NVARCHAR(50),
    QuocTich NVARCHAR(50),
    Email NVARCHAR(100),
    SoDienThoai NVARCHAR(20),
    GhiChu NVARCHAR(200)
)

-- Bảng ga tàu
CREATE TABLE GaTau (
    MaGaTau INT IDENTITY PRIMARY KEY,
    TenGa NVARCHAR(100),
    DiaChi NVARCHAR(200),
    Mien NVARCHAR(20),
    GhiChu NVARCHAR(200)
)

-- Bảng tuyến đường
CREATE TABLE TuyenDuong (
    MaTuyen INT IDENTITY PRIMARY KEY,
    MaGaDi INT FOREIGN KEY REFERENCES GaTau(MaGaTau),
    MaGaDen INT FOREIGN KEY REFERENCES GaTau(MaGaTau),
    KhoangCach INT,
    ThoiGianDuKien TIME,
    MoTa NVARCHAR(200)
)

-- Bảng tàu
CREATE TABLE Tau (
    MaTau INT IDENTITY PRIMARY KEY,
    TenTau NVARCHAR(100),
    MoTa NVARCHAR(200), --bỏ tổng số toa do truy vấn đc, 
	--bỏ loại tàu do tàu này có 1 loại là chở khách thôi
)

-- Bảng toa tàu
CREATE TABLE ToaTau (
    MaToa INT IDENTITY PRIMARY KEY,
    TenToa NVARCHAR(50),
    LoaiGhe NVARCHAR(50),
	GiaVe DECIMAL(12,2),
    --bỏ sô lượng ghế do truy vấn đc
    ViTri INT, --vị trí này là thứ tự thôi, nên để int
    MaTau INT FOREIGN KEY REFERENCES Tau(MaTau)
)

-- Bảng ghế
CREATE TABLE Ghe (
    MaGhe INT IDENTITY PRIMARY KEY,
    SoHieu NVARCHAR(10),
    ViTri NVARCHAR(50),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN ('TRONG','DADAT')),
    MaToa INT FOREIGN KEY REFERENCES ToaTau(MaToa)
)

-- Bảng chuyến tàu
CREATE TABLE ChuyenTau (
    MaChuyen INT IDENTITY PRIMARY KEY,
    MaTau INT FOREIGN KEY REFERENCES Tau(MaTau),
    MaTuyen INT FOREIGN KEY REFERENCES TuyenDuong(MaTuyen),
    GioKhoiHanh DATETIME,
	-- bỏ giờ xuất phát do trong ngày khởi hành có cả giờ rồi
    GioDen DATETIME,
    TrangThai NVARCHAR(20) CHECK (TrangThai IN ('MOBAN','DACHAY','HUY')),
    GhiChu NVARCHAR(200)
)

-- Bảng thanh toán
CREATE TABLE ThanhToan (
    MaThanhToan INT IDENTITY PRIMARY KEY,
    MaNguoiDung INT FOREIGN KEY REFERENCES NguoiDung(MaNguoiDung),
    HinhThuc NVARCHAR(50) CHECK (HinhThuc IN ('VNPAY','MOMO')), --thêm enum cho cái này
    --bỏ số tiền do truy vấn đc, với lại khi đổi trả vé nó có thể bị sai
    ThoiDiem DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN ('THANHCONG','THATBAI','DANGXULY')),
	NgayThanhToan DATE DEFAULT GETDATE()
)

-- Bảng vé
CREATE TABLE Ve (
    MaVe INT IDENTITY PRIMARY KEY,
    --Bỏ mã người dùng vì nó nối với thanh toán rồi
    MaHanhKhach INT FOREIGN KEY REFERENCES HanhKhach(MaHanhKhach),
    MaChuyen INT FOREIGN KEY REFERENCES ChuyenTau(MaChuyen),
	-- bỏ mã toa vì nó có mã ghế rồi
    MaGhe INT FOREIGN KEY REFERENCES Ghe(MaGhe),
    MaThanhToan INT FOREIGN KEY REFERENCES ThanhToan(MaThanhToan),
    -- bỏ ngày đặt vì đã lưu trong thanh toán
    GiaVe DECIMAL(12,2),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN ('DATHANHTOAN','DAHUY','DADOI')),
    MaQR NVARCHAR(100)
)

-- Dữ liệu cho bảng GaTau
INSERT INTO GaTau(TenGa, DiaChi, Mien, GhiChu) VALUES
(N'Ga Sài Gòn', N'01 Nguyễn Thông, Quận 3, TP. Hồ Chí Minh', N'Nam', N'Ga trung tâm miền Nam'),
(N'Ga Hà Nội', N'120 Lê Duẩn, Hoàn Kiếm, Hà Nội', N'Bắc', N'Ga trung tâm miền Bắc'),
(N'Ga Đà Nẵng', N'791 Hải Phòng, Thanh Khê, Đà Nẵng', N'Trung', N'Ga lớn miền Trung'),
(N'Ga Nha Trang', N'17 Thái Nguyên, Phước Tân, Nha Trang', N'Nam', N'Ga du lịch nổi tiếng'),
(N'Ga Huế', N'02 Bùi Thị Xuân, TP. Huế', N'Trung', N'Ga cố đô Huế');

-- Dữ liệu cho bảng TuyenDuong
INSERT INTO TuyenDuong(MaGaDi, MaGaDen, KhoangCach, ThoiGianDuKien, MoTa) VALUES
(1, 2, 1726, '23:00:00', N'Tuyến Bắc Nam Sài Gòn - Hà Nội'),
(1, 3, 935, '17:00:00', N'Tuyến Sài Gòn - Đà Nẵng'),
(1, 4, 411, '08:00:00', N'Tuyến Sài Gòn - Nha Trang'),
(3, 2, 791, '15:00:00', N'Tuyến Đà Nẵng - Hà Nội'),
(5, 2, 688, '13:00:00', N'Tuyến Huế - Hà Nội');

-- Dữ liệu cho bảng Tau
INSERT INTO Tau(TenTau, MoTa) VALUES
(N'SE1', N'Tàu Thống Nhất SE1 chạy tuyến Bắc Nam'),
(N'SE2', N'Tàu Thống Nhất SE2 chạy tuyến Bắc Nam'),
(N'SE3', N'Tàu khách SE3 chạy tuyến Sài Gòn - Hà Nội'),
(N'SNT2', N'Tàu khách Sài Gòn - Nha Trang'),
(N'SE22', N'Tàu khách Đà Nẵng - Hà Nội');

-- Dữ liệu cho bảng ToaTau
INSERT INTO ToaTau(TenToa, GiaVe, LoaiGhe, ViTri, MaTau) VALUES
(N'A1', 400000.00, N'Ghế mềm điều hòa', 1, 1),
(N'A2', 350000.00, N'Ghế cứng', 2, 1),
(N'B1', 300000.00, N'Giường nằm 4 chỗ', 3, 1),
(N'A1', 400000.00, N'Ghế mềm điều hòa', 1, 2),
(N'B1', 250000.00, N'Giường nằm 6 chỗ', 2, 2),
(N'A1', 200000.00, N'Ghế cứng', 1, 3),
(N'A2', 250000.00, N'Ghế mềm', 2, 3),
(N'A1', 350000.00, N'Ghế mềm điều hòa', 1, 4),
(N'A1', 200000.00, N'Ghế cứng', 1, 5);

-- Dữ liệu cho bảng Ghe
INSERT INTO Ghe(SoHieu, ViTri, TrangThai, MaToa) VALUES
(N'01A', N'Cửa sổ', 'TRONG', 1),
(N'01B', N'Giữa toa', 'TRONG', 1),
(N'02A', N'Cửa sổ', 'TRONG', 1),
(N'01A', N'Cửa sổ', 'TRONG', 2),
(N'01B', N'Giữa toa', 'TRONG', 2),
(N'01A', N'Giường trên', 'TRONG', 3),
(N'01B', N'Giường dưới', 'TRONG', 3),
(N'01A', N'Cửa sổ', 'TRONG', 4),
(N'01B', N'Giữa toa', 'TRONG', 4),
(N'01A', N'Giường trên', 'TRONG', 5),
(N'01B', N'Giường dưới', 'TRONG', 5),
(N'01A', N'Cửa sổ', 'TRONG', 6),
(N'01B', N'Giữa toa', 'TRONG', 6),
(N'01A', N'Cửa sổ', 'TRONG', 7),
(N'01B', N'Giữa toa', 'TRONG', 7),
(N'01A', N'Cửa sổ', 'TRONG', 8),
(N'01B', N'Giữa toa', 'TRONG', 8),
(N'01A', N'Cửa sổ', 'TRONG', 9),
(N'01B', N'Giữa toa', 'TRONG', 9);

-- Dữ liệu cho bảng ChuyenTau
INSERT INTO ChuyenTau(MaTau, MaTuyen, GioKhoiHanh, GioDen, TrangThai, GhiChu) VALUES
(1, 1, '2025-09-20 06:00:00', '2025-09-21 05:00:00', 'MOBAN', N'Tàu SE1 Sài Gòn - Hà Nội'),
(2, 1, '2025-09-20 18:30:00', '2025-09-22 19:00:00', 'MOBAN', N'Tàu SE2 Hà Nội - Sài Gòn'),
(3, 2, '2025-09-20 06:00:00', '2025-09-23 18:00:00', 'MOBAN', N'Tàu SE3 Sài Gòn - Đà Nẵng'),
(4, 3, '2025-09-20 09:00:00', '2025-09-21 15:30:00', 'MOBAN', N'Tàu SNT2 Sài Gòn - Nha Trang'),
(5, 4, '2025-09-20 10:00:00', '2025-09-25 22:30:00', 'MOBAN', N'Tàu SE22 Đà Nẵng - Hà Nội');

--Dữ liệu admin (chạy cả 2 cùng lúc cho chắc)
INSERT INTO NguoiDung (Ho, Ten, NgaySinh, Email, SoDienThoai, LoaiNguoiDung)
VALUES (N'Nguyễn', N'Admin', '1990-01-01', N'admin@banve.com', N'0909000000', N'QUANTRI');
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, TrangThai, MaNguoiDung)
VALUES (N'admin', N'8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92' --123456
        , N'HOATDONG',SCOPE_IDENTITY());

use BanVeGaSaiGon
go
SELECT * FROM GaTau
SELECT * FROM TuyenDuong
SELECT * FROM Tau
SELECT * FROM ToaTau
SELECT * FROM Ghe
SELECT * FROM ChuyenTau
SELECT * FROM HanhKhach
SELECT * FROM TaiKhoan
SELECT * FROM NguoiDung
SELECT * FROM Ve

use master
go
DROP DATABASE BanVeGaSaiGon