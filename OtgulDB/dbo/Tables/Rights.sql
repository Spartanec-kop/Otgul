CREATE TABLE [dbo].[Rights] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [name] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Rights] PRIMARY KEY CLUSTERED ([Id] ASC)
);

