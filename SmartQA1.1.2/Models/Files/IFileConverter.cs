using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartQA1._1._2.Models
{
    interface IFileConverter : IDisposable
    {
        //this method returns the preview absolute path
        string Convert(out string folder, out string mainFileCreated);
    }
}
