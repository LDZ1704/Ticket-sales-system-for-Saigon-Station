# Hướng dẫn sử dụng VNPay trong Visual Studio

## Các file VNPay đã được tạo

### 1. VnpayLibrary.cs (BUS_TicketSalesSystem)
- **Vị trí**: `TicketSalesSystem\BUS_TicketSalesSystem\VnpayLibrary.cs`
- **Chức năng**: Class chính để tương tác với VNPay API
- **Các method chính**:
  - `AddRequestData()`: Thêm tham số cho request
  - `CreateRequestUrl()`: Tạo URL thanh toán
  - `ValidateSignature()`: Xác minh chữ ký từ VNPay

### 2. DTO Classes (DTO_TicketSalesSystem)
- **DTO_GioHang.cs**: Quản lý giỏ hàng
- **DTO_VeTrongGio.cs**: Thông tin vé trong giỏ hàng
- **DTO_ThanhToanVNPay.cs**: Thông tin thanh toán VNPay
- **DTO_VNPayConfig.cs**: Cấu hình VNPay

### 3. BUS_DatVe.cs (BUS_TicketSalesSystem)
- **Các method mới**:
  - `TaoUrlThanhToanVNPay()`: Tạo URL thanh toán cho giỏ hàng
  - `XuLyThanhToanThanhCong()`: Xử lý khi thanh toán thành công
  - `XuLyThanhToanThatBai()`: Xử lý khi thanh toán thất bại

### 4. GUI Forms (GUI_TicketSalesSystem)
- **FormGioHang.cs**: Form quản lý giỏ hàng
- **FormThanhToanVNPay.cs**: Form thanh toán VNPay
- **FormDatVeGioHang.cs**: Form đặt vé với giỏ hàng

## Cách sử dụng trong Visual Studio

### 1. Mở Solution
```
File → Open → Project/Solution → Chọn TicketSalesSystem.sln
```

### 2. Kiểm tra các file VNPay
- Mở **Solution Explorer**
- Mở rộng **BUS_TicketSalesSystem** project
- Tìm file **VnpayLibrary.cs**
- Mở rộng **DTO_TicketSalesSystem** project
- Tìm các file DTO mới: **DTO_GioHang.cs**, **DTO_ThanhToanVNPay.cs**

### 3. Test VNPay Integration
- Mở file **VNPay_Demo.cs** (trong root folder)
- Chạy method `TestVNPayIntegration()` để test

### 4. Sử dụng trong code

#### Tạo giỏ hàng:
```csharp
var gioHang = new DTO_GioHang
{
    MaNguoiDung = 1,
    DanhSachVe = new List<DTO_VeTrongGio>
    {
        new DTO_VeTrongGio
        {
            MaChuyen = 1,
            MaGhe = 5,
            HoTen = "Nguyễn Văn A",
            GioiTinh = "Nam",
            NgaySinh = DateTime.Now.AddYears(-25),
            SoGiayTo = "123456789",
            GiaVe = 500000,
            // ... các thông tin khác
        }
    }
};
```

#### Tạo URL thanh toán:
```csharp
var busDatVe = new BUS_DatVe();
string paymentUrl = busDatVe.TaoUrlThanhToanVNPay(gioHang);
System.Diagnostics.Process.Start(paymentUrl);
```

#### Xử lý callback:
```csharp
if (thanhToanThanhCong)
{
    busDatVe.XuLyThanhToanThanhCong(maThanhToan, gioHang);
}
else
{
    busDatVe.XuLyThanhToanThatBai(maThanhToan);
}
```

## Cấu hình VNPay

### Sandbox (Test):
```csharp
VnpUrl = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html"
TmnCode = "2QXUI4J4"
SecretKey = "RAOEXHYVSDDIIENYWSLGIAUNYWKGQZP"
```

### Production:
```csharp
VnpUrl = "https://vnpayment.vn/paymentv2/vpcpay.html"
TmnCode = "YOUR_TMN_CODE"
SecretKey = "YOUR_SECRET_KEY"
```

## Test với VNPay Sandbox

1. **Thẻ test**: `9704198526191432198`
2. **CVV**: `123`
3. **Ngày hết hạn**: `12/25`
4. **OTP**: `123456`

## Lưu ý quan trọng

1. **ReturnUrl**: Cần tạo endpoint để nhận callback từ VNPay
2. **IPN URL**: Cần tạo endpoint để nhận IPN
3. **Database**: Đảm bảo có method `CapNhatTrangThaiThanhToan`
4. **Logging**: Nên log tất cả giao dịch

## Troubleshooting

### Nếu không thấy file VNPay trong Visual Studio:
1. **Refresh Solution**: Right-click Solution → Refresh
2. **Reload Project**: Right-click project → Reload
3. **Clean & Rebuild**: Build → Clean Solution → Rebuild Solution

### Nếu có lỗi build:
1. **Restore Packages**: Tools → NuGet Package Manager → Restore
2. **Check References**: Đảm bảo tất cả references đều OK
3. **Check .NET Framework**: Đảm bảo project sử dụng .NET Framework 4.7.2

## Mở rộng

- Thêm MoMo, ZaloPay
- Tích hợp email/SMS
- Thêm mã giảm giá
- Báo cáo thống kê
