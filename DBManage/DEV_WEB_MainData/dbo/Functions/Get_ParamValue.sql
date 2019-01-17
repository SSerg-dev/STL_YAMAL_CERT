CREATE function [dbo].[Get_ParamValue]
(
	 @Parameter_Code	nvarchar(255)
) returns table as return
( 
	select Parameter_Value from p_Parameter
	where Parameter_Code =  @Parameter_Code
	and RowStatus < 100
)

