CREATE TABLE [dbo].[p_ValidationErrors] (
    [Error_ID]        UNIQUEIDENTIFIER NULL,
    [Number]          INT              NULL,
    [Description_Rus] NVARCHAR (255)   NULL,
    [Description_Eng] NCHAR (255)      NULL,
    CONSTRAINT [IX_p_ValidationErrors_UK_Number] UNIQUE NONCLUSTERED ([Number] ASC)
);

