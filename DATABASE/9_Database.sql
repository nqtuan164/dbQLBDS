CREATE DATABASE [dbQLBDS]
GO
USE [dbQLBDS]
GO
/****** Object:  Table [dbo].[loaitaikhoan]    Script Date: 10/30/2013 16:31:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[loaitaikhoan](
	[maloaitaikhoan] [int] IDENTITY(1,1) NOT NULL,
	[tenloaitaikhoan] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[maloaitaikhoan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[loaitaikhoan] ON
INSERT [dbo].[loaitaikhoan] ([maloaitaikhoan], [tenloaitaikhoan]) VALUES (1, N'admin')
INSERT [dbo].[loaitaikhoan] ([maloaitaikhoan], [tenloaitaikhoan]) VALUES (2, N'member')
INSERT [dbo].[loaitaikhoan] ([maloaitaikhoan], [tenloaitaikhoan]) VALUES (3, N'sales')
SET IDENTITY_INSERT [dbo].[loaitaikhoan] OFF
/****** Object:  Table [dbo].[trangthaigiaodich]    Script Date: 10/30/2013 16:31:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trangthaigiaodich](
	[matrangthaigiaodich] [int] IDENTITY(1,1) NOT NULL,
	[tentrangthaigiaodich] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[matrangthaigiaodich] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[trangthaigiaodich] ON
INSERT [dbo].[trangthaigiaodich] ([matrangthaigiaodich], [tentrangthaigiaodich]) VALUES (1, N'Chờ xác nhận')
INSERT [dbo].[trangthaigiaodich] ([matrangthaigiaodich], [tentrangthaigiaodich]) VALUES (2, N'Đang giao dịch')
INSERT [dbo].[trangthaigiaodich] ([matrangthaigiaodich], [tentrangthaigiaodich]) VALUES (3, N'Đã giao dịch')
INSERT [dbo].[trangthaigiaodich] ([matrangthaigiaodich], [tentrangthaigiaodich]) VALUES (4, N'Thanh toán hoàn tất')
INSERT [dbo].[trangthaigiaodich] ([matrangthaigiaodich], [tentrangthaigiaodich]) VALUES (5, N'Giao dịch hủy bỏ')
SET IDENTITY_INSERT [dbo].[trangthaigiaodich] OFF
/****** Object:  Table [dbo].[trangthaicanho]    Script Date: 10/30/2013 16:31:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[trangthaicanho](
	[matrangthaicanho] [int] IDENTITY(1,1) NOT NULL,
	[tentrangthaicanho] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[matrangthaicanho] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[trangthaicanho] ON
INSERT [dbo].[trangthaicanho] ([matrangthaicanho], [tentrangthaicanho]) VALUES (1, N'Đã được thuê')
INSERT [dbo].[trangthaicanho] ([matrangthaicanho], [tentrangthaicanho]) VALUES (2, N'Chưa được thuê')
INSERT [dbo].[trangthaicanho] ([matrangthaicanho], [tentrangthaicanho]) VALUES (3, N'Đang sửa chữa, xây dựng')
SET IDENTITY_INSERT [dbo].[trangthaicanho] OFF
/****** Object:  Table [dbo].[thanhpho]    Script Date: 10/30/2013 16:31:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thanhpho](
	[mathanhpho] [int] IDENTITY(1,1) NOT NULL,
	[tenthanhpho] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[mathanhpho] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[thanhpho] ON
INSERT [dbo].[thanhpho] ([mathanhpho], [tenthanhpho]) VALUES (1, N'Hồ Chí Minh')
SET IDENTITY_INSERT [dbo].[thanhpho] OFF
/****** Object:  Table [dbo].[taikhoan]    Script Date: 10/30/2013 16:31:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[taikhoan](
	[mataikhoan] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](100) NULL,
	[matkhau] [nvarchar](100) NULL,
	[maloaitaikhoan] [int] NULL,
	[ten] [nvarchar](100) NULL,
	[ngaysinh] [datetime] NULL,
	[diachi] [nvarchar](255) NULL,
	[dienthoai] [nvarchar](100) NULL,
	[ngaydangky] [datetime] NULL,
	[trangthai] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mataikhoan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[taikhoan] ON
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (1, N'bocbalui@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 1, N'Bùi Bá Lộc', CAST(0x000081D700000000 AS DateTime), N'276 Hoàng Hoa Thám, Q 10', N'0949621911', CAST(0x00009F3400000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (2, N'nqtuan@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 1, N'Nguyễn Quốc Tuấn', CAST(0x0000823E00000000 AS DateTime), N'112 Vườn Chuối, Q 1', N'01286091882', CAST(0x00009E2600000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (3, N'd2phap@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 1, N'Dương Diệu Pháp', CAST(0x000082A300000000 AS DateTime), N'378 Nguyễn Văn Cừ, Q 5', N'01674710360', CAST(0x00009BE000000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (4, N'n2khanh@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 3, N'Nguyễn Ngọc Khánh', CAST(0x0000828400000000 AS DateTime), N'221 Cống Quỳnh, Q 1', N'0931224678', CAST(0x0000A08600000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (5, N'ntlong@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 2, N'Nguyễn Thanh Long', CAST(0x0000830100000000 AS DateTime), N'95 Phan Văn Trị, Q Bình Thạnh', N'090543112', CAST(0x00009E2A00000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (6, N'lmtrang@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 3, N'Lê Minh Trang', CAST(0x000082D700000000 AS DateTime), N'424 Tôn Đản, Q 4', N'097546113', CAST(0x0000A05B00000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (7, N'ntmphung@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 1, N'Nguyễn Thị Mỹ Phụng', CAST(0x000082E100000000 AS DateTime), N'71 Tôn Đản, Q 4', N'0765443128', CAST(0x0000A1BB00000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (8, N'ccmhoang@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 2, N'Cao Chu Minh Hoàng', CAST(0x000082A900000000 AS DateTime), N'119 Lê Quang Định, Q Bình Thạnh', N'0977654112', CAST(0x0000A00100000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (9, N'tvinh@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 3, N'Trần Vinh', CAST(0x000082A700000000 AS DateTime), N'54 Hoàng Diệu, Q 4', N'0776542889', CAST(0x0000A07800000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (10, N'lvtam@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 2, N'Lê Văn Tâm', CAST(0x0000830200000000 AS DateTime), N'288 Hồ Thị Kỉ, Q 5', N'097887990', CAST(0x0000A08400000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (11, N'dhsanh@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 3, N'Đinh Hoàng Sanh', CAST(0x000081E800000000 AS DateTime), N'88 Hồ Thị Kỉ, Q 5', N'093221678', CAST(0x0000A04300000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (12, N'nhthien@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 1, N'Ngô Hoàng Thiên', CAST(0x000082FA00000000 AS DateTime), N'99 Nguyễn Oanh, Q Gò Vấp', N'094213324', CAST(0x0000A11800000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (13, N'ntluong@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 2, N'Ngụy Thành Lương', CAST(0x0000822000000000 AS DateTime), N'63/36 Phạm Ngũ Lão, Q 1', N'097546334', CAST(0x0000A04A00000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (14, N'tthien@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 3, N'Trần Thiện Hiển', CAST(0x0000832A00000000 AS DateTime), N'297 Điện Biên Phủ, Q Bình Thạnh', N'088654112', CAST(0x0000A10600000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (15, N'tvluc@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 2, N'Trần Văn Lực', CAST(0x000081D700000000 AS DateTime), N'34 Hồ Thị Kỉ, Q 5', N'090776543', CAST(0x0000A1C800000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (16, N'dnhchau@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 3, N'Đặng Nguyễn Hoàng Châu', CAST(0x0000826100000000 AS DateTime), N'261 Kí Con, Q Gò Vấp', N'092789987', CAST(0x0000A1B100000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (17, N'nqphong@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 1, N'Ngô Quốc Phong', CAST(0x00007EC300000000 AS DateTime), N'4 Hoàng Hoa Thám, Q Tân Bình', N'098776543', CAST(0x0000A06600000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (18, N'nbchau@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 2, N'Ngô Bảo Châu', CAST(0x000082B400000000 AS DateTime), N'430 Hoàng Hoa Thám, Q Bình Thạnh', N'093446789', CAST(0x0000A13A00000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (19, N'btmphuoc@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 3, N'Bùi Thị Minh Phước', CAST(0x000079CD00000000 AS DateTime), N'421 Nguyễn Thị Minh Khai, Q 5', N'0934766554', CAST(0x0000A17500000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (20, N'bbthinh@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 2, N'Bùi Bá Thịnh', CAST(0x0000774E00000000 AS DateTime), N'19 Bùi Thị Xuân, Q 1', N'090887665', CAST(0x0000A14900000000 AS DateTime), 1)
INSERT [dbo].[taikhoan] ([mataikhoan], [email], [matkhau], [maloaitaikhoan], [ten], [ngaysinh], [diachi], [dienthoai], [ngaydangky], [trangthai]) VALUES (28, N'nqtuan164@gmail.com', N'81dc9bdb52d04dc20036dbd8313ed055', 1, N'Nguyễn Quốc Tuấn', CAST(0x0000A24A00ED5210 AS DateTime), NULL, NULL, CAST(0x0000A24A00ED5211 AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[taikhoan] OFF
/****** Object:  Table [dbo].[quan]    Script Date: 10/30/2013 16:31:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[quan](
	[maquan] [int] IDENTITY(1,1) NOT NULL,
	[tenquan] [nvarchar](100) NULL,
	[mathanhpho] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maquan] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[quan] ON
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (1, N'Quận 1', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (2, N'Quận 2', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (3, N'Quận 3', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (4, N'Quận 4', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (5, N'Quận 5', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (6, N'Quận 6', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (7, N'Quận 7', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (8, N'Quận 8', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (9, N'Quận 9', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (10, N'Quận 10', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (11, N'Quận 11', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (12, N'Quận 12', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (13, N'Thủ Đức', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (14, N'Tân Phú', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (15, N'Tân Bình', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (16, N'Phú Nhuận', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (17, N'Gò Vấp', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (18, N'Bình Thạnh', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (19, N'Bình Tân', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (20, N'Bình Chánh', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (21, N'Cần Giờ', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (22, N'Củ Chi', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (23, N'Hóc Môn', 1)
INSERT [dbo].[quan] ([maquan], [tenquan], [mathanhpho]) VALUES (24, N'Nhà Bè', 1)
SET IDENTITY_INSERT [dbo].[quan] OFF
/****** Object:  Table [dbo].[duong]    Script Date: 10/30/2013 16:31:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[duong](
	[maduong] [int] IDENTITY(1,1) NOT NULL,
	[tenduong] [nvarchar](100) NULL,
	[maquan] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[maduong] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[duong] ON
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (1, N'Nguyễn Huệ', 1)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (2, N'Lê Lợi', 1)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (3, N'Đồng Khởi', 1)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (4, N'Nguyễn Duy Trinh', 2)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (5, N'An Phú', 2)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (6, N'Lương Định Của', 2)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (7, N'Nguyễn Thị Minh Khai', 3)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (8, N'Nguyễn Đình Chiểu', 3)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (9, N'Phạm Ngọc Thạch', 3)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (10, N'Khánh Hội', 4)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (11, N'Nguyễn Tất Thành', 4)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (12, N'Hoàng Diệu', 4)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (13, N'Nguyễn Chí Thanh', 5)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (14, N'Trần Hưng Đạo', 5)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (15, N'Hùng Vương', 5)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (16, N'Bình Phú', 6)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (17, N'Hậu Giang', 6)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (18, N'Nguyễn Văn Lương', 6)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (19, N'Hoàng Văn Thái', 7)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (20, N'Nguyễn Khắc Viện', 7)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (21, N'Nguyễn Lương Bằng', 7)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (22, N'Tạ Quang Bửu', 8)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (23, N'Phạm Thế Hiển', 8)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (24, N'Dương Bá Trạc', 8)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (25, N'Liên Phường', 9)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (26, N'Đỗ Xuân Hợp', 9)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (27, N'Dương Đình Hội', 9)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (28, N'3 Tháng 2', 10)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (29, N'Lý Thường Kiệt', 10)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (30, N'Thành Thái', 10)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (31, N'Lê Đai Hành', 11)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (32, N'Âu Cơ', 11)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (33, N'Lạc Long Quân', 11)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (34, N'Lê Văn Khương', 12)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (35, N'Nguyễn Văn Quá', 12)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (36, N'Trường Chinh', 12)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (37, N'Ngô chí Quốc', 13)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (38, N'Số 30', 13)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (39, N'Số 6', 13)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (40, N'Trịnh Đình Thảo', 14)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (41, N'Lê Trọng Tấn', 14)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (42, N'Tân Hương', 14)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (43, N'Cộng Hòa', 15)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (44, N'Hoàng Văn Thụ', 15)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (45, N'Cách Mạng Tháng 8', 15)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (46, N'Phan Đình Phùng', 16)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (47, N'Phan Đăng Lưu', 16)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (48, N'Nguyễn Văn Trỗi', 16)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (49, N'Phan Văn Trị', 17)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (50, N'Nguyễn Thái Sơn', 17)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (51, N'Nguyễn Huy Điển', 17)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (52, N'Xô Viết Nghệ Tĩnh', 18)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (53, N'Bạch Đằng', 18)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (54, N'Nơ Trang Long', 18)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (55, N'Hồ Học Lãm', 19)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (56, N'Võ Văn Kiệt', 19)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (57, N'Mã Lò', 19)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (58, N'Nguyễn Văn Linh', 20)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (59, N'Trần Đại Nghĩa', 20)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (60, N'Mai Bá Hương', 20)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (61, N'Trần Quang Đạo', 21)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (62, N'Cần Thạnh', 21)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (63, N'Duyên Hải', 21)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (64, N'Hồ Văn Tắng', 22)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (65, N'Nguyễn Văn Khạ', 22)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (66, N' Liêu Bình Hương', 22)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (67, N'Nguyễn Văn Bứa', 23)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (68, N'Bà Triệu', 23)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (69, N'Lê Thị Hà', 23)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (70, N'Phạm Hữu Lầu', 24)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (71, N'Nguyễn Văn Tạo', 24)
INSERT [dbo].[duong] ([maduong], [tenduong], [maquan]) VALUES (72, N'Nguyễn Hữu Thọ', 24)
SET IDENTITY_INSERT [dbo].[duong] OFF
/****** Object:  Table [dbo].[canho]    Script Date: 10/30/2013 16:31:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[canho](
	[macanho] [int] IDENTITY(1,1) NOT NULL,
	[tencanho] [nvarchar](255) NULL,
	[maduong] [int] NULL,
	[diachi] [nvarchar](100) NULL,
	[mieuta] [nvarchar](4000) NULL,
	[toado] [varchar](40) NULL,
	[giathue] [float] NULL,
	[dientich] [float] NULL,
	[matrangthaicanho] [int] NULL,
	[ngaydang] [datetime] NULL,
	[nguoidang] [int] NULL,
	[ghichu] [text] NULL,
	[kichhoat] [int] NULL,
 CONSTRAINT [PK__canho__1B5CE7F01A14E395] PRIMARY KEY CLUSTERED 
(
	[macanho] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[canho] ON
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (1, N'The HYCO 4 Tower', 1, N'78 Nguyễn Huệ', N'Nằm ngay con đường Hoa Nguyễn Huệ, con đường vàng của TP.HCM, Trung tâm TP.HCM', N'10.728333,106.710055', 1000000, 30, 1, CAST(0x0000A0CA00000000 AS DateTime), 1, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (2, N'The HYCO 4 Tower 2', 2, N'122 Lê Lợi', N'Thuộc khu dân cư ổn định, hệ thống giao thông thuận lợi, gần khu thương mại phần mềm Quang Trung, Metro, công viên Làng Hoa...', N'10.728333,106.710055', 900000, 20, 1, CAST(0x0000A0A500000000 AS DateTime), 4, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (3, N'Prince Residence', 4, N'23F/12 Nguyễn Duy Trinh', N'Nằm trên tuyến đường huyết mạch Nam Kỳ Khởi Nghĩa – Nguyễn Văn Trỗi, là con đường chính đi từ Sân bay quốc tế Tân Sơn Nhất đến trung tâm TP.HCM. Nằm cạnh cầu Công Lý,
The Prince Residence cách trung tâm Quận 1 chỉ 1 km, cách sân bay Tân sơn nhất khoảng 6 phút đi xe, đối diện chợ Phú Nhuận, là tâm điểm dễ dàng đi đến các Quận: Q.5, Q.6, Q.11, Q Tân Bình, Gò Vấp, Bình Thạnh, Q.2…', N'10.728333,106.710055', 2500000, 70, 1, CAST(0x0000A1FB00000000 AS DateTime), 6, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (4, N'Emerald', 5, N'12A/129 An Phú', N'Nằm ngay mặt tiền đường Lê Văn Chí một vị trí đẹp nhất quận Thủ Đức, Emerald Apartment tọa lạc ngay khu vực có vị trí giao thông rất thuận lợi ngay ngã tư Thủ Đức, căn hộ có
đầy đủ tiện nghi, không gian thoáng đãng, là nơi an cư lạc nghiệp xây dựng cuộc sống dài lâu', N'10.728333,106.710055', 3000000, 80, 1, CAST(0x0000A19300000000 AS DateTime), 1, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (5, N'Hoa Sen', 18, N'93 Bis Nguyễn Văn Lương', N'Tọa lạc tại trung tâm quận 11 đối diện Đầm Sen, cách quận 1 chỉ 5 km , là căn hộ cao cấp giá tốt tại Quận 11 hiện nay. Dự án khu Căn hộ Hoa Sen
gồm 01 tòa tháp, cao 18 tầng. Chung cư Hoa Sen được thiết kế theo phong cách Châu Á đương đại với nhiều tiện ích dịch vụ như: sàn thương mại, nhà hàng, cà phê, spa, phòng tập thể dục…', N'10.728333,106.710055', 1500000, 50, 1, CAST(0x0000A1DB00000000 AS DateTime), 4, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (6, N'Gia Phú Khang', 32, N'12 Âu Cơ', N'Một cuộc sống hiện đại, tiện nghi trong một không gian mở thoáng đãng…với đầy đủ các tiện ích ngay bên trong tòa nhà, vị trí đắc địa kết nối thuận tiện…Tất cả đều hội tụ tại Gia Phú Khang', N'10.728333,106.710055', 900000, 90, 1, CAST(0x0000A23800000000 AS DateTime), 6, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (7, N'Hưng Phát', 5, N'23 Nguyễn Thông', N'Khu căn hộ năm trong khu quy hoạch Phước Kiểng – Là một khu đô thị mới hiện đại với nhiều dự án căn hộ cao cấp như: Kenton Residences, Phú Hoàng Anh, Hoàng Anh 3, Hoàng Anh Gold House, khu dân cư Sadeco….', N'10.728333,106.710055', 1100000, 150, 1, CAST(0x0000A23900000000 AS DateTime), 1, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (8, N'Babylon', 6, N'5233 Lương Định Của', N'Thuộc khu dân cư ổn định, hệ thống giao thông thuận lợi, gần khu thương mại phần mềm Quang Trung, Metro', N'10.728333,106.710055', 5000000, 80, 1, CAST(0x0000A23A00000000 AS DateTime), 4, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (9, N'Chánh Hưng', 5, N'21/1 An Phú', N'nằm trong khu quy hoạch có tổng diện tích đất hơn 42.250m2 với mật độ xây dựng toàn khu 25% gồm 4 chung cư cao 29 – 30 tầng và 2 cao ốc thương mại 27 tầng, mỗi cao ốc được bố trí với 4 mặt thông gió, tạo nên một không gian thông thoáng và ánh sáng tự nhiên cho từng căn hộ..', N'10.728333,106.710055', 7500000, 60, 1, CAST(0x0000A23000000000 AS DateTime), 6, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (10, N'Sunview Town', 24, N'382 Dương Bá Trạc', N'Ưu điểm nổi bật của SUNVIEW TOWN là mật độ xây dựng khá thấp với chỉ hơn 26.4%, phần kiến trúc cảnh quan với cây xanh, thảm cỏ và con kênh xanh rộng hơn 20 m uốn lượn quanh dự án đã góp phần tạo nét độc đáo riêng biệt mà không có dự án nào quanh khu vực có được', N'10.728333,106.710055', 8400000, 90, 2, CAST(0x0000A21200000000 AS DateTime), 1, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (11, N'Vũ Trọng Phụng', 43, N'23C Bis Cộng Hòa', N'Nằm ngay mặt tiền đường Lê Văn Chí một vị trí đẹp nhất quận Thủ Đức, Emerald Apartment tọa lạc ngay khu vực có vị trí giao thông rất thuận lợi ngay ngã tư Thủ Đức....', N'10.728333,106.710055', 5000000, 30, 2, CAST(0x0000A04E00000000 AS DateTime), 4, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (12, N'Licogi 13 Tower', 9, N'23 Nguyễn Thông', N'Nằm ngay trung tâm Q1, thuận lợi trong việc mua sắm, kinh doanh, đem lại ước mơ cho bạn...', N'10.728333,106.710055', 4500000, 70, 2, CAST(0x0000A04E00000000 AS DateTime), 6, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (13, N'Chelsea Park', 18, N'92C/12 Nguyễn Văn Lương', N'Nằm trên tuyến đường huyết mạch Nam Kỳ Khởi Nghĩa – Nguyễn Văn Trỗi, là con đường chính đi từ Sân bay quốc tế Tân Sơn Nhất đến trung tâm TP.HCM', N'10.728333,106.710055', 1200000, 50, 2, CAST(0x0000A05000000000 AS DateTime), 16, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (14, N'The Manor', 2, N'23 Nguyễn Thông', N'Tọa lạc tại trung tâm quận 11 đối diện Đầm Sen, cách quận 1 chỉ 5 km , là căn hộ cao cấp giá tốt tại Quận 11 hiện nay', N'10.728333,106.710055', 5400000, 100, 2, CAST(0x0000A05200000000 AS DateTime), 11, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (15, N'New Skyline', 32, N'98/153 Âu Cơ', N'Thuộc khu dân cư ổn định, hệ thống giao thông thuận lợi, gần khu thương mại phần mềm Quang Trung, Metro', N'10.728333,106.710055', 1050000, 80, 2, CAST(0x0000A05500000000 AS DateTime), 9, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (16, N'VP5 Linh Đàm', 36, N'3A Trường Chinh', N'Thuộc khu dân cư ổn định, hệ thống giao thông thuận lợi, gần khu thương mại phần mềm Quang Trung, dân cư ổn định', N'10.728333,106.710055', 4500000, 120, 2, CAST(0x0000A05700000000 AS DateTime), 19, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (17, N'Mulberry Lane', 26, N'847A/12B Đỗ Xuân Hợp', N'Khu căn hộ năm trong khu quy hoạch Phước Kiểng – Là một khu đô thị mới hiện đại với nhiều dự án căn hộ cao cấp như: Kenton Residences, Phú Hoàng Anh, Hoàng Anh 3...', N'10.728333,106.710055', 7600000, 30, 2, CAST(0x0000A05800000000 AS DateTime), 16, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (18, N'Văn Phú', 43, N'2D/13C Cộng Hòa', N'Khu căn hộ năm trong khu quy hoạch Phước Kiểng – Là một khu đô thị mới hiện đại với nhiều dự án căn hộ cao cấp như: Kenton Residences, Phú Hoàng Anh', N'10.728333,106.710055', 9400000, 40, 2, CAST(0x0000A05900000000 AS DateTime), 14, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (19, N'Hapulico Complex', 24, N'128 Dương Bá Trạc', N'Một cuộc sống hiện đại, tiện nghi trong một không gian mở thoáng đãng…với đầy đủ các tiện ích ngay bên trong tòa nhà, vị trí đắc địa kết nối thuận tiện...', N'10.728333,106.710055', 1200000, 190, 2, CAST(0x0000A05D00000000 AS DateTime), 11, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (20, N'Sunrine Building', 18, N'32K Nguyễn Văn Lương', N'Một cuộc sống hiện đại, tiện nghi trong một không gian mở thoáng đãng…với đầy đủ các tiện ích ngay bên trong tòa nhà, vị trí đắc địa kết nối thuận tiện, hãy chọn theo cách của bạn', N'10.728333,106.710055', 8700000, 40, 2, CAST(0x0000A06000000000 AS DateTime), 9, NULL, 1)
INSERT [dbo].[canho] ([macanho], [tencanho], [maduong], [diachi], [mieuta], [toado], [giathue], [dientich], [matrangthaicanho], [ngaydang], [nguoidang], [ghichu], [kichhoat]) VALUES (21, N'I-Home 2', 59, N'23 Trần Đại Nghĩa', N'Thuộc khu dân cư ổn định, hệ thống giao thông thuận lợi, gần khu thương mại phần mềm Quang Trung, Metro, công viên Làng Hoa...', N'10.728333,106.710055', 8500000, 100, 1, CAST(0x0000A2560007A9F5 AS DateTime), 28, NULL, 1)
SET IDENTITY_INSERT [dbo].[canho] OFF
/****** Object:  Table [dbo].[hinhanhcanho]    Script Date: 10/30/2013 16:31:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hinhanhcanho](
	[mahinhanh] [int] IDENTITY(1,1) NOT NULL,
	[macanho] [int] NULL,
	[lienket] [nvarchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[mahinhanh] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[thuecanho]    Script Date: 10/30/2013 16:31:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[thuecanho](
	[mathuecanho] [int] IDENTITY(1,1) NOT NULL,
	[mataikhoan] [int] NULL,
	[macanho] [int] NULL,
	[tiencoc] [float] NULL,
	[thoigianthue] [datetime] NULL,
	[thoigianketthuc] [datetime] NULL,
	[thoigiangiaodich] [datetime] NULL,
	[dienthoai] [nvarchar](100) NULL,
	[diachi] [nvarchar](100) NULL,
	[ghichu] [text] NULL,
	[kichhoat] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[mathuecanho] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[thuecanho] ON
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (1, 3, 1, 20000000, CAST(0x0000A23F00000000 AS DateTime), CAST(0x0000A2D800000000 AS DateTime), CAST(0x0000A23D00000000 AS DateTime), N'0949621911', N'276 Hoàng Hoa Thám, Q Bình Thạnh', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (2, 5, 2, 25000000, CAST(0x0000A24A00000000 AS DateTime), CAST(0x0000A2E200000000 AS DateTime), CAST(0x0000A24700000000 AS DateTime), N'01695222486', N'221 Cống Quỳnh, Q 1', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (3, 3, 3, 30000000, CAST(0x0000A2E100000000 AS DateTime), CAST(0x0000A37A00000000 AS DateTime), CAST(0x0000A2DF00000000 AS DateTime), N'0949621911', N'276 Hoàng Hoa Thám, Q Bình Thạnh', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (4, 5, 4, 28000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222567', N'221 Cống Quỳnh, Q 1', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (5, 8, 5, 38000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222568', N'99 Nguyễn Oanh, Q Gò Vấp', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (6, 10, 6, 18000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222569', N'19 Bùi Thị Xuân, Q 1', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (7, 13, 7, 19000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222570', N'288 Hồ Thị Kỉ, Q 5', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (8, 15, 8, 22000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222571', N'63/36 Phạm Ngũ Lão, Q 1', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (9, 18, 9, 24000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222572', N'119 Lê Quang Định, Q Bình Thạnh', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (10, 20, 10, 26000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222573', N'112 Vườn Chuối, Q 1', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (11, 8, 20, 27000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222574', N'321 Cống Quỳnh, Q 1', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (12, 10, 19, 29000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222575', N'189 Cống Quỳnh, Q 1', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (13, 13, 18, 31000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222576', N'339 Cống Quỳnh, Q 1', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (14, 15, 17, 32000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222577', N'4 Hoàng Hoa Thám, Q Tân Bình', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (15, 18, 16, 33000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222578', N'12 Phan Văn Trị, Q Gò Vấp', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (16, 20, 15, 34000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222579', N'261 Kí Con, Q Gò Vấp', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (17, 8, 14, 35000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222580', N'297 Điện Biên Phủ, Q Bình Thạnh', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (18, 10, 13, 36000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222481', N'63/36 Phạm Ngũ Lão, Q 1', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (19, 13, 12, 31000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222482', N'99 Nguyễn Oanh, Q Gò Vấp', NULL, 1)
INSERT [dbo].[thuecanho] ([mathuecanho], [mataikhoan], [macanho], [tiencoc], [thoigianthue], [thoigianketthuc], [thoigiangiaodich], [dienthoai], [diachi], [ghichu], [kichhoat]) VALUES (20, 15, 11, 32000000, CAST(0x0000A30000000000 AS DateTime), CAST(0x0000A39900000000 AS DateTime), CAST(0x0000A2F900000000 AS DateTime), N'01695222483', N'88 Hồ Thị Kỉ, Q 5', NULL, 1)
SET IDENTITY_INSERT [dbo].[thuecanho] OFF
/****** Object:  Table [dbo].[nhangiaodich]    Script Date: 10/30/2013 16:31:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhangiaodich](
	[magiaodich] [int] IDENTITY(1,1) NOT NULL,
	[mataikhoan] [int] NULL,
	[mathuecanho] [int] NULL,
	[matrangthaigiaodich] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[magiaodich] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[nhangiaodich] ON
INSERT [dbo].[nhangiaodich] ([magiaodich], [mataikhoan], [mathuecanho], [matrangthaigiaodich]) VALUES (53, 6, 1, 3)
INSERT [dbo].[nhangiaodich] ([magiaodich], [mataikhoan], [mathuecanho], [matrangthaigiaodich]) VALUES (54, 11, 2, 2)
INSERT [dbo].[nhangiaodich] ([magiaodich], [mataikhoan], [mathuecanho], [matrangthaigiaodich]) VALUES (55, 14, 3, 4)
INSERT [dbo].[nhangiaodich] ([magiaodich], [mataikhoan], [mathuecanho], [matrangthaigiaodich]) VALUES (56, 19, 4, 5)
INSERT [dbo].[nhangiaodich] ([magiaodich], [mataikhoan], [mathuecanho], [matrangthaigiaodich]) VALUES (57, 6, 5, 2)
INSERT [dbo].[nhangiaodich] ([magiaodich], [mataikhoan], [mathuecanho], [matrangthaigiaodich]) VALUES (58, 28, 6, 3)
INSERT [dbo].[nhangiaodich] ([magiaodich], [mataikhoan], [mathuecanho], [matrangthaigiaodich]) VALUES (59, 28, 7, 3)
INSERT [dbo].[nhangiaodich] ([magiaodich], [mataikhoan], [mathuecanho], [matrangthaigiaodich]) VALUES (60, 3, 8, 3)
INSERT [dbo].[nhangiaodich] ([magiaodich], [mataikhoan], [mathuecanho], [matrangthaigiaodich]) VALUES (61, 3, 9, 3)
SET IDENTITY_INSERT [dbo].[nhangiaodich] OFF
/****** Object:  Default [DF__canho__kichhoat__1ED998B2]    Script Date: 10/30/2013 16:31:39 ******/
ALTER TABLE [dbo].[canho] ADD  CONSTRAINT [DF__canho__kichhoat__1ED998B2]  DEFAULT ((1)) FOR [kichhoat]
GO
/****** Object:  Default [DF__taikhoan__trangt__060DEAE8]    Script Date: 10/30/2013 16:31:39 ******/
ALTER TABLE [dbo].[taikhoan] ADD  DEFAULT ((1)) FOR [trangthai]
GO
/****** Object:  Default [DF__thuecanho__kichh__2A4B4B5E]    Script Date: 10/30/2013 16:31:39 ******/
ALTER TABLE [dbo].[thuecanho] ADD  DEFAULT ((1)) FOR [kichhoat]
GO
/****** Object:  ForeignKey [FK__canho__diachi__1BFD2C07]    Script Date: 10/30/2013 16:31:39 ******/
ALTER TABLE [dbo].[canho]  WITH CHECK ADD  CONSTRAINT [FK__canho__diachi__1BFD2C07] FOREIGN KEY([maduong])
REFERENCES [dbo].[duong] ([maduong])
GO
ALTER TABLE [dbo].[canho] CHECK CONSTRAINT [FK__canho__diachi__1BFD2C07]
GO
/****** Object:  ForeignKey [FK__canho__matrangth__1CF15040]    Script Date: 10/30/2013 16:31:39 ******/
ALTER TABLE [dbo].[canho]  WITH CHECK ADD  CONSTRAINT [FK__canho__matrangth__1CF15040] FOREIGN KEY([matrangthaicanho])
REFERENCES [dbo].[trangthaicanho] ([matrangthaicanho])
GO
ALTER TABLE [dbo].[canho] CHECK CONSTRAINT [FK__canho__matrangth__1CF15040]
GO
/****** Object:  ForeignKey [FK__canho__nguoidang__1DE57479]    Script Date: 10/30/2013 16:31:39 ******/
ALTER TABLE [dbo].[canho]  WITH CHECK ADD  CONSTRAINT [FK__canho__nguoidang__1DE57479] FOREIGN KEY([nguoidang])
REFERENCES [dbo].[taikhoan] ([mataikhoan])
GO
ALTER TABLE [dbo].[canho] CHECK CONSTRAINT [FK__canho__nguoidang__1DE57479]
GO
/****** Object:  ForeignKey [FK__duong__maquan__1367E606]    Script Date: 10/30/2013 16:31:39 ******/
ALTER TABLE [dbo].[duong]  WITH CHECK ADD FOREIGN KEY([maquan])
REFERENCES [dbo].[quan] ([maquan])
GO
/****** Object:  ForeignKey [FK__hinhanhca__macan__239E4DCF]    Script Date: 10/30/2013 16:31:39 ******/
ALTER TABLE [dbo].[hinhanhcanho]  WITH CHECK ADD  CONSTRAINT [FK__hinhanhca__macan__239E4DCF] FOREIGN KEY([macanho])
REFERENCES [dbo].[canho] ([macanho])
GO
ALTER TABLE [dbo].[hinhanhcanho] CHECK CONSTRAINT [FK__hinhanhca__macan__239E4DCF]
GO
/****** Object:  ForeignKey [FK__nhangiaod__matai__32E0915F]    Script Date: 10/30/2013 16:31:39 ******/
ALTER TABLE [dbo].[nhangiaodich]  WITH CHECK ADD FOREIGN KEY([mataikhoan])
REFERENCES [dbo].[taikhoan] ([mataikhoan])
GO
/****** Object:  ForeignKey [FK__nhangiaod__mathu__33D4B598]    Script Date: 10/30/2013 16:31:39 ******/
ALTER TABLE [dbo].[nhangiaodich]  WITH CHECK ADD FOREIGN KEY([mathuecanho])
REFERENCES [dbo].[thuecanho] ([mathuecanho])
GO
/****** Object:  ForeignKey [FK__nhangiaod__matra__34C8D9D1]    Script Date: 10/30/2013 16:31:39 ******/
ALTER TABLE [dbo].[nhangiaodich]  WITH CHECK ADD FOREIGN KEY([matrangthaigiaodich])
REFERENCES [dbo].[trangthaigiaodich] ([matrangthaigiaodich])
GO
/****** Object:  ForeignKey [FK__quan__mathanhpho__0EA330E9]    Script Date: 10/30/2013 16:31:39 ******/
ALTER TABLE [dbo].[quan]  WITH CHECK ADD FOREIGN KEY([mathanhpho])
REFERENCES [dbo].[thanhpho] ([mathanhpho])
GO
/****** Object:  ForeignKey [FK__taikhoan__maloai__0519C6AF]    Script Date: 10/30/2013 16:31:39 ******/
ALTER TABLE [dbo].[taikhoan]  WITH CHECK ADD FOREIGN KEY([maloaitaikhoan])
REFERENCES [dbo].[loaitaikhoan] ([maloaitaikhoan])
GO
/****** Object:  ForeignKey [FK__thuecanho__macan__29572725]    Script Date: 10/30/2013 16:31:39 ******/
ALTER TABLE [dbo].[thuecanho]  WITH CHECK ADD  CONSTRAINT [FK__thuecanho__macan__29572725] FOREIGN KEY([macanho])
REFERENCES [dbo].[canho] ([macanho])
GO
ALTER TABLE [dbo].[thuecanho] CHECK CONSTRAINT [FK__thuecanho__macan__29572725]
GO
/****** Object:  ForeignKey [FK__thuecanho__matai__286302EC]    Script Date: 10/30/2013 16:31:39 ******/
ALTER TABLE [dbo].[thuecanho]  WITH CHECK ADD FOREIGN KEY([mataikhoan])
REFERENCES [dbo].[taikhoan] ([mataikhoan])
GO
