CREATE TABLE [dbo].[Services]
(
	[BookingId] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [VehicleNumber] NVARCHAR(50) NOT NULL, 
    [VehicleModel] NVARCHAR(50) NOT NULL,
    [ServiceType] NVARCHAR(50) NOT NULL, 
    [ServiceInstructions] NVARCHAR(200) NULL, 
    [ServiceTasks] VARBINARY(MAX) NULL, 
    [RequestedDate] NVARCHAR(50) NOT NULL, 
    [CompletedDate] NVARCHAR(50) NULL
)
