CREATE TABLE [dbo].[CellTable]
(
	[Id]               INT          IDENTITY (1, 1) NOT NULL,
    [VendingMachineId] INT          NOT NULL,
    [CellId]           NVARCHAR (5) NOT NULL,
    [ItemId]           INT          NOT NULL,
    [ItemQty]          INT          NOT NULL,
)
