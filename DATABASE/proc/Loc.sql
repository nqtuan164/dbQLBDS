/*
*		STORED PROCEDURES
*		Bùi Bá Lộc - 1241363
*/

--
CREATE PROC sp_thuecanho
	@mataikhoan int, @macanho int, @tiencoc float, @thoigianthue datetime, @thoigiankethuc datetime,
	@thoigiangiaodich datetime, @dienthoai nvarchar(100), @diachi nvarchar(100), @ghichu text
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM canho WHERE macanho = @macanho)
		BEGIN
			RAISERROR(N'Mã căn hộ không tồn tại', 16, 9)
		END
	ELSE
		BEGIN
			INSERT INTO thuecanho(mataikhoan, macanho, tiencoc, thoigianthue, thoigianketthuc,
								thoigiangiaodich, dienthoai, diachi, ghichu, kichhoat)
			VALUES(@mataikhoan, @macanho, @tiencoc, @thoigianthue, @thoigiankethuc, 
				@thoigiangiaodich, @dienthoai, @diachi, @ghichu, 1)
		END
END
GO
--

CREATE PROC sp_xoathuecanho
	@mathuecanho int
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM thuecanho WHERE mathuecanho = @mathuecanho)
		BEGIN
			RAISERROR(N'Mã thuê căn hộ không tồn tại', 16, 9)
		END
	ELSE
		BEGIN
			DELETE FROM nhangiaodich WHERE mathuecanho = @mathuecanho
			DELETE FROM thuecanho WHERE mathuecanho = @mathuecanho
		END	
END
GO
--

CREATE PROC sp_suathuecanho
	@mathuecanho int, @mataikhoan int, @macanho int, @tiencoc float, @thoigianthue datetime, 
	@thoigiankethuc datetime, @thoigiangiaodich datetime, @dienthoai nvarchar(100), 
	@diachi nvarchar(100), @ghichu text, @kichhoat int
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM thuecanho WHERE mathuecanho = @mathuecanho)
		BEGIN
			RAISERROR(N'Mã thuê căn hộ không tồn tại', 16, 9)
		END
	ELSE
		BEGIN
			UPDATE thuecanho
			SET  mataikhoan = @mataikhoan, macanho = @macanho, tiencoc = @tiencoc, thoigianthue = @thoigianthue,
				thoigianketthuc = @thoigiankethuc, thoigiangiaodich = @thoigiangiaodich, dienthoai = @dienthoai, diachi = @diachi,
				ghichu = @ghichu, kichhoat = @kichhoat
			WHERE mathuecanho = @mathuecanho
		END	
END
GO
--

CREATE PROC sp_xemcanho
	@macanho int
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM canho WHERE macanho = @macanho)
		BEGIN
			RAISERROR(N'Mã thuê căn hộ không tồn tại', 16, 9)
		END
	ELSE
		BEGIN
			SELECT * FROM canho WHERE macanho = @macanho
		END	
END
GO

CREATE PROC sp_DanhSachTaiKhoan
@page INT,
@pagesize INT,
@count INT OUTPUT
AS
BEGIN
	SELECT @count = COUNT(*)
	FROM taikhoan
	
	DECLARE @start INT
	SET @start = @pagesize * (@page - 1)
	
	SELECT TOP(@pagesize)*
	FROM(
		SELECT  *, ROW_NUMBER() OVER(ORDER BY mataikhoan) AS NUM
		FROM taikhoan
		)AS A
	WHERE NUM > @start
	
	RETURN @count
END