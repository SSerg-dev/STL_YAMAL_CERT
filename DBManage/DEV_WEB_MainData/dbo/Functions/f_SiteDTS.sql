                
                create function dbo.f_SiteDTS
                (
                       @DToffset     datetimeoffset
                )      returns             datetime 
                begin
                       Declare @DT datetime;
                       set @DT = (select @DToffset AT TIME ZONE (select top 1 Parameter_Value from dbo.p_Parameter where Parameter_Code = 'SiteTimezone'));
                       return @DT;
                end;                
            
