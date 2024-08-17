/*
 Navicat Premium Dump SQL

 Source Server         : sql-localhost
 Source Server Type    : SQL Server
 Source Server Version : 16001000 (16.00.1000)
 Source Host           : localhost:1433
 Source Catalog        : library
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000 (16.00.1000)
 File Encoding         : 65001

 Date: 16/08/2024 22:40:39
*/


-- ----------------------------
-- Table structure for Authors
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Authors]') AND type IN ('U'))
	DROP TABLE [dbo].[Authors]
GO

CREATE TABLE [dbo].[Authors] (
  [Id] uniqueidentifier DEFAULT newid() NOT NULL,
  [FirstName] nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [LastName] nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Active] bit DEFAULT 1 NOT NULL,
  [CreateddAt] datetime DEFAULT getdate() NULL
)
GO

ALTER TABLE [dbo].[Authors] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Authors
-- ----------------------------

-- ----------------------------
-- Table structure for Authtokens
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Authtokens]') AND type IN ('U'))
	DROP TABLE [dbo].[Authtokens]
GO

CREATE TABLE [dbo].[Authtokens] (
  [Id] uniqueidentifier DEFAULT newid() NOT NULL,
  [UserID] uniqueidentifier  NOT NULL,
  [Token] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [CreatedAt] datetime DEFAULT getdate() NULL,
  [ExpiresAt] datetime2(7)  NULL,
  [IsRevoked] bit  NULL,
  [RevokedAt] datetime2(7)  NULL
)
GO

ALTER TABLE [dbo].[Authtokens] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Authtokens
-- ----------------------------
INSERT INTO [dbo].[Authtokens] ([Id], [UserID], [Token], [CreatedAt], [ExpiresAt], [IsRevoked], [RevokedAt]) VALUES (N'D1A46DC9-331F-4FBD-A8DD-59C6E6F09797', N'6D945F18-8F8E-4AA4-B96B-439AD3200E03', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjZkOTQ1ZjE4LThmOGUtNGFhNC1iOTZiLTQzOWFkMzIwMGUwMyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJSYWhtYW4iLCJuYmYiOjE3MjM4MTQxNjgsImV4cCI6MTcyMzgxNzc2OH0.ZtTX3eEVlkIR9JS0xhoVVxEe6I5qWokwJGM67SMTwx0', N'2024-08-16 16:46:08.863', N'2024-08-16 17:46:08.8652158', N'0', N'0001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[Authtokens] ([Id], [UserID], [Token], [CreatedAt], [ExpiresAt], [IsRevoked], [RevokedAt]) VALUES (N'9C1DDF39-9DA6-450E-B185-741CC17B66FB', N'FD4168CD-3D16-4E30-9D2F-03FFBDFC94E5', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImZkNDE2OGNkLTNkMTYtNGUzMC05ZDJmLTAzZmZiZGZjOTRlNSIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJJcmFuIiwibmJmIjoxNzIzODExNzA3LCJleHAiOjE3MjM4MTUzMDd9.GcGsF_yZYlgngGsFCeEoz2RE5CMn3sTt4DioB4XqDF0', N'2024-08-16 16:05:07.990', N'2024-08-16 17:05:07.9855775', N'0', N'0001-01-01 00:00:00.0000000')
GO

INSERT INTO [dbo].[Authtokens] ([Id], [UserID], [Token], [CreatedAt], [ExpiresAt], [IsRevoked], [RevokedAt]) VALUES (N'2B060F27-5326-49BB-BB1F-BB83B3CD7F7D', N'6D945F18-8F8E-4AA4-B96B-439AD3200E03', N'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjZkOTQ1ZjE4LThmOGUtNGFhNC1iOTZiLTQzOWFkMzIwMGUwMyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJSYWhtYW4iLCJuYmYiOjE3MjM4MTQxMjcsImV4cCI6MTcyMzgxNzcyN30.PMZpcbVTxHgilhDBzGEEftivRTnuHx-fhG-xZyXa27c', N'2024-08-16 16:45:28.183', N'2024-08-16 17:45:27.9128957', N'0', N'0001-01-01 00:00:00.0000000')
GO


-- ----------------------------
-- Table structure for Books
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Books]') AND type IN ('U'))
	DROP TABLE [dbo].[Books]
GO

CREATE TABLE [dbo].[Books] (
  [Id] uniqueidentifier DEFAULT newid() NOT NULL,
  [Name] nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Isbn] nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [CategoryId] uniqueidentifier  NOT NULL,
  [AuthorId] uniqueidentifier  NOT NULL,
  [PublishYear] int  NULL,
  [CreatedAt] datetime DEFAULT getdate() NULL,
  [Active] bit DEFAULT 1 NOT NULL
)
GO

