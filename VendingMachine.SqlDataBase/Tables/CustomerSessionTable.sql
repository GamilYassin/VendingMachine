CREATE TABLE [dbo].[CustomerSessionTable]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [VendingMachineId] INT NOT NULL,
	[BalanceEncode]	       NVARCHAR(100)   NOT NULL, 
    [Status] NVARCHAR(50) NOT NULL

)
