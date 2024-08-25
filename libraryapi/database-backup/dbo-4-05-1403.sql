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

 Date: 25/08/2024 20:12:52
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
  [Active] bit DEFAULT 1 NOT NULL,
  [status] int DEFAULT 1 NOT NULL
)
GO

ALTER TABLE [dbo].[Books] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'0:reserved, 1: free',
'SCHEMA', N'dbo',
'TABLE', N'Books',
'COLUMN', N'status'
GO


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
-- Table structure for UserBooks
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UserBooks]') AND type IN ('U'))
	DROP TABLE [dbo].[UserBooks]
GO

CREATE TABLE [dbo].[UserBooks] (
  [Id] uniqueidentifier  NOT NULL,
  [UserId] uniqueidentifier  NOT NULL,
  [BookId] uniqueidentifier  NOT NULL,
  [ReservedDate] datetime  NOT NULL,
  [ExpirationDate] datetime  NOT NULL,
  [Active] bit DEFAULT 1 NOT NULL,
  [status] int DEFAULT 0 NOT NULL
)
GO

ALTER TABLE [dbo].[UserBooks] SET (LOCK_ESCALATION = TABLE)
GO

EXEC sp_addextendedproperty
'MS_Description', N'0: reserved, 1:returned',
'SCHEMA', N'dbo',
'TABLE', N'UserBooks',
'COLUMN', N'status'
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
-- Primary Key structure for table UserBooks
-- ----------------------------
ALTER TABLE [dbo].[UserBooks] ADD CONSTRAINT [PK__UserBook__3214EC0786E7E1BD] PRIMARY KEY CLUSTERED ([Id])
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
-- Foreign Keys structure for table UserBooks
-- ----------------------------
ALTER TABLE [dbo].[UserBooks] ADD CONSTRAINT [user_book_user_id_foreign_key] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE NO ACTION ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[UserBooks] ADD CONSTRAINT [user_book_book_id_foreign_key] FOREIGN KEY ([BookId]) REFERENCES [dbo].[Books] ([Id]) ON DELETE NO ACTION ON UPDATE CASCADE
GO


-- ----------------------------
-- Foreign Keys structure for table Users
-- ----------------------------
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [FK_Users_Roles] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[Roles] ([Id]) ON DELETE NO ACTION ON UPDATE NO ACTION
GO

