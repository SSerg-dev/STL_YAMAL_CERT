﻿CREATE TABLE [dbo].[p_DocumentNaks_to_HIFGroup] (
    [RowStatus]                   INT              NOT NULL,
    [Insert_DTS]                  DATETIME2 (7)    NOT NULL,
    [Update_DTS]                  DATETIME2 (7)    NOT NULL,
    [Created_User_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]            UNIQUEIDENTIFIER NOT NULL,
    [DocumentNaks_to_HIFGroup_ID] UNIQUEIDENTIFIER NOT NULL,
    [DocumentNaks_ID]             UNIQUEIDENTIFIER NOT NULL,
    [HIFGroup_ID]                 UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_DocumentNaks_to_HIFGroup] PRIMARY KEY CLUSTERED ([DocumentNaks_to_HIFGroup_ID] ASC),
    CONSTRAINT [FK_p_DocumentNaks_to_HIFGroup_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaks_to_HIFGroup_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_DocumentNaks_to_HIFGroup_p_DocumentNaks_DocumentNaks_ID] FOREIGN KEY ([DocumentNaks_ID]) REFERENCES [dbo].[p_DocumentNaks] ([DocumentNaks_ID]) ON DELETE CASCADE,
    CONSTRAINT [FK_p_DocumentNaks_to_HIFGroup_p_HIFGroup_HIFGroup_ID] FOREIGN KEY ([HIFGroup_ID]) REFERENCES [dbo].[p_HIFGroup] ([HIFGroup_ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaks_to_HIFGroup_Modified_User_ID]
    ON [dbo].[p_DocumentNaks_to_HIFGroup]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaks_to_HIFGroup_HIFGroup_ID]
    ON [dbo].[p_DocumentNaks_to_HIFGroup]([HIFGroup_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaks_to_HIFGroup_DocumentNaks_ID]
    ON [dbo].[p_DocumentNaks_to_HIFGroup]([DocumentNaks_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_DocumentNaks_to_HIFGroup_Created_User_ID]
    ON [dbo].[p_DocumentNaks_to_HIFGroup]([Created_User_ID] ASC);

