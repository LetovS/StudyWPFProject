using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPFProject.Infrastructure
{
    public static class NameExtractorHelper_Extension
    {
        public static string GetShortName(this string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString)) return string.Empty;
            var result = inputString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return result.Length switch
            {
                1 => result[0],
                2 => string.Format("{0} {1}.", result[0], result[1]),
                3 => string.Format("{0} {1} {2}.", result[0], result[1], result[2]),
                _ => throw new ArgumentException("Too many whitespaces in input string.")
            };
        }
    }
}
