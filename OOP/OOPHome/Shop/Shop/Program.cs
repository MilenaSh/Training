using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            var myPhone = new PhoneDevice("Nokia", 200, true, Shop.Enum.DeviceType.Phone);

            Console.WriteLine(myPhone.ToString());
        }
    }
}
