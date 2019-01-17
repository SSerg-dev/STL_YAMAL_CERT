
-- =============================================
-- Author:		ASmirnov
-- Create date: 2017-01-04
-- Description:	The procedure marks register as deleted 
-- =============================================
CREATE PROCEDURE [dbo].[Delete_Register]
	-- Add the parameters for the stored procedure here
	 @i_Register_ID			nvarchar(250),
	 @i_User_Name			nvarchar(250),
	 @i_UserLanguage		nvarchar(250),

	 @o_Reg_ID				nvarchar(250) OUTPUT,
	 @o_Reg_Number			nvarchar(250) OUTPUT,
	 @o_Error_ID			nvarchar(250) OUTPUT,
	 @o_Error_Mesage    	nvarchar(250) OUTPUT

AS
BEGIN

Declare @Row_status_Del		bigint
	   ,@REG_Number			nvarchar(100)

	   ,@MText				nvarchar(max)

	   ,@x_Count			bigint
	   ,@Error_ID			int 
	   ,@Cur_Date			datetime
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

-- Message variables initializations
-- User language 0 - English, 1 - Russian

-- Data initialization 
SET @Error_ID = 0
SET @Row_status_Del = 200
SET @Cur_Date = getdate()

	-- Input data preparation

	 	-- Data check 
	-- ======== Status =========================================================
	SET @x_Count = 0 

	-- ======= RowStatus =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[RowStatus_sys] where Row_Status = TRY_cast(@Row_status_Del as int) 

	IF @x_Count <> 1
	begin
		SET @MText = 'Wrong RowStatus!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = 'Ошибка статуса строки!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	end

	-- ======= Register_ID =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[Register] where Register_ID = TRY_cast(@i_Register_ID as uniqueidentifier) 

	IF @x_Count <> 1 
	begin
		SET @MText = 'Register_ID not found!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = 'GUID реестра не найден!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	end
	Else IF @x_Count = 1 
	begin
		select @REG_Number = Register_Number from [dbo].[Register] where Register_ID = TRY_cast(@i_Register_ID as uniqueidentifier) 
	end


-- ==== Main data  operation =======================

		Begin Transaction WTB;
	
		-- ====Register Update ====	
		BEGIN
			Begin try
				Update [dbo].[p_Register]
				set Row_Status = '200'
					,Modified_By = @i_User_Name
					,Update_DTS = @Cur_Date
				Where Register_ID = @i_Register_ID;
			END TRY 
		 
			BEGIN CATCH  
				SET @Error_ID = ERROR_NUMBER()
				SET @MText = ERROR_MESSAGE()

				IF @@TRANCOUNT > 0  
					BEGIN
					ROLLBACK TRANSACTION WTB;  
					GOTO Tran_WTB_Rejected;
					END;
			END CATCH; 

		
Tran_WTB_Rejected: --all catched errors in WTB transaction lead here	

		IF @@TRANCOUNT > 0 
			BEGIN
			  
			COMMIT TRANSACTION WTB; 
		
			END;

    -- Output parameters of the procedure 
DataErrorWay: --all data checkig errors lead here

	SET @o_Reg_ID = Ltrim(Rtrim(TRY_cast(@i_Register_ID as nvarchar(250))))
	SET @o_Reg_Number = Ltrim(Rtrim(TRY_cast(@REG_Number as nvarchar(250))))
	SET @o_Error_ID = Ltrim(Rtrim(TRY_cast(@Error_ID as nvarchar(250))))
	SET @o_Error_Mesage = Ltrim(Rtrim(TRY_cast(@MText as nvarchar(250))))

END
END
