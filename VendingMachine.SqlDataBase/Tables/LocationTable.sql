CREATE TABLE [dbo].[LocationTable]
(
    [VendingMachineId] INT            NOT NULL PRIMARY KEY,
    [Street]           NVARCHAR (50)  NOT NULL,
    [City]             NVARCHAR (50)  NOT NULL,
    [Landmark]         NVARCHAR (100) NOT NULL,
)
