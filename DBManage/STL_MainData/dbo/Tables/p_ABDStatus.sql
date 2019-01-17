CREATE TABLE [dbo].[p_ABDStatus] (
    [ABDStatus_ID]    UNIQUEIDENTIFIER CONSTRAINT [DF_ABDStatus_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Stage]           NVARCHAR (100)   NULL,
    [Code]            NVARCHAR (50)    NOT NULL,
    [Description_Eng] NVARCHAR (255)   NULL,
    [Description_Rus] NVARCHAR (255)   NULL,
    [Status_Type]     INT              NULL,
    [Row_status]      INT              NULL,
    [Insert_DTS]      DATETIME2 (7)    NULL,
    [Update_DTS]      DATETIME2 (7)    NULL,
    [ReportColor]     NVARCHAR (50)    NULL,
    [ReportOrder]     INT              NULL,
    CONSTRAINT [PK_p_ABDStatus] PRIMARY KEY CLUSTERED ([ABDStatus_ID] ASC),
    CONSTRAINT [FK_p_ABDStatus_Row_status_p_RowStatus_sys] FOREIGN KEY ([Row_status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [UQ_p_ABDStatus] UNIQUE NONCLUSTERED ([Code] ASC)
);

