namespace CovidApp
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BaseResponse<int>> CoronaCount()
        {
            BaseResponse<int> response = new BaseResponse<int>();
            try
            {
                var coronas =  await _userRepository.GetAllByIsCorona(true);
                response.Data = coronas.Count();
                response.ResponseStatusCodes = ResponseStatusCodes.Success;
                return response;
            }
            catch (Exception e)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.NotFound;
                return response;
            }
        }

        public async Task<BaseResponse<int>> CoronaCountByCity(int plateCode)
        {
            BaseResponse<int> response = new BaseResponse<int>();
            try
            {
                var coronas =  await _userRepository.GetAllByCityPlateCodeAndIsCorona(plateCode,true);
                response.Data = coronas.Count();
                response.ResponseStatusCodes = ResponseStatusCodes.Success;
                return response;
            }
            catch (Exception e)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.NotFound;
                return response;
            }
        }

        public async Task<BaseResponse<User>> Create(User user)
        {
            BaseResponse<User> response = new BaseResponse<User>();
            var createdUser = await _userRepository.FindById(user.Id);
            if (createdUser is not null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountCreateFail;
                return response;
            }
            await _userRepository.Create(user);
            response.ResponseStatusCodes = ResponseStatusCodes.AccountCreateSuccess;
            response.Data = createdUser;
            return response;
        }

        public async Task<BaseResponse<User>> Delete(User user)
        { 
            BaseResponse<User> response = new BaseResponse<User>();
            var deletedUser = await _userRepository.FindById(user.Id);
            if (deletedUser is not null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountDeleteFail;
                return response;
            }
            await _userRepository.Delete(user);
            response.ResponseStatusCodes = ResponseStatusCodes.AccountDeleteSuccess;
            response.Data = deletedUser;
            return response;
        }

        public async Task<BaseResponse<User>> FindById(int id)
        {
            BaseResponse<User> response = new BaseResponse<User>();
            try
            {
                response.Data = await _userRepository.FindById(id);
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

        public async Task<BaseResponse<List<User>>> GetAll()
        {
            BaseResponse<List<User>> response = new BaseResponse<List<User>>();
            try
            {
                response.Data = await _userRepository.GetAll();
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

        public async Task<BaseResponse<List<User>>> GetAllUserByCityFromPlateCode(int plateCode)
        {
            BaseResponse<List<User>> response = new BaseResponse<List<User>>();
            try
            {
                response.Data = await _userRepository.GetAllUserByCityFromPlateCode(plateCode);
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

        public async Task<BaseResponse<List<User>>> GetAllByCityPlateCodeAndIsCorona(int plateCode, bool isCorona)
        {
            BaseResponse<List<User>> response = new BaseResponse<List<User>>();
            try
            {
                response.Data = await _userRepository.GetAllByCityPlateCodeAndIsCorona(plateCode,isCorona);
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

        public async Task<BaseResponse<List<User>>> GetAllByIsCorona(bool isCorona)
        {
            BaseResponse<List<User>> response = new BaseResponse<List<User>>();
            try
            {
                response.Data = await _userRepository.GetAllByIsCorona(isCorona);
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

        public async Task<BaseResponse<User>> Update(User user)
        {
            BaseResponse<User> response = new BaseResponse<User>();
            var deletedUser = await _userRepository.FindById(user.Id);
            if (deletedUser is not null)
            {
                response.ResponseStatusCodes = ResponseStatusCodes.AccountUpdateFail;
                return response;
            }
            await _userRepository.Update(user);
            response.ResponseStatusCodes = ResponseStatusCodes.AccountUpdateSuccess;
            response.Data = deletedUser;
            return response;
        }
    }

}