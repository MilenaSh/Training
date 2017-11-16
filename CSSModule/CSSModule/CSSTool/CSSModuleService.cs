using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSSTool.Models;

namespace CSSTool
{
    public class CSSModuleService : ICSSService
    {
        public string AddRulesToCss(string css, CSSRule[] rules)
        {
            var newRules = string.Empty;

            foreach (var item in rules)
            {
                newRules += item.ToString();
            }

            var result = css + newRules;
            return result;
        }

        public CSSRule CreateRuleMode(string rule, Dictionary<string, string> values)
        {
            var result = new CSSRule(rule, values);

            return result;
        }

        public string MinimizeFile(string fileText)
        {
            if (string.IsNullOrEmpty(fileText))
            {
                return null;
            }

            var body = fileText;
            body = Regex.Replace(body, @"[a-zA-Z]+#", "#");
            body = Regex.Replace(body, @"[\n\r]+\s*", string.Empty);
            body = Regex.Replace(body, @"\s+", " ");
            body = Regex.Replace(body, @"\s?([:,;{}])\s?", "$1");
            body = body.Replace(";}", "}");
            body = Regex.Replace(body, @"([\s:]0)(px|pt|%|em)", "$1");

            // Remove comments from CSS
            body = Regex.Replace(body, @"/\*[\d\D]*?\*/", string.Empty);

            return body;
        }
    }
}
