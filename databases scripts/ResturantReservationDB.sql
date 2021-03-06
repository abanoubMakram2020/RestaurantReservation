USE [master]
GO
/****** Object:  Database [ResturantReservationDB]    Script Date: 6/21/2021 3:32:22 AM ******/
CREATE DATABASE [ResturantReservationDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ResturantReservationDB', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ResturantReservationDB.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'ResturantReservationDB_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\ResturantReservationDB_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [ResturantReservationDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ResturantReservationDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ResturantReservationDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ResturantReservationDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ResturantReservationDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ResturantReservationDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ResturantReservationDB] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [ResturantReservationDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET RECOVERY FULL 
GO
ALTER DATABASE [ResturantReservationDB] SET  MULTI_USER 
GO
ALTER DATABASE [ResturantReservationDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ResturantReservationDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ResturantReservationDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ResturantReservationDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [ResturantReservationDB] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'ResturantReservationDB', N'ON'
GO
USE [ResturantReservationDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/21/2021 3:32:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FoodType]    Script Date: 6/21/2021 3:32:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FoodNameAr] [nvarchar](50) NOT NULL,
	[FoodNameEn] [nvarchar](50) NOT NULL,
	[FoodSellUnit] [int] NOT NULL,
 CONSTRAINT [PK_FoodType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reservation]    Script Date: 6/21/2021 3:32:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reservation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ClientName] [nvarchar](50) NOT NULL,
	[TableNo] [int] NOT NULL,
	[NumberOfPeople] [int] NOT NULL,
	[ReservationDate] [datetime2](7) NOT NULL,
	[Note] [nvarchar](max) NULL,
 CONSTRAINT [PK_Reservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ReservationFoods]    Script Date: 6/21/2021 3:32:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ReservationFoods](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ReservationId] [int] NOT NULL,
	[FoodTypeId] [int] NOT NULL,
 CONSTRAINT [PK_ReservationFoods] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Table]    Script Date: 6/21/2021 3:32:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[No] [int] NOT NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Unit]    Script Date: 6/21/2021 3:32:22 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Unit](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NameAr] [nvarchar](50) NOT NULL,
	[NameEn] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20210620232216_InitialData', N'5.0.7')
SET IDENTITY_INSERT [dbo].[FoodType] ON 

INSERT [dbo].[FoodType] ([Id], [FoodNameAr], [FoodNameEn], [FoodSellUnit]) VALUES (1, N'لحمة', N'meat', 1)
INSERT [dbo].[FoodType] ([Id], [FoodNameAr], [FoodNameEn], [FoodSellUnit]) VALUES (2, N'فراخ', N'chicken', 1)
INSERT [dbo].[FoodType] ([Id], [FoodNameAr], [FoodNameEn], [FoodSellUnit]) VALUES (3, N'طاجن جمبري', N'Shrimp Casserole', 2)
INSERT [dbo].[FoodType] ([Id], [FoodNameAr], [FoodNameEn], [FoodSellUnit]) VALUES (4, N'طاجن لحمة', N'Meat Casserole', 2)
INSERT [dbo].[FoodType] ([Id], [FoodNameAr], [FoodNameEn], [FoodSellUnit]) VALUES (5, N'سلطة خضرا', N'green salad', 3)
SET IDENTITY_INSERT [dbo].[FoodType] OFF
SET IDENTITY_INSERT [dbo].[Reservation] ON 

INSERT [dbo].[Reservation] ([Id], [ClientName], [TableNo], [NumberOfPeople], [ReservationDate], [Note]) VALUES (1, N'Paki Wall', 1, 5, CAST(N'2021-06-21 01:24:40.2907732' AS DateTime2), N'Blanditiis ipsam pra')
INSERT [dbo].[Reservation] ([Id], [ClientName], [TableNo], [NumberOfPeople], [ReservationDate], [Note]) VALUES (2, N'Fatima Garza', 7, 7, CAST(N'2021-06-21 01:24:13.7646101' AS DateTime2), N'Aut aut labore aliqu')
INSERT [dbo].[Reservation] ([Id], [ClientName], [TableNo], [NumberOfPeople], [ReservationDate], [Note]) VALUES (3, N'Venus Tran', 3, 5, CAST(N'2021-06-21 02:26:17.8679846' AS DateTime2), N'Repellendus Qui seq')
INSERT [dbo].[Reservation] ([Id], [ClientName], [TableNo], [NumberOfPeople], [ReservationDate], [Note]) VALUES (4, N'Evangeline Williamson', 4, 7, CAST(N'2021-06-21 02:54:19.0055876' AS DateTime2), N'Amet minus expedita')
SET IDENTITY_INSERT [dbo].[Reservation] OFF
SET IDENTITY_INSERT [dbo].[ReservationFoods] ON 

