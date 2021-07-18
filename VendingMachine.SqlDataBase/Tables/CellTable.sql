CREATE TABLE [dbo].[CellTable]
(
    [Id]    INt NOT Null IDENTITY,
    [VendingMachineId] INT          NOT NULL,
    [CellId]           NVARCHAR (5) NOT NULL,
    [ItemId]           INT          NOT NULL,
    [ItemQty]          INT          NOT NULL,
)
