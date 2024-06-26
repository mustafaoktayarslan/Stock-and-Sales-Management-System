USE [master]
GO
/****** Object:  Database [MarketDB]    Script Date: 25.06.2024 09:45:58 ******/
CREATE DATABASE [MarketDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MarketDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MarketDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MarketDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\MarketDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [MarketDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MarketDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MarketDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MarketDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MarketDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MarketDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MarketDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MarketDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MarketDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MarketDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MarketDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MarketDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MarketDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MarketDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MarketDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MarketDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MarketDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MarketDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MarketDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MarketDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MarketDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MarketDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MarketDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MarketDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MarketDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MarketDB] SET  MULTI_USER 
GO
ALTER DATABASE [MarketDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MarketDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MarketDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MarketDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MarketDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MarketDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MarketDB] SET QUERY_STORE = OFF
GO
USE [MarketDB]
GO
/****** Object:  Table [dbo].[tbStockIn]    Script Date: 25.06.2024 09:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbStockIn](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[refno] [varchar](50) NULL,
	[barcode] [varchar](50) NULL,
	[qty] [int] NULL,
	[sdate] [datetime] NULL,
	[stockinby] [varchar](50) NULL,
	[status] [varchar](50) NULL,
	[supplierid] [int] NULL,
 CONSTRAINT [PK_tbStockIn] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbSupplier]    Script Date: 25.06.2024 09:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbSupplier](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[supplier] [varchar](50) NOT NULL,
	[address] [text] NOT NULL,
	[contactperson] [varchar](50) NOT NULL,
	[phone] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[fax] [varchar](50) NULL,
 CONSTRAINT [PK_tbSupplier] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblProduct]    Script Date: 25.06.2024 09:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblProduct](
	[barcode] [varchar](50) NOT NULL,
	[pdesc] [varchar](max) NOT NULL,
	[bid] [int] NOT NULL,
	[cid] [int] NOT NULL,
	[price] [decimal](18, 2) NOT NULL,
	[qty] [int] NULL,
	[reorder] [int] NULL,
 CONSTRAINT [PK_tblProduct_1] PRIMARY KEY CLUSTERED 
(
	[barcode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[viewStockIn]    Script Date: 25.06.2024 09:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewStockIn]
AS
SELECT   dbo.tbStockIn.id, dbo.tbStockIn.refno, dbo.tbStockIn.barcode, dbo.tblProduct.pdesc, dbo.tbStockIn.qty, dbo.tbStockIn.sdate, dbo.tbStockIn.stockinby, dbo.tbStockIn.status, dbo.tbSupplier.supplier
FROM      dbo.tblProduct INNER JOIN
                dbo.tbStockIn ON dbo.tblProduct.barcode = dbo.tbStockIn.barcode INNER JOIN
                dbo.tbSupplier ON dbo.tbStockIn.supplierid = dbo.tbSupplier.id
GO
/****** Object:  Table [dbo].[tbCart]    Script Date: 25.06.2024 09:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbCart](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[transno] [varchar](50) NULL,
	[barcode] [varchar](50) NULL,
	[price] [decimal](18, 2) NULL,
	[qty] [int] NULL,
	[disc_percent] [decimal](18, 2) NULL,
	[disc] [decimal](18, 2) NULL,
	[total] [decimal](18, 2) NULL,
	[sdate] [date] NULL,
	[status] [varchar](50) NULL,
	[cashier] [varchar](50) NULL,
 CONSTRAINT [PK_tbCart] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[viewTopSelling]    Script Date: 25.06.2024 09:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewTopSelling]
AS
SELECT   dbo.tbCart.barcode, dbo.tblProduct.pdesc, dbo.tbCart.qty, dbo.tbCart.sdate, dbo.tbCart.total, dbo.tbCart.status
FROM      dbo.tbCart INNER JOIN
                dbo.tblProduct ON dbo.tbCart.barcode = dbo.tblProduct.barcode
GO
/****** Object:  Table [dbo].[tbBrand]    Script Date: 25.06.2024 09:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbBrand](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[brand] [varchar](50) NULL,
 CONSTRAINT [PK_tbBrand] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbCategory]    Script Date: 25.06.2024 09:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbCategory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[category] [varchar](50) NOT NULL,
 CONSTRAINT [PK_tbCategory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[viewCriticalItems]    Script Date: 25.06.2024 09:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewCriticalItems]
AS
SELECT   dbo.tblProduct.barcode, dbo.tblProduct.pdesc, dbo.tbBrand.brand, dbo.tbCategory.category, dbo.tblProduct.price, dbo.tblProduct.reorder, dbo.tblProduct.qty
FROM      dbo.tblProduct INNER JOIN
                dbo.tbCategory ON dbo.tblProduct.cid = dbo.tbCategory.id INNER JOIN
                dbo.tbBrand ON dbo.tblProduct.bid = dbo.tbBrand.id
WHERE   (dbo.tblProduct.qty <= dbo.tblProduct.reorder)
GO
/****** Object:  View [dbo].[viewInventoryList]    Script Date: 25.06.2024 09:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewInventoryList]
AS
SELECT   dbo.tblProduct.barcode, dbo.tblProduct.pdesc, dbo.tbBrand.brand, dbo.tbCategory.category, dbo.tblProduct.price, dbo.tblProduct.reorder, dbo.tblProduct.qty
FROM      dbo.tblProduct INNER JOIN
                dbo.tbCategory ON dbo.tblProduct.cid = dbo.tbCategory.id INNER JOIN
                dbo.tbBrand ON dbo.tblProduct.bid = dbo.tbBrand.id
GO
/****** Object:  Table [dbo].[tbCancel]    Script Date: 25.06.2024 09:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbCancel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[transno] [varchar](50) NULL,
	[barcode] [varchar](50) NULL,
	[price] [decimal](18, 2) NULL,
	[qty] [int] NULL,
	[total] [decimal](18, 2) NULL,
	[sdate] [date] NULL,
	[voidby] [varchar](50) NULL,
	[cancelledby] [varchar](50) NULL,
	[reason] [text] NULL,
	[action] [varchar](50) NULL,
 CONSTRAINT [PK_tbCancel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  View [dbo].[viewCancelItem]    Script Date: 25.06.2024 09:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[viewCancelItem]
AS
SELECT   dbo.tbCancel.transno, dbo.tbCancel.barcode, dbo.tblProduct.pdesc, dbo.tbCancel.price, dbo.tbCancel.qty, dbo.tbCancel.total, dbo.tbCancel.sdate, dbo.tbCancel.voidby, dbo.tbCancel.cancelledby, dbo.tbCancel.reason, dbo.tbCancel.action
FROM      dbo.tbCancel INNER JOIN
                dbo.tblProduct ON dbo.tbCancel.barcode = dbo.tblProduct.barcode
GO
/****** Object:  Table [dbo].[tbAdjustment]    Script Date: 25.06.2024 09:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbAdjustment](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[refno] [varchar](50) NULL,
	[barcode] [varchar](50) NULL,
	[qty] [int] NULL,
	[action] [varchar](50) NULL,
	[remarks] [varchar](50) NULL,
	[sdate] [date] NULL,
	[user] [varchar](50) NULL,
 CONSTRAINT [PK_tbAdjustment] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbStore]    Script Date: 25.06.2024 09:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbStore](
	[store] [varchar](50) NOT NULL,
	[address] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbUser]    Script Date: 25.06.2024 09:45:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbUser](
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[role] [varchar](50) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[isactive] [varchar](50) NULL,
 CONSTRAINT [PK_tbUser] PRIMARY KEY CLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

-- tbUser tablosuna bir kullanıcı eklenmesi
INSERT INTO [dbo].[tbUser] (username, password, role, name, isactive)
VALUES ('admin', 'admin', 'yönetici', 'ADMIN', 'True');

GO
ALTER TABLE [dbo].[tbCart] ADD  CONSTRAINT [DF_tbCart_qty]  DEFAULT ((0)) FOR [qty]
GO
ALTER TABLE [dbo].[tbCart] ADD  CONSTRAINT [DF_tbCart_disc_percent]  DEFAULT ((0)) FOR [disc_percent]
GO
ALTER TABLE [dbo].[tbCart] ADD  CONSTRAINT [DF_tbCart_disc]  DEFAULT ((0)) FOR [disc]
GO
ALTER TABLE [dbo].[tbCart] ADD  CONSTRAINT [DF_tbCart_status]  DEFAULT ('Beklemede') FOR [status]
GO
ALTER TABLE [dbo].[tblProduct] ADD  CONSTRAINT [DF_tblProduct_bid]  DEFAULT ((0)) FOR [bid]
GO
ALTER TABLE [dbo].[tblProduct] ADD  CONSTRAINT [DF_tblProduct_cid]  DEFAULT ((0)) FOR [cid]
GO
ALTER TABLE [dbo].[tblProduct] ADD  CONSTRAINT [DF_tblProduct_qty]  DEFAULT ((0)) FOR [qty]
GO
ALTER TABLE [dbo].[tbStockIn] ADD  CONSTRAINT [DF_tbStockIn_qty]  DEFAULT ((0)) FOR [qty]
GO
ALTER TABLE [dbo].[tbStockIn] ADD  CONSTRAINT [DF_tbStockIn_status]  DEFAULT ('Beklemede') FOR [status]
GO
ALTER TABLE [dbo].[tbUser] ADD  CONSTRAINT [DF_tbUser_isactive]  DEFAULT ('False') FOR [isactive]
GO
ALTER TABLE [dbo].[tbCart]  WITH CHECK ADD  CONSTRAINT [FK_tbCart_tblProduct] FOREIGN KEY([barcode])
REFERENCES [dbo].[tblProduct] ([barcode])
GO
ALTER TABLE [dbo].[tbCart] CHECK CONSTRAINT [FK_tbCart_tblProduct]
GO
ALTER TABLE [dbo].[tblProduct]  WITH CHECK ADD  CONSTRAINT [FK_tblProduct_tbBrand] FOREIGN KEY([bid])
REFERENCES [dbo].[tbBrand] ([id])
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[tblProduct] CHECK CONSTRAINT [FK_tblProduct_tbBrand]
GO
ALTER TABLE [dbo].[tblProduct]  WITH CHECK ADD  CONSTRAINT [FK_tblProduct_tbCategory] FOREIGN KEY([cid])
REFERENCES [dbo].[tbCategory] ([id])
ON DELETE SET DEFAULT
GO
ALTER TABLE [dbo].[tblProduct] CHECK CONSTRAINT [FK_tblProduct_tbCategory]
GO
ALTER TABLE [dbo].[tbStockIn]  WITH CHECK ADD  CONSTRAINT [FK_tbStockIn_tblProduct] FOREIGN KEY([barcode])
REFERENCES [dbo].[tblProduct] ([barcode])
GO
ALTER TABLE [dbo].[tbStockIn] CHECK CONSTRAINT [FK_tbStockIn_tblProduct]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[10] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tbCancel"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 299
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tblProduct"
            Begin Extent = 
               Top = 6
               Left = 250
               Bottom = 241
               Right = 424
            End
            DisplayFlags = 280
            TopColumn = 1
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 12
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewCancelItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewCancelItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[17] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -192
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblProduct"
            Begin Extent = 
               Top = 6
               Left = 462
               Bottom = 146
               Right = 636
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbCategory"
            Begin Extent = 
               Top = 6
               Left = 250
               Bottom = 108
               Right = 424
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbBrand"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 108
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewCriticalItems'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewCriticalItems'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[14] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblProduct"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 146
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 3
         End
         Begin Table = "tbCategory"
            Begin Extent = 
               Top = 130
               Left = 293
               Bottom = 232
               Right = 467
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbBrand"
            Begin Extent = 
               Top = 6
               Left = 462
               Bottom = 108
               Right = 636
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1605
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewInventoryList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewInventoryList'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tblProduct"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 146
               Right = 212
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbStockIn"
            Begin Extent = 
               Top = 6
               Left = 250
               Bottom = 271
               Right = 424
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "tbSupplier"
            Begin Extent = 
               Top = 6
               Left = 462
               Bottom = 146
               Right = 636
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewStockIn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewStockIn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[11] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "tbCart"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 300
               Right = 222
            End
            DisplayFlags = 280
            TopColumn = 1
         End
         Begin Table = "tblProduct"
            Begin Extent = 
               Top = 6
               Left = 250
               Bottom = 297
               Right = 441
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 9
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewTopSelling'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'viewTopSelling'
GO
USE [master]
GO
ALTER DATABASE [MarketDB] SET  READ_WRITE 
GO
