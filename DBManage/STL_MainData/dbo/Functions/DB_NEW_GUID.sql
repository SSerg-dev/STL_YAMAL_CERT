
-- =============================================
-- Author:		RAlizade
-- Create date: 2017-11-27
-- Description:	Function returns a new GUID from the DB. It is a utility function for SSIS
-- =============================================
CREATE FUNCTION [dbo].[DB_NEW_GUID] 
(
	-- Add the parameters for the function here

)
RETURNS uniqueidentifier
AS
BEGIN

	RETURN (select new_id from dbo.getnewID)

END
