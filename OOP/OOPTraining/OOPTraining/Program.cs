using OOPTraining.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTraining
{
    class Program
    {
        static void Main(string[] args)
        {

            var newUniverse = new ScientificUniverse("Star Wars", 800000, UniverseType.SciFantasy);

            // var newFantasyUniverse = new FantasyUniverse("Fantasy", 10000, UniverseType.Fantasy);

            //var secondUniverse = new ScientificUniverse("Firescape", 4000000, UniverseType.Fantasy);
            var scienceGenerator = new FantasyCreator();

            var thrd = scienceGenerator.CreateRandomUniverse();

            Console.WriteLine(thrd.ToString());


            //var myUniverse = new Universe
            //{
            //    Name = "Star Wars",
            //    Age = 8000000000,
            //    Type = UniverseType.SciFantasy
            //};

            //var myUniverse2 = new Universe();
            //myUniverse2.Name = "Star Trek";
            //myUniverse2.Age = 1400000000;
            //myUniverse2.Type = UniverseType.SciFiction;

            //var myUnverse3 = new Universe("Warcraft", 1000000, UniverseType.Fantasy);

            //Console.WriteLine(myUniverse.ToString());
            //Console.WriteLine(myUniverse2.ToString());
            //Console.WriteLine(myUnverse3.ToString());
        }
    }
}
