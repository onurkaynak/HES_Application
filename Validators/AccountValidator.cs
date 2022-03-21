using System.Text.RegularExpressions;
using FluentValidation;

namespace CovidApp
{
    public class AccountValidator : AbstractValidator<Account>
    {
        public AccountValidator()
        {
            RuleFor(x => x.PhoneNumber).Must(IsPhoneNumber).WithMessage("Telefon numarası formatı yanlış girildi.");
            
            RuleFor(x => x.IsVisibility)
            .NotEmpty().WithMessage("IsVisibility alanı boş geçilemez")
            .Must(x => x.Equals(true) || x.Equals(false)).WithMessage("Blocked alanı \"true\" ya da \"false\" olmalıdır.");
            
            RuleFor(x => x.Blocked)
            .NotEmpty().WithMessage("Blocked alanı boş geçilemez")
            .Must(x => x.Equals(true) || x.Equals(false)).WithMessage("Blocked alanı \"true\" ya da \"false\" olmalıdır.");
        }

        private bool IsPhoneNumber(string arg)
        {
            Regex regex = new Regex(@"^[0-9]{10}$");
            return regex.IsMatch(arg);
        }
    }
}