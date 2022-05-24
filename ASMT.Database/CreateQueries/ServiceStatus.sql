CREATE TABLE [dbo].[ServiceStatus]
(
	[BookingId] NVARCHAR(50) NOT NULL PRIMARY KEY,
    [IsEngineOilChangeDone] BIT NULL , 
    [IsBreakOilChangeDone] BIT NULL, 
    [IsAirCheckDone] BIT NULL, 
    [IsWaterWashDone] BIT NULL, 
    [IsWheelAlignmentDone] BIT NULL, 
    [IsTyreChangeDone] BIT NULL, 
    [IsPollutionCheckDone] BIT NULL, 
    [IsOtherReqDoneDone] BIT NULL, 
    [OverallStatus] NVARCHAR(50) NOT NULL
)
