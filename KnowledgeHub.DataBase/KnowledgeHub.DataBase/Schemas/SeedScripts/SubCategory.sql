PRINT 'INSERTING Rows Into [dbo].[SubCategory]';
IF NOT EXISTS (SELECT 1 FROM dbo.SubCategory)
BEGIN
INSERT INTO dbo.SubCategory(Name,CategoryId) VALUES('Mobile-App',1) 
END