using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace StudyWPFProject.Infrastructure.Validators
{
    internal class ValidatorTeachersName : ValidationRule
    {
        public string? InputString { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) return null!;

            if (value is not string inputString || string.IsNullOrWhiteSpace(inputString)) return null!;

            var result = inputString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var res = result.Length switch
                {
                    1 => result[0],
                    2 => string.Format("{0} {1}.", result[0], result[1]),
                    3 => string.Format("{0} {1} {2}.", result[0], result[1], result[2]),
                    _ => throw new ArgumentException("Too many whitespaces in input string.")
                };
                return ValidationResult.ValidResult;
            }
            catch (Exception)
            {
                return new ValidationResult(false, "Please enter correct data.");
            }
            //TODO доделать валидатор
        }
    }
}
