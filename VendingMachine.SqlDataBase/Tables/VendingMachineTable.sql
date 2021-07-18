CREATE TABLE [dbo].[VendingMachineTable]
(
	[Id]            INT           NULL,
    [Model]         NVARCHAR (50) NULL,
    [Manufacturer]  NVARCHAR (50) NULL,
    [Frequency]     INT           NULL,
    [LastMaintDate] DATETIME2 (7) NULL,
    [GrandBalance]  NVARCHAR (50) NULL,
    [BalanceText]     NVARCHAR(100)           NULL,
    [StartDate]     DATETIME2 (7) NULL,
    [State]         NVARCHAR (50) NULL,
)