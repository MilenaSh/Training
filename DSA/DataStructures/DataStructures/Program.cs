using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class TestClas
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

    }

    class TestClasModel
    {

        public string Name { get; set; }

        public decimal Price { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //var myList = new List<string>();

            //myList.Add("Sample string");

            var testList = new List2<string>();

            //testList.ResizeCollection(10);

            testList.Add("Sample string");
            testList.Add("Sample string1");
            testList.Add("Sample string2");
            testList.Add("Sample string3");

            

           Console.WriteLine( testList.Remove("Sample string2"));

           

            testList.IndexOf("Sample string");
        

            // Console.WriteLine(testList.IndexOf("Sample string"));

           //  Console.WriteLine(testList.Contains("Sample string"));

            testList.Clear();

            //Console.WriteLine(testList);



            //var test = new HashSet<string>();
            //var list = new List<TestClas>();
            //for (int i = 0; i < 20; i++)
            //{
            //    list.Add(new TestClas
            //    {
            //        Id = i,
            //        Name = "Name " + i,
            //        Price = 20 * i
            //    });
            //}

            //var result = list
            //    .Where(x => x.Price < 300)
            //    .GroupBy(x => x.Name)
            //    .Select(x =>);

            //var t = 5;

            // create custom dictionaries

           // var myTestDictionary = new MyDictionary<string, string>();
           // myTestDictionary.Add("Milena", "5");
          //  myTestDictionary.Add("Plamen", "6");

          //  Console.WriteLine(myTestDictionary);

        }
    }
}
