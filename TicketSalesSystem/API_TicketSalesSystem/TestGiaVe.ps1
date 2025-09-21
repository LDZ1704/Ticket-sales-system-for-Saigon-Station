# PowerShell script để test API tính giá vé

$baseUrl = "http://localhost:8080"

Write-Host "Testing Gia Ve API..." -ForegroundColor Green

# Test 1: Tính giá vé
Write-Host "`n1. Testing tính giá vé..." -ForegroundColor Yellow
try {
    $response = Invoke-RestMethod -Uri "$baseUrl/api/giave/tinh?maChuyen=1&maGhe=5" -Method GET
    Write-Host "Success! Giá vé được tính:" -ForegroundColor Green
    Write-Host "  - Mã ghế: $($response.data.maGhe)" -ForegroundColor Cyan
    Write-Host "  - Số hiệu: $($response.data.soHieu)" -ForegroundColor Cyan
    Write-Host "  - Tên toa: $($response.data.tenToa)" -ForegroundColor Cyan
    Write-Host "  - Loại ghế: $($response.data.loaiGhe)" -ForegroundColor Cyan
    Write-Host "  - Giá vé cơ bản: $($response.data.giaVeCoBan)" -ForegroundColor Cyan
    Write-Host "  - Khoảng cách: $($response.data.khoangCach) km" -ForegroundColor Cyan
    Write-Host "  - Ga đi: $($response.data.gaDi)" -ForegroundColor Cyan
    Write-Host "  - Ga đến: $($response.data.gaDen)" -ForegroundColor Cyan
    Write-Host "  - Giá vé: $($response.data.giaVeCuoiCung)" -ForegroundColor Green
} catch {
    Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
}

# Test 2: Lấy giá vé cơ bản
Write-Host "`n2. Testing lấy giá vé cơ bản..." -ForegroundColor Yellow
try {
    $response = Invoke-RestMethod -Uri "$baseUrl/api/giave/coban?maGhe=5" -Method GET
    Write-Host "Success! Giá vé cơ bản:" -ForegroundColor Green
    Write-Host "  - Mã ghế: $($response.data.maGhe)" -ForegroundColor Cyan
    Write-Host "  - Giá vé cơ bản: $($response.data.giaVeCoBan)" -ForegroundColor Cyan
} catch {
    Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
}

# Test 3: Test endpoint
Write-Host "`n3. Testing test endpoint..." -ForegroundColor Yellow
try {
    $response = Invoke-RestMethod -Uri "$baseUrl/api/giave/test" -Method GET
    Write-Host "Success! Test results:" -ForegroundColor Green
    foreach ($result in $response.results) {
        if ($result.success) {
            Write-Host "  - Chuyến $($result.maChuyen), Ghế $($result.maGhe): Thành công" -ForegroundColor Green
            Write-Host "    Giá vé: $($result.data.giaVeCuoiCung)" -ForegroundColor Cyan
        } else {
            Write-Host "  - Chuyến $($result.maChuyen), Ghế $($result.maGhe): Thất bại - $($result.message)" -ForegroundColor Red
        }
    }
} catch {
    Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
}

# Test 4: Test với các ghế khác nhau
Write-Host "`n4. Testing với các ghế khác nhau..." -ForegroundColor Yellow
$testGhes = @(1, 5, 10, 15, 20)
foreach ($maGhe in $testGhes) {
    try {
        $response = Invoke-RestMethod -Uri "$baseUrl/api/giave/tinh?maChuyen=1&maGhe=$maGhe" -Method GET
        Write-Host "  - Ghế $maGhe: $($response.data.giaVeCuoiCung) VND ($($response.data.loaiGhe))" -ForegroundColor Cyan
    } catch {
        Write-Host "  - Ghế $maGhe: Không tìm thấy" -ForegroundColor Red
    }
}

Write-Host "`nGia Ve API testing completed!" -ForegroundColor Green
