using Shop.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Device
    {
        // empty constructor

        public Device()
        {

        }

        // constructor with all properties

        public Device( string name, int price, bool inStock, DeviceType type)
        {
        this.Name = name;
        this.Price = price;
        this.InStock = inStock;
        this.Type = type; // TOCHECK
        }

        public string Name { get; set; }

        public int Price { get; set; }

        public bool InStock { get; set; }

        public DeviceType Type { get; set; }

    public override string ToString()
    {
        return String.Format("Name: {0}, Price: {1}, InStock: {2}, Type: {3}", Name, Price, InStock, Type);
    }

}

