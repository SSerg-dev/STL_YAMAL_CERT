using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using SmartQA1._1._2.DB.WebDb;

namespace SmartQA1._1._2.Models.Register
{
    public class NamedList<T> : List<T>
    {
        public bool IsLatest = false;
        public string Name;
        public int id;

        public NamedList(string name, int id)
        {
            Name = name;
            this.id = id;
        }

        public NamedList(string name, List<T> list) : base(list)
        {
            Name = name;
        }
    }
}