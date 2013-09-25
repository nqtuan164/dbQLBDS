USE [dbQLBDS]
GO
/****** Object:  Table [dbo].[loaitaikhoan]    Script Date: 09/26/2013 01:24:40 ******/
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
/****** Object:  Table [dbo].[trangthaigiaodich]    Script Date: 09/26/2013 01:24:40 ******/
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
/****** Object:  Table [dbo].[trangthaicanho]    Script Date: 09/26/2013 01:24:40 ******/
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
/****** Object:  Table [dbo].[thanhpho]    Script Date: 09/26/2013 01:24:40 ******/
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
/****** Object:  Table [dbo].[taikhoan]    Script Date: 09/26/2013 01:24:40 ******/
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
/****** Object:  Table [dbo].[quan]    Script Date: 09/26/2013 01:24:40 ******/
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
/****** Object:  Table [dbo].[duong]    Script Date: 09/26/2013 01:24:40 ******/
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
/****** Object:  Table [dbo].[canho]    Script Date: 09/26/2013 01:24:40 ******/
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
	[mieuta] [text] NULL,
	[toado] [varchar](30) NULL,
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
/****** Object:  Table [dbo].[hinhanhcanho]    Script Date: 09/26/2013 01:24:40 ******/
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
/****** Object:  Table [dbo].[thuecanho]    Script Date: 09/26/2013 01:24:40 ******/
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
/****** Object:  Table [dbo].[nhangiaodich]    Script Date: 09/26/2013 01:24:40 ******/
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
/****** Object:  Default [DF__canho__kichhoat__1ED998B2]    Script Date: 09/26/2013 01:24:40 ******/
ALTER TABLE [dbo].[canho] ADD  CONSTRAINT [DF__canho__kichhoat__1ED998B2]  DEFAULT ((1)) FOR [kichhoat]
GO
/****** Object:  Default [DF__taikhoan__trangt__060DEAE8]    Script Date: 09/26/2013 01:24:40 ******/
ALTER TABLE [dbo].[taikhoan] ADD  DEFAULT ((1)) FOR [trangthai]
GO
/****** Object:  Default [DF__thuecanho__kichh__2A4B4B5E]    Script Date: 09/26/2013 01:24:40 ******/
ALTER TABLE [dbo].[thuecanho] ADD  DEFAULT ((1)) FOR [kichhoat]
GO
/****** Object:  ForeignKey [FK__canho__diachi__1BFD2C07]    Script Date: 09/26/2013 01:24:40 ******/
ALTER TABLE [dbo].[canho]  WITH CHECK ADD  CONSTRAINT [FK__canho__diachi__1BFD2C07] FOREIGN KEY([maduong])
REFERENCES [dbo].[duong] ([maduong])
GO
ALTER TABLE [dbo].[canho] CHECK CONSTRAINT [FK__canho__diachi__1BFD2C07]
GO
/****** Object:  ForeignKey [FK__canho__matrangth__1CF15040]    Script Date: 09/26/2013 01:24:40 ******/
ALTER TABLE [dbo].[canho]  WITH CHECK ADD  CONSTRAINT [FK__canho__matrangth__1CF15040] FOREIGN KEY([matrangthaicanho])
REFERENCES [dbo].[trangthaicanho] ([matrangthaicanho])
GO
ALTER TABLE [dbo].[canho] CHECK CONSTRAINT [FK__canho__matrangth__1CF15040]
GO
/****** Object:  ForeignKey [FK__canho__nguoidang__1DE57479]    Script Date: 09/26/2013 01:24:40 ******/
ALTER TABLE [dbo].[canho]  WITH CHECK ADD  CONSTRAINT [FK__canho__nguoidang__1DE57479] FOREIGN KEY([nguoidang])
REFERENCES [dbo].[taikhoan] ([mataikhoan])
GO
ALTER TABLE [dbo].[canho] CHECK CONSTRAINT [FK__canho__nguoidang__1DE57479]
GO
/****** Object:  ForeignKey [FK__duong__maquan__1367E606]    Script Date: 09/26/2013 01:24:40 ******/
ALTER TABLE [dbo].[duong]  WITH CHECK ADD FOREIGN KEY([maquan])
REFERENCES [dbo].[quan] ([maquan])
GO
/****** Object:  ForeignKey [FK__hinhanhca__macan__239E4DCF]    Script Date: 09/26/2013 01:24:40 ******/
ALTER TABLE [dbo].[hinhanhcanho]  WITH CHECK ADD  CONSTRAINT [FK__hinhanhca__macan__239E4DCF] FOREIGN KEY([macanho])
REFERENCES [dbo].[canho] ([macanho])
GO
ALTER TABLE [dbo].[hinhanhcanho] CHECK CONSTRAINT [FK__hinhanhca__macan__239E4DCF]
GO
/****** Object:  ForeignKey [FK__nhangiaod__matai__32E0915F]    Script Date: 09/26/2013 01:24:40 ******/
ALTER TABLE [dbo].[nhangiaodich]  WITH CHECK ADD FOREIGN KEY([mataikhoan])
REFERENCES [dbo].[taikhoan] ([mataikhoan])
GO
/****** Object:  ForeignKey [FK__nhangiaod__mathu__33D4B598]    Script Date: 09/26/2013 01:24:40 ******/
ALTER TABLE [dbo].[nhangiaodich]  WITH CHECK ADD FOREIGN KEY([mathuecanho])
REFERENCES [dbo].[thuecanho] ([mathuecanho])
GO
/****** Object:  ForeignKey [FK__nhangiaod__matra__34C8D9D1]    Script Date: 09/26/2013 01:24:40 ******/
ALTER TABLE [dbo].[nhangiaodich]  WITH CHECK ADD FOREIGN KEY([matrangthaigiaodich])
REFERENCES [dbo].[trangthaigiaodich] ([matrangthaigiaodich])
GO
/****** Object:  ForeignKey [FK__quan__mathanhpho__0EA330E9]    Script Date: 09/26/2013 01:24:40 ******/
ALTER TABLE [dbo].[quan]  WITH CHECK ADD FOREIGN KEY([mathanhpho])
REFERENCES [dbo].[thanhpho] ([mathanhpho])
GO
/****** Object:  ForeignKey [FK__taikhoan__maloai__0519C6AF]    Script Date: 09/26/2013 01:24:40 ******/
ALTER TABLE [dbo].[taikhoan]  WITH CHECK ADD FOREIGN KEY([maloaitaikhoan])
REFERENCES [dbo].[loaitaikhoan] ([maloaitaikhoan])
GO
/****** Object:  ForeignKey [FK__thuecanho__macan__29572725]    Script Date: 09/26/2013 01:24:40 ******/
ALTER TABLE [dbo].[thuecanho]  WITH CHECK ADD  CONSTRAINT [FK__thuecanho__macan__29572725] FOREIGN KEY([macanho])
REFERENCES [dbo].[canho] ([macanho])
GO
ALTER TABLE [dbo].[thuecanho] CHECK CONSTRAINT [FK__thuecanho__macan__29572725]
GO
/****** Object:  ForeignKey [FK__thuecanho__matai__286302EC]    Script Date: 09/26/2013 01:24:40 ******/
ALTER TABLE [dbo].[thuecanho]  WITH CHECK ADD FOREIGN KEY([mataikhoan])
REFERENCES [dbo].[taikhoan] ([mataikhoan])
GO
