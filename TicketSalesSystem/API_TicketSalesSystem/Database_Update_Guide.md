# Hướng dẫn cập nhật Database

## Vấn đề hiện tại

Lỗi `"The specified type member 'GiaVe' is not supported in LINQ to Entities"` xảy ra vì:

1. Chúng ta đã thêm trường `GiaVe` vào model class `ToaTau`
2. Nhưng chưa cập nhật database schema
3. Entity Framework không thể translate `tt.GiaVe` thành SQL

## Giải pháp tạm thời

Hiện tại code đã được sửa để sử dụng giá mặc định `100000` VND cho tất cả vé.

## Giải pháp vĩnh viễn

### Bước 1: Chạy script SQL

Mở SQL Server Management Studio và chạy file `UpdateDatabase.sql`:

```sql
-- Thêm trường GiaVe vào bảng ToaTau
ALTER TABLE ToaTau 
ADD GiaVe DECIMAL(12,2) NULL

-- Cập nhật giá vé mặc định
UPDATE ToaTau 
SET GiaVe = CASE 
    WHEN LoaiGhe = 'VIP' OR LoaiGhe = 'THƯƠNG GIA' THEN 200000
    WHEN LoaiGhe = 'GIƯỜNG NẰM' OR LoaiGhe = 'SLEEPER' THEN 150000
    WHEN LoaiGhe = 'NGOI MỀM' OR LoaiGhe = 'SOFT SEAT' THEN 120000
    WHEN LoaiGhe = 'NGOI CỨNG' OR LoaiGhe = 'HARD SEAT' THEN 80000
    ELSE 100000
END
WHERE GiaVe IS NULL
```

### Bước 2: Cập nhật Entity Framework Model

Sau khi chạy SQL script, cần cập nhật Entity Framework model:

1. Mở file `TicketSalesModel.edmx` trong Visual Studio
2. Right-click → "Update Model from Database"
3. Chọn bảng `ToaTau` và thêm trường `GiaVe`
4. Save và rebuild project

### Bước 3: Cập nhật code

Sau khi cập nhật model, có thể sửa lại code để sử dụng `tt.GiaVe`:

```csharp
// Trong DAL_Ghe.cs
GiaVe = tt.GiaVe ?? 100000

// Trong DAL_TinhGiaVe.cs  
return query.FirstOrDefault() ?? 100000;
```

## Kiểm tra

Sau khi cập nhật database:

1. Chạy lại ứng dụng
2. Thử chọn toa tàu trong đặt vé
3. Kiểm tra API tính giá vé: `GET /api/giave/tinh?maChuyen=1&maGhe=5`

## Lưu ý

- Backup database trước khi chạy script
- Test trên môi trường development trước
- Đảm bảo tất cả developers cập nhật model sau khi chạy script
