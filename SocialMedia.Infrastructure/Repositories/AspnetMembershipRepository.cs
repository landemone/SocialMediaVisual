using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Infrastructure.Core;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class AspnetMembershipRepository : BaseRepository<AspnetMembership>, IAspnetMembershipRepository
    {
        public AspnetMembershipRepository(SocialMediaContext context) : base(context) { }

        public async Task<AspnetMembership> GetLoginByCredentials(LoginQueryFilter userLogin)

        {
            return await _entities.FirstOrDefaultAsync(x => x.Email == userLogin.Email && x.Password == userLogin.Password);

        }
    }
}
