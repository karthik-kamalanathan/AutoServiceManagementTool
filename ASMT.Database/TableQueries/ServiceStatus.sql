CREATE TABLE [dbo].[ServiceStatus]
(
	[BookingId] INT NOT NULL PRIMARY KEY,
    [IsEngineOilChangeDone] BIT NULL , 
    [IsBreakOilChangeDone] BIT NULL, 
    [IsAirCheckDone] BIT NULL, 
    [IsWaterWashDone] BIT NULL, 
    [IsWheelAlignmentDone] BIT NULL, 
    [IsTyreChangeDone] BIT NULL, 
    [IsPollutionCheckDone] BIT NULL, 
    [IsOtherReqDoneDone] BIT NULL, 
    [OverallStatus] NCHAR(10) NOT NULL
)
