UPDATE [dbo].[People] SET 
	firstname = SUBSTRING(name, 1, CHARINDEX(' ', name, 1) - 1),
	lastname = SUBSTRING(name, CHARINDEX(' ', name, 1) + 1, len(name))