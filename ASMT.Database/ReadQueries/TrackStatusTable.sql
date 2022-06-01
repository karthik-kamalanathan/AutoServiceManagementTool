/****** Script for SelectTopNRows command from SSMS  ******/
SELECT [BookingId]
      ,[TasksDone]
      ,[TasksTotal]
      ,[IsPaymentDone]
      ,[IsCompleted]
      ,[ExpectedDate]
  FROM [ASMT].[dbo].[TrackStatus]