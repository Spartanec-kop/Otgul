CREATE TABLE [dbo].[Role] (
    [id]        INT  NOT NULL,
    [name]      TEXT NOT NULL,
    [isDeleted] BIT  NOT NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED ([id] ASC)
);

