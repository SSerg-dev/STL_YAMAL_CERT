CREATE TABLE [dbo].[p_User] (
    [User_ID]          UNIQUEIDENTIFIER CONSTRAINT [DF_User_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NULL,
    [Update_DTS]       DATETIME2 (7)    NULL,
    [Row_Status]       INT              NULL,
    [User_Domain_Name] NVARCHAR (120)   NOT NULL,
    [User_First_Name]  NVARCHAR (120)   NULL,
    [User_Last_Name]   NVARCHAR (120)   NULL,
    [Description]      NVARCHAR (250)   NULL
);

