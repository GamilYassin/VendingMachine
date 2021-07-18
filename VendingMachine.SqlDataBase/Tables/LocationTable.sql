CREATE TABLE [dbo].[LocationTable]
(
    [Id] INT Not null IDENTITY,
    [VendingMachineId] INT            NOT NULL PRIMARY KEY,
    [Street]           NVARCHAR (50)  NOT NULL,
    [City]             NVARCHAR (50)  NOT NULL,
    [Landmark]         NVARCHAR (100) NOT NULL,
)
