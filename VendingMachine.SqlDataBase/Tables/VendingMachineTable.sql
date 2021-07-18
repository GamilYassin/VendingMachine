CREATE TABLE [dbo].[VendingMachineTable]
(
	[Id]            INT           NOT NULL PRIMARY KEY,
    [Model]         NVARCHAR (50) NOT NULL,
    [Manufacturer]  NVARCHAR (50) NOT NULL,
    [Frequency]     INT           NOT NULL,
    [LastMaintDate] DATETIME2 (7) NOT NULL,
    [GrandBalance]  NVARCHAR (50) NOT NULL,
    [BalanceEncode]     NVARCHAR(100)           NOT NULL,
    [StartDate]     DATETIME2 (7) NOT NULL,
    [State]         NVARCHAR (50) NOT NULL,
)
