USE master
GO

CREATE DATABASE BanVeGaSaiGon
GO

USE BanVeGaSaiGon
GO

-- Bảng tài khoản
CREATE TABLE TaiKhoan (
    MaTaiKhoan INT IDENTITY PRIMARY KEY,
    TenDangNhap NVARCHAR(50) UNIQUE NOT NULL,
    MatKhau NVARCHAR(255) NOT NULL,
    NgayTao DATE DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN ('HoatDong','Khoa'))
)

-- Bảng người dùng
CREATE TABLE NguoiDung (
    MaNguoiDung INT IDENTITY PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    Email NVARCHAR(100),
    SoDienThoai NVARCHAR(20),
    LoaiNguoiDung NVARCHAR(20) CHECK (LoaiNguoiDung IN ('Khach','NhanVien','QuanTri')),
    MaTaiKhoan INT FOREIGN KEY REFERENCES TaiKhoan(MaTaiKhoan)
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
    MoTa NVARCHAR(200),
    TongSoToa INT,
    LoaiTau NVARCHAR(50)
)

-- Bảng toa tàu
CREATE TABLE ToaTau (
    MaToa INT IDENTITY PRIMARY KEY,
    TenToa NVARCHAR(50),
    LoaiGhe NVARCHAR(50),
    SoLuongGhe INT,
    ViTri NVARCHAR(50),
    MaTau INT FOREIGN KEY REFERENCES Tau(MaTau)
)

-- Bảng ghế
CREATE TABLE Ghe (
    MaGhe INT IDENTITY PRIMARY KEY,
    SoHieu NVARCHAR(10),
    ViTri NVARCHAR(50),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN ('Trong','DaDat','DangGiu')),
    MaToa INT FOREIGN KEY REFERENCES ToaTau(MaToa)
)

-- Bảng chuyến tàu
CREATE TABLE ChuyenTau (
    MaChuyen INT IDENTITY PRIMARY KEY,
    MaTau INT FOREIGN KEY REFERENCES Tau(MaTau),
    MaTuyen INT FOREIGN KEY REFERENCES TuyenDuong(MaTuyen),
    NgayKhoiHanh DATE,
    GioXuatPhat TIME,
    GioDen TIME,
    TrangThai NVARCHAR(20) CHECK (TrangThai IN ('MoBan','DaChay','Huy')),
    GhiChu NVARCHAR(200)
)

-- Bảng thanh toán
CREATE TABLE ThanhToan (
    MaThanhToan INT IDENTITY PRIMARY KEY,
    MaNguoiDung INT FOREIGN KEY REFERENCES NguoiDung(MaNguoiDung),
    HinhThuc NVARCHAR(50),
    SoTien DECIMAL(12,2),
    ThoiDiem DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN ('ThanhCong','ThatBai','DangXuLy'))
)

-- Bảng vé
CREATE TABLE Ve (
    MaVe INT IDENTITY PRIMARY KEY,
    MaNguoiDung INT FOREIGN KEY REFERENCES NguoiDung(MaNguoiDung),
    MaHanhKhach INT FOREIGN KEY REFERENCES HanhKhach(MaHanhKhach),
    MaChuyen INT FOREIGN KEY REFERENCES ChuyenTau(MaChuyen),
    MaToa INT FOREIGN KEY REFERENCES ToaTau(MaToa),
    MaGhe INT FOREIGN KEY REFERENCES Ghe(MaGhe),
    MaThanhToan INT FOREIGN KEY REFERENCES ThanhToan(MaThanhToan),
    NgayDat DATETIME DEFAULT GETDATE(),
    GiaVe DECIMAL(12,2),
    TrangThai NVARCHAR(20) CHECK (TrangThai IN ('GiuCho','DaThanhToan','DaHuy','DaDoi')),
    MaQR NVARCHAR(100)
)

--DROP DATABASE BanVeGaSaiGon