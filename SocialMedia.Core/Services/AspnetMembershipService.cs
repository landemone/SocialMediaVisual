using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastructure.Core;
using System.Threading.Tasks;

namespace SocialMedia.Core.Services
{
    public class AspnetMembershipService : IAspnetMembershipService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AspnetMembershipService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AspnetMembership> GetLoginByCredentials(LoginQueryFilter aspnetMembership)
        {
            return await _unitOfWork.AspnetMembershipRepository.GetLoginByCredentials(aspnetMembership);
        }

        public async Task RegisterUser(AspnetMembership membership)
        {
            
            await _unitOfWork.AspnetMembershipRepository.Add(membership);
            await _unitOfWork.SaveChangesAsync();


        }
    }
}
