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
    GioKhoiHanh DATE,
	-- bỏ giờ xuất phát do trong ngày khởi hành có cả giờ rồi
    GioDen Date, -- chỉnh giờ đến thành Date luôn
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

--DROP DATABASE BanVeGaSaiGon