CREATE TABLE [dbo].[SubCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,  
    [Name] VARCHAR(MAX) NOT NULL, 
    [CategoryId] INT NOT NULL, 
    CONSTRAINT [FK_SubCategory_To_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id])
)
