# PowerShell script để test VNPay callback API

$baseUrl = "http://localhost:8080"
$callbackUrl = "$baseUrl/api/vnpay/callback"

# Test data - mô phỏng callback từ VNPay
$testParams = @{
    vnp_SecureHash = "test_hash_signature"
    vnp_ResponseCode = "00"
    vnp_TxnRef = "123_456"  # MaThanhToan_MaNguoiDung
    vnp_Amount = "15000000"  # 150,000 VND
    vnp_OrderInfo = "MaChuyen:1,MaGhe:5,HoTen:Nguyen Van A,GioiTinh:Nam,NgaySinh:1990-01-01,LoaiGiayTo:CCCD,SoGiayTo:123456789,QuocTich:Viet Nam,Email:test@email.com,SoDienThoai:0123456789"
    vnp_TransactionNo = "12345678"
    vnp_PayDate = "20241201120000"
    vnp_BankCode = "NCB"
    vnp_CardType = "ATM"
}

# Tạo query string
$queryString = ""
foreach ($param in $testParams.GetEnumerator()) {
    $queryString += "$($param.Key)=$($param.Value)&"
}
$queryString = $queryString.TrimEnd('&')

# Gửi GET request
Write-Host "Testing VNPay Callback API..."
Write-Host "URL: $callbackUrl"
Write-Host "Query String: $queryString"

try {
    $response = Invoke-RestMethod -Uri "$callbackUrl?$queryString" -Method GET -ContentType "application/json"
    Write-Host "Response:"
    $response | ConvertTo-Json -Depth 3
} catch {
    Write-Host "Error: $($_.Exception.Message)"
    Write-Host "Response: $($_.Exception.Response)"
}

# Test POST request
Write-Host "`nTesting POST request..."
try {
    $response = Invoke-RestMethod -Uri $callbackUrl -Method POST -Body $testParams -ContentType "application/x-www-form-urlencoded"
    Write-Host "Response:"
    $response | ConvertTo-Json -Depth 3
} catch {
    Write-Host "Error: $($_.Exception.Message)"
    Write-Host "Response: $($_.Exception.Response)"
}
