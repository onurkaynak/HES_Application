namespace CovidApp
{
    public interface IUserRepository
    {
        Task Create(User user);
        Task Update(User user);
        Task Delete(User user);
        Task<List<User>> GetAll();
        Task<User> FindById(int id);
        Task<List<User>> GetAllByIsCorona(bool isCorona);
        Task<List<User>> GetAllUserByCityFromPlateCode(int plateCode);
        Task<List<User>> GetAllByCityPlateCodeAndIsCorona(int plateCode, bool isCorona);
    }
    
}