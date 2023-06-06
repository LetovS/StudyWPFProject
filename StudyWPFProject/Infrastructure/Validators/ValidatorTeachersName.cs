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
            if (value is not string inputString || string.IsNullOrWhiteSpace(inputString)) return new ValidationResult(false, "Строка не может быть пустой.")!;

            var result = inputString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var check_numbers = result.Where(x => int.TryParse(x, out int b)).Select(x => x).ToArray();


            if (check_numbers.Length > 0) return new ValidationResult(false, "ФИО не может содержать цифр.");
            if (result.Length > 3) return new ValidationResult(false, "Слишком много слов.");
            try
            {
                var res = result.Length switch
                {
                    1 => result[0],
                    2 => string.Format("{0} {1}.", result[0], result[1]),
                    3 => string.Format("{0} {1} {2}.", result[0], result[1], result[2]),
                    _ => throw new ArgumentException(nameof(inputString))
                };
                return ValidationResult.ValidResult;
            }           
            catch (ArgumentException)
            {
                return new ValidationResult(false, "Please enter correct data.");
            }
            //TODO доделать валидатор
        }
    }
}
