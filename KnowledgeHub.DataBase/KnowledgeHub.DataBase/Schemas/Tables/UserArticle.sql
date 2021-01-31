CREATE TABLE [dbo].[UserArticle]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [CreatedDate] DATETIME NOT NULL,
    [ArticleId] INT NOT NULL, 
    [IsLiked] BIT NOT NULL, 
    [IsSaved] BIT NOT NULL, 
    [IsMarkedRead] BIT NOT NULL, 
    [TagId] INT NOT NULL, 
    CONSTRAINT [FK_UserArticle_To_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_UserArticle_Article] FOREIGN KEY ([ArticleId]) REFERENCES [Article]([Id]),
    CONSTRAINT [FK_Tag_UserArticle] FOREIGN KEY ([TagId]) REFERENCES [UserTag]([Id])
)
