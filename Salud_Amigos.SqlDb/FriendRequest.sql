CREATE TABLE [dbo].[FriendRequest]
(
	[Id]										UNIQUEIDENTIFIER	PRIMARY KEY DEFAULT NEWSEQUENTIALID(),
	[RequestFromEmail]							NVARCHAR(100)		NOT NULL ,
	[RequestToEmail]							NVARCHAR(100)		NOT NULL ,
	[RequestFromUserId]							UNIQUEIDENTIFIER	NOT NULL ,
	[RequestToUserId]							UNIQUEIDENTIFIER	NOT NULL ,
	[RequestFromNickName]						NVARCHAR(100)		NOT NULL ,
	[RequestToNickName]							NVARCHAR(100)		NOT NULL ,
	[Timestamp]									DATETIMEOFFSET		NOT NULL ,
	

	CONSTRAINT UC_EmailFriendRequest UNIQUE (RequestFromUserId,RequestToUserId) ,
	CONSTRAINT FK_ToUser FOREIGN KEY (RequestToUserId) REFERENCES [dbo].[User]([Id]) ON DELETE CASCADE
)