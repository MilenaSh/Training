using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class MyDictionary<T1, T2> where T1 : IComparable<T1>, IEquatable<T1>
    {

        // constants - not yet used
        private const int InitialKey = 1;
        private const string InitialValue = "student";



        public MyDictionary()
        {
            this.keys = new List<T1>();
            this.values = new List<T2>();
        }

        // properties 

        private IList<T1> keys;
        private HashSet<T1> keys2;
        private IList<KeyValuePair<T1, T2>> entities;
        private IList<T2> values;

        //  public T2 this[T1 key] { get { }; set { }; };

        public IList<T1> Keys
        {
            get
            {
                return this.keys;
            }

            set
            {
                this.keys = value;
            }
        }

        public IList<T2> Values
        {
            get
            {
                return this.values;
            }

            set
            {
                this.values = value;
            }
        }

        public int Count() // to rewrite with values
        {
            int count = 0;
            foreach (var item in this.keys)
            {
                count++;
            }
            return count;
        }

        // returns an integer with the number of values

        // TODO - check if readonly
        //public bool IsReadOnly()
        //{
        //    return false;
        //}

        public T2 this[T1 key]
        {
            get
            {
                if (!this.keys2.Contains(key))
                {
                    throw new ArgumentNullException();
                }

                var resultKeyValuePair = this.entities.FirstOrDefault(x => x.Key.Equals(key));
                return resultKeyValuePair.Value;
            }
            set
            {
                var itemToRemove = this.entities.FirstOrDefault(x => x.Key.Equals(key));
                var newItem = new KeyValuePair<T1, T2>(key, value);
                this.entities.Remove(itemToRemove);
                this.entities.Add(newItem);
            }
        }

        public void Add(T1 key, T2 value)
        {

            // can have duplicated values but not duplicated keys

            //  check if the key is null
            if (key == null)
            {
                throw new Exception("There is no provided key");
            }
            //  check if  an element with the same key already exists in the dictionary
            if (ContainsKey(key))
            {
                throw new Exception("The provided key already exists");
            }

            // check if the dictionary is not readonly
            if (IsReadOnly())
            {
                throw new Exception("The dictionary is readonly");
            }

            this.keys.Add(key);
            this.values.Add(value);
        }

        public void Add(KeyValuePair<T1, T2> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            // remove all keys
            this.keys.Clear();

            // remove all values
            this.values.Clear();

        }

        public bool Contains(KeyValuePair<T1, T2> item)
        {
            var result = false;
            // check if contains the key


            // chek if the key corresponds to the given value

            return result;
        }

        public bool ContainsKey(T1 key)
        {
            var result = false;

            foreach (var item in this.keys)
            {
                if (EqualityComparer<T1>.Default.Equals(item, key))
                {
                    result = true;
                }
            }
            return result;
        }

        public void CopyTo(KeyValuePair<T1, T2>[] array, int arrayIndex)
        {

            throw new NotImplementedException();
        }

        public IEnumerator<KeyValuePair<T1, T2>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T1 key)
        {
            var result = false;

            // remove a key and value by a given key
            foreach (var item in this.keys)
            {
                if (EqualityComparer<T1>.Default.Equals(item, key))
                {
                    this.keys.Clear();



                    result = true;
                }
            }

            return result;
        }

        public bool Remove(KeyValuePair<T1, T2> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(T1 key, out T2 value)
        {
            throw new NotImplementedException();
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
