using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace SortedNames
{
    class Program
    {

        public class Names
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string ThirdName { get; set; }
            public string FourthName { get; set; }
            public string LastName { get; set; }

        }
        static void Main(string[] args)
        {
            string strdata = File.ReadAllText(@"C:\Users\Administrator\Documents\Visual Studio 2010\Projects\SortedNames\SortedNames\unsorted-names-list.txt");
            string[] rowdata = strdata.Split("\r\n\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<Names> stulist = new List<Names>();
            foreach (string name in rowdata)
            {

                
                Names stuobj = new Names();
                string[] splitdata = name.Split(' ');

                if (name.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Length >= 2)
                {
                    stuobj.FirstName = splitdata[0];
                    stuobj.SecondName = splitdata[1];
                    stuobj.LastName = splitdata[1];

                }
                if (name.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Length >= 3)
                {
                    stuobj.FirstName = splitdata[0];
                    stuobj.SecondName = splitdata[1];
                    stuobj.ThirdName = splitdata[2];
                    stuobj.LastName = splitdata[2];
                }

                if (name.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Length >= 4)
                {
                    stuobj.FirstName = splitdata[0];
                    stuobj.SecondName = splitdata[1];
                    stuobj.ThirdName = splitdata[2];
                    stuobj.FourthName = splitdata[3];
                    stuobj.LastName = splitdata[3];
                }









                stulist.Add(stuobj);
                
            }
            //You will have the sorted data here
            var sortedlist = stulist.OrderBy(s => s.LastName).ThenBy(s => s.FirstName);



            TextWriter twriter = new StreamWriter(@"C:\Users\Administrator\Documents\Visual Studio 2010\Projects\SortedNames\SortedNames\sorted-names-list.txt");
            foreach (var show in sortedlist)
            {

                twriter.WriteLine(string.Format("{0} {1} {2} {3}", show.FirstName, show.SecondName, show.ThirdName, show.FourthName));
                Console.WriteLine("{0} {1} {2} {3}", show.FirstName, show.SecondName, show.ThirdName, show.FourthName);
                
            }
            twriter.Close();

        



        }
    }
}
