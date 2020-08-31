using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Calculo_De_Costos.Rules
{
    public class MoneyValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string moneyValidation = value as string;
            if(string.IsNullOrWhiteSpace(moneyValidation))
                return new ValidationResult(false, $"El campo no puede estar vacio");
            else if (!ValidateCurrency(moneyValidation))
                return new ValidationResult(false, $"El costo {moneyValidation} no es un valor valido");
            return new ValidationResult(true, null);
        }

        bool ValidateCurrency(string price)
        {
            decimal test;
            return decimal.TryParse(price, System.Globalization.NumberStyles.Currency, new CultureInfo("es-MX"),out test);
        }
    }
}
