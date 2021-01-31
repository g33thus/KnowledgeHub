CREATE TABLE [dbo].[Comment]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ArticleId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [Description] VARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Comment_To_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Comment_To_Article] FOREIGN KEY ([ArticleId]) REFERENCES [Article]([Id])
)
