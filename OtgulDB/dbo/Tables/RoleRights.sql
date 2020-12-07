CREATE TABLE [dbo].[RoleRights] (
    [RoleId]   INT NOT NULL,
    [RightId] INT NOT NULL,
    CONSTRAINT [FK_RoleRights_Rights] FOREIGN KEY ([RightId]) REFERENCES [dbo].[Rights] ([Id]),
    CONSTRAINT [FK_RoleRights_Roles] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([id])
);

