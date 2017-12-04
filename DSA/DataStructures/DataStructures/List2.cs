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

        // Count Length - property only with get - TODO

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
            this.currentLength++;
        }

        // Add range method - at the end
        public void AddRange(IEnumerable<T> collection)
        {
            // adds more than one item
            // determin how big internal size is needed
            int collectionSize = collection.Count();

            // determin multiplier
            var initialInternalSize = this.internalSize;
            var multiplier = 1;

            while (this.internalSize * multiplier <= (collectionSize + this.currentLength))
            {
                multiplier *= 2;
            }
           
            // call new resize method // 32
            ResizeCollection(multiplier);

            // add each item of the collection
            foreach (var item in collection)
            {
                this.arr[this.currentLength] = item;
                this.currentLength++;
            }

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
            bool result = false;
            var tempArr = new T[this.internalSize];
            var myArr = this.arr;

            // get index of item
            var index = IndexOf(item);

            if (index < 0)
            {
                return false;
            }

            // shift all to left from given position

            // determin the first item that needs to be shifted

            // make loop to the end of the array

            var firstIndex = index + 1;

            for (int i = firstIndex; i < this.currentLength; i++)
            {
                this.arr[i - 1] = this.arr[i];
            }

            this.currentLength--;
            // if index >=0 shift positions

            //if (index == 0)
            //{
            //    for (int i = 1; i < myArr.Length; i++)
            //    {
            //        tempArr[i - 1] = myArr[i];
            //        myArr[i - 1] = tempArr[i - 1];
            //    }
            //    result = true;
            //    this.arr = tempArr;

            //    // change length 
            //    currentLength = currentLength - 1;
            //    var lastArr = new T[currentLength];

            //    for (int i = 0; i < currentLength; i++)
            //    {
            //        lastArr[i] = this.arr[i];
            //    }
            //    this.arr = lastArr;
            //}

            //if (index > 0)
            //{
            //    for (int i = 0; i < index; i++)
            //    {
            //        tempArr[i] = myArr[i];
            //    }
            //    for (int i = index; i < myArr.Length - 1; i++)
            //    {
            //        tempArr[i] = myArr[i + 1];
            //    }
            //    result = true;
            //    this.arr = tempArr;

            //    // change length 
            //    currentLength = currentLength - 1;
            //    var lastArr = new T[currentLength];

            //    for (int i = 0; i < currentLength; i++)
            //    {
            //        lastArr[i] = this.arr[i];
            //    }
            //    this.arr = lastArr;
            //}

            // check if currentLength >= internal size / multiplier

            return result;
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
