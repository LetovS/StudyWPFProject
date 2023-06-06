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
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) return null!;

            if (value is not string inputString) return null!;
            

            var result = inputString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var res = result.Length switch
                {
                    0 => throw new ArgumentNullException(),
                    1 => result[0],
                    2 => string.Format("{0} {1}.", result[0], result[1]),
                    3 => string.Format("{0} {1} {2}.", result[0], result[1], result[2]),
                    _ => throw new ArgumentException()
                };
                return ValidationResult.ValidResult;
            }
            catch (ArgumentNullException)
            {
                return new ValidationResult(false, "Field can't empty");
            }
            catch (ArgumentException e)
            {
                return new ValidationResult(false, "Please enter correct data.");
            }
            //TODO доделать валидатор
        }
    }
}
