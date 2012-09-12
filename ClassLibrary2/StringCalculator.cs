using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary2
{
    class StringCalculator
    {
        internal static object Add(string p)
        {
            var delimiters = new List<string> {",","\n"};

            if (p.StartsWith("//"))
            {
                var indexOfN = p.IndexOf('\n');
                delimiters.AddRange(p.Substring(2, indexOfN - 2).Split(new []{'[',']'}));
                p = p.Substring(indexOfN, p.Length - indexOfN);
            }

            var digits = p.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries).Where(s => Int32.Parse(s) <= 1000).ToList();

            var negatives = digits.Where(s => Int32.Parse(s) < 0).ToList();
            if (negatives.Any())
            {
                throw new Exception(String.Format("Negatives are not allowed. Negative values: {0}", String.Join(", ", negatives)));
            }

            return digits.Sum(s => Int32.Parse(s));
        }
    }
}
