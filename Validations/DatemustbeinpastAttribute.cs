using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Validations
{
    public class DatemustbeinpastAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return value is DateTime date && date < DateTime.Now;
        }
    }
}
