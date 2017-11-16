using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSTool.Models
{
    public class CSSRule
    {
        private string rule;

        public string Rule
        {
            get { return this.rule; }
            set { this.rule = value; }
        }

        public IDictionary<string, string> Values { get; set; }

        public CSSRule(string rule, IDictionary<string, string> values)
        {
            this.Rule = rule;
            this.Values = values;
        }

        public CSSRule(string css)
        {
            var lines = css.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var dic = new Dictionary<string, string>();
            for (int i = 0; i < lines.Length; i++)
            {
                if (i == 0)
                {
                    this.Rule = lines[i];
                }
                if (i == 1 || i == lines.Length - 1)
                {
                    continue;
                }

                var keyValuePair = lines[i].Split(':');

                var key = keyValuePair[0];
                var value = keyValuePair[1];

                if (!dic.ContainsKey(key))
                {
                    dic.Add(key, value);
                    continue;
                }

                dic[key] = value;
            }
        }

        //returns true if property already existed
        public bool AddoRChangeValue(string property, string newValue)
        {
            if (this.Values.ContainsKey(property))
            {
                this.Values[property] = newValue;
                return true;
            }

            this.Values.Add(property, newValue);
            return false;
        }

        // returns true if value was deleted
        public bool RemoveValue(string property)
        {
            if (this.Values.ContainsKey(property))
            {
                this.Values.Remove(property);
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            var strBuilder = new StringBuilder();

            strBuilder.AppendLine(this.Rule);
            strBuilder.AppendLine("{");

            foreach (var key in this.Values.Keys)
            {
                strBuilder.AppendLine($"    {key} : {this.Values[key]};");
            }

            strBuilder.AppendLine("}");

            return strBuilder.ToString();
        }
    }
}
