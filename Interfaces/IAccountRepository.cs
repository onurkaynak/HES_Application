namespace CovidApp
{
    public interface IAccountRepository
    {
        Task Create(Account account);
        Task Update(Account account);
        Task Delete(Account account);
        Task<List<Account>> GetAll();
        Task<List<Account>> GetAllByBlocked(bool isBlocked);
        Task<List<Account>> GetAllByVisibility(bool isVisible);
        Task<Account> FindByPhoneNumberAsync(string phoneNumber);
        Account FindByPhoneNumber(string phoneNumber);
        Task<Account> FindByIdAsync(int id);
        Account FindById(int id);
    }
}