INSERT [dbo].[ReservationFoods] ([Id], [ReservationId], [FoodTypeId]) VALUES (2, 2, 3)
INSERT [dbo].[ReservationFoods] ([Id], [ReservationId], [FoodTypeId]) VALUES (3, 2, 5)
INSERT [dbo].[ReservationFoods] ([Id], [ReservationId], [FoodTypeId]) VALUES (4, 1, 1)
INSERT [dbo].[ReservationFoods] ([Id], [ReservationId], [FoodTypeId]) VALUES (5, 3, 3)
INSERT [dbo].[ReservationFoods] ([Id], [ReservationId], [FoodTypeId]) VALUES (7, 4, 1)
INSERT [dbo].[ReservationFoods] ([Id], [ReservationId], [FoodTypeId]) VALUES (8, 4, 2)
INSERT [dbo].[ReservationFoods] ([Id], [ReservationId], [FoodTypeId]) VALUES (9, 4, 3)
INSERT [dbo].[ReservationFoods] ([Id], [ReservationId], [FoodTypeId]) VALUES (10, 4, 4)
SET IDENTITY_INSERT [dbo].[ReservationFoods] OFF
SET IDENTITY_INSERT [dbo].[Table] ON 

INSERT [dbo].[Table] ([Id], [No]) VALUES (1, 1)
INSERT [dbo].[Table] ([Id], [No]) VALUES (2, 2)
INSERT [dbo].[Table] ([Id], [No]) VALUES (3, 3)
INSERT [dbo].[Table] ([Id], [No]) VALUES (4, 4)
INSERT [dbo].[Table] ([Id], [No]) VALUES (5, 5)
INSERT [dbo].[Table] ([Id], [No]) VALUES (6, 6)
INSERT [dbo].[Table] ([Id], [No]) VALUES (7, 7)
INSERT [dbo].[Table] ([Id], [No]) VALUES (8, 8)
INSERT [dbo].[Table] ([Id], [No]) VALUES (9, 9)
INSERT [dbo].[Table] ([Id], [No]) VALUES (10, 10)
SET IDENTITY_INSERT [dbo].[Table] OFF
SET IDENTITY_INSERT [dbo].[Unit] ON 

INSERT [dbo].[Unit] ([Id], [NameAr], [NameEn]) VALUES (1, N'كيلو', N'Killo')
INSERT [dbo].[Unit] ([Id], [NameAr], [NameEn]) VALUES (2, N'طبق', N'Dish')
INSERT [dbo].[Unit] ([Id], [NameAr], [NameEn]) VALUES (3, N'طاجن', N'Casserole')
SET IDENTITY_INSERT [dbo].[Unit] OFF
/****** Object:  Index [IX_FoodType_FoodSellUnit]    Script Date: 6/21/2021 3:32:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_FoodType_FoodSellUnit] ON [dbo].[FoodType]
(
	[FoodSellUnit] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Reservation_TableNo]    Script Date: 6/21/2021 3:32:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_Reservation_TableNo] ON [dbo].[Reservation]
(
	[TableNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ReservationFoods_FoodTypeId]    Script Date: 6/21/2021 3:32:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_ReservationFoods_FoodTypeId] ON [dbo].[ReservationFoods]
(
	[FoodTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ReservationFoods_ReservationId]    Script Date: 6/21/2021 3:32:22 AM ******/
CREATE NONCLUSTERED INDEX [IX_ReservationFoods_ReservationId] ON [dbo].[ReservationFoods]
(
	[ReservationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FoodType]  WITH CHECK ADD  CONSTRAINT [FK_FoodType_Unit_FoodSellUnit] FOREIGN KEY([FoodSellUnit])
REFERENCES [dbo].[Unit] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FoodType] CHECK CONSTRAINT [FK_FoodType_Unit_FoodSellUnit]
GO
ALTER TABLE [dbo].[Reservation]  WITH CHECK ADD  CONSTRAINT [FK_Reservation_Table_TableNo] FOREIGN KEY([TableNo])
REFERENCES [dbo].[Table] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Reservation] CHECK CONSTRAINT [FK_Reservation_Table_TableNo]
GO
ALTER TABLE [dbo].[ReservationFoods]  WITH CHECK ADD  CONSTRAINT [FK_ReservationFoods_FoodType_FoodTypeId] FOREIGN KEY([FoodTypeId])
REFERENCES [dbo].[FoodType] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReservationFoods] CHECK CONSTRAINT [FK_ReservationFoods_FoodType_FoodTypeId]
GO
ALTER TABLE [dbo].[ReservationFoods]  WITH CHECK ADD  CONSTRAINT [FK_ReservationFoods_Reservation_ReservationId] FOREIGN KEY([ReservationId])
REFERENCES [dbo].[Reservation] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ReservationFoods] CHECK CONSTRAINT [FK_ReservationFoods_Reservation_ReservationId]
GO
USE [master]
GO
ALTER DATABASE [ResturantReservationDB] SET  READ_WRITE 
GO
