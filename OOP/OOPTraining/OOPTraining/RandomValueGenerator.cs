using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTraining
{
    public abstract class RandomValueGenerator : IRandomValueGenerator
    {
        protected readonly string ABC = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        protected Random rng = new Random();
        public int GenerateInt(int start, int end)
        {
            return this.rng.Next(start, end + 1);
        }

        public virtual long GenerateLong(long start, long end)
        {
            var randomDoubl = rng.NextDouble();
            var longMax = long.MaxValue;

            var isPositiv = this.GenerateInt(0, 100) > 50 ? 1 : -1;

            var result = (long)(randomDoubl * longMax * isPositiv);

            return result;
        }

        public string GenerateString(int lenght)
        {
            var str = string.Empty;

            for (int i = 0; i < lenght; i++)
            {
                str += this.ABC[this.GenerateInt(0, this.ABC.Length - 1)].ToString();
            }

            return str;
        }
    }
}
