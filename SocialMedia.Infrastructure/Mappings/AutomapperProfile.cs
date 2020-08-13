using AutoMapper;
using SocialMedia.Core.DTOs;
using SocialMedia.Infrastructure.Core;

namespace SocialMedia.Infrastructure.Mappings
{
    public class AutomapperProfile:Profile
    {

        public AutomapperProfile()
        {
            CreateMap<Post, PostDto>().ReverseMap();
         
            CreateMap<AspnetMembership, AspnetMembershipDto>().ReverseMap();
            CreateMap<AspnetUsers, AspnetUsersDto>().ReverseMap();
        }
    }
}
