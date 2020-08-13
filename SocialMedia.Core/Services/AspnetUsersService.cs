using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastructure.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class AspnetUsersService : IAspnetUsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AspnetUsersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<AspnetUsers>> GetLoginByCredentials(LoginQueryFilter AspnetUsers)
        {
            var log= _unitOfWork.AspnetUsersRepository.GetLoginByCredentials(AspnetUsers);
          
            return log;
        }

        public async Task RegisterUser(AspnetUsers membership)
        {

            await _unitOfWork.AspnetUsersRepository.Add(membership);
            await _unitOfWork.SaveChangesAsync();


        }

       public async Task<AspnetUsers> GetUserId(AspnetUsers _aspnetUsers)
        {
            return await _unitOfWork.AspnetUsersRepository.GetUserId(_aspnetUsers);
        }
    }
}
