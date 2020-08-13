using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMedia.Api.Responses;
using SocialMedia.Core.DTOs;
using SocialMedia.Core.Interfaces;
using SocialMedia.Core.QueryFilters;
using SocialMedia.Core.Services;
using SocialMedia.Infrastructure.Core;
using SocialMedia.Infrastructure.Interfaces;

namespace SocialMedia.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AspnetMembershipController : ControllerBase
    {

        private readonly IAspnetMembershipService _aspnetMembershipService;
        private readonly IAspnetUsersService _aspnetUsersService;
        private readonly IMapper _mapper;


      
        public AspnetMembershipController(IAspnetMembershipService aspnetMembershipService,IAspnetUsersService aspnetUsersService, IMapper mapper)
        {
            _aspnetMembershipService = aspnetMembershipService;
            _aspnetUsersService = aspnetUsersService;
            _mapper = mapper;
           
        }


        [HttpPost]
        public async Task<IActionResult> Post(AspnetMembershipDto aspnetMembershipDto)
        {
            var aspnetMembershi = _mapper.Map<AspnetMembership>(aspnetMembershipDto);

            await _aspnetMembershipService.RegisterUser(aspnetMembershi);

            aspnetMembershipDto = _mapper.Map<AspnetMembershipDto>(aspnetMembershi);
            var response = new ApiResponse<AspnetMembershipDto>(aspnetMembershipDto);
            return Ok(response);
        }


        [HttpGet(Name = nameof(GetLoginAM))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<AspnetMembershipDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetLoginAM([FromQuery] LoginQueryFilter filters)
        {
            var post = _aspnetMembershipService.GetLoginByCredentials(filters);
         //   var postDto = _mapper.Map<IEnumerable<AspnetMembershipDto>>(post);


            //var metadata = new Metadata
            //{
            //    NextPageUrl = post.Email


            //};
            //var response = new ApiResponse<IEnumerable<AspnetUsersDto>>(postDto)
            //{
            //    Meta = metadata
            //};

            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(postDto));
            return Ok(post);
        }
    }
}
