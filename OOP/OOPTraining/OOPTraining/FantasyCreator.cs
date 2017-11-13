using OOPTraining.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPTraining
{
    public class FantasyCreator : RandomValueGenerator, IUniverseCreator
    {
        public Universe CreateRandomUniverse()
        {
            var result = new FantasyUniverse
            {
                Name = this.GenerateString(this.GenerateInt(5, 20)),
                Age = this.GenerateLong(0, 1000),
                Type = (UniverseType)this.GenerateInt(3, 3)
            };

            if (result.Type == UniverseType.Fantasy)
            {
                result.DominantForce = "Magic";
            }

            return result;
        }


    }
}
