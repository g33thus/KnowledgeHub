CREATE TABLE [dbo].[Tag]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SubCategoryId] INT NOT NULL,
    [Name] NVARCHAR(MAX) NOT NULL, 
    CONSTRAINT [FK_Tags_To_SubCategory] FOREIGN KEY ([SubCategoryId]) REFERENCES [SubCategory]([Id]) 
)
