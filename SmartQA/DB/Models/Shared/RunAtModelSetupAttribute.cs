using System;

namespace SmartQA.DB.Models.Shared
{
    /// <summary>
    /// Run the method at model setup, during DataContext.OnModelCreating.
    /// Decorated method must have signature:
    ///
    /// </summary>
    /// <example>
    /// [RunAtModelSetup]
    /// static void CustomModelSetup(ModelBuilder modelBuilder) {
    ///
    /// } 
    /// </example>
    public class RunAtModelSetupAttribute : Attribute       
    {
        
    }
}