# Hướng dẫn tích hợp VNPay cho hệ thống bán vé tàu

## Tổng quan
Hệ thống đã được tích hợp VNPay để hỗ trợ thanh toán trực tuyến cho việc mua vé tàu. Hệ thống hỗ trợ mua nhiều vé cùng lúc thông qua giỏ hàng.

## Các thành phần chính

### 1. VnpayLibrary.cs
- Class chính để tương tác với VNPay API
- Hỗ trợ tạo URL thanh toán và xác minh chữ ký
- Sử dụng HMAC SHA512 để bảo mật

### 2. DTO Classes
- `DTO_GioHang`: Quản lý giỏ hàng chứa nhiều vé
- `DTO_VeTrongGio`: Thông tin vé trong giỏ hàng
- `DTO_ThanhToanVNPay`: Thông tin thanh toán VNPay
- `DTO_VNPayConfig`: Cấu hình VNPay

### 3. Business Logic (BUS_DatVe.cs)
- `TaoUrlThanhToanVNPay()`: Tạo URL thanh toán VNPay
- `XuLyThanhToanThanhCong()`: Xử lý khi thanh toán thành công
- `XuLyThanhToanThatBai()`: Xử lý khi thanh toán thất bại

### 4. GUI Forms
- `FormGioHang`: Quản lý giỏ hàng
- `FormThanhToanVNPay`: Form thanh toán VNPay
- `FormDatVeGioHang`: Form đặt vé với giỏ hàng

## Cấu hình VNPay

### Sandbox Environment
```csharp
public class DTO_VNPayConfig
{
    public string VnpUrl = "https://sandbox.vnpayment.vn/paymentv2/vpcpay.html";
    public string TmnCode = "2QXUI4J4";
    public string SecretKey = "RAOEXHYVSDDIIENYWSLGIAUNYWKGQZP";
    public string ReturnUrl = "http://localhost:5111/api/vnpay-return";
}
```

### Production Environment
Để chuyển sang production, cần thay đổi:
- `VnpUrl`: `https://vnpayment.vn/paymentv2/vpcpay.html`
- `TmnCode`: Mã terminal thực tế
- `SecretKey`: Secret key thực tế
- `ReturnUrl`: URL callback thực tế

## Cách sử dụng

### 1. Thêm vé vào giỏ hàng
```csharp
var veTrongGio = new DTO_VeTrongGio
{
    MaChuyen = 1,
    MaGhe = 5,
    HoTen = "Nguyễn Văn A",
    GioiTinh = "Nam",
    NgaySinh = DateTime.Now.AddYears(-25),
    SoGiayTo = "123456789",
    GiaVe = 500000,
    // ... các thông tin khác
};

gioHang.DanhSachVe.Add(veTrongGio);
```

### 2. Tạo URL thanh toán
```csharp
var busDatVe = new BUS_DatVe();
string paymentUrl = busDatVe.TaoUrlThanhToanVNPay(gioHang);
System.Diagnostics.Process.Start(paymentUrl);
```

### 3. Xử lý callback từ VNPay
```csharp
// Khi VNPay redirect về ReturnUrl
if (thanhToanThanhCong)
{
    busDatVe.XuLyThanhToanThanhCong(maThanhToan, gioHang);
}
else
{
    busDatVe.XuLyThanhToanThatBai(maThanhToan);
}
```

## Luồng thanh toán

1. **Chọn vé**: Người dùng chọn chuyến tàu và ghế
2. **Thêm vào giỏ**: Thêm vé vào giỏ hàng với thông tin hành khách
3. **Thanh toán**: Nhấn "Thanh toán VNPay"
4. **Chuyển hướng**: Hệ thống tạo URL và mở trình duyệt
5. **Thanh toán**: Người dùng thanh toán trên VNPay
6. **Callback**: VNPay redirect về ReturnUrl
7. **Xử lý**: Hệ thống xử lý kết quả và tạo vé

## Bảo mật

- Sử dụng HMAC SHA512 để ký dữ liệu
- Validate tất cả thông tin đầu vào
- Kiểm tra chữ ký từ VNPay trước khi xử lý
- Mã hóa thông tin nhạy cảm

## Xử lý lỗi

- Validate ghế trống trước khi đặt
- Kiểm tra thông tin hành khách
- Xử lý lỗi thanh toán
- Rollback khi có lỗi

## Testing

### Test với VNPay Sandbox
1. Sử dụng thẻ test: `9704198526191432198`
2. CVV: `123`
3. Ngày hết hạn: `12/25`
4. OTP: `123456`

### Test Cases
- Đặt 1 vé
- Đặt nhiều vé cùng lúc
- Thanh toán thành công
- Thanh toán thất bại
- Hủy thanh toán

## Lưu ý quan trọng

1. **ReturnUrl**: Cần tạo endpoint để nhận callback từ VNPay
2. **IPN URL**: Cần tạo endpoint để nhận IPN (Instant Payment Notification)
3. **Database**: Đảm bảo có method `CapNhatTrangThaiThanhToan` trong DAL
4. **Logging**: Nên log tất cả giao dịch để debug
5. **Timeout**: Xử lý timeout khi gọi VNPay API

## Mở rộng

- Thêm các phương thức thanh toán khác (MoMo, ZaloPay)
- Tích hợp email/SMS thông báo
- Thêm mã giảm giá
- Tích hợp báo cáo thống kê
