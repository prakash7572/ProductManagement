/****** Object:  Database [ProdcutManagement]    Script Date: 10/3/2023 1:21:56 AM ******/
CREATE DATABASE [ProdcutManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MachineTest', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MachineTest.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MachineTest_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MachineTest_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [ProdcutManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProdcutManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProdcutManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProdcutManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProdcutManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProdcutManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProdcutManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProdcutManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProdcutManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProdcutManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProdcutManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProdcutManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProdcutManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProdcutManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProdcutManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProdcutManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProdcutManagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [ProdcutManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProdcutManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProdcutManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProdcutManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProdcutManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProdcutManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProdcutManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProdcutManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [ProdcutManagement] SET  MULTI_USER 
GO
ALTER DATABASE [ProdcutManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProdcutManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProdcutManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProdcutManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProdcutManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProdcutManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'ProdcutManagement', N'ON'
GO
ALTER DATABASE [ProdcutManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [ProdcutManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ProdcutManagement]
GO
/****** Object:  Table [dbo].[Categorys]    Script Date: 10/3/2023 1:21:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorys](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](100) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 10/3/2023 1:21:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [int] NULL,
	[SubCategoryName] [int] NULL,
	[ProductName] [varchar](100) NULL,
	[ShorDescription] [varchar](100) NULL,
	[FullDescription] [varchar](max) NULL,
	[Status] [bit] NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Profiles]    Script Date: 10/3/2023 1:21:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Profiles](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](100) NULL,
	[Password] [varchar](100) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SubCategorys]    Script Date: 10/3/2023 1:21:57 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SubCategorys](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [int] NULL,
	[SubCategoryName] [varchar](100) NULL,
	[Status] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categorys] ON 
GO
INSERT [dbo].[Categorys] ([ID], [CategoryName], [Status]) VALUES (1, N'Food', 1)
GO
INSERT [dbo].[Categorys] ([ID], [CategoryName], [Status]) VALUES (2, N'Tech', 0)
GO
INSERT [dbo].[Categorys] ([ID], [CategoryName], [Status]) VALUES (69, N'Water', 1)
GO
INSERT [dbo].[Categorys] ([ID], [CategoryName], [Status]) VALUES (70, N'Medicine', 0)
GO
INSERT [dbo].[Categorys] ([ID], [CategoryName], [Status]) VALUES (71, N'Medicine', 1)
GO
SET IDENTITY_INSERT [dbo].[Categorys] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 
GO
INSERT [dbo].[Products] ([ID], [CategoryName], [SubCategoryName], [ProductName], [ShorDescription], [FullDescription], [Status]) VALUES (1, 69, 1019, N'JAL', N'Short_', N'Long Description', 1)
GO
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Profiles] ON 
GO
INSERT [dbo].[Profiles] ([ID], [Email], [Password]) VALUES (1, N'prakash@gmail.com', N'12345')
GO
SET IDENTITY_INSERT [dbo].[Profiles] OFF
GO
SET IDENTITY_INSERT [dbo].[SubCategorys] ON 
GO
INSERT [dbo].[SubCategorys] ([ID], [CategoryName], [SubCategoryName], [Status]) VALUES (1, 1, N'Milk', 1)
GO
INSERT [dbo].[SubCategorys] ([ID], [CategoryName], [SubCategoryName], [Status]) VALUES (1014, 1, N'Laptop', 1)
GO
INSERT [dbo].[SubCategorys] ([ID], [CategoryName], [SubCategoryName], [Status]) VALUES (1017, 2, N'Android', 1)
GO
INSERT [dbo].[SubCategorys] ([ID], [CategoryName], [SubCategoryName], [Status]) VALUES (1019, 69, N'Black-Water', 1)
GO
INSERT [dbo].[SubCategorys] ([ID], [CategoryName], [SubCategoryName], [Status]) VALUES (1020, 69, N'ColorLess-Water', 1)
GO
SET IDENTITY_INSERT [dbo].[SubCategorys] OFF
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([CategoryName])
REFERENCES [dbo].[Categorys] ([ID])
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD FOREIGN KEY([SubCategoryName])
REFERENCES [dbo].[SubCategorys] ([ID])
GO
ALTER TABLE [dbo].[SubCategorys]  WITH CHECK ADD FOREIGN KEY([CategoryName])
REFERENCES [dbo].[Categorys] ([ID])
GO
USE [master]
GO
ALTER DATABASE [ProdcutManagement] SET  READ_WRITE 
GO
