UPDATE [dbo].[Credentials]
   SET [Location] = @Location
      ,[Username] = @Username
      ,[Password] = @Password
 WHERE Username = ''