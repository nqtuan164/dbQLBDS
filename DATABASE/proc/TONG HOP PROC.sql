-----------------CAN HO-----------------
CREATE PROCEDURE [dbo].[sp_DanhSachCanHo]
	@page INT,
	@pagesize INT,
	@count INT OUTPUT
AS
BEGIN
	SELECT @count = COUNT(*)
	FROM canho

	DECLARE @start INT
	SET @start = @pagesize * (@page - 1)

	SELECT TOP(@pagesize) * 
	FROM 
	(
		SELECT * , ROW_NUMBER() OVER (ORDER BY macanho) as num
		FROM canho
	) AS a
	WHERE num > @start

	RETURN @count
END
GO

CREATE PROCEDURE [dbo].[sp_ChinhSuaCanHo]
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
BEGIN
	/* SET NOCOUNT ON */
	IF NOT EXISTS (SELECT * FROM canho WHERE macanho = @macanho)
	BEGIN
		RAISERROR (N'Không tìm thấy căn hộ cần chỉnh sửa', 10, 1)
	END


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

	RETURN
END
GO

CREATE PROCEDURE dbo.sp_TaoCanHo
	@tencanho NVARCHAR(255),
	@maduong INT,
	@diachi NVARCHAR(100),
	@mieuta NVARCHAR(4000),
	@toado NVARCHAR(30),
	@giathue FLOAT,
	@dientich FLOAT,
	@matrangthaicanho INT,
	@ngaydang DATETIME,
	@nguoidang INT
AS
BEGIN
	/* SET NOCOUNT ON */
	INSERT INTO canho (
		tencanho, 
		maduong, 
		diachi, 
		mieuta, 
		toado, 
		giathue, 
		dientich,
		matrangthaicanho,
		ngaydang,
		nguoidang,
		kichhoat)
	VALUES (
		@tencanho, 
		@maduong,
		@diachi,
		@mieuta,
		@toado,
		@giathue,
		@dientich,
		@matrangthaicanho,
		@ngaydang,
		@nguoidang,
		1
		)		   
	RETURN
END
-----------------TAI KHOAN-----------------
CREATE PROCEDURE [dbo].[sp_DangNhapTaiKhoan]
	@email nvarchar(100), @matkhau nvarchar(100)
AS
BEGIN
	IF(NOT EXISTS (SELECT * FROM taikhoan WHERE email = @email AND matkhau = @matkhau AND trangthai = 1)) 
	BEGIN
		RAISERROR (N'Đăng nhập không thành công', 10, 1)
	END
	ELSE 
	BEGIN
		SELECT * FROM taikhoan WHERE email = @email AND matkhau = @matkhau
	END
END
GO
--
CREATE PROCEDURE [dbo].[sp_DangKyTaiKhoan]
	@email nvarchar(100), 
	@matkhau nvarchar(100), 
	@maloaitaikhoan int, 
	@ten nvarchar(100), 
	@ngaysinh datetime, 
	@diachi nvarchar(255),	
	@dienthoai nvarchar(100), 
	@ngaydangky datetime, 
	@trangthai int
AS
BEGIN
	IF(EXISTS(SELECT email FROM taikhoan WHERE email = @email)) BEGIN
		RAISERROR(N'Email đã tồn tại', 10, 1)
	END
	ELSE BEGIN
		INSERT INTO taikhoan(email, matkhau, maloaitaikhoan, ten, ngaysinh, diachi, dienthoai, ngaydangky, trangthai)
		VALUES(@email, @matkhau, @maloaitaikhoan, @ten, @ngaysinh, @diachi, @dienthoai, @ngaydangky, @trangthai)
	END
END
GO
--
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
		SELECT  *, ROW_NUMBER() OVER(ORDER BY mataikhoan) AS num
		FROM taikhoan
		)AS a
	WHERE num > @start
	
	RETURN @count
END
GO


-----------------THUE CAN HO-----------------
CREATE PROCEDURE [dbo].[sp_DanhSachThueCanHo]
	@page INT,
	@pagesize INT,
	@count INT OUTPUT
AS
BEGIN
	SELECT @count = COUNT(*)
	FROM canho

	DECLARE @start INT
	SET @start = @pagesize * (@page - 1)

	SELECT TOP(@pagesize) * 
	FROM 
	(
		SELECT * , ROW_NUMBER() OVER (ORDER BY mathuecanho ASC, thoigiangiaodich DESC) as num
		FROM thuecanho
		WHERE kichhoat = 1
	) AS a
	WHERE num > @start

	RETURN @count
END

