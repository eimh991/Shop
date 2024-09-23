using Shop.Enum;
using Shop.Interfaces;
using Shop.Model;
using Shop.Repositories;
using Shop.UsersDTO;

namespace Shop.Service
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        public UserService(IRepository<User> userRepository) {
            _userRepository = userRepository;
        }

        public async Task ChangeStatusAsync(int userId,string status)
        {
            if (!string.IsNullOrEmpty(status)
                && status.ToLower() == UserRole.Manager.ToString().ToLower()
                && status.ToLower() == UserRole.Admin.ToString().ToLower())
            {

                await ((UserRepository)_userRepository).ChangeStatusAsync(userId,status);

            }
        }

        public async Task CreateAsync(UserDTO entity)
        {
            User user = new User()
            {
                UserName = entity.UserName,
                Email = entity.Email,
                PasswordHash = entity.PasswordHash,
                Balance = 0.0m,
                Role = Enum.UserRole.User,
            };
            
            await  _userRepository.CreateAsync(user);
        }

        public async Task Delete(int id)
        {
            await _userRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync(string search)
        {
            return await _userRepository.GetAllAsync(search);
        }

        public async Task<User> GetByEmaiAsync(string email)
        {
             return await ((UserRepository)_userRepository).GetByEmailAsync(email);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(UserDTO entity)
        {
            User user = new User()
            {
                UserName = entity.UserName,
                Email = entity.Email,
                PasswordHash = entity.PasswordHash,
            };
           await _userRepository.UpdateAsync(user);
        }


    }
}
