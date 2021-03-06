
CREATE PROC sp_nhangiaodich
	@mataikhoan int, @mathuecanho int, @matrangthaigiaodich int
AS
BEGIN
	INSERT INTO nhangiaodich(mataikhoan, mathuecanho, matrangthaigiaodich)
	VALUES(@mataikhoan, @mathuecanho, @matrangthaigiaodich);
END
GO


CREATE PROC sp_suagiaodich
	@magiaodich int, @mataikhoan int, @mathuecanho int, @matrangthaigiaodich int
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM nhangiaodich WHERE magiaodich = @magiaodich) BEGIN
		RAISERROR(N'Mã giao dịch không tồn tại', 16, 9)
	END
	ELSE BEGIN
		UPDATE nhangiaodich
		SET mataikhoan = @mataikhoan,
			mathuecanho = @mathuecanho,
			matrangthaigiaodich = @matrangthaigiaodich
		WHERE magiaodich = @magiaodich
	END
END
GO


CREATE PROC sp_xoagiaodich
	@magiaodich int
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM nhangiaodich WHERE magiaodich = @magiaodich) BEGIN
		RAISERROR(N'Mã giao dịch không tồn tại', 16, 9)
	END
	ELSE BEGIN
		DELETE FROM nhangiaodich WHERE magiaodich = @magiaodich
	END
END
GO


CREATE PROC sp_capnhattrangthaigiaodich
	@magiaodich int, @matrangthaigiaodich int
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM nhangiaodich WHERE magiaodich = @magiaodich) BEGIN
		RAISERROR(N'Mã giao dịch không tồn tại', 16, 9)
	END
	ELSE BEGIN
		UPDATE nhangiaodich
		SET matrangthaigiaodich = @matrangthaigiaodich
		WHERE magiaodich = @magiaodich
	END
END
GO

