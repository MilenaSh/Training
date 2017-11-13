using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPTraining.Enum;

namespace OOPTraining
{
    public class FantasyUniverse : Universe
    {
        public FantasyUniverse()
        {
        }

        public FantasyUniverse(string name, long age, UniverseType type) : base(name, age, type)
        {
            if (type == UniverseType.SciFiction || type == UniverseType.SciFantasy)
            {
                throw new InvalidCastException("You have done goof!");
            }
        }      
        public override string ToString()
        {
            var baseResult = base.ToString();
           // baseResult += System.Environment.NewLine;
            baseResult += $"The Dominant force is: {this.DominantForce}";
            return baseResult;
        }
    }
}
