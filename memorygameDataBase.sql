USE [master]
GO
/****** Object:  Database [memorygame]    Script Date: 1/29/2019 2:07:01 PM ******/
CREATE DATABASE [memorygame]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'memorygame', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\memorygame.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'memorygame_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\memorygame_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [memorygame] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [memorygame].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [memorygame] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [memorygame] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [memorygame] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [memorygame] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [memorygame] SET ARITHABORT OFF 
GO
ALTER DATABASE [memorygame] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [memorygame] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [memorygame] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [memorygame] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [memorygame] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [memorygame] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [memorygame] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [memorygame] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [memorygame] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [memorygame] SET  DISABLE_BROKER 
GO
ALTER DATABASE [memorygame] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [memorygame] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [memorygame] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [memorygame] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [memorygame] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [memorygame] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [memorygame] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [memorygame] SET RECOVERY FULL 
GO
ALTER DATABASE [memorygame] SET  MULTI_USER 
GO
ALTER DATABASE [memorygame] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [memorygame] SET DB_CHAINING OFF 
GO
ALTER DATABASE [memorygame] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [memorygame] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [memorygame] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [memorygame] SET QUERY_STORE = OFF
GO
USE [memorygame]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [memorygame]
GO
/****** Object:  Table [dbo].[GameResults]    Script Date: 1/29/2019 2:07:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GameResults](
	[GameResultID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[DatePlayed] [datetime] NOT NULL,
	[GameSessionLength] [time](0) NOT NULL,
	[StepsTaken] [int] NOT NULL,
 CONSTRAINT [PK_GameResults] PRIMARY KEY CLUSTERED 
(
	[GameResultID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 1/29/2019 2:07:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[ImageID] [int] IDENTITY(1,1) NOT NULL,
	[ImageName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 1/29/2019 2:07:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[DateAdded] [datetime] NOT NULL,
	[Phone] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Message] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 1/29/2019 2:07:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NULL,
	[DateOfBirth] [date] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersFeedback]    Script Date: 1/29/2019 2:07:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersFeedback](
	[FeedbackID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[FeedbackDate] [datetime] NOT NULL,
	[FeedbackText] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_UsersFeedback] PRIMARY KEY CLUSTERED 
(
	[FeedbackID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[GameResults] ON 

INSERT [dbo].[GameResults] ([GameResultID], [UserID], [DatePlayed], [GameSessionLength], [StepsTaken]) VALUES (124, 150, CAST(N'2019-01-28T12:33:00.920' AS DateTime), CAST(N'00:00:40' AS Time), 30)
INSERT [dbo].[GameResults] ([GameResultID], [UserID], [DatePlayed], [GameSessionLength], [StepsTaken]) VALUES (125, 151, CAST(N'2019-01-28T12:36:34.210' AS DateTime), CAST(N'00:00:54' AS Time), 36)
INSERT [dbo].[GameResults] ([GameResultID], [UserID], [DatePlayed], [GameSessionLength], [StepsTaken]) VALUES (126, 152, CAST(N'2019-01-28T12:39:58.267' AS DateTime), CAST(N'00:00:46' AS Time), 34)
INSERT [dbo].[GameResults] ([GameResultID], [UserID], [DatePlayed], [GameSessionLength], [StepsTaken]) VALUES (127, 153, CAST(N'2019-01-28T12:42:05.183' AS DateTime), CAST(N'00:00:45' AS Time), 32)
INSERT [dbo].[GameResults] ([GameResultID], [UserID], [DatePlayed], [GameSessionLength], [StepsTaken]) VALUES (128, 154, CAST(N'2019-01-28T12:44:54.013' AS DateTime), CAST(N'00:01:00' AS Time), 40)
INSERT [dbo].[GameResults] ([GameResultID], [UserID], [DatePlayed], [GameSessionLength], [StepsTaken]) VALUES (129, 156, CAST(N'2019-01-28T19:47:06.297' AS DateTime), CAST(N'00:00:54' AS Time), 34)
SET IDENTITY_INSERT [dbo].[GameResults] OFF
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([ImageID], [ImageName]) VALUES (2, N'arial.jpg')
INSERT [dbo].[Images] ([ImageID], [ImageName]) VALUES (3, N'eric.jpg')
INSERT [dbo].[Images] ([ImageID], [ImageName]) VALUES (4, N'flounder.jpg')
INSERT [dbo].[Images] ([ImageID], [ImageName]) VALUES (5, N'orsola-young.jpg')
INSERT [dbo].[Images] ([ImageID], [ImageName]) VALUES (6, N'orsola.jpg')
INSERT [dbo].[Images] ([ImageID], [ImageName]) VALUES (7, N'scuttle.jpg')
INSERT [dbo].[Images] ([ImageID], [ImageName]) VALUES (8, N'sebas.jpg')
INSERT [dbo].[Images] ([ImageID], [ImageName]) VALUES (9, N'triton.jpg')
SET IDENTITY_INSERT [dbo].[Images] OFF
SET IDENTITY_INSERT [dbo].[Messages] ON 

INSERT [dbo].[Messages] ([MessageID], [DateAdded], [Phone], [Email], [Message]) VALUES (28, CAST(N'2019-01-24T07:37:25.653' AS DateTime), NULL, NULL, N'Do you have more games?')
INSERT [dbo].[Messages] ([MessageID], [DateAdded], [Phone], [Email], [Message]) VALUES (29, CAST(N'2019-01-24T07:38:19.907' AS DateTime), N'052-9685743', N'we@gmail.com', N'You Rock!')
INSERT [dbo].[Messages] ([MessageID], [DateAdded], [Phone], [Email], [Message]) VALUES (30, CAST(N'2019-01-24T07:41:57.863' AS DateTime), N'054-8383842', NULL, N'My kids love this game!')
INSERT [dbo].[Messages] ([MessageID], [DateAdded], [Phone], [Email], [Message]) VALUES (31, CAST(N'2019-01-28T12:34:17.883' AS DateTime), N'053-4456935', NULL, N'Love this game, Thank you!')
INSERT [dbo].[Messages] ([MessageID], [DateAdded], [Phone], [Email], [Message]) VALUES (32, CAST(N'2019-01-28T12:52:58.417' AS DateTime), N'056-5464535', NULL, N'Do you have more  games like this one?')
SET IDENTITY_INSERT [dbo].[Messages] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([UserID], [FullName], [UserName], [Password], [Email], [DateOfBirth]) VALUES (150, N'Shelly Rubin', N'Shelly1', N'Shelly123', N'shelly@gmail.com', CAST(N'1992-02-03' AS Date))
INSERT [dbo].[Users] ([UserID], [FullName], [UserName], [Password], [Email], [DateOfBirth]) VALUES (151, N'Ben Candy', N'beny', N'benben', N'ben@gmail.com', CAST(N'2012-02-06' AS Date))
INSERT [dbo].[Users] ([UserID], [FullName], [UserName], [Password], [Email], [DateOfBirth]) VALUES (152, N'Gal Bon', N'Gali', N'gal12', NULL, CAST(N'1998-02-09' AS Date))
INSERT [dbo].[Users] ([UserID], [FullName], [UserName], [Password], [Email], [DateOfBirth]) VALUES (153, N'Amit S', N'amiti', N'amiti', NULL, NULL)
INSERT [dbo].[Users] ([UserID], [FullName], [UserName], [Password], [Email], [DateOfBirth]) VALUES (154, N'Kate Midel', N'katie', N'royal', N'kate@gmail.com', NULL)
INSERT [dbo].[Users] ([UserID], [FullName], [UserName], [Password], [Email], [DateOfBirth]) VALUES (155, N'Lotam kan', N'lotam', N'lotam', NULL, CAST(N'2019-01-27' AS Date))
INSERT [dbo].[Users] ([UserID], [FullName], [UserName], [Password], [Email], [DateOfBirth]) VALUES (156, N'Gigi Kalef', N'gidi', N'gidi', N'gidi@gmail.com', CAST(N'1994-07-09' AS Date))
SET IDENTITY_INSERT [dbo].[Users] OFF
SET IDENTITY_INSERT [dbo].[UsersFeedback] ON 

INSERT [dbo].[UsersFeedback] ([FeedbackID], [UserID], [FeedbackDate], [FeedbackText]) VALUES (44, 150, CAST(N'2019-01-28T12:33:54.567' AS DateTime), N'Great Game!!')
INSERT [dbo].[UsersFeedback] ([FeedbackID], [UserID], [FeedbackDate], [FeedbackText]) VALUES (45, 151, CAST(N'2019-01-28T12:37:50.140' AS DateTime), N'I had a lot of fun:)')
INSERT [dbo].[UsersFeedback] ([FeedbackID], [UserID], [FeedbackDate], [FeedbackText]) VALUES (46, 152, CAST(N'2019-01-28T12:41:01.457' AS DateTime), N'Best Game ever!!')
INSERT [dbo].[UsersFeedback] ([FeedbackID], [UserID], [FeedbackDate], [FeedbackText]) VALUES (47, 153, CAST(N'2019-01-28T12:43:37.900' AS DateTime), N'I''m in love the little mermaid. LoL')
INSERT [dbo].[UsersFeedback] ([FeedbackID], [UserID], [FeedbackDate], [FeedbackText]) VALUES (48, 154, CAST(N'2019-01-28T12:46:34.587' AS DateTime), N'Classic game for all ages')
INSERT [dbo].[UsersFeedback] ([FeedbackID], [UserID], [FeedbackDate], [FeedbackText]) VALUES (49, 154, CAST(N'2019-01-28T12:54:46.483' AS DateTime), N'fun game')
INSERT [dbo].[UsersFeedback] ([FeedbackID], [UserID], [FeedbackDate], [FeedbackText]) VALUES (50, 156, CAST(N'2019-01-28T19:48:20.793' AS DateTime), N'I love you!:)')
SET IDENTITY_INSERT [dbo].[UsersFeedback] OFF
ALTER TABLE [dbo].[GameResults] ADD  CONSTRAINT [DF_Table_1_PlayDate]  DEFAULT (getdate()) FOR [DatePlayed]
GO
ALTER TABLE [dbo].[Messages] ADD  CONSTRAINT [DF_Messages_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[UsersFeedback] ADD  CONSTRAINT [DF_UsersFeedback_FeedbackDate]  DEFAULT (getdate()) FOR [FeedbackDate]
GO
ALTER TABLE [dbo].[GameResults]  WITH CHECK ADD  CONSTRAINT [FK__GameResul__UserI__4222D4EF] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[GameResults] CHECK CONSTRAINT [FK__GameResul__UserI__4222D4EF]
GO
ALTER TABLE [dbo].[UsersFeedback]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
USE [master]
GO
ALTER DATABASE [memorygame] SET  READ_WRITE 
GO
