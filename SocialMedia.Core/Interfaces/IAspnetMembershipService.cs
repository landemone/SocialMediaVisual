using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastructure.Core;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IAspnetMembershipService
    {
        Task<AspnetMembership> GetLoginByCredentials(LoginQueryFilter aspnetMembership);
        Task RegisterUser(AspnetMembership membership);
    }
}