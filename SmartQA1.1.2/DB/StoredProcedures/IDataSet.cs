using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartQA1._1._2.DB.StoredProcedures
{
    public interface IDataSet<T>
    {
        T ConvertFromException(Exception ex);
        T ConvertFromErrorMessage(string errorMessage);
        string ToString();
    }
}
