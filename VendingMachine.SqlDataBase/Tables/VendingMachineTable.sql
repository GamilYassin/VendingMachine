CREATE TABLE [dbo].[VendingMachineTable]
(
	[Id]            INT           NOT NULL IDENTITY,
    [Model]         NVARCHAR (50) NULL,
    [Manufacturer]  NVARCHAR (50) NULL,
    [Frequency]     INT           NOT NULL,
    [LastMaintDate] DATETIME2 (7) NOT NULL,
    [GrandBalance]  NVARCHAR (50) NULL,
    [StartDate]     DATETIME2 (7) NOT NULL,
    [EndOfLifeDate] DATETIME2 (7) NOT NULL,
    [State]         NVARCHAR (50) NOT NULL,
)
