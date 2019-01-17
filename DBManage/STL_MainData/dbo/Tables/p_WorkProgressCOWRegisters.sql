CREATE TABLE [dbo].[p_WorkProgressCOWRegisters] (
    [WorkProgressCOWRegisters_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_WorkProgressCOWRegisters_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Parent_ID]                   UNIQUEIDENTIFIER NULL,
    [Log_ID]                      NVARCHAR (50)    NOT NULL,
    [WorkPackage_ID]              UNIQUEIDENTIFIER NULL,
    [Reg]                         NVARCHAR (4000)  NULL,
    [TitleObject_ID]              UNIQUEIDENTIFIER NULL,
    [Module_ID]                   UNIQUEIDENTIFIER NULL,
    [Marka_ID]                    UNIQUEIDENTIFIER NULL,
    [Work_Desc]                   NVARCHAR (4000)  NULL,
    [CNT_Date]                    DATETIME2 (7)    NULL,
    [Repr_SCNT]                   NVARCHAR (255)   NULL,
    [Repr_CNT]                    NVARCHAR (255)   NULL,
    [Status_Date]                 DATETIME2 (7)    NULL,
    [ABDStatus_ID]                UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]                  INT              NOT NULL,
    [Insert_DTS]                  DATETIME2 (7)    NOT NULL,
    [Update_DTS]                  DATETIME2 (7)    NOT NULL,
    [Source_File]                 NVARCHAR (500)   NULL,
    CONSTRAINT [PK_p_WorkProgressCOWRegisters] PRIMARY KEY CLUSTERED ([WorkProgressCOWRegisters_ID] ASC)
);

