using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartQA.Migrations
{
    public partial class DocDateFunction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"                
                create function dbo.f_SiteDTS
                (
                       @DToffset     datetimeoffset
                )      returns             datetime 
                begin
                       Declare @DT datetime;
                       set @DT = (select @DToffset AT TIME ZONE (select top 1 Parameter_Value from dbo.p_Parameter where Parameter_Code = 'SiteTimezone'));
                       return @DT;
                end;                
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"                
                drop function if exists dbo.f_SiteDTS;                                
            ");
        }
    }
}
