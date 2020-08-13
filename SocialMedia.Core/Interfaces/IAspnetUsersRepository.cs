using SocialMedia.Core.CustomEntities;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastructure.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IAspnetUsersRepository : IRepository<AspnetUsers>
    {
        Task<IEnumerable<AspnetUsers>> GetLoginByCredentials(LoginQueryFilter userLogin);
        Task<AspnetUsers> GetUserId(AspnetUsers _aspnetUsers);
    }
}