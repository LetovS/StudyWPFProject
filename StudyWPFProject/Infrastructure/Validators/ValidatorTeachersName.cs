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
            throw new NotImplementedException();
            //TODO доделать валидатор
        }
    }
}
