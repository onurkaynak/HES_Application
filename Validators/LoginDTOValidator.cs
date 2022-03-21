using System.Text.RegularExpressions;
using FluentValidation;

namespace CovidApp
{
    public class LoginDTOValidator : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.PhoneNumber).Must(IsPhoneNumber).WithMessage("Telefon numarası formatı yanlış girildi.");
        }
        private bool IsPhoneNumber(string arg)
        {
            Regex regex = new Regex(@"^[0-9]{10}$");
            return regex.IsMatch(arg);
        }
    }
}