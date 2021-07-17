CREATE TABLE [dbo].[UserTable]
(
	[Id]           INT           NOT NULL IDENTITY,
    [UserName]     NVARCHAR (50) NOT NULL,
    [UserPassword] NVARCHAR (50) NULL,
    [Privilege]    NVARCHAR (50) NOT NULL,
)
