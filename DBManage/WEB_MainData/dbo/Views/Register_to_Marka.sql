CREATE VIEW dbo.Register_to_Marka
AS
SELECT        Register_to_Marka_ID, Register_ID, Marka_ID, Iteration
FROM            dbo.p_Register_to_Marka
WHERE        (RowStatus < 100)