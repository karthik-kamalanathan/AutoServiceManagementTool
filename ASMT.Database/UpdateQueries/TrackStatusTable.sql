UPDATE [dbo].[TrackStatus]
   SET [BookingId] = @BookingId
      ,[TasksDone] = @TasksDone
      ,[TasksTotal] = @TasksTotal
      ,[IsPaymentDone] = @IsPaymentDone
      ,[IsCompleted] = @IsCompleted
      ,[ExpectedDate] = @ExpectedDate
 WHERE BookingId = ''