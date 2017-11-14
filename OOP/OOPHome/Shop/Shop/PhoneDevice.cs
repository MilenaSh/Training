using Shop.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class PhoneDevice: Device
    {   
        public PhoneDevice()
        {
        }

        public PhoneDevice(string name, int price, bool inStock, DeviceType type) : base(name, price, inStock, type)
        {

        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Price: {1}, InStock: {2}, Type: {3}", Name, Price, InStock, Type);
        }
    }
}
