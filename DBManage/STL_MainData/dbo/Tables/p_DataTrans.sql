CREATE TABLE [dbo].[p_DataTrans] (
    [DataTrans_ID]        UNIQUEIDENTIFIER NOT NULL,
    [Row_Status]          INT              NULL,
    [Insert_DTS]          DATETIME2 (7)    NULL,
    [Update_DTS]          DATETIME2 (7)    NULL,
    [Value_in_Min]        NVARCHAR (255)   NULL,
    [Value_in_Max]        NVARCHAR (255)   NULL,
    [Value_out_Min]       NVARCHAR (255)   NULL,
    [Value_out_Max]       NVARCHAR (255)   NULL,
    [Group_Number]        INT              NULL,
    [Value_out_Min_Limit] NVARCHAR (255)   NULL,
    [Value_out_Max_Limit] NVARCHAR (255)   NULL,
    CONSTRAINT [PK_p_DataTrans] PRIMARY KEY CLUSTERED ([DataTrans_ID] ASC)
);

