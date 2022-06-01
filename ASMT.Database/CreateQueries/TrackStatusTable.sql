CREATE TABLE [dbo].[TrackStatus]
(
	[BookingId] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [TasksDone] NCHAR(10) NOT NULL, 
    [TasksTotal] NCHAR(10) NOT NULL, 
    [IsPaymentDone] BIT NOT NULL, 
    [IsCompleted] BIT NOT NULL, 
    [ExpectedDate] NVARCHAR(50) NOT NULL
)