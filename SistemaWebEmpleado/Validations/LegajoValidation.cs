using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SistemaWebEmpleado.Validations
{
    public class LegajoValidation: ValidationAttribute
    {
        public LegajoValidation()
        {
            ErrorMessage = "El legajo debe comnzar con AA y seguir con 5 numeros";
        }

        public override bool IsValid(object value)
        {
            var regex = "AA([0-9]{5}$)";
            if (Regex.IsMatch(Convert.ToString(value), regex, RegexOptions.IgnoreCase))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
