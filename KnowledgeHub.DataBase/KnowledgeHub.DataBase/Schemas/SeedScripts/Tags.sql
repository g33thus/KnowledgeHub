PRINT 'INSERTING Rows Into [dbo].[Tags]';
IF NOT EXISTS (SELECT 1 FROM dbo.Tag)
BEGIN
INSERT INTO dbo.Tag(SubCategoryId, Name) VALUES(1,'Angular') 
INSERT INTO dbo.Tag(SubCategoryId, Name) VALUES(1,'ReactJs') 
END




