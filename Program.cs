using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace SortedNames
{
    class Program
    {
        //Create Public Class to define parameter, there is a name consisting of 4 words so I made 4 parameters and 1 additional parameter for sorting
        public class Names
        {
            public string FirstName { get; set; }
            public string SecondName { get; set; }
            public string ThirdName { get; set; }
            public string FourthName { get; set; }
            public string LastName { get; set; }  //additional parameter for sorting function

        }
        static void Main(string[] args)
        {
            //create a function for uploading txtfile
            string strdata = File.ReadAllText(@"C:\Users\Administrator\Documents\Visual Studio 2010\Projects\SortedNames\SortedNames\unsorted-names-list.txt");
            string[] rowdata = strdata.Split("\r\n\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            List<Names> stulist = new List<Names>();
            foreach (string name in rowdata)
            {

                
                Names stuobj = new Names();
                string[] splitdata = name.Split(' ');

                if (name.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Length >= 2) //for a name that has 2 words
                {
                    stuobj.FirstName = splitdata[0];
                    stuobj.SecondName = splitdata[1];
                    stuobj.LastName = splitdata[1]; //the second word is lastname

                }
                if (name.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Length >= 3) //for a name that has 3 words
                {
                    stuobj.FirstName = splitdata[0];
                    stuobj.SecondName = splitdata[1];
                    stuobj.ThirdName = splitdata[2];
                    stuobj.LastName = splitdata[2]; //the third word is lastname
                }

                if (name.Split(new char[0], StringSplitOptions.RemoveEmptyEntries).Length >= 4) //for a name that has 4 words
                {
                    stuobj.FirstName = splitdata[0];
                    stuobj.SecondName = splitdata[1];
                    stuobj.ThirdName = splitdata[2];
                    stuobj.FourthName = splitdata[3];
                    stuobj.LastName = splitdata[3]; //the fourth word is lastname
                }









                stulist.Add(stuobj);
                
            }


            //create a sorting function based on lastname (last word) and firstname
            var sortedlist = stulist.OrderBy(s => s.LastName).ThenBy(s => s.FirstName);


            //create a sorting function based on lastname (last word) and firstname
            TextWriter twriter = new StreamWriter(@"C:\Users\Administrator\Documents\Visual Studio 2010\Projects\SortedNames\SortedNames\sorted-names-list.txt");
            foreach (var show in sortedlist)
            {

                twriter.WriteLine(string.Format("{0} {1} {2} {3}", show.FirstName, show.SecondName, show.ThirdName, show.FourthName)); //create txtfile
                Console.WriteLine("{0} {1} {2} {3}", show.FirstName, show.SecondName, show.ThirdName, show.FourthName); //show data
                
            }
            twriter.Close();

        



        }
    }
}
