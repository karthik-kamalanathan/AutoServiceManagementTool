CREATE TABLE [dbo].[Services]
(
	[BookingId] INT NOT NULL PRIMARY KEY, 
    [VehicleType] CHAR(10) NOT NULL, 
    [VehicleModel] NCHAR(12) NOT NULL, 
    [ServiceType] NCHAR(10) NOT NULL, 
    [EngineOilChange] BIT NULL , 
    [BreakOilChange] BIT NULL, 
    [AirCheck] BIT NULL, 
    [WaterWash] BIT NULL, 
    [WheelAlignment] BIT NULL, 
    [TyreChange] BIT NULL, 
    [TyreChangeInstruction] NVARCHAR(140) NULL, 
    [PollutionCheck] BIT NULL, 
    [ServiceInstructions] NVARCHAR(200) NULL
)
