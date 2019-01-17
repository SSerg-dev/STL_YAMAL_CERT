

CREATE VIEW [dbo].[R_Register_to_ABDStatus]
AS
SELECT        dbo.p_Register.Register_Number, dbo.p_Register.Register_ID, dbo.p_Register.SCTR_RESP, dbo.p_Register.CTR_RESP, dbo.p_Register.Created_By, 
                         dbo.p_Register.Modified_By, dbo.p_Register.LOG_ID, dbo.p_Register.FileLOG, dbo.p_ABDStatus.Stage, dbo.p_ABDStatus.Description_Eng, 
                         dbo.p_ABDStatus.Description_Rus
FROM            dbo.p_Register_to_ABDStatus INNER JOIN
                         dbo.p_Register ON dbo.p_Register_to_ABDStatus.Register_ID = dbo.p_Register.Register_ID INNER JOIN
                         dbo.p_ABDStatus ON dbo.p_Register_to_ABDStatus.ABDStatus_ID = dbo.p_ABDStatus.ABDStatus_ID
