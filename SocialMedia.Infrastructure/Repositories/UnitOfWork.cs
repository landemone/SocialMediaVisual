using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Core;
using SocialMedia.Infrastructure.Data;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SocialMediaContext _context;

        private readonly IPostRepository _postRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Comment> _commentRepository;
        private readonly IAspnetMembershipRepository _aspnetMembershipRepository;
        private readonly IAspnetUsersRepository _aspnetUsersRepository;

        public UnitOfWork(SocialMediaContext context)
        {
            _context = context;
        }

        public IPostRepository PostRepository => _postRepository ?? new PostRepository(_context);

        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_context);

        public IRepository<Comment> CommentRepository => _commentRepository ?? new BaseRepository<Comment>(_context);

        public IAspnetMembershipRepository AspnetMembershipRepository => _aspnetMembershipRepository ?? new AspnetMembershipRepository(_context);

        public IAspnetUsersRepository AspnetUsersRepository => _aspnetUsersRepository ?? new AspnetUsersRepository(_context);


        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
