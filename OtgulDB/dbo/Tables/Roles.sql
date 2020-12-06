CREATE TABLE [dbo].[Roles] (
    [id]        INT  NOT NULL,
    [name]      TEXT NOT NULL,
    [isDeleted] BIT  NOT NULL,
    CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED ([id] ASC)
);

