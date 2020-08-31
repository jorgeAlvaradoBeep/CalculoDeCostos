using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Calculo_De_Costos.Services
{
    public class ValidationMethods
    {
        public static bool ValidateLetter(string val)
        {
            if(!String.IsNullOrEmpty(val))
                return Regex.Match(val, "^[a-zA-Z]$").Success;
            return false;
        }
        public static bool ValidateNumber(string val)
        {
            return Regex.Match(val, "^[0-9]{1,4}$").Success;
        }
    }
}
