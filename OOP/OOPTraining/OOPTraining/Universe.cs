namespace OOPTraining
{
    using OOPTraining.Enum;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public abstract class Universe
    {
        public Universe()
        {

        }

        public Universe(string name, long age, UniverseType type)
        {
            this.Name = name;
            this.Age = age;
            this.Type = type;
        }

        public string Name { get; set; }

        public long Age { get; set; }

        public UniverseType Type { get; set; }

        public string DominantForce { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine("Name: " + this.Name);
            result.AppendLine(string.Format("Age: {0} years", this.Age));
            result.Append($"The Universe is: {this.Type.ToString()}");
            return result.ToString();
        }
    }
}
