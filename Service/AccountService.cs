using Ubiety.Dns.Core;

namespace CovidApp
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<BaseResponse<Account>> Create(Account account)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            var createdAccount = await _accountRepository.FindByIdAsync(account.Id);
            if (createdAccount is not null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountCreateFail;
                return response;
            }
            await _accountRepository.Create(account);
            response.ResponseStatusCodes = ResponseStatusCodes.AccountCreateSuccess;
            response.Data = account;
            return response;
        }

        public async Task<BaseResponse<string>> Delete(int id)
        {
            BaseResponse<string> response = new BaseResponse<string>();
            var deletedAccount = await _accountRepository.FindByIdAsync(id);
            if (deletedAccount is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountDeleteFail;
                return response;
            }
            await _accountRepository.Delete(deletedAccount);
            response.ResponseStatusCodes = ResponseStatusCodes.AccountDeleteSuccess;
            return response;
        }

        public async Task<BaseResponse<Account>> FindById(int id)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            try
            {
                response.Data = await _accountRepository.FindByIdAsync(id);
                response.ResponseStatusCodes = ResponseStatusCodes.Success;
                return response;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.ResponseStatusCodes = ResponseStatusCodes.BadRequest;
                return response;
            }
        }

        public async Task<BaseResponse<Account>> FindByPhoneNumberAsync(string phoneNumber)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            try
            {
                response.Data = await _accountRepository.FindByPhoneNumberAsync(phoneNumber);
                response.ResponseStatusCodes = ResponseStatusCodes.Success;
                return response;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.ResponseStatusCodes = ResponseStatusCodes.BadRequest;
                return response;
            }
        }

        public async Task<BaseResponse<List<Account>>> GetAll()
        {
            BaseResponse<List<Account>> response = new BaseResponse<List<Account>>();
            try
            {
                response.Data = await _accountRepository.GetAll();
                response.ResponseStatusCodes = ResponseStatusCodes.Success;
                return response;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.ResponseStatusCodes = ResponseStatusCodes.BadRequest;
                return response;
            }
        }

        public async Task<BaseResponse<List<Account>>> GetAllByBlocked(bool isBlocked)
        {
            BaseResponse<List<Account>> response = new BaseResponse<List<Account>>();
            try
            {
                response.Data = await _accountRepository.GetAllByBlocked(isBlocked);
                response.ResponseStatusCodes = ResponseStatusCodes.Success;
                return response;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.ResponseStatusCodes = ResponseStatusCodes.BadRequest;
                return response;
            }
        }

        public async Task<BaseResponse<List<Account>>> GetAllByVisibility(bool isVisible)
        {
            BaseResponse<List<Account>> response = new BaseResponse<List<Account>>();
            try
            {
                response.Data = await _accountRepository.GetAllByVisibility(isVisible);
                response.ResponseStatusCodes = ResponseStatusCodes.Success;
                return response;
            }
            catch (Exception e)
            {
                response.Data = null;
                response.ResponseStatusCodes = ResponseStatusCodes.BadRequest;
                return response;
            }
        }

        public async Task<BaseResponse<Account>> Update(Account account)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            var updatedAccount = await _accountRepository.FindByIdAsync(account.Id);
            if (updatedAccount is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountUpdateFail;
                return response;
            }
            await _accountRepository.Update(account);
            response.ResponseStatusCodes = ResponseStatusCodes.AccountUpdateSuccess;
            response.Data = account;
            return response;
        }

        public async Task<BaseResponse<Account>> UpdatePhoneNumber(string oldPhoneNumber, string newPhoneNumber)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            var updatedAccount = await _accountRepository.FindByPhoneNumberAsync(oldPhoneNumber);
            if (updatedAccount is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountUpdatePhoneNumberFail;
                return response;
            }
            updatedAccount.PhoneNumber = newPhoneNumber;
            await _accountRepository.Update(updatedAccount);
            response.ResponseStatusCodes = ResponseStatusCodes.AccountUpdatePhoneNumberSuccess;
            response.Data = updatedAccount;
            return response;
        }

        public async Task<BaseResponse<Account>> ChangeIsBlockedById(int id)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            var account = await _accountRepository.FindByIdAsync(id);
            if (account is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountChangeIsBlockFail;
                return response;
            }
            account.Blocked = !account.Blocked;
            await _accountRepository.Update(account);
            response.ResponseStatusCodes = ResponseStatusCodes.AccountChangeIsBlockSuccess;
            response.Data = account;
            return response;
        }

        public async Task<BaseResponse<Account>> ChangeVisibilityById(int id)
        {
            BaseResponse<Account> response = new BaseResponse<Account>();
            var account = await _accountRepository.FindByIdAsync(id);
            if (account is null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountChangeVisibilityFail;
                return response;
            }
            account.IsVisibility = !account.IsVisibility;
            await _accountRepository.Update(account);
            response.ResponseStatusCodes = ResponseStatusCodes.AccountChangeVisibilitySuccess;
            response.Data = account;
            return response;
        }
    }

}