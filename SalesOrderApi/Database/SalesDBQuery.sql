-- CREATE DATABASE Sales_DB
--
-- use Sales_DB

USE [Sales_DB]
GO
/****** Object:  Table [dbo].[tbl_Category]    Script Date: 23-07-22 08:33:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Customer]    Script Date: 23-07-22 08:33:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Customer](
	[Code] [nvarchar](20) NOT NULL,
	[Name] [nvarchar](200) NOT NULL,
	[Address] [nvarchar](max) NULL,
	[Phoneno] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreateUser] [nvarchar](50) NULL,
	[ModifyUser] [nvarchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[ModifyDate] [datetime] NULL,
 CONSTRAINT [PK_tbl_customer] PRIMARY KEY CLUSTERED
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_product]    Script Date: 23-07-22 08:33:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_product](
	[Code] [varchar](20) NOT NULL,
	[Name] [varchar](250) NULL,
	[Price] [decimal](18, 3) NULL,
	[Category] [int] NULL,
 CONSTRAINT [PK_tbl_product] PRIMARY KEY CLUSTERED
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_role]    Script Date: 23-07-22 08:33:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_role](
	[roleid] [varchar](50) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_tbl_role] PRIMARY KEY CLUSTERED
(
	[roleid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_SalesHeader]    Script Date: 23-07-22 08:33:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SalesHeader](
	[InvoiceNo] [nvarchar](20) NOT NULL,
	[InvoiceDate] [smalldatetime] NOT NULL,
	[CustomerId] [nvarchar](20) NOT NULL,
	[Customer Name] [nvarchar](100) NULL,
	[DeliveryAddress] [ntext] NULL,
	[Remarks] [ntext] NULL,
	[Total] [numeric](18, 2) NULL,
	[Tax] [numeric](18, 4) NULL,
	[NetTotal] [numeric](18, 2) NULL,
	[CreateUser] [nvarchar](50) NULL,
	[CreateDate] [smalldatetime] NULL,
	[ModifyUser] [nvarchar](50) NULL,
	[ModifyDate] [smalldatetime] NULL,
 CONSTRAINT [PK_tbl_SaleHeader] PRIMARY KEY CLUSTERED
(
	[InvoiceNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_SalesProductInfo]    Script Date: 23-07-22 08:33:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_SalesProductInfo](
	[InvoiceNo] [nvarchar](20) NOT NULL,
	[ProductCode] [nvarchar](20) NOT NULL,
	[ProductName] [nvarchar](100) NULL,
	[Qty] [int] NULL,
	[SalesPrice] [numeric](18, 3) NULL,
	[Total] [numeric](18, 2) NULL,
	[CreateUser] [nvarchar](50) NULL,
	[CreateDate] [smalldatetime] NULL,
	[ModifyUser] [nvarchar](50) NULL,
	[ModifyDate] [smalldatetime] NULL,
 CONSTRAINT [PK_tbl_SalesInvoiceDetail] PRIMARY KEY CLUSTERED
(
	[InvoiceNo] ASC,
	[ProductCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 23-07-22 08:33:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_user](
	[userid] [varchar](50) NOT NULL,
	[Name] [varchar](50) NULL,
	[password] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Role] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tbl_user] PRIMARY KEY CLUSTERED
(
	[userid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[tbl_Customer] ([Code], [Name], [Address], [Phoneno], [Email], [IsActive], [CreateUser], [ModifyUser], [CreateDate], [ModifyDate]) VALUES (N'202201', N'Chris Mathew', N'1st street,2nd block,chennai', N'87789000', N'chris@in.com', 1, N'adminuser', N'adminuser', CAST(N'2022-07-09 00:00:00.000' AS DateTime), CAST(N'2022-07-09 00:00:00.000' AS DateTime))
GO
INSERT [dbo].[tbl_Customer] ([Code], [Name], [Address], [Phoneno], [Email], [IsActive], [CreateUser], [ModifyUser], [CreateDate], [ModifyDate]) VALUES (N'202202', N'Ramesh Kumar', N'1st street,2nd block,chennai', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_Customer] ([Code], [Name], [Address], [Phoneno], [Email], [IsActive], [CreateUser], [ModifyUser], [CreateDate], [ModifyDate]) VALUES (N'202203', N'Wasim Jaffer', N'1st street,2nd block,chennai', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_Customer] ([Code], [Name], [Address], [Phoneno], [Email], [IsActive], [CreateUser], [ModifyUser], [CreateDate], [ModifyDate]) VALUES (N'202204', N'Rahul Sharma', N'1st street,2nd block,chennai', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_Customer] ([Code], [Name], [Address], [Phoneno], [Email], [IsActive], [CreateUser], [ModifyUser], [CreateDate], [ModifyDate]) VALUES (N'202205', N'Robin Char', N'1st street,2nd block,chennai', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_Customer] ([Code], [Name], [Address], [Phoneno], [Email], [IsActive], [CreateUser], [ModifyUser], [CreateDate], [ModifyDate]) VALUES (N'202206', N'Umesh Yadav', N'1st street,2nd block,chennai', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_Customer] ([Code], [Name], [Address], [Phoneno], [Email], [IsActive], [CreateUser], [ModifyUser], [CreateDate], [ModifyDate]) VALUES (N'202207', N'Adam GilChrist', N'1st street,2nd block,chennai', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_Customer] ([Code], [Name], [Address], [Phoneno], [Email], [IsActive], [CreateUser], [ModifyUser], [CreateDate], [ModifyDate]) VALUES (N'202208', N'Bishaoi', N'1st street,2nd block,chennai', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_product] ([Code], [Name], [Price], [Category]) VALUES (N'p101', N'Cricket Bat', CAST(1000.000 AS Decimal(18, 3)), 1)
GO
INSERT [dbo].[tbl_product] ([Code], [Name], [Price], [Category]) VALUES (N'p102', N'Ball', CAST(100.000 AS Decimal(18, 3)), 2)
GO
INSERT [dbo].[tbl_product] ([Code], [Name], [Price], [Category]) VALUES (N'p103', N'Pad', CAST(250.000 AS Decimal(18, 3)), 1)
GO
INSERT [dbo].[tbl_SalesHeader] ([InvoiceNo], [InvoiceDate], [CustomerId], [Customer Name], [DeliveryAddress], [Remarks], [Total], [Tax], [NetTotal], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate]) VALUES (N'INV001', CAST(N'2022-07-10 16:01:00' AS SmallDateTime), N'202201', N'Chris Mathew', N'', N'', CAST(1100.00 AS Numeric(18, 2)), CAST(0.0000 AS Numeric(18, 4)), CAST(1100.00 AS Numeric(18, 2)), N'adminuser', CAST(N'2022-07-10 16:01:00' AS SmallDateTime), NULL, NULL)
GO
INSERT [dbo].[tbl_SalesHeader] ([InvoiceNo], [InvoiceDate], [CustomerId], [Customer Name], [DeliveryAddress], [Remarks], [Total], [Tax], [NetTotal], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate]) VALUES (N'INV003', CAST(N'2022-07-10 16:01:00' AS SmallDateTime), N'202201', N'Chris Mathew', N'', N'Removed ball', CAST(1000.00 AS Numeric(18, 2)), CAST(0.0000 AS Numeric(18, 4)), CAST(1500.00 AS Numeric(18, 2)), N'adminuser', CAST(N'2022-07-10 16:01:00' AS SmallDateTime), NULL, NULL)
GO
INSERT [dbo].[tbl_SalesProductInfo] ([InvoiceNo], [ProductCode], [ProductName], [Qty], [SalesPrice], [Total], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate]) VALUES (N'INV001', N'p101', N'Cricket bat', 1, CAST(1000.000 AS Numeric(18, 3)), CAST(1000.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_SalesProductInfo] ([InvoiceNo], [ProductCode], [ProductName], [Qty], [SalesPrice], [Total], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate]) VALUES (N'INV001', N'p102', N'Ball', 1, CAST(100.000 AS Numeric(18, 3)), CAST(100.00 AS Numeric(18, 2)), NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[tbl_SalesProductInfo] ([InvoiceNo], [ProductCode], [ProductName], [Qty], [SalesPrice], [Total], [CreateUser], [CreateDate], [ModifyUser], [ModifyDate]) VALUES (N'INV003', N'p101', N'Cricket bat', 1, CAST(1000.000 AS Numeric(18, 3)), CAST(1000.00 AS Numeric(18, 2)), N'adminuser', CAST(N'2022-07-10 21:52:00' AS SmallDateTime), NULL, NULL)
GO
