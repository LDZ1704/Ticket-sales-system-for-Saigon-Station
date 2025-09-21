-- Script để thêm trường GiaVe vào bảng ToaTau
-- Chạy script này trong SQL Server Management Studio

USE BanVeGaSaiGon
GO

-- Thêm trường GiaVe vào bảng ToaTau
ALTER TABLE ToaTau 
ADD GiaVe DECIMAL(12,2) NULL
GO

-- Cập nhật giá vé mặc định cho các toa tàu hiện có
-- Bạn có thể điều chỉnh giá vé theo từng loại toa

-- Ví dụ: Cập nhật giá vé cho các toa tàu
UPDATE ToaTau 
SET GiaVe = CASE 
    WHEN LoaiGhe = 'VIP' OR LoaiGhe = 'THƯƠNG GIA' THEN 200000
    WHEN LoaiGhe = 'GIƯỜNG NẰM' OR LoaiGhe = 'SLEEPER' THEN 150000
    WHEN LoaiGhe = 'NGOI MỀM' OR LoaiGhe = 'SOFT SEAT' THEN 120000
    WHEN LoaiGhe = 'NGOI CỨNG' OR LoaiGhe = 'HARD SEAT' THEN 80000
    ELSE 100000 -- Giá mặc định
END
WHERE GiaVe IS NULL
GO

-- Kiểm tra kết quả
SELECT MaToa, TenToa, LoaiGhe, GiaVe 
FROM ToaTau 
ORDER BY MaToa
GO

PRINT 'Đã thêm trường GiaVe vào bảng ToaTau thành công!'
