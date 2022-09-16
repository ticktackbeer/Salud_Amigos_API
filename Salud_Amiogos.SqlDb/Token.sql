﻿CREATE TABLE [dbo].[Token]
(  
	[Id]							UNIQUEIDENTIFIER	PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[UserId]						UNIQUEIDENTIFIER	NOT NULL ,
	[Email]							NVARCHAR(50)		NOT NULL ,
	[Token]							NVARCHAR(200)		NOT NULL,
	[Timestamp]						DATETIMEOFFSET		NOT NULL ,

	CONSTRAINT UC_Token UNIQUE (Email),
	CONSTRAINT FK_UserId_FriendId FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id]) ON DELETE CASCADE,
)