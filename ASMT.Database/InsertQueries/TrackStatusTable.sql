INSERT INTO [dbo].[TrackStatus]
           ([BookingId]
           ,[TasksDone]
           ,[TasksTotal]
           ,[IsPaymentDone]
           ,[IsCompleted]
           ,[ExpectedDate])
     VALUES (@BookingId, @TasksDone, @TasksTotal, @IsPaymentDone, @IsCompleted, @ExpectedDate)