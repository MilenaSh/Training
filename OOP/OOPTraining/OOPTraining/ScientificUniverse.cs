using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPTraining.Enum;

namespace OOPTraining
{
    public class ScientificUniverse : Universe
    {
        public ScientificUniverse()
        {
        }

        public ScientificUniverse(string name, long age, UniverseType type) : base(name, age, type)
        {
            if(type == UniverseType.Fantasy)
            {
                throw new InvalidCastException("You have tried to make a scientific univers fantasy type");
            }

            if(type == UniverseType.SciFantasy)
            {
                this.DominantForce = "The Force";
                return;
            }

            this.DominantForce = "SCIENCE";
            
        }

        public override string ToString()
        {
            var baseResult = base.ToString();
            baseResult += System.Environment.NewLine;
            baseResult += $"The Dominant force is: {this.DominantForce}";
            return baseResult;
        }

    }
}
