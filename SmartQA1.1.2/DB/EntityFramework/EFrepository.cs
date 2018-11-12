using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SmartQA1._1._2.DB.EntityFramework;
using SmartQA1._1._2.DB;

namespace SmartQA1._1._2.DB
{
    public class EFrepository
    {
        private static EFrepository instance;
        public Entities context;

        private EFrepository()
        {
            context = new Entities();
        }

        public static EFrepository Instance
        {
            get
            {
                return new EFrepository();
            }
        }

        /*
        public static EFrepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EFrepository();
                }
                return instance;
            }
        }
        */


    }
}