using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exemple.Domain
{
    public record RegistrationNumber
    {
        private static readonly Regex ValidPattern = new("^PC[0-9]{6}$");

        public string Value { get; }

        private RegistrationNumber(string value)
        {
            if (ValidPattern.IsMatch(value))
            {
                Value = value;
            }
            else
            {
                throw new InvalidRegistrationNumberException("");
            }
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
