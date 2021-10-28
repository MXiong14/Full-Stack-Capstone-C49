USE [master]

IF db_id('KicksKollector') IS NULL
  CREATE DATABASE [KicksKollector]
GO

USE [KicksKollector]
GO


DROP TABLE IF EXISTS [Comment];
DROP TABLE IF EXISTS [Post];
DROP TABLE IF EXISTS [Brand];;
DROP TABLE IF EXISTS [UserProfile];;
GO


CREATE TABLE [UserProfile] (
  [Id] int PRIMARY KEY IDENTITY,
  [Email] nvarchar(255) NOT NULL UNIQUE,
  [FirstName] nvarchar(255),
  [LastName] nvarchar(255),
  [FireBaseUserId] nvarchar(255)
)

CREATE TABLE [Post] (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255),
  [Size] int,
  [StyleCode] nvarchar(255),
  [Quantity] int,
  [PurchasePrice] int,
  [SoldPrice] int,
  [UserProfileId] int,
  [BrandId] int,

CONSTRAINT [FK_Post_Brand] FOREIGN KEY ([BrandId]) REFERENCES [Brand] ([Id]),
CONSTRAINT [FK_Post_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
ON DELETE CASCADE
)

CREATE TABLE [Brand] (
  [Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(255),
)



CREATE TABLE [Comment] (
  [Id] int PRIMARY KEY IDENTITY,
  [PostId] int,
  [UserProfileId] int,
  [Content] text,

 CONSTRAINT [FK_Comment_Post] FOREIGN KEY ([PostId]) REFERENCES [Post] ([Id]),
 CONSTRAINT [FK_Comment_UserProfile] FOREIGN KEY ([UserProfileId]) REFERENCES [UserProfile] ([Id])
 ON DELETE CASCADE
)
GO