namespace CovidApp
{
    public interface IAccountService
    {
        Task<BaseResponse<Account>> Create(Account account);
        Task<BaseResponse<Account>> Update(Account account);
        Task<BaseResponse<string>> Delete(int id);
        Task<BaseResponse<List<Account>>> GetAll();
        Task<BaseResponse<List<Account>>> GetAllByBlocked(bool isBlocked);
        Task<BaseResponse<List<Account>>> GetAllByVisibility(bool isVisible);
        Task<BaseResponse<Account>> FindByPhoneNumberAsync(string phoneNumber);
        Task<BaseResponse<Account>> FindById(int id);
        Task<BaseResponse<Account>> UpdatePhoneNumber(string oldPhoneNumber, string newPhoneNumber);
        Task<BaseResponse<Account>> ChangeVisibilityById(int id);
        Task<BaseResponse<Account>> ChangeIsBlockedById(int id);
    }
}