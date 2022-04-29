CREATE TABLE [dbo].[Bookings]
(
	[BookingId] INT NOT NULL PRIMARY KEY, 
    [LocationId] INT NOT NULL, 
    [Name] CHAR(30) NOT NULL, 
    [VehicleNumber] NCHAR(12) NOT NULL, 
    [VehicleModel] NCHAR(15) NOT NULL, 
    [PickUp] BIT NOT NULL, 
    [PickUpAddress] NVARCHAR(140) NOT NULL, 
    [Drop] BIT NOT NULL, 
    [DropAddress] NVARCHAR(140) NOT NULL
)
