CREATE TABLE [dbo].[Department] (
    [id]    INT          NOT NULL,
    [name]  VARCHAR (60) NOT NULL,
    [chief] VARCHAR (60) NOT NULL,
    [departmentCode] INT NOT NULL, 
    CONSTRAINT [PK_department] PRIMARY KEY CLUSTERED ([id] ASC)
);

