using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;

namespace Api.Service.Services
{
    public class LoginService : ILoginService
    {
        public IUserRepository _repository { get; set; }

        public LoginService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<object> FindByLogin(LoginDto user)
        {
            if (user != null && !string.IsNullOrEmpty(user.Email))
            {
                return await _repository.FindByLogin(user.Email);
            }
            else
            {
                return null;
            }
        }
    }
}
