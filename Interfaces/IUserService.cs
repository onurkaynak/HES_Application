namespace CovidApp
{
    public interface IUserService
    {
        Task<BaseResponse<User>> Create(User user);
        Task<BaseResponse<User>> Update(User user);
        Task<BaseResponse<User>> Delete(User user);
        Task<BaseResponse<List<User>>> GetAll();
        Task<BaseResponse<User>> FindById(int id);
        Task<BaseResponse<List<User>>> GetAllByIsCorona(bool isCorona);
        Task<BaseResponse<List<User>>> GetAllUserByCityFromPlateCode(int plateCode);
        Task<BaseResponse<List<User>>> GetAllByCityPlateCodeAndIsCorona(int plateCode, bool isCorona);
        Task<BaseResponse<int>> CoronaCount();
        Task<BaseResponse<int>> CoronaCountByCity(int plateCode);
    }
}