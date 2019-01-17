﻿CREATE TABLE [dbo].[p_WeldPasses] (
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [WeldPasses_ID]    UNIQUEIDENTIFIER NOT NULL,
    [WeldPasses_Code]  NVARCHAR (MAX)   NOT NULL,
    [Description_Rus]  NVARCHAR (MAX)   NULL,
    CONSTRAINT [PK_p_WeldPasses] PRIMARY KEY CLUSTERED ([WeldPasses_ID] ASC),
    CONSTRAINT [FK_p_WeldPasses_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_WeldPasses_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_p_WeldPasses_Modified_User_ID]
    ON [dbo].[p_WeldPasses]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_WeldPasses_Created_User_ID]
    ON [dbo].[p_WeldPasses]([Created_User_ID] ASC);

