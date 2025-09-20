# PowerShell script để test QR Code API

$baseUrl = "http://localhost:8080"

Write-Host "Testing QR Code API..." -ForegroundColor Green

# Test 1: Generate QR code với format base64
Write-Host "`n1. Testing QR Code generation (Base64 format)..." -ForegroundColor Yellow
try {
    $response = Invoke-RestMethod -Uri "$baseUrl/api/qrcode/generate?data=Hello World&format=base64" -Method GET
    Write-Host "Success! QR Code generated (Base64): $($response.data.Substring(0, 50))..." -ForegroundColor Green
} catch {
    Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
}

# Test 2: Generate QR code với format SVG
Write-Host "`n2. Testing QR Code generation (SVG format)..." -ForegroundColor Yellow
try {
    $response = Invoke-RestMethod -Uri "$baseUrl/api/qrcode/generate?data=Hello World&format=svg" -Method GET
    Write-Host "Success! QR Code generated (SVG): $($response.data.Substring(0, 100))..." -ForegroundColor Green
} catch {
    Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
}

# Test 3: Generate QR code với format text
Write-Host "`n3. Testing QR Code generation (Text format)..." -ForegroundColor Yellow
try {
    $response = Invoke-RestMethod -Uri "$baseUrl/api/qrcode/generate?data=Hello World&format=text" -Method GET
    Write-Host "Success! QR Code generated (Text):" -ForegroundColor Green
    Write-Host $response.data -ForegroundColor Cyan
} catch {
    Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
}

# Test 4: POST request với JSON body
Write-Host "`n4. Testing QR Code generation (POST with JSON)..." -ForegroundColor Yellow
try {
    $body = @{
        data = "Test QR Code from POST"
        format = "base64"
    } | ConvertTo-Json

    $response = Invoke-RestMethod -Uri "$baseUrl/api/qrcode/generate" -Method POST -Body $body -ContentType "application/json"
    Write-Host "Success! QR Code generated via POST: $($response.data.Substring(0, 50))..." -ForegroundColor Green
} catch {
    Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
}

# Test 5: Test endpoint
Write-Host "`n5. Testing QR Code test endpoint..." -ForegroundColor Yellow
try {
    $response = Invoke-RestMethod -Uri "$baseUrl/api/qrcode/test" -Method GET
    Write-Host "Success! Test endpoint response:" -ForegroundColor Green
    Write-Host "Test Data: $($response.testData)" -ForegroundColor Cyan
    Write-Host "Base64 Length: $($response.base64.Length)" -ForegroundColor Cyan
    Write-Host "SVG Length: $($response.svg.Length)" -ForegroundColor Cyan
    Write-Host "Text Length: $($response.text.Length)" -ForegroundColor Cyan
} catch {
    Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
}

# Test 6: Test với dữ liệu vé
Write-Host "`n6. Testing QR Code với dữ liệu vé..." -ForegroundColor Yellow
try {
    $ticketData = "VE_123_456_789_20241201120000"
    $response = Invoke-RestMethod -Uri "$baseUrl/api/qrcode/generate?data=$ticketData&format=base64" -Method GET
    Write-Host "Success! Ticket QR Code generated: $($response.data.Substring(0, 50))..." -ForegroundColor Green
} catch {
    Write-Host "Error: $($_.Exception.Message)" -ForegroundColor Red
}

Write-Host "`nQR Code API testing completed!" -ForegroundColor Green
