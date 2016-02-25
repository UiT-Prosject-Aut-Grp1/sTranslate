using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using sTranslate.Tools; 

namespace sTranslate.TestApp
{
    class Program
    {
        static void StressTest(string filePath, int numLoops)
        {
            try
            {
                DateTime startTime = DateTime.Now;
                int searchCounter = 0;
                int pctComplete = 0;
                List<TimeSpan> loopTimes = new List<TimeSpan>();
                DateTime loopStartTime, loopEndTime;
                string fromText, context, property, criteria, toLang, toText;
                string[] lines = System.IO.File.ReadAllLines(filePath + @"\StressTest.csv", Encoding.GetEncoding("ISO-8859-1"));

                for (int i = 1; i<=numLoops; i++)
                {
                    loopStartTime = DateTime.Now;
                    foreach (string line in lines) {
                        string[] splitLine = line.Split(';');
                        fromText = splitLine[0];
                        context = splitLine[1];
                        property = splitLine[2];
                        criteria = splitLine[3];
                        toLang = splitLine[4];
                        toText = Tools.XltTool.ToText(EnumsXlt.ToCriteria(criteria), fromText, EnumsXlt.ToPropertyType(property), context, toLang);
                        searchCounter++;
                    }
                    loopEndTime = DateTime.Now;
                    loopTimes.Add(loopEndTime - loopStartTime);
                    pctComplete = (int)Math.Floor((float) i / (float)numLoops * 100.0);
                    Console.Write("\r{0}%",pctComplete);
                }
                Console.WriteLine();
                TimeSpan elapsedTime = DateTime.Now - startTime;

                Console.WriteLine("Duration: {0} sec", elapsedTime);
                Console.WriteLine("Searches: {0}", searchCounter);
                Console.WriteLine("Loops: {0}", numLoops);
                Console.Write("Loop times: ");

                try
                {
                    // Try to delete the file.
                    File.Delete(filePath + @"\Log.csv");
                }
                catch (IOException)
                {
                }

                System.IO.StreamWriter objWriter;
                objWriter = new System.IO.StreamWriter(filePath + @"\Log.csv");
                //FileStream myFile = File.OpenWrite(filePath + @"\Log.csv");
                foreach (var item in loopTimes)
                {
                    Console.Write(item + ", ");
                    objWriter.WriteLine(item.ToString());
                }
                Console.WriteLine();
                objWriter.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", XltTool.ExceptionMsg(ex, true));
            }
        }
        
        /// <summary>
        /// Using: TestApp Context Property Criteria ToLang FromText  
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory;
            int numLoops = 1000;
            StressTest(filePath, numLoops);

            Console.ReadKey();
        }
    }
}
