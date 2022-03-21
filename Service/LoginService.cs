using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace CovidApp
{
    public class LoginService : ILoginService
    {
        private readonly AppSettings _appSettings;
        private readonly IAccountRepository _accountRepository;

        public LoginService(IAccountRepository accountRepository, IOptions<AppSettings> appSettings)
        {
            _accountRepository = accountRepository;
            _appSettings = appSettings.Value;
        }

        public LoginResponseDTO Authenticate(LoginDTO model)
        {
            var Account = _accountRepository.FindByPhoneNumber(model.PhoneNumber);
            if (Account == null) return null;
            var token = generateJwtToken(Account);

            return new LoginResponseDTO(token);
        }

        public Account findAccountById(int id)
        {
            return _accountRepository.FindById(id);
        }

        private string generateJwtToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", account.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}