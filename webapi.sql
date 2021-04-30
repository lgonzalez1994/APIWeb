USE [webapi]
GO
/****** Object:  User [webapi]    Script Date: 30/04/2021 1:27:23 a. m. ******/
CREATE USER [webapi] FOR LOGIN [webapi] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [webapi]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [webapi]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [webapi]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [webapi]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [webapi]
GO
ALTER ROLE [db_datareader] ADD MEMBER [webapi]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [webapi]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [webapi]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [webapi]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 30/04/2021 1:27:23 a. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[id] [int] NOT NULL,
	[nombre] [varchar](30) NOT NULL,
	[apellido] [varchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](250) NOT NULL,
 CONSTRAINT [PK_usuarios] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [password]) VALUES (2, N'Luis1111', N'1111Gonzalez', N'lfg_1994@gmail.com.ar', N'ae2b1fca515949e5d54fb22b8ed95575')
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [password]) VALUES (3, N'Juan', N'Lozano', N'juan.lozano@gmail.com', N'ae2b1fca515949e5d54fb22b8ed95575')
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [password]) VALUES (4, N'Marcelo', N'Tinelli', N'marcelo.tinelli@gmail.com', N'ae2b1fca515949e5d54fb22b8ed95575')
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [password]) VALUES (5, N'Lionel', N'Messi', N'lionel.messi@gmail.com', N'ae2b1fca515949e5d54fb22b8ed95575')
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [password]) VALUES (6, N'Andres', N'Iniesta', N'andres.iniesta@gmail.com', N'ae2b1fca515949e5d54fb22b8ed95575')
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [password]) VALUES (7, N'Roman', N'Riquelme', N'juan.riquelme@gmail.com', N'ae2b1fca515949e5d54fb22b8ed95575')
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [password]) VALUES (8, N'Mariano', N'Iudica', N'mariano.iudica@gmail.com', N'ae2b1fca515949e5d54fb22b8ed95575')
INSERT [dbo].[Usuarios] ([id], [nombre], [apellido], [email], [password]) VALUES (9, N'Federico', N'Bueno', N'federico.bueno@gmail.com', N'ae2b1fca515949e5d54fb22b8ed95575')
