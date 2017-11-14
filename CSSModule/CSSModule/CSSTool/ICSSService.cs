using CSSTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSSTool
{
    public interface ICSSService
    {
        string MinimizeFile(string fileText);

        string AddRulesToCss(string css, CSSRule[] rules);

        CSSRule CreateRuleMode(string rule, Dictionary<string, string> values);
    }
}
