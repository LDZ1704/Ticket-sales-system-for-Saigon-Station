# VNPay Callback API

API này xử lý callback từ VNPay sau khi thanh toán thành công.

## Cài đặt và chạy

1. **Cài đặt NuGet packages:**
   ```bash
   nuget restore
   ```

2. **Cấu hình database:**
   - Cập nhật connection string trong `App.config`
   - Đảm bảo database `BanVeGaSaiGon` đã được tạo

3. **Cấu hình VNPay:**
   - Cập nhật `VNPay_HashSecret` trong `App.config`
   - Cập nhật `VNPay_TmnCode` trong `App.config`
   - Cập nhật `VNPay_ReturnUrl` trong `App.config`

4. **Chạy API:**
   ```bash
   dotnet run
   ```
   Hoặc chạy file exe trong thư mục bin/Debug

## API Endpoints

### POST/GET /api/vnpay/callback

Xử lý callback từ VNPay sau khi thanh toán.

### GET /api/qrcode/generate

Tạo QR code với format khác nhau.

**Parameters:**
- `data` (required): Dữ liệu để tạo QR code
- `format` (optional): Format output - "base64" (default), "svg", "text"

**Example:**
```
GET /api/qrcode/generate?data=Hello World&format=svg
```

### POST /api/qrcode/generate

Tạo QR code với POST request.

**Request Body:**
```json
{
  "data": "Hello World",
  "format": "base64"
}
```

### GET /api/qrcode/test

Test API để kiểm tra tất cả format QR code.

### GET /api/giave/tinh

Tính giá vé dựa trên chuyến tàu và ghế.

**Parameters:**
- `maChuyen` (required): Mã chuyến tàu
- `maGhe` (required): Mã ghế

**Example:**
```
GET /api/giave/tinh?maChuyen=1&maGhe=5
```

### GET /api/giave/coban

Lấy giá vé cơ bản từ toa tàu.

**Parameters:**
- `maGhe` (required): Mã ghế

### GET /api/giave/test

Test API để kiểm tra tính giá vé với dữ liệu mẫu.

**Request Parameters:**
- `vnp_SecureHash`: Chữ ký bảo mật từ VNPay
- `vnp_ResponseCode`: Mã phản hồi (00 = thành công)
- `vnp_TxnRef`: Mã giao dịch (format: MaThanhToan_MaNguoiDung)
- `vnp_Amount`: Số tiền thanh toán
- `vnp_OrderInfo`: Thông tin đơn hàng (chứa thông tin hành khách và vé)

**Response:**
```json
{
  "success": true,
  "message": "Payment successful",
  "data": {
    "maVe": 123,
    "maHanhKhach": 456,
    "maThanhToan": 789,
    "maQR": "base64_encoded_qr_code",
    "giaVe": 150000
  }
}
```

## Format của vnp_OrderInfo

Thông tin đơn hàng phải có format:
```
MaChuyen:1,MaGhe:5,HoTen:Nguyen Van A,GioiTinh:Nam,NgaySinh:1990-01-01,LoaiGiayTo:CCCD,SoGiayTo:123456789,QuocTich:Viet Nam,Email:test@email.com,SoDienThoai:0123456789
```

## Xử lý sau khi thanh toán thành công

1. **Validate signature** từ VNPay
2. **Cập nhật trạng thái thanh toán** thành "THANHCONG"
3. **Lưu thông tin hành khách** vào bảng `HanhKhach`
4. **Lưu thông tin vé** vào bảng `Ve`
5. **Tạo QR code** cho vé
6. **Cập nhật trạng thái ghế** thành "DADAT"

## Cách tính giá vé

```
Giá vé = Giá vé trong bảng ToaTau
```

- Lấy trực tiếp giá vé từ trường `GiaVe` trong bảng `ToaTau`
- Không có tính toán phức tạp hay hệ số
- Nếu `GiaVe` null thì dùng giá mặc định 100,000 VND

## Lưu ý

- API chạy trên port 8080
- Đảm bảo VNPay được cấu hình đúng return URL
- QR code được tạo dưới dạng base64 string
- Tất cả thông tin được lưu vào database theo cấu trúc đã định
- Giá vé được lấy trực tiếp từ bảng ToaTau, không tính toán phức tạp
