using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using sTranslate.Tools; 

namespace sTranslate.TestApp
{
    class Program
    {
        /// <summary>
        /// Using: TestApp Context Property Criteria ToLang FromText  
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DateTime startTime = DateTime.Now;
            // Get my name
            string[] strArr = Assembly.GetCallingAssembly().FullName.Split(',');
            string myName = strArr[0];
 
            // Check command syntax
            if (args.Length < 5)
            {
                Console.WriteLine("Using: {0}.exe Context Property Criteria ToLang Text", myName);
                return; 
            }

            string context = args[0];
            string property = args[1];
            string criteria = args[2];
            string toLang = args[3];
            string text = args[4];

            try
            {
                // Call translation an print output
                string toText = Tools.XltTool.GetToText(EnumsXlt.ToCriteria(criteria), text, EnumsXlt.ToPropertyType(property), context, toLang);
                Console.WriteLine("{0}: English: \"{1}\" translated to Norwegian: \"{2}\"", myName, text, toText);
                Console.WriteLine("{0}: Duration: {1}", myName, DateTime.Now.Subtract(startTime));
                Console.WriteLine("Press any key to end ...");
                Console.ReadKey(); 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", XltTool.ExceptionMsg(ex, true)); 
            }
        }
    }
}
