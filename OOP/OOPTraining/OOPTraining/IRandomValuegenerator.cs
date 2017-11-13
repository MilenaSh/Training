using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTraining
{
    public interface IRandomValueGenerator
    {
        string GenerateString(int lenght);

        long GenerateLong(long start, long end);

        int GenerateInt(int start, int end);
    }
}
