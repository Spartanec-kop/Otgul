CREATE TABLE [dbo].[UserRights] (
    [UserId]  INT NOT NULL,
    [RightId] INT NOT NULL,
    CONSTRAINT [FK_userRights_Rights] FOREIGN KEY ([RightId]) REFERENCES [dbo].[Rights] ([Id]),
    CONSTRAINT [FK_userRights_Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([id])
);

