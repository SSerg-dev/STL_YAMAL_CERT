using Microsoft.EntityFrameworkCore;
using SmartQA.DB.QueryModels;

namespace SmartQA.DB
{
    public partial class DataContext
    {
        public DbQuery<PersonNaksCount> PersonNaksCount { get; set; }
        public DbQuery<NaksValidCount> NaksValidCount { get; set; }
    }
}