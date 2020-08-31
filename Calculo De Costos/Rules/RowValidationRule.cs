using Calculo_De_Costos.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calculo_De_Costos.Rules
{
    public class RowValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string letter = value as string;
            if (!ValidationMethods.ValidateNumber(letter))
                return new ValidationResult(false, $"Solo un numero");
            return new ValidationResult(true, null);
        }
    }
}
