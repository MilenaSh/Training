using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class List2<T>
    {
        // constants for the list
        private const int InitialSizeConstant = 4;
        private const int Multiplier = 2;

        // fields
        private T[] arr;
        private int internalSize;
        private int currentLength; // next index

        // To access by index
        public T this[int index]
        {
            get
            {
                if (index > currentLength - 1)
                {
                    throw new IndexOutOfRangeException("The index is too large");
                }

                if (index < 0)
                {
                    throw new IndexOutOfRangeException("The index is smaller than 0");
                }

                return this.arr[index];
            }
            set
            {
                if (index > currentLength - 1)
                {
                    throw new IndexOutOfRangeException("The index is too large");
                }

                if (index < 0)
                {
                    throw new IndexOutOfRangeException("The index is smaller than 0");
                }

                this.arr[index] = value;
            }
        }

        // Count Length - property only with get
       // public int Count => throw new NotImplementedException();

        public List2()
        {
            this.internalSize = List2<T>.InitialSizeConstant;
            this.arr = new T[this.internalSize];
            this.currentLength = 0;
        }

        // Add items - when the array length is reached
        public void Add(T item)
        {
            // check the current size of the array and resize if more than the length
            if (this.currentLength == this.internalSize)
            {
                this.Resize();
            }

            // find the first free index
            var index = this.currentLength;

            // add the new item to the first free index
            this.arr[index] = item;

            // increase currentLength
            currentLength++;
        }

        // Add range method - at the end
        public void AddRange(IEnumerable<T> collection)
        {
            // adds more than one item

            // determin how big internal size is needed

            // call new resize method

            // add each item of the collection

            // change current length

        }

        // Deletes all items and resets size to the default
        public void Clear()
        {
            //2 / create new array with initial size
            T[] tempArr = new T[this.internalSize];

            // assign to current arr
            this.arr = tempArr;

            // change current length
            currentLength = 0;          
        }

        // If it contains the given value
        public bool Contains(T item)
        {
            if (IndexOf(item) == -1)
            {
                return false;
            }
            // if indexof = -1 -> return false
            return true;         
        }

        // Index of the given value
        public int IndexOf(T item)
        {
            int result = -1;
            // return index of matching value
            for (int i = 0; i < this.currentLength; i++)
            {
                if (this.arr[i].ToString() == item.ToString())
                {
                    result = i;
                }
            }
            return result;
        }

        // Delete
        public bool Remove(T item)
        {
            // get index of item

            // if index >=0 shift positions

            // change length 

            // check if currentLength >= internal size / multiplier

            throw new NotImplementedException();
        }

        //Doubles the size of the array and copy the new value
        private void Resize()
        {
            // change internal this.size
            this.internalSize = this.internalSize * Multiplier;

            // initialize new array with new internal size
            T[] tempArr = new T[this.internalSize];

            // coppy current arr into new array
            for (int i = 0; i < currentLength; i++)
            {
                tempArr[i] = this.arr[i];
            }

            // assign the new array to be the current arr
            this.arr = tempArr;
        }

        // New resize method with Multiplier as input

        //to change to private
        public void ResizeCollection(int inputMultiplier)
        {
            // change internal this.size
            this.internalSize = this.internalSize * inputMultiplier;

            // initialize new array with new internal size
            T[] tempArr = new T[this.internalSize];

            // coppy current arr into new array
            for (int i = 0; i < currentLength; i++)
            {
                tempArr[i] = this.arr[i];
            }

            // assign the new array to be the current arr
            this.arr = tempArr;


        }

    }
}
