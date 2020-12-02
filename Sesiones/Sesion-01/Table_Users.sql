USE [UsersDB]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 10/24/2020 12:21:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](255) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[Username] [varchar](50) NOT NULL
) ON [PRIMARY]
GO

