using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Chat.Api.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class PatternAttribute : ValidationAttribute
    {
        readonly Regex Pattern;
        new readonly string ErrorMessage;
        readonly bool MatchTrue;
        public PatternAttribute(string pattern, string errorMessage, Boolean matchTrue = true)
        {
            this.Pattern = new Regex(pattern);
            this.ErrorMessage = errorMessage;
            this.MatchTrue = matchTrue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (Pattern.IsMatch((string)value) == MatchTrue)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }

    }
}
