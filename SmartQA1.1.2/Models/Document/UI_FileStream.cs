using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartQA1._1._2.DB.WebDb
{
    public partial class UI_FileStream : IEquatable<UI_FileStream>
    {
        public bool Equals(UI_FileStream other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return FileTable_ID.Equals(other.FileTable_ID);
        }

        //public override bool Equals(object obj)
        //{
        //    if (ReferenceEquals(null, obj)) return false;
        //    if (ReferenceEquals(this, obj)) return true;
        //    if (obj.GetType() != this.GetType()) return false;
        //    return Equals((UI_FileStream) obj);
        //}

        public override int GetHashCode()
        {
            return FileTable_ID.GetHashCode();
        }
    }
}