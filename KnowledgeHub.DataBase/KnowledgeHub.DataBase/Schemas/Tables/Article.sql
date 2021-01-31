CREATE TABLE [dbo].[Article]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Url] VARCHAR(1000) NOT NULL, 
    [Title] VARCHAR(MAX) NOT NULL, 
    [PublishedAt] DATETIME NULL, 
    [ImageUrl] VARCHAR(MAX) NULL, 
    [Snippet] VARCHAR(MAX) NOT NULL, 
    [Likes] INT NOT NULL, 
    CONSTRAINT [AK_Article_Url] UNIQUE ([Url])
)
