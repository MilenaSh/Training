using CSSTool;
using CSSTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSModule
{
    public class Program
    {
        static string test1 =
        @"div.relative 
        {
            position: relative;
            left: 30px;
            border: 3px solid #73AD21;
        }
";
        static void Main(string[] args)
        {
            var service = new CSSModuleService();

            var text = test1;
            var rule = "*";
            var values = new Dictionary<string, string>();
            values.Add("border", "1px solid red");

            var newRule = service.CreateRuleMode(rule, values);
            var newText = service.AddRulesToCss(text, new CSSRule[] { newRule });
            Console.WriteLine(newText);

        }
    }
}
