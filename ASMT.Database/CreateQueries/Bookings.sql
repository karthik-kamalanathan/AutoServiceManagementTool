CREATE TABLE [dbo].[Bookings]
(
	[BookingId] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [LocationId] NVARCHAR(50) NOT NULL, 
    [Name] NVARCHAR(50) NOT NULL, 
    [VehicleNumber] NVARCHAR(50) NOT NULL, 
    [VehicleModel] NVARCHAR(50) NOT NULL, 
    [PickUp] BIT NOT NULL, 
    [PickUpAddress] NVARCHAR(140) NOT NULL, 
    [Drop] BIT NOT NULL, 
    [DropAddress] NVARCHAR(140) NOT NULL, 
    [CreatedDate] NVARCHAR(50) NOT NULL
)
