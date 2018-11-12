using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartQA1._1._2.Service
{
	public class StringBank
	{
		/*this class is used as a generator of static string array, used then
		as by random string generators*/

		public static string[] bank;
		static StringBank() {
			bank = textString.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries);
		}

		static string textString = @"At vero eos et accusamus et iusto odio 
					dignissimos ducimus qui blanditiis praesentium voluptatum delaniti atque corrupti 
					quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, 
					similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et 
					dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero 
					tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod 
					maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. 
					Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe 
					eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque 
					earum rerum hic tenetur a sapiente delactus, ut aut reiciendis voluptatibus 
					maiores alias consequatur aut perferendis doloribus asperiores repellat.";

		public static string generateArbitraryString()
		{
			string[] mutatedString = StringBank.bank;
			int i = 0; 
			mutatedString[i++] = null;
			mutatedString[i++] = "@";
			mutatedString[i++] = "/";
			mutatedString[i++] = "#";
			mutatedString[i++] = ('"').ToString();
			mutatedString[i++] = "*";
			mutatedString[i++] = "select";
			mutatedString[i++] = "; select * from [DEV_STL_MainData].[dbo].[UI_ABDFinalFolderList]";
			mutatedString[i++] = "16549878";
			mutatedString[i++] = "213.";
			mutatedString[i++] = ".21";
			mutatedString[i++] = "123.21.23.";
			mutatedString[i++] = "/*4";
			mutatedString[i++] = "23.12.2017";
			mutatedString[i++] = "12.23.2017";
			mutatedString[i++] = "-12.32.234";
			mutatedString[i++] = "12.14.2017";
			mutatedString[i++] = "12.12.12";
			mutatedString[i++] = "12.12.2012";
			mutatedString[i++] = "YAM";
			mutatedString[i++] = "COW";
			mutatedString[i++] = "ЭМ";
			mutatedString[i++] = "АВК";
			mutatedString[i++] = "ГП";
			mutatedString[i++] = "R00";
			mutatedString[i++] = "18";
			mutatedString[i++] = "КОМП";
			mutatedString[i++] = "";
	
			return mutatedString[(new Random()).Next(mutatedString.Length)];
		}
	}
}