ALTER TABLE [dbo].[Books] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Books
-- ----------------------------

-- ----------------------------
-- Table structure for Categories
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Categories]') AND type IN ('U'))
	DROP TABLE [dbo].[Categories]
GO

CREATE TABLE [dbo].[Categories] (
  [Id] uniqueidentifier DEFAULT newid() NOT NULL,
  [Name] nvarchar(256) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Active] bit DEFAULT 1 NOT NULL,
  [CreateddAt] datetime DEFAULT getdate() NULL
)
GO

ALTER TABLE [dbo].[Categories] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Categories
-- ----------------------------
INSERT INTO [dbo].[Categories] ([Id], [Name], [Active], [CreateddAt]) VALUES (N'5C17F862-84F3-4A08-B468-04242FE31E30', N'علمی', N'0', N'2024-08-16 22:33:06.743')
GO

INSERT INTO [dbo].[Categories] ([Id], [Name], [Active], [CreateddAt]) VALUES (N'B28048DA-E072-4AA9-B289-72B4201CDC6F', N'کودک', N'0', N'2024-08-16 22:34:54.303')
GO


-- ----------------------------
-- Table structure for Roles
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Roles]') AND type IN ('U'))
	DROP TABLE [dbo].[Roles]
GO

CREATE TABLE [dbo].[Roles] (
  [Id] int  IDENTITY(1,1) NOT NULL,
  [Name] nvarchar(50) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Description] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [Active] bit DEFAULT 1 NULL,
  [CreatedAt] datetime DEFAULT getdate() NULL,
  [UpdatedAt] datetime  NULL
)
GO

ALTER TABLE [dbo].[Roles] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Roles
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Roles] ON
GO

INSERT INTO [dbo].[Roles] ([Id], [Name], [Description], [Active], [CreatedAt], [UpdatedAt]) VALUES (N'1', N'member', NULL, N'0', N'2024-08-16 06:46:03.020', NULL)
GO

INSERT INTO [dbo].[Roles] ([Id], [Name], [Description], [Active], [CreatedAt], [UpdatedAt]) VALUES (N'2', N'admin', NULL, N'0', N'2024-08-16 16:16:04.787', NULL)
GO

SET IDENTITY_INSERT [dbo].[Roles] OFF
GO


-- ----------------------------
-- Table structure for Users
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type IN ('U'))
	DROP TABLE [dbo].[Users]
GO

CREATE TABLE [dbo].[Users] (
  [Id] uniqueidentifier DEFAULT newid() NOT NULL,
  [Email] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [FirstName] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [LastName] nvarchar(100) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [PasswordHash] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [RoleID] int  NULL,
  [CreatedAt] datetime DEFAULT getdate() NULL,
  [UpdatedAt] datetime  NULL,
  [Active] bit DEFAULT 1 NULL
)
GO

ALTER TABLE [dbo].[Users] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Users
-- ----------------------------
INSERT INTO [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [PasswordHash], [RoleID], [CreatedAt], [UpdatedAt], [Active]) VALUES (N'FD4168CD-3D16-4E30-9D2F-03FFBDFC94E5', N'Iran15@gmail.com', N'Iran', N'Banoo', N'$MYHASH$V1$10000$3Hy57sIFHEEY7xHXtdO9tukFX95o145ci4l5wMEQknfyuyQK', N'1', N'2024-08-16 08:54:41.240', NULL, N'0')
GO

