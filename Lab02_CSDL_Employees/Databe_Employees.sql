--USE MASTER;
--GO
----DROP DATABASE ExamWinForm;
--go
--CREATE DATABASE ExamWinForm;
--go
--USE [ExamWinForm]
--GO 
--SET ANSI_NULLS ON
--GO
--SET QUOTED_IDENTIFIER ON
--GO
--SET ANSI_PADDING ON
--GO
CREATE TABLE [dbo].[Departments](
	[DeptID] [char](3) NOT NULL,
	[DeptName] [nvarchar](50) NULL,
 CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED 
(
	[DeptID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Departments] ([DeptID], [DeptName]) VALUES (N'ACC', N'Accounting')
INSERT [dbo].[Departments] ([DeptID], [DeptName]) VALUES (N'ADM', N'Administration')
INSERT [dbo].[Departments] ([DeptID], [DeptName]) VALUES (N'DTY', N'DTY')
INSERT [dbo].[Departments] ([DeptID], [DeptName]) VALUES (N'ENG', N'Engineering')
INSERT [dbo].[Departments] ([DeptID], [DeptName]) VALUES (N'FVC', N'F & A')
INSERT [dbo].[Departments] ([DeptID], [DeptName]) VALUES (N'MAR', N'Marketing')
 
SET ANSI_NULLS ON
GO 
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON  
GO
CREATE TABLE [dbo].[Employees](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeName] [nvarchar](250) NOT NULL CHECK (LEN([EmployeeName])>5),
	[DeptID] [char](3) NOT NULL,
	[Gender] [bit] NOT NULL,
	[BirthDate] [datetime] NULL CHECK (YEAR([BirthDate])<=1999),
	[Tel] [nvarchar](50) NOT NULL CHECK (LEN([Tel])>6 AND LEFT([Tel],1)='0'),
	[Address] [nvarchar](500) NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO 
SET IDENTITY_INSERT [dbo].[Employees] ON
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeName], [DeptID], [Gender], [BirthDate], [Tel], [Address]) VALUES (3, N'Dang Thuy  Thi ', N'ACC', 0, CAST(0x0000637300000000 AS DateTime), N'071.838432', N'287 Phan Dinh Phung')
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeName], [DeptID], [Gender], [BirthDate], [Tel], [Address]) VALUES (4, N'Nguyen Quoc  Van ', N'ADM', 1, CAST(0x00006A4400000000 AS DateTime), N'065.853710', N'126  block S -Nguyen Kim Dept.')
INSERT [dbo].[Employees] ([EmployeeID], [EmployeeName], [DeptID], [Gender], [BirthDate], [Tel], [Address]) VALUES (5, N'Mai Hoang Van ', N'ENG', 1, CAST(0x0000654400000000 AS DateTime), N'08.8950450', N'183/7/8A NguyenThai Son')
SET IDENTITY_INSERT [dbo].[Employees] OFF
/****** Object:  ForeignKey [FK_Employees_Departments]    Script Date: 07/18/2011 19:05:26 ******/
ALTER TABLE [dbo].[Employees]  WITH CHECK ADD  CONSTRAINT [FK_Employees_Departments] FOREIGN KEY([DeptID])
REFERENCES [dbo].[Departments] ([DeptID])
GO
ALTER TABLE [dbo].[Employees] CHECK CONSTRAINT [FK_Employees_Departments]
GO
