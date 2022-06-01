INSERT INTO [dbo].[Services]
           ([BookingId]
           ,[VehicleNumber]
           ,[VehicleModel]
           ,[ServiceType]
           ,[ServiceInstructions]
           ,[ServiceTasks]
           ,[RequestedDate]
           ,[CompletedDate])
     VALUES (@BookingId, @VehicleNumber, @VehicleModel, @ServiceType, @ServiceInstructions, @ServiceTasks, @RequestedDate, @CompletedDate)