CREATE TABLE [dbo].[Departments] (
    [id]    INT          NOT NULL,
    [name]  VARCHAR (60) NOT NULL,
    [chief] VARCHAR (60) NOT NULL,
    [departmentCode] INT NOT NULL, 
    CONSTRAINT [PK_departments] PRIMARY KEY CLUSTERED ([id] ASC)
);

