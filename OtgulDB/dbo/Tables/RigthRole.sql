CREATE TABLE [dbo].[RigthRole] (
    [idRole]   INT NOT NULL,
    [idPRight] INT NOT NULL,
    CONSTRAINT [FK_rigthRole_Rights] FOREIGN KEY ([idPRight]) REFERENCES [dbo].[Rights] ([Id]),
    CONSTRAINT [FK_rigthRole_Role] FOREIGN KEY ([idRole]) REFERENCES [dbo].[Role] ([id])
);

