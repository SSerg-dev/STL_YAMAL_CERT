CREATE TABLE [dbo].[p_PID_to_VendorRequisition] (
    [PID_to_VendorRequisition_ID] UNIQUEIDENTIFIER CONSTRAINT [DF_PID_to_VendorRequisition_ID] DEFAULT (newsequentialid()) NOT NULL,
    [Insert_DTS]                  DATETIME2 (7)    NULL,
    [Update_DTS]                  DATETIME2 (7)    NULL,
    [Row_Status]                  INT              NULL,
    [PID_ID]                      UNIQUEIDENTIFIER NOT NULL,
    [VendorRequisition_ID]        UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_p_PID_to_VendorRequisition] PRIMARY KEY CLUSTERED ([PID_to_VendorRequisition_ID] ASC),
    CONSTRAINT [FK_p_PID_to_VendorRequisition_PID_ID_p_PID] FOREIGN KEY ([PID_ID]) REFERENCES [dbo].[p_PID] ([PID_ID]),
    CONSTRAINT [FK_p_PID_to_VendorRequisition_Row_Status_p_RowStatus_sys] FOREIGN KEY ([Row_Status]) REFERENCES [dbo].[p_RowStatus_sys] ([Row_Status]),
    CONSTRAINT [FK_p_PID_to_VendorRequisition_VendorRequisition_ID_p_VendorRequisition] FOREIGN KEY ([VendorRequisition_ID]) REFERENCES [dbo].[p_VendorRequisition] ([VendorRequisition_ID]),
    CONSTRAINT [UQ_p_PID_to_VendorRequisition] UNIQUE NONCLUSTERED ([PID_ID] ASC, [VendorRequisition_ID] ASC)
);

