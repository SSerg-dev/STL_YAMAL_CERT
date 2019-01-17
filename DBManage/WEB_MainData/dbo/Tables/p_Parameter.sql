CREATE TABLE [dbo].[p_Parameter] (
    [Parameter_ID]     UNIQUEIDENTIFIER CONSTRAINT [DF_Parameter_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]        INT              NOT NULL,
    [Insert_DTS]       DATETIME2 (7)    NOT NULL,
    [Update_DTS]       DATETIME2 (7)    NOT NULL,
    [Created_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID] UNIQUEIDENTIFIER NOT NULL,
    [Parameter_Code]   NVARCHAR (255)   NOT NULL,
    [Parameter_Value]  NVARCHAR (1000)  NOT NULL,
    [Description_Rus]  NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_Parameter] PRIMARY KEY CLUSTERED ([Parameter_ID] ASC),
    CONSTRAINT [FK_p_Parameter_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Parameter_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_Parameter_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_Parameter] UNIQUE NONCLUSTERED ([Parameter_Code] ASC)
);

