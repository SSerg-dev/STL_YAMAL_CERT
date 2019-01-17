
-- =============================================
-- Author:		ASmirnov
-- Create date: 2017-01-05
-- Description:	The procedure adds a new Marka
-- =============================================
CREATE PROCEDURE [dbo].[New_Marka]
	-- Add the parameters for the stored procedure here
		 @i_Marka_Name						nvarchar(250)
		,@i_Code_of_mark					nvarchar(250)
		,@i_Description_Eng					nvarchar(4000)
		,@i_Description_Rus					nvarchar(4000)
		,@i_Engineering_Drawing_Type_Eng	nvarchar(4000)
		,@i_Engineering_Drawing_Type_Rus	nvarchar(4000)
		,@i_IsUsedInMatrix					nvarchar(250)
		,@i_IsPriority						nvarchar(250)
		,@i_ReportColor						nvarchar(250)
		,@i_ReportOrder						nvarchar(250)
		,@i_User_Name						nvarchar(250)
		,@i_Row_Status						nvarchar(250)
		,@i_UserLanguage					nvarchar(250)

		,@o_Marka_ID						nvarchar(250) OUTPUT
		,@o_Marka_Name						nvarchar(250) OUTPUT
		,@o_Error_ID						nvarchar(250) OUTPUT
		,@o_Error_Mesage    				nvarchar(250) OUTPUT

AS
BEGIN

Declare @Cur_Date datetime

Declare @MText nvarchar(max)
Declare @NEW_ID uniqueidentifier

Declare @x_Count bigint 
Declare @Error_ID int

Declare @IsUsedInMatrix bit
Declare @IsPriority bit
Declare @ReportOrder int


	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

-- Message variables initializations
-- User language 0 - English, 1 - Russian

-- Data initialization 
SET @Error_ID = 0
SET @Cur_Date = getdate()

	-- Input data preparation
	 SET @i_Marka_Name						= Ltrim(Rtrim(@i_Marka_Name))
	 SET @i_Code_of_mark					= Ltrim(Rtrim(@i_Code_of_mark))
	 SET @i_Description_Eng					= Ltrim(Rtrim(@i_Description_Eng))
	 SET @i_Description_Rus					= Ltrim(Rtrim(@i_Description_Rus))
	 SET @i_Engineering_Drawing_Type_Eng	= Ltrim(Rtrim(@i_Engineering_Drawing_Type_Eng))
	 SET @i_Engineering_Drawing_Type_Rus	= Ltrim(Rtrim(@i_Engineering_Drawing_Type_Rus))
	 
	-- Data check 
	-- ======== Status =========================================================
	SET @x_Count = 0 

	-- === Incomeing Date checking ==============
	IF TRY_CONVERT(bit,@i_IsUsedInMatrix) is null
	BEGIN
		SET @MText = N'Is used in matrix value error!'
		IF TRY_cast(@i_UserLanguage as int) = 1 SET @MText = N'Ошибка значения Используется в матрице!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	END
	ELSE
	BEGIN
		SET @IsUsedInMatrix = CONVERT(bit,@i_IsUsedInMatrix)
	END

	IF TRY_CONVERT(bit,@i_IsPriority) is null
	BEGIN
		SET @MText = N'Is Priority value error!'
		IF TRY_cast(@i_UserLanguage as int) = 1 SET @MText = N'Ошибка значения приоритетности!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	END
	ELSE
	BEGIN
		SET @IsPriority = CONVERT(bit,@i_IsPriority)
	END

	IF TRY_CONVERT(int,@i_ReportOrder) is null
	BEGIN
		SET @MText = N'ReportOrder value error!'
		IF TRY_cast(@i_UserLanguage as int) = 1 SET @MText = N'Ошибка значения очередности сортировки!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	END
	ELSE
	BEGIN
		SET @ReportOrder = CONVERT(int,@i_ReportOrder)
	END

	-- ======= RowStatus =======================================================
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[RowStatus_sys] where Row_Status = TRY_cast(@i_Row_Status as int) 

	IF @x_Count <> 1
	begin
		SET @MText = N'Wrong RowStatus!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = N'Ошибка статуса строки!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	end

	-- === Is New Marka is Unique =============
	
	IF @i_Marka_Name  is null or @i_Marka_Name  = ''
	BEGIN
		SET @MText = 'Marka name is incorrect!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = 'Некорректное название марки!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	END 
	
	SET @x_Count = 0 
	Select @x_Count = count(*) from [dbo].[p_Marka] where Marka_Name = @i_Marka_Name

	IF @x_Count > 0
	BEGIN
		SET @MText = N'Такое название марки уже есть в базе!'
		IF TRY_cast(@i_UserLanguage as Int) = 1 SET @MText = N'That Marka name allredy exists!'
		SET @Error_ID = 30 -- General Data Error 
		GoTo DataErrorWay;
	END

-- ==== Main data insert operation =======================

		SET @NEW_ID = newid()

		Begin Transaction WTB;
	
		-- ====Marka Insertion ====
		Begin try
		INSERT INTO [dbo].[p_Marka]
           ([Marka_ID]
           ,[Marka_Name]
           ,[Code_of_mark]
           ,[Description_Eng]
           ,[Description_Rus]
           ,[Engineering_Drawing_Type_Eng]
           ,[Engineering_Drawing_Type_Rus]
           ,[Row_Status]
           ,[IsUsedInMatrix]
           ,[IsPriority]
           ,[Insert_DTS]
           ,[Update_DTS]
           ,[ReportColor]
           ,[ReportOrder]
		   ,[Created_By]
		   ,[Modified_By])
     VALUES
           (@NEW_ID
           ,@i_Marka_Name
           ,@i_Code_of_mark
           ,@i_Description_Eng
           ,@i_Description_Rus
           ,@i_Engineering_Drawing_Type_Eng
           ,@i_Engineering_Drawing_Type_Rus
           ,TRY_cast(@i_Row_Status as int)
           ,@IsUsedInMatrix
           ,@IsPriority
           ,@Cur_Date
           ,@Cur_Date
           ,@i_ReportColor
           ,@ReportOrder
		   ,@i_User_Name
		   ,@i_User_Name);

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

	SET @o_Marka_ID = Ltrim(Rtrim(TRY_cast(@NEW_ID as nvarchar(250))))
	SET @o_Marka_Name = Ltrim(Rtrim(TRY_cast(@i_Marka_Name as nvarchar(250))))
	SET @o_Error_ID = Ltrim(Rtrim(TRY_cast(@Error_ID as nvarchar(250))))
	SET @o_Error_Mesage = Ltrim(Rtrim(TRY_cast(@MText as nvarchar(250))))

END
