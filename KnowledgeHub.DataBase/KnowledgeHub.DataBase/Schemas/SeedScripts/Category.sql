PRINT 'INSERTING Rows Into [dbo].[Category]';

IF NOT EXISTS (SELECT 1 FROM dbo.Category)
BEGIN
INSERT INTO dbo.Category (Name) VALUES('Development') 
END