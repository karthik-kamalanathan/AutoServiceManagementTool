CREATE TABLE [dbo].[Bookings]
(
	[BookingId] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [Location] NVARCHAR(50) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL,
    [Phone] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(50) NULL,
    [VehicleNumber] NVARCHAR(50) NOT NULL, 
    [VehicleModel] NVARCHAR(50) NOT NULL, 
    [CreatedDate] NVARCHAR(50) NOT NULL,
    [RequestedDate] NVARCHAR(50) NOT NULL,
    [CompletedDate] NVARCHAR(50) NULL  
)