CREATE TABLE [dbo].[Reply]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CommentId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [Description] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Reply_To_Comment] FOREIGN KEY ([CommentId]) REFERENCES [Comment]([Id]), 
    CONSTRAINT [FK_Reply_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
