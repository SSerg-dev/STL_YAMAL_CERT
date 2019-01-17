

-- =============================================
-- Author:		RAlizade
-- Create date: 2017-11-07
-- Description:	Universal function of data transformation
-- =============================================
CREATE FUNCTION dbo.DataTransformation 
(
	-- Add the parameters for the function here
	@x_Value nvarchar(max),
	@x_Algorithm int,
	@x_Group int
		
)
RETURNS nvarchar(max)
AS
BEGIN

declare @x_Out_Value nvarchar(max)



------------------------------------------
 IF @x_Algorithm = 1
 begin
  
 set @x_Out_Value = @x_Value

 Select @x_Out_Value = Value_out_Min 
 from dbo.DataTrans 
 where @x_Value = Value_in_Min 
 and Group_Number = @x_Group   
 end 
 
 -----------------------------------------

 IF @x_Algorithm = 2
 begin
 
 Declare @x_Value_in_Min float
 Declare @x_Value_in_Max float
 
 Declare @x_Value_out_Min int

 Declare @x_Value_out_Min_Limit Date
 Declare @x_Top_Date Date
  
 Select @x_Value_out_Min = cast(Value_out_Min as int),
		@x_Value_out_Min_Limit = cast(Value_out_Min_Limit as Date)
 from dbo.DataTrans
 where cast(@x_Value as float) >= Cast(Value_in_Min as float) and cast(@x_Value as float) < Cast(Value_in_Max as float) 
 and Group_Number = @x_Group;
 
 set @x_Top_Date = dateadd(day,@x_Value_out_Min,cast(getdate() as date))

	 IF @x_Top_Date > @x_Value_out_Min_Limit
	 begin
	   set @x_Top_Date = @x_Value_out_Min_Limit
	 end 

	 set @x_Out_Value = cast(@x_Top_Date as nvarchar(max))
 end

------------------------------------------
  Return @x_Out_Value

END
