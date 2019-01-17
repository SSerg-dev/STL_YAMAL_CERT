﻿CREATE TABLE [dbo].[p_DocumentNaksAttest_to_WeldGOST14098] (
    [DocumentNaksAttest_to_WeldGOST14098_ID] UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                             DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]                             DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]                        UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID]                       UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]                              INT                NOT NULL,
    [DocumentNaksAttest_ID]                  UNIQUEIDENTIFIER   NOT NULL,
    [WeldGOST14098_ID]                       UNIQUEIDENTIFIER   NOT NULL,
    CONSTRAINT [PK_p_DocumentNaksAttest_to_WeldGOST14098] PRIMARY KEY CLUSTERED ([DocumentNaksAttest_to_WeldGOST14098_ID] ASC),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldGOST14098_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldGOST14098_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldGOST14098_p_DocumentNaksAttest_DocumentNaksAttest_ID] FOREIGN KEY ([DocumentNaksAttest_ID]) REFERENCES [dbo].[p_DocumentNaksAttest] ([DocumentNaksAttest_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldGOST14098_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [FK_p_DocumentNaksAttest_to_WeldGOST14098_p_WeldGOST14098_WeldGOST14098_ID] FOREIGN KEY ([WeldGOST14098_ID]) REFERENCES [dbo].[p_WeldGOST14098] ([WeldGOST14098_ID])
);




GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldGOST14098_Created_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldGOST14098]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldGOST14098_DocumentNaksAttest_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldGOST14098]([DocumentNaksAttest_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldGOST14098_Modified_User_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldGOST14098]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldGOST14098_RowStatus]
    ON [dbo].[p_DocumentNaksAttest_to_WeldGOST14098]([RowStatus] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaksAttest_to_WeldGOST14098_WeldGOST14098_ID]
    ON [dbo].[p_DocumentNaksAttest_to_WeldGOST14098]([WeldGOST14098_ID] ASC);

