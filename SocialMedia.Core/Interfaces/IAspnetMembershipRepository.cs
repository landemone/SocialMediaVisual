using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastructure.Core;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IAspnetMembershipRepository : IRepository<AspnetMembership>
    {
        Task<AspnetMembership> GetLoginByCredentials(LoginQueryFilter userLogin);
    }
}