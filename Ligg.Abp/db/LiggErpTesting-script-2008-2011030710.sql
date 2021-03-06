USE [master]
GO
/****** Object:  Database [LiggErpTesting]    Script Date: 12/3/2020 7:42:28 PM ******/
CREATE DATABASE [LiggErpTesting] ON  PRIMARY 
( NAME = N'LiduoErpTesting', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\LiduoErpTesting1.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LiduoErpTesting_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\LiduoErpTesting1_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LiggErpTesting] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LiggErpTesting].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LiggErpTesting] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LiggErpTesting] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LiggErpTesting] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LiggErpTesting] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LiggErpTesting] SET ARITHABORT OFF 
GO
ALTER DATABASE [LiggErpTesting] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LiggErpTesting] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LiggErpTesting] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LiggErpTesting] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LiggErpTesting] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LiggErpTesting] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LiggErpTesting] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LiggErpTesting] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LiggErpTesting] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LiggErpTesting] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LiggErpTesting] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LiggErpTesting] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LiggErpTesting] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LiggErpTesting] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LiggErpTesting] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LiggErpTesting] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [LiggErpTesting] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LiggErpTesting] SET RECOVERY FULL 
GO
ALTER DATABASE [LiggErpTesting] SET  MULTI_USER 
GO
ALTER DATABASE [LiggErpTesting] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LiggErpTesting] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LiggErpTesting', N'ON'
GO
USE [LiggErpTesting]
GO
/****** Object:  User [DESKTOP-DEV\developer]    Script Date: 12/3/2020 7:42:33 PM ******/
CREATE USER [DESKTOP-DEV\developer] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/3/2020 7:42:33 PM ******/
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
/****** Object:  Table [dbo].[Adm.Users]    Script Date: 12/3/2020 7:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adm.Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](16) NOT NULL,
	[Name] [nvarchar](32) NOT NULL,
	[Password] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Disabled] [bit] NOT NULL,
	[CreatorId] [uniqueidentifier] NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[LastModifierId] [uniqueidentifier] NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
	[DepartmentId] [uniqueidentifier] NULL,
	[Builtin] [bit] NOT NULL,
 CONSTRAINT [PK_Adm.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Biz.Materials]    Script Date: 12/3/2020 7:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Biz.Materials](
	[Id] [uniqueidentifier] NOT NULL,
	[Type] [int] NOT NULL,
	[No] [bigint] NOT NULL,
	[NameId] [uniqueidentifier] NOT NULL,
	[Specification] [nvarchar](64) NULL,
	[OtherAttribute] [nvarchar](64) NULL,
	[Stuff] [nvarchar](64) NULL,
	[DrawingCode] [nvarchar](64) NULL,
	[BasicUnitId] [uniqueidentifier] NOT NULL,
	[Disabled] [bit] NOT NULL,
	[CreatorId] [uniqueidentifier] NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[LastModifierId] [uniqueidentifier] NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Biz.Materials] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Biz.MaterialUnits]    Script Date: 12/3/2020 7:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Biz.MaterialUnits](
	[Id] [uniqueidentifier] NOT NULL,
	[UnitId] [uniqueidentifier] NOT NULL,
	[BasicUnitId] [uniqueidentifier] NOT NULL,
	[Coefficient] [real] NOT NULL,
	[CreatorId] [uniqueidentifier] NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[LastModifierId] [uniqueidentifier] NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Biz.MaterialUnits] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BuilderTable]    Script Date: 12/3/2020 7:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BuilderTable](
	[Id] [nvarchar](50) NOT NULL,
	[TableName] [nvarchar](200) NOT NULL,
	[Comment] [nvarchar](500) NULL,
	[DetailTableName] [nvarchar](255) NULL,
	[DetailComment] [nvarchar](500) NULL,
	[ClassName] [nvarchar](100) NOT NULL,
	[Namespace] [nvarchar](100) NULL,
	[ModuleCode] [nvarchar](255) NULL,
	[ModuleName] [nvarchar](300) NULL,
	[Folder] [nvarchar](300) NULL,
	[Options] [nvarchar](1000) NULL,
	[TypeId] [nvarchar](50) NULL,
	[TypeName] [nvarchar](20) NULL,
	[CreateTime] [datetime2](0) NOT NULL,
	[CreateUserId] [nvarchar](50) NULL,
	[UpdateTime] [datetime2](0) NULL,
	[UpdateUserId] [nvarchar](50) NULL,
	[UpdateUserName] [varchar](50) NULL,
	[CreateUserName] [varchar](50) NULL,
 CONSTRAINT [PK__systable__3214EC074BC5F3BD] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 12/3/2020 7:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [varchar](50) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[DtCode] [varchar](50) NOT NULL,
	[DtValue] [varchar](50) NULL,
	[Enable] [bit] NOT NULL,
	[SortNo] [int] NOT NULL,
	[Description] [varchar](500) NULL,
	[TypeId] [varchar](50) NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[CreateUserId] [varchar](50) NOT NULL,
	[CreateUserName] [varchar](200) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[UpdateUserId] [varchar](50) NULL,
	[UpdateUserName] [varchar](200) NULL,
 CONSTRAINT [PK__Category__3214EC0757425361] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cfg.MaterialCategories]    Script Date: 12/3/2020 7:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cfg.MaterialCategories](
	[Id] [uniqueidentifier] NOT NULL,
	[ParentId] [uniqueidentifier] NULL,
	[Type] [int] NOT NULL,
	[No] [bigint] NOT NULL,
	[DisplayName] [nvarchar](32) NOT NULL,
	[CreatorId] [uniqueidentifier] NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[LastModifierId] [uniqueidentifier] NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Cfg.MaterialCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cfg.Organizations]    Script Date: 12/3/2020 7:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cfg.Organizations](
	[Id] [uniqueidentifier] NOT NULL,
	[ParentId] [uniqueidentifier] NULL,
	[Type] [int] NOT NULL,
	[Code] [nvarchar](16) NOT NULL,
	[ShortName] [nvarchar](32) NULL,
	[DisplayName] [nvarchar](32) NULL,
	[OrderTag] [nvarchar](16) NULL,
	[ImageKey] [int] NOT NULL,
	[Disabled] [bit] NOT NULL,
	[CreatorId] [uniqueidentifier] NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[LastModifierId] [uniqueidentifier] NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Cfg.Organizations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cfg.Roles]    Script Date: 12/3/2020 7:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cfg.Roles](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](16) NULL,
	[DisplayName] [nvarchar](32) NOT NULL,
	[Description] [nvarchar](64) NULL,
	[CreatorId] [uniqueidentifier] NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[LastModifierId] [uniqueidentifier] NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
	[OrderTag] [nvarchar](16) NULL,
 CONSTRAINT [PK_Cfg.Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cfg.Transactions]    Script Date: 12/3/2020 7:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cfg.Transactions](
	[Id] [uniqueidentifier] NOT NULL,
	[Type] [int] NOT NULL,
	[DisplayName] [nvarchar](64) NULL,
	[ImageKey] [int] NOT NULL,
	[CreatorId] [uniqueidentifier] NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[LastModifierId] [uniqueidentifier] NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
	[OrderTag] [nvarchar](16) NULL,
	[Code] [nvarchar](16) NOT NULL,
	[ParentId] [uniqueidentifier] NULL,
	[Description] [nvarchar](64) NULL,
 CONSTRAINT [PK_Cfg.Transactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cfg.Units]    Script Date: 12/3/2020 7:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cfg.Units](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [nvarchar](16) NULL,
	[DisplayName] [nvarchar](32) NOT NULL,
	[Description] [nvarchar](64) NULL,
	[IsBasicUnit] [bit] NOT NULL,
	[CreatorId] [uniqueidentifier] NOT NULL,
	[CreationTime] [datetime2](7) NOT NULL,
	[LastModifierId] [uniqueidentifier] NOT NULL,
	[ModificationTime] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Cfg.Units] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DataPrivilegeRule]    Script Date: 12/3/2020 7:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DataPrivilegeRule](
	[Id] [varchar](50) NOT NULL,
	[SourceCode] [varchar](50) NOT NULL,
	[SubSourceCode] [varchar](50) NULL,
	[Description] [varchar](255) NOT NULL,
	[SortNo] [int] NOT NULL,
	[PrivilegeRules] [varchar](1000) NOT NULL,
	[Enable] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[CreateUserId] [varchar](50) NOT NULL,
	[CreateUserName] [varchar](200) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[UpdateUserId] [varchar](50) NULL,
	[UpdateUserName] [varchar](200) NULL,
 CONSTRAINT [PK__DataPriv__3214EC0782473638] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OpenJob]    Script Date: 12/3/2020 7:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OpenJob](
	[Id] [varchar](50) NOT NULL,
	[JobName] [varchar](200) NOT NULL,
	[RunCount] [int] NOT NULL,
	[ErrorCount] [int] NOT NULL,
	[NextRunTime] [datetime] NULL,
	[LastRunTime] [datetime] NULL,
	[LastErrorTime] [datetime] NULL,
	[JobType] [int] NOT NULL,
	[JobCall] [varchar](500) NOT NULL,
	[JobCallParams] [varchar](500) NULL,
	[Cron] [varchar](50) NOT NULL,
	[Status] [int] NOT NULL,
	[Remark] [varchar](128) NULL,
	[CreateTime] [datetime] NOT NULL,
	[CreateUserId] [varchar](50) NOT NULL,
	[CreateUserName] [varchar](200) NOT NULL,
	[UpdateTime] [datetime] NULL,
	[UpdateUserId] [varchar](50) NULL,
	[UpdateUserName] [varchar](200) NULL,
	[OrgId] [varchar](50) NULL,
 CONSTRAINT [PK_OPENJOB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Resource]    Script Date: 12/3/2020 7:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Resource](
	[Id] [varchar](50) NOT NULL,
	[CascadeId] [varchar](255) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[SortNo] [int] NOT NULL,
	[Description] [varchar](500) NOT NULL,
	[ParentName] [varchar](50) NULL,
	[ParentId] [varchar](50) NULL,
	[AppId] [varchar](50) NULL,
	[AppName] [varchar](50) NULL,
	[TypeName] [varchar](20) NULL,
	[TypeId] [varchar](50) NULL,
	[Disable] [bit] NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[CreateUserId] [varchar](50) NOT NULL,
	[CreateUserName] [varchar](200) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[UpdateUserId] [varchar](50) NULL,
	[UpdateUserName] [varchar](200) NULL,
 CONSTRAINT [PK__Resource__3214EC07A3FEAC15] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WmsInboundOrderDtbl]    Script Date: 12/3/2020 7:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WmsInboundOrderDtbl](
	[Id] [varchar](50) NOT NULL,
	[OrderId] [varchar](50) NOT NULL,
	[Price] [decimal](18, 6) NULL,
	[PriceNoTax] [decimal](18, 6) NULL,
	[InStockStatus] [bit] NOT NULL,
	[AsnStatus] [int] NOT NULL,
	[GoodsId] [varchar](50) NOT NULL,
	[GoodsBatch] [varchar](50) NOT NULL,
	[QualityFlg] [varchar](50) NOT NULL,
	[OrderNum] [decimal](18, 2) NOT NULL,
	[InNum] [decimal](18, 2) NOT NULL,
	[LeaveNum] [decimal](18, 2) NOT NULL,
	[HoldNum] [decimal](18, 2) NOT NULL,
	[ProdDate] [varchar](30) NULL,
	[ExpireDate] [varchar](30) NULL,
	[TaxRate] [decimal](10, 2) NULL,
	[OwnerId] [varchar](32) NOT NULL,
	[Remark] [varchar](128) NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[CreateUserId] [varchar](50) NOT NULL,
	[CreateUserName] [varchar](200) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[UpdateUserId] [varchar](50) NULL,
	[UpdateUserName] [varchar](200) NULL,
 CONSTRAINT [PK__WmsInbou__DE2DE9BB34BC7C0B] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WmsInboundOrderTbl]    Script Date: 12/3/2020 7:42:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WmsInboundOrderTbl](
	[Id] [varchar](50) NOT NULL,
	[ExternalNo] [varchar](50) NULL,
	[ExternalType] [varchar](50) NULL,
	[Status] [int] NOT NULL,
	[OrderType] [varchar](50) NOT NULL,
	[GoodsType] [varchar](50) NULL,
	[PurchaseNo] [varchar](30) NULL,
	[StockId] [varchar](12) NOT NULL,
	[OwnerId] [varchar](50) NULL,
	[ShipperId] [varchar](50) NULL,
	[SupplierId] [varchar](50) NULL,
	[ScheduledInboundTime] [datetime2](7) NULL,
	[Remark] [varchar](256) NULL,
	[Enable] [bit] NOT NULL,
	[TransferType] [varchar](50) NULL,
	[InBondedArea] [bit] NOT NULL,
	[ReturnBoxNum] [decimal](8, 0) NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[CreateUserId] [varchar](50) NOT NULL,
	[CreateUserName] [varchar](200) NOT NULL,
	[UpdateTime] [datetime2](7) NULL,
	[UpdateUserId] [varchar](50) NULL,
	[UpdateUserName] [varchar](200) NULL,
	[OrgId] [varchar](50) NULL,
 CONSTRAINT [PK__WmsInbou__3214EC070A6E292B] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = OFF, ALLOW_PAGE_LOCKS = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Adm.Users] ADD  DEFAULT (CONVERT([bit],(0))) FOR [Builtin]
GO
ALTER TABLE [dbo].[OpenJob] ADD  DEFAULT ((0)) FOR [RunCount]
GO
ALTER TABLE [dbo].[OpenJob] ADD  DEFAULT ((0)) FOR [ErrorCount]
GO
ALTER TABLE [dbo].[OpenJob] ADD  DEFAULT ((0)) FOR [JobType]
GO
ALTER TABLE [dbo].[OpenJob] ADD  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[OpenJob] ADD  DEFAULT (getdate()) FOR [CreateTime]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表英文全称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'TableName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'表描述、中文名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'Comment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子表英文全称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'DetailTableName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'子表描述、中文名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'DetailComment'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实体类名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'ClassName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'命名空间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'Namespace'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'ModuleCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'模块名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'ModuleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代码相对文件夹路径' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'Folder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其它生成选项' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'Options'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'TypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'TypeName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'UpdateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'修改人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'UpdateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable', @level2type=N'COLUMN',@level2name=N'CreateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代码生成器的表信息' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BuilderTable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类名称或描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'DtCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通常与分类标识一致，但万一有不一样的情况呢？' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'DtValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'SortNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'CreateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'UpdateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category', @level2type=N'COLUMN',@level2name=N'UpdateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类表，也可用作数据字典。表示一个全集，比如：男、女、未知。关联的分类类型表示按什么进行的分类，如：按照性别对人类对象集' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Category'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数据ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataPrivilegeRule', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资源标识（模块编号）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataPrivilegeRule', @level2type=N'COLUMN',@level2name=N'SourceCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'二级资源标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataPrivilegeRule', @level2type=N'COLUMN',@level2name=N'SubSourceCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataPrivilegeRule', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataPrivilegeRule', @level2type=N'COLUMN',@level2name=N'SortNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'权限规则' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataPrivilegeRule', @level2type=N'COLUMN',@level2name=N'PrivilegeRules'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataPrivilegeRule', @level2type=N'COLUMN',@level2name=N'Enable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataPrivilegeRule', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataPrivilegeRule', @level2type=N'COLUMN',@level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataPrivilegeRule', @level2type=N'COLUMN',@level2name=N'CreateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataPrivilegeRule', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataPrivilegeRule', @level2type=N'COLUMN',@level2name=N'UpdateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataPrivilegeRule', @level2type=N'COLUMN',@level2name=N'UpdateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统授权规制表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DataPrivilegeRule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Id' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'JobName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务执行次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'RunCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'异常次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'ErrorCount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'下次执行时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'NextRunTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次执行时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'LastRunTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后一次失败时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'LastErrorTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务执行方式0：本地任务；1：外部接口任务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'JobType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'JobCall'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务参数，JSON格式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'JobCallParams'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CRON表达式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'Cron'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'任务运行状态（0：停止，1：正在运行，2：暂停）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'CreateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'UpdateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'UpdateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'定时任务' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OpenJob'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资源标识' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'节点语义ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'CascadeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'Name'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'排序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'SortNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'Description'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父节点名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'ParentName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父节点流ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资源所属应用ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'AppId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属应用名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'AppName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'TypeName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'TypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否可用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'Disable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'CreateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'UpdateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource', @level2type=N'COLUMN',@level2name=N'UpdateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'资源表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Resource'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库通知单明细号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库通知单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'OrderId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'含税单价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'Price'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'无税单价' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'PriceNoTax'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否收货中(0:非收货中,1:收货中)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'InStockStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'到货状况(SYS_GOODSARRIVESTATUS)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'AsnStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'GoodsId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品批号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'GoodsBatch'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品质(SYS_QUALITYFLAG)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'QualityFlg'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通知数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'OrderNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'到货数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'InNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'剩余数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'LeaveNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'占用数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'HoldNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'ProdDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'失效日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'ExpireDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税率' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'TaxRate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货主编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'OwnerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'CreateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'UpdateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl', @level2type=N'COLUMN',@level2name=N'UpdateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库通知单明细' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderDtbl'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库通知单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'相关单据号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'ExternalNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'相关单据类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'ExternalType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库通知单状态(SYS_INSTCINFORMSTATUS)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'Status'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库类型(SYS_INSTCTYPE)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'OrderType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品类别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'GoodsType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'采购单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'PurchaseNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'StockId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货主编号(固定值CQM)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'OwnerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'承运人编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'ShipperId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'SupplierId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'预定入库时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'ScheduledInboundTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'有效标志' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'Enable'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'承运方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'TransferType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否入保税库(0:否,1:是)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'InBondedArea'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销退箱数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'ReturnBoxNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'CreateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'CreateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'UpdateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新人ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'UpdateUserId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最后更新人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'UpdateUserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl', @level2type=N'COLUMN',@level2name=N'OrgId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库通知单（入库订单）' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WmsInboundOrderTbl'
GO
USE [master]
GO
ALTER DATABASE [LiggErpTesting] SET  READ_WRITE 
GO
