using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyList<T>
    {
        private const int InitialSize = 4;
        private const int Multiplier = 2;

        private int size;
        private T[] arr;

        public int Length { get; set; }


        public MyList()
        {
            size = InitialSize;
            arr = new T[size];
            Length = 0;
        }

        //public void Add()


    }
}
