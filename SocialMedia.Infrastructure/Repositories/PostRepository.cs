﻿using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Core;
using SocialMedia.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {

        public PostRepository( SocialMediaContext context):base(context) 
        {
        }
        public async Task<IEnumerable<Post>> GetPostsByUser(int userid)
        {
            return await _entities.Where(x => x.UserId == userid).ToListAsync();
        }
    }
}
