CREATE TABLE [dbo].[RigthRole] (
    [RoleId]   INT NOT NULL,
    [RightsId] INT NOT NULL,
    CONSTRAINT [FK_rigthRole_Rights] FOREIGN KEY ([RightsId]) REFERENCES [dbo].[Rights] ([Id]),
    CONSTRAINT [FK_rigthRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role] ([id])
);

