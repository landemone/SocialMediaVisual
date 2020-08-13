using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastructure.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IAspnetUsersService
    {
        Task<IEnumerable<AspnetUsers>> GetLoginByCredentials(LoginQueryFilter AspnetUsers);
        Task RegisterUser(AspnetUsers membership);
        Task<AspnetUsers> GetUserId(AspnetUsers _aspnetUsers);
    }
}