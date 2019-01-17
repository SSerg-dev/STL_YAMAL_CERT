CREATE TABLE [dbo].[p_ProcessPhase] (
    [ProcessPhase_ID]   UNIQUEIDENTIFIER CONSTRAINT [DF_ProcessPhase_ID] DEFAULT (newsequentialid()) NOT NULL,
    [RowStatus]         INT              NOT NULL,
    [Insert_DTS]        DATETIME2 (7)    NOT NULL,
    [Update_DTS]        DATETIME2 (7)    NOT NULL,
    [Created_User_ID]   UNIQUEIDENTIFIER NOT NULL,
    [Modified_User_ID]  UNIQUEIDENTIFIER NOT NULL,
    [ProcessPhase_Code] NVARCHAR (255)   NOT NULL,
    CONSTRAINT [PK_p_ProcessPhase] PRIMARY KEY CLUSTERED ([ProcessPhase_ID] ASC),
    CONSTRAINT [FK_p_ProcessPhase_Created_User_ID_p_AppUser] FOREIGN KEY ([Created_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_ProcessPhase_Modified_User_ID_p_AppUser] FOREIGN KEY ([Modified_User_ID]) REFERENCES [dbo].[p_AppUser] ([AppUser_ID]),
    CONSTRAINT [FK_p_ProcessPhase_RowStatus_p_RowStatus] FOREIGN KEY ([RowStatus]) REFERENCES [dbo].[p_RowStatus] ([RowStatus_ID]),
    CONSTRAINT [UQ_p_ProcessPhase] UNIQUE NONCLUSTERED ([ProcessPhase_Code] ASC)
);

