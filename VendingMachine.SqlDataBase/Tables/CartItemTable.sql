CREATE TABLE [dbo].[CartItemTable]
(
	[Id] INT NOT Null IDENTITY,
	[SessionId] INT NOT NULL,
	[SellItemId] INT NOT NULL,
	[SellItemQty] INT NOT NULL,
)
