CREATE TABLE [dbo].[Services]
(
	[BookingId] NVARCHAR(50) NOT NULL PRIMARY KEY, 
    [VehicleType] NVARCHAR(50) NOT NULL, 
    [VehicleModel] NVARCHAR(50) NOT NULL, 
    [ServiceType] NVARCHAR(50) NOT NULL, 
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
