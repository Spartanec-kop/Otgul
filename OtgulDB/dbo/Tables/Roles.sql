CREATE TABLE [dbo].[Roles] (
    [id]        INT  IDENTITY (1, 1) NOT NULL,
    [name]      TEXT NOT NULL,
    [isDeleted] BIT  NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([id] ASC)
);

