UPDATE [dbo].[Services]
   SET [BookingId] = @BookingId
      ,[VehicleNumber] = @VehicleNumber
      ,[VehicleModel] = @VehicleModel
      ,[ServiceType] = @ServiceType
      ,[ServiceInstructions] = @ServiceInstructions
      ,[ServiceTasks] = @ServiceTasks
      ,[RequestedDate] = @RequestedDate
      ,[CompletedDate] = @CompletedDate
 WHERE BookingId = ''