INSERT INTO [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [PasswordHash], [RoleID], [CreatedAt], [UpdatedAt], [Active]) VALUES (N'DF9BC08C-42F1-4143-AF00-111C0D7A4C9B', N'rahman2@gmail.com', N'rrr', N'jjj', N'$MYHASH$V1$10000$ZZQMHtH09rQRqu7qoAd5Edvh1j3g46EFlylYLuEGaHrGGt17', N'1', N'2024-08-16 16:29:23.767', NULL, N'0')
GO

INSERT INTO [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [PasswordHash], [RoleID], [CreatedAt], [UpdatedAt], [Active]) VALUES (N'1FADA4BD-8886-4311-B0A7-3BF7A3A06A7E', N'rahman3@gmail.com', N'rrr', N'jjj', N'$MYHASH$V1$10000$JMXFv7LbpcqYDisonpAZwFkCnTKigIhMHwj8+XqT2F4IihVG', N'1', N'2024-08-16 16:41:57.100', NULL, N'0')
GO

INSERT INTO [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [PasswordHash], [RoleID], [CreatedAt], [UpdatedAt], [Active]) VALUES (N'6D945F18-8F8E-4AA4-B96B-439AD3200E03', N'rahman@gmail.com', N'Rahman', N'Jafarinejad', N'$MYHASH$V1$10000$noWf/Tui95iAUWXAQe/j0bxyhdP77TcO3J302HLXgyKp2XDp', N'2', N'2024-08-16 16:17:00.010', NULL, N'0')
GO


-- ----------------------------
-- Primary Key structure for table Authors
-- ----------------------------
ALTER TABLE [dbo].[Authors] ADD CONSTRAINT [PK__Authors__3214EC075ADFBFAF] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Authtokens
-- ----------------------------
ALTER TABLE [dbo].[Authtokens] ADD CONSTRAINT [PK__JWTokens__3214EC07C7CB835D] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Books
-- ----------------------------
ALTER TABLE [dbo].[Books] ADD CONSTRAINT [PK__Books__3214EC072982216E] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Categories
-- ----------------------------
ALTER TABLE [dbo].[Categories] ADD CONSTRAINT [PK__Categori__3214EC07031E6BCA] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for Roles
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[Roles]', RESEED, 2)
GO


-- ----------------------------
-- Indexes structure for table Roles
-- ----------------------------
CREATE NONCLUSTERED INDEX [IDX_RoleName]
ON [dbo].[Roles] (
  [Name] ASC
)
GO

CREATE NONCLUSTERED INDEX [IDX_IsActive]
ON [dbo].[Roles] (
  [Active] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table Roles
-- ----------------------------
ALTER TABLE [dbo].[Roles] ADD CONSTRAINT [PK__Roles__3214EC07910F47C1] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Users
-- ----------------------------
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [PK__Users__3214EC07DF7A6B30] PRIMARY KEY CLUSTERED ([Id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table Authtokens
-- ----------------------------
ALTER TABLE [dbo].[Authtokens] ADD CONSTRAINT [FK__JWTokens__UserID__5070F446] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[Authtokens] ADD CONSTRAINT [FK_JwtTokens_Users] FOREIGN KEY ([UserID]) REFERENCES [dbo].[Users] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Books
-- ----------------------------
ALTER TABLE [dbo].[Books] ADD CONSTRAINT [FK__Books__CategoryI__60A75C0F] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Categories] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

ALTER TABLE [dbo].[Books] ADD CONSTRAINT [FK__Books__AuthorId__619B8048] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO


-- ----------------------------
-- Foreign Keys structure for table Users
-- ----------------------------
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [FK_Users_Roles] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Roles] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

