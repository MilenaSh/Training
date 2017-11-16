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

            //var testList = new List2<string>();

            //Console.WriteLine(testList);

            //testList.Add("Sample string");

            //Console.WriteLine(testList);
            var test = new HashSet<string>();
            var list = new List<TestClas>();
            for (int i = 0; i < 20; i++)
            {
                list.Add(new TestClas
                {
                    Id = i,
                    Name = "Name " + i,
                    Price = 20 * i
                });
            }

            var result = list
                .Where(x => x.Price < 300)
                .GroupBy(x => x.Name)
                .Select(x=>)

            var t = 5;
        } 
    }
}
