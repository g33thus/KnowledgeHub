CREATE TABLE [dbo].[UserTag]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [TagId] INT NOT NULL, 
    CONSTRAINT [FK_UserTags_To_Tags] FOREIGN KEY ([TagId]) REFERENCES [Tag]([Id]), 
    CONSTRAINT [FK_UserTags_To_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])
)
