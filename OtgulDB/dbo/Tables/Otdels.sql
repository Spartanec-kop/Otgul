CREATE TABLE [dbo].[Otdels] (
    [id]         INT           IDENTITY (1, 1) NOT NULL,
    [codOtdela]  INT           NOT NULL,
    [nameOtdela] NVARCHAR (60) NOT NULL,
    [director]   NVARCHAR (60) NOT NULL,
    CONSTRAINT [PK_Otdels] PRIMARY KEY CLUSTERED ([id] ASC)
);

