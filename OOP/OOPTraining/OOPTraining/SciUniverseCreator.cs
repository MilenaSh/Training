using OOPTraining.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTraining
{
    public class SciUniverseCreator : RandomValueGenerator, IUniverseCreator
    {
       
        public Universe CreateRandomUniverse()
        {
            var result = new ScientificUniverse
            {
                Name = this.GenerateString(this.GenerateInt(5, 20)),
                Age = this.GenerateLong(0, 1000),
                Type = (UniverseType)this.GenerateInt(1,2)
            };

            if(result.Type == UniverseType.SciFantasy)
            {
                result.DominantForce = "Ther FORCE";
            }
            else
            {
                result.DominantForce = "Science";
            }

            return result;
        }

        public override long GenerateLong(long start, long end)
        {
            var baseResult = base.GenerateLong(start, end);

            if(baseResult <= long.MaxValue-5)
            {
                baseResult += 5;
            }

            return baseResult;
        }

    }
}
