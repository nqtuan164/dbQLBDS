CREATE PROC sp_dangNhapTaiKhoan
	@email nvarchar(100), @matkhau nvarchar(100)
AS
BEGIN
	IF(NOT EXISTS(SELECT * FROM taikhoan WHERE email = @email AND matkhau = @matkhau))
	BEGIN
		RAISERROR('Đăng nhập không thành công', 16, 1)
	END
END
GO
--exec sp_dangNhapTaiKhoan 'd2phap@gmail.com', phapabcdf

CREATE PROC sp_dangKyTaiKhoan
	@email nvarchar(100), @matkhau nvarchar(100), @maloaitaikhoan int, 
	@ten nvarchar(100), @ngaysinh datetime, @diachi nvarchar(255),	
	@dienthoai nvarchar(100), @ngaydangky datetime, @trangthai int
AS
BEGIN
	IF(EXISTS(SELECT email FROM taikhoan WHERE email = @email)) BEGIN
		RAISERROR('Email đã tồn tại',16,1)
	END
	ELSE BEGIN
		INSERT INTO taikhoan(email, matkhau, maloaitaikhoan, ten, ngaysinh, diachi, dienthoai, ngaydangky, trangthai)
		VALUES(@email, @matkhau, @maloaitaikhoan, @ten, @ngaysinh, @diachi, @dienthoai, @ngaydangky, @trangthai)
	END
END
GO

CREATE PROC sp_capNhatTaiKhoan
	@email nvarchar(100), @matkhau nvarchar(100), @maloaitaikhoan int, 
	@ten nvarchar(100), @ngaysinh datetime, @diachi nvarchar(255), 
	@dienthoai nvarchar(100), @ngaydangky datetime
AS
BEGIN
	UPDATE taikhoan 
	SET matkhau = @matkhau, maloaitaikhoan = @maloaitaikhoan, ten = @ten,
		ngaysinh = @ngaysinh, diachi = @diachi, dienthoai = @dienthoai,
		ngaydangky = @ngaydangky
	WHERE email = @email
END
GO

CREATE PROC sp_capNhatTrangThaiTaiKhoan
	@email nvarchar(100), @trangthai int
AS
BEGIN
	IF(NOT EXISTS(SELECT * FROM taikhoan WHERE email = @email))
	BEGIN
		RAISERROR('Email không tồn tại',16,1)
	END
	
	UPDATE taikhoan 
	SET trangthai = @trangthai 
	WHERE email = @email
END
GO

--exec sp_capNhatTrangThaiTaiKhoan 'd2phap@gmail.comxxx', 0