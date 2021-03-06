USE [master]
GO
/****** Object:  Database [TextQuestDatabase]    Script Date: 13.02.2019 10:24:31 ******/
CREATE DATABASE [TextQuestDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TextQuestDatabase', FILENAME = N'C:\Users\Student\TextQuestDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TextQuestDatabase_log', FILENAME = N'C:\Users\Student\TextQuestDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [TextQuestDatabase] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TextQuestDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TextQuestDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [TextQuestDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TextQuestDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TextQuestDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET  ENABLE_BROKER 
GO
ALTER DATABASE [TextQuestDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TextQuestDatabase] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [TextQuestDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TextQuestDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [TextQuestDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TextQuestDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TextQuestDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TextQuestDatabase] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TextQuestDatabase] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TextQuestDatabase] SET QUERY_STORE = OFF
GO
USE [TextQuestDatabase]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [TextQuestDatabase]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 13.02.2019 10:24:31 ******/
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
/****** Object:  Table [dbo].[Interactions]    Script Date: 13.02.2019 10:24:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SceneObjectId] [int] NULL,
	[InventoryObjectId] [int] NULL,
	[NextInteractionId] [int] NULL,
 CONSTRAINT [PK_Interactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Inventories]    Script Date: 13.02.2019 10:24:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Inventories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Inventories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InventoryObjects]    Script Date: 13.02.2019 10:24:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InventoryObjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Decription] [nvarchar](max) NOT NULL,
	[IsInfinite] [bit] NOT NULL,
	[ImageUrl] [nvarchar](max) NULL,
	[InventoryId] [int] NULL,
 CONSTRAINT [PK_InventoryObjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SceneObjects]    Script Date: 13.02.2019 10:24:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SceneObjects](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[x] [int] NULL,
	[y] [int] NULL,
	[z] [int] NULL,
	[IsPickable] [bit] NOT NULL,
	[IsSpawned] [bit] NULL,
	[IsInnerPass] [bit] NULL,
	[HasAction] [bit] NOT NULL,
	[AssociatedInventoryObjectId] [int] NULL,
	[SceneId] [int] NULL,
	[ImageUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_SceneObjects] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scenes]    Script Date: 13.02.2019 10:24:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scenes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BackgroundImageUrl] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[UpperSceneId] [int] NULL,
	[DownSceneId] [int] NULL,
	[LeftSceneId] [int] NULL,
	[RightSceneId] [int] NULL,
	[InnerSceneId] [int] NULL,
 CONSTRAINT [PK_Scenes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190211103950_initial migration', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190211130338_SceneObject entity rework', N'2.1.4-rtm-31024')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190211134300_Scene entity rework', N'2.1.4-rtm-31024')
SET IDENTITY_INSERT [dbo].[InventoryObjects] ON 

INSERT [dbo].[InventoryObjects] ([Id], [Name], [Decription], [IsInfinite], [ImageUrl], [InventoryId]) VALUES (1, N'Ключ', N'Видавший виды бронзовый ключ', 0, N'\images\key.png', NULL)
SET IDENTITY_INSERT [dbo].[InventoryObjects] OFF
SET IDENTITY_INSERT [dbo].[SceneObjects] ON 

INSERT [dbo].[SceneObjects] ([Id], [Name], [Description], [x], [y], [z], [IsPickable], [IsSpawned], [IsInnerPass], [HasAction], [AssociatedInventoryObjectId], [SceneId], [ImageUrl]) VALUES (1, N'Стол', N'Простой деревянный стол', 450, 400, 8, 0, 0, 0, 0, NULL, 1, N'/images/table.png')
INSERT [dbo].[SceneObjects] ([Id], [Name], [Description], [x], [y], [z], [IsPickable], [IsSpawned], [IsInnerPass], [HasAction], [AssociatedInventoryObjectId], [SceneId], [ImageUrl]) VALUES (2, N'Ключ', N'Потертый бронзовый ключ', 500, 420, 7, 1, 0, 0, 0, 1, 1, N'/images/key.png')
INSERT [dbo].[SceneObjects] ([Id], [Name], [Description], [x], [y], [z], [IsPickable], [IsSpawned], [IsInnerPass], [HasAction], [AssociatedInventoryObjectId], [SceneId], [ImageUrl]) VALUES (3, N'Замочная скважина', N'Почему она не на двери?', 380, 250, 9, 0, 0, 0, 1, NULL, 1, N'/images/lock.png')
INSERT [dbo].[SceneObjects] ([Id], [Name], [Description], [x], [y], [z], [IsPickable], [IsSpawned], [IsInnerPass], [HasAction], [AssociatedInventoryObjectId], [SceneId], [ImageUrl]) VALUES (4, N'Дверь', N'Да она же фанерная', 80, 190, 10, 0, 0, 0, 1, NULL, 1, N'/images/door_closed.png')
INSERT [dbo].[SceneObjects] ([Id], [Name], [Description], [x], [y], [z], [IsPickable], [IsSpawned], [IsInnerPass], [HasAction], [AssociatedInventoryObjectId], [SceneId], [ImageUrl]) VALUES (6, N'Открытая дверь', N'Она довольно открыта', 0, 0, 0, 0, 1, 1, 0, NULL, 1, N'/images/door_open.png')
SET IDENTITY_INSERT [dbo].[SceneObjects] OFF
SET IDENTITY_INSERT [dbo].[Scenes] ON 

INSERT [dbo].[Scenes] ([Id], [BackgroundImageUrl], [Description], [UpperSceneId], [DownSceneId], [LeftSceneId], [RightSceneId], [InnerSceneId]) VALUES (1, N'/images/background.png', N'Тестовая комната', 0, 0, 0, 3, 0)
INSERT [dbo].[Scenes] ([Id], [BackgroundImageUrl], [Description], [UpperSceneId], [DownSceneId], [LeftSceneId], [RightSceneId], [InnerSceneId]) VALUES (3, N'/images/back2.jpg', N'Тестовая комната 2', 0, 0, 1, 0, 0)
SET IDENTITY_INSERT [dbo].[Scenes] OFF
/****** Object:  Index [IX_InventoryObjects_InventoryId]    Script Date: 13.02.2019 10:24:38 ******/
CREATE NONCLUSTERED INDEX [IX_InventoryObjects_InventoryId] ON [dbo].[InventoryObjects]
(
	[InventoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SceneObjects_AssociatedInventoryObjectId]    Script Date: 13.02.2019 10:24:38 ******/
CREATE NONCLUSTERED INDEX [IX_SceneObjects_AssociatedInventoryObjectId] ON [dbo].[SceneObjects]
(
	[AssociatedInventoryObjectId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_SceneObjects_SceneId]    Script Date: 13.02.2019 10:24:38 ******/
CREATE NONCLUSTERED INDEX [IX_SceneObjects_SceneId] ON [dbo].[SceneObjects]
(
	[SceneId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Interactions]  WITH CHECK ADD  CONSTRAINT [FK_Interactions_Interactions] FOREIGN KEY([NextInteractionId])
REFERENCES [dbo].[Interactions] ([Id])
GO
ALTER TABLE [dbo].[Interactions] CHECK CONSTRAINT [FK_Interactions_Interactions]
GO
ALTER TABLE [dbo].[Interactions]  WITH CHECK ADD  CONSTRAINT [FK_Interactions_InventoryObjects] FOREIGN KEY([InventoryObjectId])
REFERENCES [dbo].[InventoryObjects] ([Id])
GO
ALTER TABLE [dbo].[Interactions] CHECK CONSTRAINT [FK_Interactions_InventoryObjects]
GO
ALTER TABLE [dbo].[Interactions]  WITH CHECK ADD  CONSTRAINT [FK_Interactions_SceneObjects] FOREIGN KEY([SceneObjectId])
REFERENCES [dbo].[SceneObjects] ([Id])
GO
ALTER TABLE [dbo].[Interactions] CHECK CONSTRAINT [FK_Interactions_SceneObjects]
GO
ALTER TABLE [dbo].[InventoryObjects]  WITH CHECK ADD  CONSTRAINT [FK_InventoryObjects_Inventories_InventoryId] FOREIGN KEY([InventoryId])
REFERENCES [dbo].[Inventories] ([Id])
GO
ALTER TABLE [dbo].[InventoryObjects] CHECK CONSTRAINT [FK_InventoryObjects_Inventories_InventoryId]
GO
ALTER TABLE [dbo].[SceneObjects]  WITH CHECK ADD  CONSTRAINT [FK_SceneObjects_InventoryObjects_AssociatedInventoryObjectId] FOREIGN KEY([AssociatedInventoryObjectId])
REFERENCES [dbo].[InventoryObjects] ([Id])
GO
ALTER TABLE [dbo].[SceneObjects] CHECK CONSTRAINT [FK_SceneObjects_InventoryObjects_AssociatedInventoryObjectId]
GO
ALTER TABLE [dbo].[SceneObjects]  WITH CHECK ADD  CONSTRAINT [FK_SceneObjects_Scenes_SceneId] FOREIGN KEY([SceneId])
REFERENCES [dbo].[Scenes] ([Id])
GO
ALTER TABLE [dbo].[SceneObjects] CHECK CONSTRAINT [FK_SceneObjects_Scenes_SceneId]
GO
USE [master]
GO
ALTER DATABASE [TextQuestDatabase] SET  READ_WRITE 
GO
