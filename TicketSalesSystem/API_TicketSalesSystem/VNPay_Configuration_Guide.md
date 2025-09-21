# Hướng dẫn cấu hình VNPay cho Callback API

## 1. Cấu hình trong VNPay Merchant Portal

### Bước 1: Đăng nhập vào VNPay Merchant Portal
- Truy cập: https://sandbox.vnpayment.vn/merchantv2/
- Đăng nhập bằng tài khoản merchant

### Bước 2: Cấu hình Return URL
- Vào **Cấu hình** > **Cấu hình URL**
- Thiết lập **Return URL**: `http://your-domain:8080/api/vnpay/callback`
- Thiết lập **IPN URL**: `http://your-domain:8080/api/vnpay/callback`

### Bước 3: Lấy thông tin cấu hình
- **TmnCode**: Mã merchant từ VNPay
- **HashSecret**: Mã bí mật để tạo chữ ký

## 2. Cấu hình trong App.config

```xml
<appSettings>
    <!-- Thay YOUR_VNPAY_HASH_SECRET bằng HashSecret từ VNPay -->
    <add key="VNPay_HashSecret" value="YOUR_VNPAY_HASH_SECRET" />
    
    <!-- Thay YOUR_VNPAY_TMN_CODE bằng TmnCode từ VNPay -->
    <add key="VNPay_TmnCode" value="YOUR_VNPAY_TMN_CODE" />
    
    <!-- URL thanh toán VNPay -->
    <add key="VNPay_Url" value="https://sandbox.vnpayment.vn/paymentv2/vpcpay.html" />
    
    <!-- URL callback của bạn -->
    <add key="VNPay_ReturnUrl" value="http://localhost:8080/api/vnpay/callback" />
</appSettings>
```

## 3. Cấu hình Database

### Connection String
```xml
<connectionStrings>
    <add name="TicketSalesContext" 
         connectionString="Data Source=.;Initial Catalog=BanVeGaSaiGon;Integrated Security=True" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

## 4. Format dữ liệu gửi đến VNPay

### vnp_TxnRef (Mã giao dịch)
Format: `{MaThanhToan}_{MaNguoiDung}`
Ví dụ: `123_456`

### vnp_OrderInfo (Thông tin đơn hàng)
Format: `MaChuyen:{maChuyen},MaGhe:{maGhe},HoTen:{hoTen},GioiTinh:{gioiTinh},NgaySinh:{ngaySinh},LoaiGiayTo:{loaiGiayTo},SoGiayTo:{soGiayTo},QuocTich:{quocTich},Email:{email},SoDienThoai:{soDienThoai}`

Ví dụ:
```
MaChuyen:1,MaGhe:5,HoTen:Nguyen Van A,GioiTinh:Nam,NgaySinh:1990-01-01,LoaiGiayTo:CCCD,SoGiayTo:123456789,QuocTich:Viet Nam,Email:test@email.com,SoDienThoai:0123456789
```

## 5. Xử lý Callback

### Thành công (vnp_ResponseCode = "00")
1. Validate signature
2. Cập nhật trạng thái thanh toán thành "THANHCONG"
3. Lưu thông tin hành khách
4. Lưu thông tin vé
5. Tạo QR code
6. Cập nhật trạng thái ghế thành "DADAT"

### Thất bại (vnp_ResponseCode != "00")
1. Cập nhật trạng thái thanh toán thành "THATBAI"

## 6. Test API

### Sử dụng PowerShell script
```powershell
.\TestCallback.ps1
```

### Sử dụng Postman
- Method: GET hoặc POST
- URL: `http://localhost:8080/api/vnpay/callback`
- Body (nếu POST): form-data với các parameters từ VNPay

## 7. Lưu ý quan trọng

1. **Bảo mật**: Luôn validate signature từ VNPay
2. **Idempotency**: Xử lý trường hợp callback bị gọi nhiều lần
3. **Logging**: Ghi log tất cả callback để debug
4. **Error Handling**: Xử lý lỗi một cách graceful
5. **Database Transaction**: Sử dụng transaction để đảm bảo tính nhất quán

## 8. Troubleshooting

### Lỗi "Invalid signature"
- Kiểm tra HashSecret có đúng không
- Kiểm tra cách tạo signature có đúng chuẩn VNPay không

### Lỗi "Invalid transaction reference format"
- Kiểm tra format của vnp_TxnRef
- Đảm bảo MaThanhToan và MaNguoiDung tồn tại trong database

### Lỗi database
- Kiểm tra connection string
- Kiểm tra các bảng đã được tạo chưa
- Kiểm tra quyền truy cập database
