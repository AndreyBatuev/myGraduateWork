USE [BatuevDiplom]
GO
/****** Object:  User [andy]    Script Date: 22.05.2025 17:11:06 ******/
CREATE USER [andy] FOR LOGIN [andy] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [andy]
GO
/****** Object:  Table [dbo].[archive_zapis]    Script Date: 22.05.2025 17:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[archive_zapis](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[dateZapis] [datetime] NOT NULL,
	[doctorName] [nvarchar](255) NOT NULL,
	[doctorSpec] [nvarchar](255) NOT NULL,
	[login] [nvarchar](100) NOT NULL,
	[treatment] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[emplo]    Script Date: 22.05.2025 17:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[emplo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nvarchar](255) NOT NULL,
	[password] [nvarchar](255) NOT NULL,
	[root] [bit] NULL,
	[first_name] [nvarchar](255) NULL,
	[last_name] [nvarchar](255) NULL,
	[middle_name] [nvarchar](255) NULL,
	[specialization] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 22.05.2025 17:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NameLogin] [varchar](50) NOT NULL,
	[pass] [varchar](50) NULL,
	[firstName] [nvarchar](255) NULL,
	[surName] [nvarchar](255) NULL,
	[otchestvo] [nvarchar](255) NULL,
	[serPass] [varchar](50) NULL,
	[numPass] [varchar](50) NULL,
	[PolisOMS] [varchar](50) NULL,
	[Snils] [varchar](50) NULL,
	[birthDate] [date] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[zapis]    Script Date: 22.05.2025 17:11:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[zapis](
	[dateZapis] [datetime] NOT NULL,
	[doctorName] [nvarchar](255) NULL,
	[doctorSpec] [nvarchar](255) NULL,
	[login] [nvarchar](255) NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[archive_zapis] ON 

INSERT [dbo].[archive_zapis] ([id], [dateZapis], [doctorName], [doctorSpec], [login], [treatment]) VALUES (2, CAST(N'2025-03-01T12:00:00.000' AS DateTime), N'Ольга Викторовна Смирнова', N'Терапевт', N'Olya', N'Инсулин')
INSERT [dbo].[archive_zapis] ([id], [dateZapis], [doctorName], [doctorSpec], [login], [treatment]) VALUES (3, CAST(N'2025-03-16T13:40:00.000' AS DateTime), N'Ольга Викторовна Смирнова', N'Терапевт', N'BatuevAV', N'Активированный уголь')
INSERT [dbo].[archive_zapis] ([id], [dateZapis], [doctorName], [doctorSpec], [login], [treatment]) VALUES (4, CAST(N'2025-03-16T10:30:00.000' AS DateTime), N'Ольга Викторовна Смирнова', N'Терапевт', N'Leo', N'Витамины группы B')
SET IDENTITY_INSERT [dbo].[archive_zapis] OFF
SET IDENTITY_INSERT [dbo].[emplo] ON 

INSERT [dbo].[emplo] ([id], [username], [password], [root], [first_name], [last_name], [middle_name], [specialization]) VALUES (1, N'root', N'toor', 1, N'root', N'rooter', N'rootovich', NULL)
INSERT [dbo].[emplo] ([id], [username], [password], [root], [first_name], [last_name], [middle_name], [specialization]) VALUES (4, N'anton', N'123', 0, N'Антон', N'Андреев', N'Батуев', N'Терапевт')
INSERT [dbo].[emplo] ([id], [username], [password], [root], [first_name], [last_name], [middle_name], [specialization]) VALUES (5, N'olga', N'456', 0, N'Ольга', N'Викторовна', N'Батуева', N'Терапевт')
INSERT [dbo].[emplo] ([id], [username], [password], [root], [first_name], [last_name], [middle_name], [specialization]) VALUES (6, N'dmitry', N'789', 0, N'Дмитрий', N'Сергеевич', N'Козлов', N'Терапевт')
INSERT [dbo].[emplo] ([id], [username], [password], [root], [first_name], [last_name], [middle_name], [specialization]) VALUES (7, N'elena', N'101', 0, N'Елена', N'Петрова', N'Сидорова', N'Хирург')
INSERT [dbo].[emplo] ([id], [username], [password], [root], [first_name], [last_name], [middle_name], [specialization]) VALUES (8, N'alexander', N'202', 0, N'Александр', N'Иванович', N'Морозов', N'Хирург')
INSERT [dbo].[emplo] ([id], [username], [password], [root], [first_name], [last_name], [middle_name], [specialization]) VALUES (9, N'irina', N'303', 0, N'Ирина', N'Александровна', N'Волкова', N'Хирург')
INSERT [dbo].[emplo] ([id], [username], [password], [root], [first_name], [last_name], [middle_name], [specialization]) VALUES (10, N'igor', N'404', 0, N'Игорь', N'Николаев', N'Иванов', N'Кардиолог')
INSERT [dbo].[emplo] ([id], [username], [password], [root], [first_name], [last_name], [middle_name], [specialization]) VALUES (11, N'tatyana', N'505', 0, N'Татьяна', N'Владимировна', N'Белова', N'Кардиолог')
INSERT [dbo].[emplo] ([id], [username], [password], [root], [first_name], [last_name], [middle_name], [specialization]) VALUES (12, N'sergey', N'606', 0, N'Сергей', N'Михайлович', N'Павлов', N'Кардиолог')
INSERT [dbo].[emplo] ([id], [username], [password], [root], [first_name], [last_name], [middle_name], [specialization]) VALUES (13, N'maria', N'707', 0, N'Мария', N'Сергеевна', N'Кузнецова', N'Невролог')
INSERT [dbo].[emplo] ([id], [username], [password], [root], [first_name], [last_name], [middle_name], [specialization]) VALUES (14, N'mariaAV', N'707', 0, N'Мария', N'Андреевна', N'Вальтер', N'Невролог')
INSERT [dbo].[emplo] ([id], [username], [password], [root], [first_name], [last_name], [middle_name], [specialization]) VALUES (15, N'mariaDD', N'707', 0, N'Мария', N'Дмитреевна', N'Демидидовна', N'Невролог')
INSERT [dbo].[emplo] ([id], [username], [password], [root], [first_name], [last_name], [middle_name], [specialization]) VALUES (16, N'mariaАА', N'707', 0, N'Мария', N'Алексадровна', N'Авдеева', N'Невролог')
SET IDENTITY_INSERT [dbo].[emplo] OFF
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [NameLogin], [pass], [firstName], [surName], [otchestvo], [serPass], [numPass], [PolisOMS], [Snils], [birthDate]) VALUES (6, N'BatuevAV', N'123', N'Андрей', N'Батуев', N'Валерьевич', N'2346', N'573645', N'12354386709', N'12547564845', CAST(N'2005-09-28' AS Date))
INSERT [dbo].[users] ([id], [NameLogin], [pass], [firstName], [surName], [otchestvo], [serPass], [numPass], [PolisOMS], [Snils], [birthDate]) VALUES (7, N'Leo', N'123', N'Леонид', N'Комаров', N'Романович', N'3241', N'765433', N'1234645613', N'2342765421', CAST(N'2005-10-25' AS Date))
INSERT [dbo].[users] ([id], [NameLogin], [pass], [firstName], [surName], [otchestvo], [serPass], [numPass], [PolisOMS], [Snils], [birthDate]) VALUES (4, N'Olya', N'123', N'Ольга', N'Яканова', N'Игоревна', N'4615', N'200200', N'2342342891', N'3452367327', CAST(N'2005-07-05' AS Date))
INSERT [dbo].[users] ([id], [NameLogin], [pass], [firstName], [surName], [otchestvo], [serPass], [numPass], [PolisOMS], [Snils], [birthDate]) VALUES (5, N'Olya11', N'123', N'Ольга', N'Яканова', N'Игоревна', N'46155', N'2002005', N'23423428915', N'34523673275', CAST(N'2005-07-11' AS Date))
SET IDENTITY_INSERT [dbo].[users] OFF
SET IDENTITY_INSERT [dbo].[zapis] ON 

INSERT [dbo].[zapis] ([dateZapis], [doctorName], [doctorSpec], [login], [id]) VALUES (CAST(N'2025-02-26T13:30:00.000' AS DateTime), N'Суворов Фёдор Романович', N'Терапевт', N'Olya', 7)
INSERT [dbo].[zapis] ([dateZapis], [doctorName], [doctorSpec], [login], [id]) VALUES (CAST(N'2025-02-27T12:20:00.000' AS DateTime), N'Кузнецова Яна Тимуровна', N'Терапевт', N'Olya', 8)
INSERT [dbo].[zapis] ([dateZapis], [doctorName], [doctorSpec], [login], [id]) VALUES (CAST(N'2025-02-28T11:30:00.000' AS DateTime), N'Мария Андреевна', N'Невролог', N'Olya', 9)
INSERT [dbo].[zapis] ([dateZapis], [doctorName], [doctorSpec], [login], [id]) VALUES (CAST(N'2025-02-28T11:30:00.000' AS DateTime), N'Ирина Александровна', N'Хирург', N'Olya', 10)
INSERT [dbo].[zapis] ([dateZapis], [doctorName], [doctorSpec], [login], [id]) VALUES (CAST(N'2025-02-27T18:20:00.000' AS DateTime), N'Мария Андреевна', N'Невролог', N'Olya', 11)
INSERT [dbo].[zapis] ([dateZapis], [doctorName], [doctorSpec], [login], [id]) VALUES (CAST(N'2025-02-26T12:30:00.000' AS DateTime), N'Ирина Александровна', N'Хирург', N'Olya', 12)
INSERT [dbo].[zapis] ([dateZapis], [doctorName], [doctorSpec], [login], [id]) VALUES (CAST(N'2025-02-26T12:30:00.000' AS DateTime), N'Ольга Викторовна', N'Терапевт', N'Olya', 13)
INSERT [dbo].[zapis] ([dateZapis], [doctorName], [doctorSpec], [login], [id]) VALUES (CAST(N'2025-02-26T12:30:00.000' AS DateTime), N'Игорь Николаев', N'Кардиолог', N'Olya', 14)
INSERT [dbo].[zapis] ([dateZapis], [doctorName], [doctorSpec], [login], [id]) VALUES (CAST(N'2025-03-01T10:40:00.000' AS DateTime), N'Антон Андреев Батуев', N'Терапевт', N'Olya', 15)
INSERT [dbo].[zapis] ([dateZapis], [doctorName], [doctorSpec], [login], [id]) VALUES (CAST(N'2025-03-01T10:00:00.000' AS DateTime), N'Мария Андреевна Вальтер', N'Невролог', N'Olya', 17)
INSERT [dbo].[zapis] ([dateZapis], [doctorName], [doctorSpec], [login], [id]) VALUES (CAST(N'2025-03-16T13:30:00.000' AS DateTime), N'Ольга Викторовна Смирнова', N'Терапевт', N'Olya', 18)
INSERT [dbo].[zapis] ([dateZapis], [doctorName], [doctorSpec], [login], [id]) VALUES (CAST(N'2025-03-16T10:40:00.000' AS DateTime), N'Ольга Викторовна Смирнова', N'Терапевт', N'Olya', 21)
SET IDENTITY_INSERT [dbo].[zapis] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__emplo__F3DBC572245286F5]    Script Date: 22.05.2025 17:11:06 ******/
ALTER TABLE [dbo].[emplo] ADD UNIQUE NONCLUSTERED 
(
	[username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[emplo] ADD  DEFAULT ((0)) FOR [root]
GO
