INSERT INTO [dbo].[Bookings]
           ([BookingId]
           ,[Location]
           ,[Name]
           ,[Phone]
           ,[Email]
           ,[VehicleNumber]
           ,[VehicleModel]
           ,[CreatedDate]
           ,[RequestedDate]
           ,[CompletedDate])
     VALUES (@BookingId, @Location, @Name, @Phone, @Email, @VehicleNumber, @VehicleModel, @CreatedDate, @RequestedDate, @CompletedDate)