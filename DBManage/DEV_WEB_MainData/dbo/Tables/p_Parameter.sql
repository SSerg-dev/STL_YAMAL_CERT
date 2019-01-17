CREATE TABLE [dbo].[p_Parameter] (
    [Parameter_ID]     UNIQUEIDENTIFIER   DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Update_DTS]       DATETIMEOFFSET (7) NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER   NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER   NOT NULL,
    [RowStatus]        INT                NOT NULL,
    [Parameter_Code]   NVARCHAR (255)     NOT NULL,
    [Parameter_Value]  NVARCHAR (1000)    NOT NULL,
    [Description_Rus]  NVARCHAR (255)     NULL,
    CONSTRAINT [PK_p_Parameter] PRIMARY KEY CLUSTERED ([Parameter_ID] ASC),
    CONSTRAINT [FK_p_Parameter_p_AppUser_Created_User_ID] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Parameter_p_AppUser_Modified_User_ID] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Parameter_p_RowStatus_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [AK_p_Parameter_Parameter_Code] UNIQUE NONCLUSTERED ([Parameter_Code] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_p_Parameter_Created_User_ID]
    ON [dbo].[p_Parameter]([Created_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Parameter_Modified_User_ID]
    ON [dbo].[p_Parameter]([Modified_User_ID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_p_Parameter_RowStatus]
    ON [dbo].[p_Parameter]([RowStatus] ASC);

