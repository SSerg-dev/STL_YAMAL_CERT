using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DevExpress.Web.Mvc;
using SmartQA1._1._2.Models.Register;

namespace SmartQA1._1._2.Views.CommonSettings
{
    /// <summary>
    /// This class is used just to pass variables between partial views - 
    /// FormLayout and SingleSelect
    /// </summary>
    public class SingleSelect
    {
        public MVCxFormLayoutItem i;
        public Dictionary<Guid, string> dict;
        public string name;

        public SingleSelect(MVCxFormLayoutItem i, Dictionary<Guid, string> dict, string name)
        {
            this.i = i;
            this.dict = dict;
            this.name = name;

            if (i == null) throw new ArgumentNullException("Layout item is null");
            if (dict == null) throw new ArgumentNullException("Dictionary provided is null");
            if (name == null) throw new ArgumentNullException("Name provided is null");
        }
    }
}