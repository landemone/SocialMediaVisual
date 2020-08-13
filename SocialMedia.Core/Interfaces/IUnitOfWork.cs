using SocialMedia.Infrastructure.Core;
using System;
using System.Threading.Tasks;

namespace SocialMedia.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IPostRepository PostRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Comment> CommentRepository { get; }
        IAspnetMembershipRepository AspnetMembershipRepository { get; }
        IAspnetUsersRepository AspnetUsersRepository { get; }


        void SaveChanges();
        Task SaveChangesAsync();
    }
}
