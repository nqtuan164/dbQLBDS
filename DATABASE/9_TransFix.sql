﻿--UNREPEATABLE READ
CREATE PROCEDURE [dbo].[sp_DangNhapTaiKhoan_Fixed]
	@email nvarchar(100), @matkhau nvarchar(100)
AS
BEGIN TRAN
	set tran isolation level repeatable read
	
	IF(NOT EXISTS (SELECT * FROM taikhoan WHERE email = @email AND matkhau = @matkhau AND trangthai = 1)) BEGIN
		RAISERROR (N'Đăng nhập không thành công', 10, 1)
		ROLLBACK TRAN
		RETURN
	END
	ELSE BEGIN
		WAITFOR DELAY '00:00:05'
		SELECT * FROM taikhoan WHERE email = @email AND matkhau = @matkhau AND trangthai = 1
	END
COMMIT TRAN
GO
--------------------------------------

--LOST UPDATE
CREATE PROCEDURE [dbo].[sp_NhanGiaoDich_Fixed]
	@mataikhoan INT,
	@mathuecanho INT
AS
BEGIN TRAN
	set tran isolation level Serializable
	SET DEADLOCK_PRIORITY LOW
	
	DECLARE @macanho INT
	SELECT @macanho = ch.macanho 
	FROM canho ch, thuecanho t
	WHERE 
		ch.macanho = t.macanho AND
		t.mathuecanho = @mathuecanho AND 
		ch.matrangthaicanho = 2 AND 
		ch.kichhoat = 1
	
	--TODO: KIỂM TRA SỰ TỒN TẠI CỦA CĂN HỘ VỚI ĐIỀU KIỆN ĐÃ ĐƯỢC THUÊ HAY CHƯA.
	IF @macanho IS NULL
	BEGIN
		RAISERROR (N'Căn hộ đã được sử dụng hoặc không tồn tại', 10, 1)
		ROLLBACK TRAN
		RETURN
	END
	
	--TODO: KIỂM TRA SỰ TỒN TẠI CỦA THUÊ CĂN HỘ
	IF EXISTS (SELECT * 
			   FROM nhangiaodich
			   WHERE 
				mathuecanho = @mathuecanho)
	BEGIN
		RAISERROR (N'Giao dịch đã được nhận xử lý', 10, 1)
		ROLLBACK TRAN
		RETURN
	END
	
	WAITFOR DELAY '00:00:10'

	--TODO: TẠO GIAO DỊCH CĂN HỘ
	INSERT INTO nhangiaodich 
	(mataikhoan, mathuecanho, matrangthaigiaodich) VALUES
	(@mataikhoan, @mathuecanho, 1)
	
	
	--TODO: CẬP NHẬT TRẠNG THÁI CĂN HỘ
	UPDATE canho 
	SET matrangthaicanho = 1
	WHERE macanho = @macanho
	
COMMIT TRAN
GO
--delete nhangiaodich where mataikhoan = 3
--update canho set matrangthaicanho = 2 where macanho = 9
----------------------------------------------

--LOST UPDATE
CREATE PROCEDURE [dbo].[sp_ChinhSuaCanHo_Fixed]
	@macanho INT,
	@tencanho NVARCHAR(255),
	@maduong INT,
	@diachi NVARCHAR(100),
	@mieuta NVARCHAR(4000),
	@toado NVARCHAR(30),
	@giathue FLOAT,
	@dientich FLOAT,
	@matrangthaicanho INT
AS
BEGIN TRAN
	set tran isolation level Serializable
	SET DEADLOCK_PRIORITY HIGH
	
	IF NOT EXISTS (SELECT * FROM canho WHERE macanho = @macanho)
	BEGIN
		RAISERROR (N'Không tìm thấy căn hộ cần chỉnh sửa', 10, 1)
		ROLLBACK TRAN
		RETURN
	END
	WAITFOR DELAY '00:00:05'
	
	UPDATE canho 
	SET
		tencanho = @tencanho,
		maduong = @maduong,
		diachi = @diachi,
		mieuta = @mieuta,
		toado = @toado,
		giathue = @giathue,
		dientich = @dientich,
		matrangthaicanho = @matrangthaicanho
	WHERE macanho = @macanho
	
COMMIT TRAN
GO
----------------------------------------------

--DIRTY READ
CREATE PROCEDURE dbo.sp_XemCanHo_Fixed
	@macanho INT
AS
BEGIN TRAN
	SET TRANSACTION ISOLATION LEVEL READ COMMITTED
	SELECT ch.*, d.tenduong, q.tenquan, tp.tenthanhpho
    FROM canho ch, duong d, quan q, thanhpho tp
    WHERE ch.kichhoat = 1 AND
        ch.matrangthaicanho = 2 AND
        ch.maduong = d.maduong AND
        d.maquan = q.maquan AND
        q.mathanhpho = tp.mathanhpho AND
        ch.macanho = @macanho
    ORDER BY ch.ngaydang DESC

COMMIT TRAN
GO