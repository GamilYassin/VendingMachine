CREATE TABLE [dbo].[CustomerSessionTable]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [VendingMachineId] INT NOT NULL,
	[BalanceId]	       INT   NOT NULL, 
    [Status] NVARCHAR(50) NOT NULL

)
