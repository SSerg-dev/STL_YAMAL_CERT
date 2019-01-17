CREATE VIEW dbo.Register_to_TitleObject
AS
SELECT        Register_to_TitleObject_ID, Register_ID, TitleObject_ID, Iteration
FROM            dbo.p_Register_to_TitleObject
WHERE        (RowStatus < 100)