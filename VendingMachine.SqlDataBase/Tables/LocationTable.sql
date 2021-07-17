CREATE TABLE [dbo].[LocationTable]
(
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [VendingMachineId] INT            NOT NULL,
    [Street]            NVARCHAR (50)  NULL,
    [City]             NVARCHAR (50)  NULL,
    [Landmark]         NVARCHAR (100) NULL,
)
