


CREATE view [dbo].[Register_to_ABDStatus]
AS
SELECT        Register_To_ABDStatus_ID, Parent_ID, Register_ID, ABDStatus_ID, ABDStatusDate
FROM            dbo.p_Register_to_ABDStatus
WHERE        (row_status < 100)
