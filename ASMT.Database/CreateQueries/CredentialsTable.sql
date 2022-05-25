CREATE TABLE [dbo].[Credentials]
(
	[Location] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Username] NVARCHAR(15) NOT NULL, 
    [Password] NVARCHAR(15) NOT NULL
)
