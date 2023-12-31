USE [TestTuyaI]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 9/19/2023 12:28:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Apellidos] [varchar](50) NOT NULL,
	[Identificacion] [varchar](50) NOT NULL,
	[Telefono] [bigint] NOT NULL,
	[Email] [varchar](50) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetails]    Script Date: 9/19/2023 12:28:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderId] [int] NOT NULL,
	[idProducto] [int] NOT NULL,
	[descripcionProducto] [varchar](50) NOT NULL,
	[valorUnitario] [money] NOT NULL,
	[cantidad] [int] NOT NULL,
	[Total] [money] NOT NULL,
 CONSTRAINT [PK_OrderDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 9/19/2023 12:28:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FechaOrden] [datetime] NOT NULL,
	[customerId] [int] NOT NULL,
	[valorOrden] [money] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [Nombre], [Apellidos], [Identificacion], [Telefono], [Email]) VALUES (1, N'Felipe', N'Bertrand', N'223445', 456984565, N'test@gmail.com')
INSERT [dbo].[Customers] ([Id], [Nombre], [Apellidos], [Identificacion], [Telefono], [Email]) VALUES (2, N'Peggy', N'Bertrand', N'334444', 6632155, N'peggy@gmail.com')
INSERT [dbo].[Customers] ([Id], [Nombre], [Apellidos], [Identificacion], [Telefono], [Email]) VALUES (3, N'laura', N'Castaño', N'333232', 344354554, N'laura@gmail.com')
SET IDENTITY_INSERT [dbo].[Customers] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderDetails] ON 

INSERT [dbo].[OrderDetails] ([Id], [OrderId], [idProducto], [descripcionProducto], [valorUnitario], [cantidad], [Total]) VALUES (1, 1, 1, N'Mochila', 10000.0000, 1, 10000.0000)
INSERT [dbo].[OrderDetails] ([Id], [OrderId], [idProducto], [descripcionProducto], [valorUnitario], [cantidad], [Total]) VALUES (2, 2, 1, N'Mochila', 20000.0000, 1, 20000.0000)
SET IDENTITY_INSERT [dbo].[OrderDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [FechaOrden], [customerId], [valorOrden]) VALUES (1, CAST(N'2023-09-19T02:37:51.707' AS DateTime), 1, 10000.0000)
INSERT [dbo].[Orders] ([Id], [FechaOrden], [customerId], [valorOrden]) VALUES (2, CAST(N'2023-09-19T02:37:51.707' AS DateTime), 1, 20000.0000)
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
ALTER TABLE [dbo].[OrderDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetails_Orders] FOREIGN KEY([OrderId])
REFERENCES [dbo].[Orders] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetails] CHECK CONSTRAINT [FK_OrderDetails_Orders]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([customerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
