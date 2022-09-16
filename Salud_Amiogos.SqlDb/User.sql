﻿CREATE TABLE [dbo].[User]
(
	[Id]							UNIQUEIDENTIFIER	PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[Email]							NVARCHAR(50)		NOT NULL ,
	[Token]							NVARCHAR(200)		NOT NULL,
	[NickName]						NVARCHAR(100)		NOT NULL,
	[Name]							NVARCHAR(100)		NOT NULL,
	[Password]						NVARCHAR(200)		NOT NULL,
	[Age]							INT					NOT NULL,
	[Timestamp]						DATETIMEOFFSET		NOT NULL ,

	CONSTRAINT UC_Email UNIQUE (Email),
	
)