
Select
BookLibrary.[Title] ,[dbo].[Library].BookID from BookLibrary INNER JOIN 
[dbo].[Library] On BookLibrary.[BookID]=[Library].[BookId] and [Library].TakerId='1659';
