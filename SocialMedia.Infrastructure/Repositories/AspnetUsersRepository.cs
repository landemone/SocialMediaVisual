using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastructure.Core;
using SocialMedia.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class AspnetUsersRepository : BaseRepository<AspnetUsers>, IAspnetUsersRepository
    {
        public AspnetUsersRepository(SocialMediaContext context) : base(context) { }

        public async Task<IEnumerable<AspnetUsers>> GetLoginByCredentials(LoginQueryFilter userLogin)

        {
            return await _entities.Where(x => x.UserName == userLogin.Email && x.AspnetMembership.Password == userLogin.Password).ToListAsync();

        }

        public async Task<AspnetUsers> GetUserId(AspnetUsers _aspnetUsers)
        {
            return await _entities.FirstOrDefaultAsync(x => x.UserName == _aspnetUsers.UserName);
        }
    }
}
