CREATE TABLE [dbo].[UserRights] (
    [UserId]  INT NOT NULL,
    [RightsId] INT NOT NULL,
    CONSTRAINT [FK_userRights_Rights] FOREIGN KEY ([RightsId]) REFERENCES [dbo].[Rights] ([Id]),
    CONSTRAINT [FK_userRights_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([id])
);

