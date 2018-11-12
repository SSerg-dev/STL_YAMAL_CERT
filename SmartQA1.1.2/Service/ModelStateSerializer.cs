using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SmartQA1._1._2.Service
{
    public static class ModelStateSerializer
    {
        public static string Serialize(this ModelStateDictionary modelState)
        {
            var sb = new StringBuilder();

            foreach (var error in modelState)
            {
                sb.Append(error);
            }

            return sb.ToString();
        }
    }
}