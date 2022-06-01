UPDATE [dbo].[Bookings]
   SET [BookingId] = @BookingId
      ,[Location] = @Location
      ,[Name] = @Name
      ,[Phone] = @Phone
      ,[Email] = @Email
      ,[VehicleNumber] = @VehicleNumber
      ,[VehicleModel] = @VehicleModel
      ,[CreatedDate] = @CreatedDate
      ,[RequestedDate] = @RequestedDate
      ,[CompletedDate] = @CompletedDate
 WHERE BookingId = ''