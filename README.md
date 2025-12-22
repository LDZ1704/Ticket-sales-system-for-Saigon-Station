# Hệ thống Bán Vé Tàu Ga Sài Gòn

Hệ thống quản lý và bán vé tàu hỏa cho Ga Sài Gòn, được xây dựng bằng C# Windows Forms với kiến trúc 3 lớp và tích hợp thanh toán VNPay.

## Kiến trúc hệ thống

- **GUI_TicketSalesSystem**: Ứng dụng Windows Forms (giao diện người dùng)
- **BUS_TicketSalesSystem**: Lớp Business Logic
- **DAL_TicketSalesSystem**: Lớp Data Access (Entity Framework)
- **DTO_TicketSalesSystem**: Data Transfer Objects
- **API_TicketSalesSystem**: API xử lý callback VNPay (chạy trên port 8080)

## Tính năng chính

### 1. Quản lý người dùng và tài khoản
- Đăng ký/Đăng nhập với phân quyền (Khách hàng, Nhân viên, Quản trị viên)
- Đổi mật khẩu
- Quản lý thông tin cá nhân
- Quản lý người dùng (dành cho Quản trị viên)
- Cấp quyền và phân quyền người dùng

### 2. Tra cứu và đặt vé
- **Tra cứu chuyến tàu**: Tìm kiếm theo ga đi, ga đến, ngày khởi hành
- **Xem chi tiết**: Thông tin chuyến tàu, toa tàu, ghế ngồi, giá vé
- **Đặt vé**: Chọn ghế, nhập thông tin hành khách, thanh toán
- **Quản lý vé**: Xem danh sách vé đã đặt, chi tiết vé
- **Đổi vé**: Đổi chuyến tàu hoặc ghế ngồi
- **Hủy vé**: Hủy vé đã đặt (theo quy định)

### 3. Quản lý hệ thống (Quản trị viên)
- **Dashboard**: Tổng quan hệ thống, thống kê nhanh
- **Quản lý chuyến tàu**: Thêm, sửa, xóa chuyến tàu
- **Quản lý ga tàu**: Quản lý thông tin các ga tàu
- **Quản lý tàu**: Quản lý thông tin tàu, toa tàu, ghế ngồi
- **Quản lý tuyến đường**: Cấu hình tuyến đường và khoảng cách
- **Thống kê và báo cáo**: Thống kê doanh thu, số lượng vé, báo cáo tổng hợp
- **Lịch sử hoạt động**: Theo dõi các hoạt động trong hệ thống
- **Cài đặt hệ thống**: Cấu hình các thông số hệ thống

### 4. Thanh toán và QR Code
- Thanh toán trực tuyến qua VNPay
- Tạo QR code tự động cho mỗi vé sau khi thanh toán thành công
- Xử lý callback từ VNPay và cập nhật trạng thái vé tự động

## Yêu cầu hệ thống

- .NET Framework
- SQL Server
- Visual Studio
- VNPay Merchant Account (cho thanh toán)

## Cài đặt

### 1. Database

Chạy script `DatabaseBanVe.sql` để tạo database `BanVeGaSaiGon`:

```sql
USE master
GO
-- Chạy toàn bộ script trong DatabaseBanVe.sql
```

### 2. Cấu hình Connection String

Cập nhật connection string trong `App.config` của các project:

```xml
<connectionStrings>
    <add name="TicketSalesContext" 
         connectionString="Data Source=.;Initial Catalog=BanVeGaSaiGon;Integrated Security=True" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 3. Cấu hình VNPay (cho API)

Trong `API_TicketSalesSystem/App.config`:

```xml
<appSettings>
    <add key="VNPay_HashSecret" value="YOUR_VNPAY_HASH_SECRET" />
    <add key="VNPay_TmnCode" value="YOUR_VNPAY_TMN_CODE" />
    <add key="VNPay_Url" value="https://sandbox.vnpayment.vn/paymentv2/vpcpay.html" />
    <add key="VNPay_ReturnUrl" value="http://localhost:8080/api/vnpay/callback" />
</appSettings>
```

**Lưu ý**: Cấu hình Return URL trong VNPay Merchant Portal: `http://your-domain:8080/api/vnpay/callback`

### 4. Build và chạy

1. Mở `TicketSalesSystem.sln` trong Visual Studio
2. Restore NuGet packages
3. Build solution (F6)
4. Chạy `GUI_TicketSalesSystem` để khởi động ứng dụng
5. Chạy `API_TicketSalesSystem` để khởi động API callback (port 8080)

## API Endpoints

API hỗ trợ các chức năng:
- **VNPay Callback**: `/api/vnpay/callback` - Xử lý callback từ VNPay
- **QR Code**: `/api/qrcode/generate` - Tạo QR code cho vé (format: base64, svg, text)
- **Tính giá vé**: `/api/giave/tinh` - Tính giá vé theo chuyến và ghế

Chi tiết các API endpoints xem tại `API_TicketSalesSystem/README.md`

## Cấu trúc Database

Các bảng chính:
- `NguoiDung` - Thông tin người dùng
- `TaiKhoan` - Tài khoản đăng nhập
- `ChuyenTau` - Chuyến tàu
- `Ve` - Vé tàu
- `HanhKhach` - Thông tin hành khách
- `ThanhToan` - Giao dịch thanh toán
- `Ghe`, `ToaTau`, `Tau` - Cấu trúc tàu
- `GaTau`, `TuyenDuong` - Tuyến đường và ga tàu

## Thanh toán VNPay

Hệ thống tích hợp thanh toán qua VNPay với quy trình tự động:
1. Người dùng đặt vé → Tạo giao dịch thanh toán
2. Chuyển hướng đến VNPay để thanh toán
3. VNPay gửi callback về API → Xử lý tự động: validate signature, cập nhật trạng thái, lưu thông tin vé, tạo QR code

**Format dữ liệu:**
- `vnp_TxnRef`: `{MaThanhToan}_{MaNguoiDung}`
- `vnp_OrderInfo`: Chứa thông tin chuyến tàu, ghế, hành khách (chi tiết xem `API_TicketSalesSystem/README.md`)

## Tài liệu tham khảo

- `API_TicketSalesSystem/README.md` - Chi tiết API endpoints
- `API_TicketSalesSystem/VNPay_Configuration_Guide.md` - Hướng dẫn cấu hình VNPay
- `API_TicketSalesSystem/Database_Update_Guide.md` - Hướng dẫn cập nhật database

## Lưu ý

- API callback chạy trên port 8080 (có thể thay đổi trong `Program.cs`)
- Đảm bảo database đã được tạo và cấu hình đúng connection string
- VNPay Return URL phải khớp với cấu hình trong Merchant Portal
- Giá vé được lấy từ bảng `ToaTau.GiaVe` (mặc định 100,000 VND nếu null)
- Hệ thống hỗ trợ 3 loại người dùng: Khách hàng (KHACH), Nhân viên (NHANVIEN), Quản trị viên (QUANTRI)
