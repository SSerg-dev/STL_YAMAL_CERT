CREATE TABLE [dbo].[p_WorkProgressRegisters] (
    [WorkProgressRegisters_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_WorkProgressRegisters_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Parent_ID]                UNIQUEIDENTIFIER NULL,
    [LogId]                    NVARCHAR (50)    NOT NULL,
    [WorkPackage_ID]           UNIQUEIDENTIFIER NOT NULL,
    [Reg]                      NVARCHAR (255)   NULL,
    [TitleObject_ID]           UNIQUEIDENTIFIER NOT NULL,
    [Unit]                     NVARCHAR (255)   NULL,
    [Marka_ID]                 UNIQUEIDENTIFIER NOT NULL,
    [Work_Desc]                NVARCHAR (255)   NULL,
    [CNT_Date]                 DATETIME2 (7)    NULL,
    [Repr_SCNT]                NVARCHAR (255)   NULL,
    [Repr_CNT]                 NVARCHAR (255)   NULL,
    [Status_Date]              DATETIME2 (7)    NULL,
    [ABDStatus_ID]             UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]               INT              NOT NULL,
    [Insert_DTS]               DATETIME2 (7)    NOT NULL,
    [Update_DTS]               DATETIME2 (7)    NOT NULL,
    [Source_File]              NVARCHAR (500)   NULL,
    [SDM_FEI_SI]               NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_WorkProgressRegisters] PRIMARY KEY CLUSTERED ([WorkProgressRegisters_ID] ASC)
);

