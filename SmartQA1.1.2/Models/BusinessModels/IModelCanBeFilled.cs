using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartQA1._1._2
{
    /*Classes that usually implement this interface usually are view Models*/
	public interface IModelCanBeFilled<T>
	{
        /*this method is called either by TestClasses or by MVC Controllers
         They both convert the return value to Json. */
        IList<T> fill(string searchParameter = null);
    }
}
