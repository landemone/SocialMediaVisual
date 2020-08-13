using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SocialMedia.Api.Responses;
using SocialMedia.Core.CustomEntities;
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
    public class AspnetUsersController : ControllerBase
    {

        private readonly IAspnetUsersService _aspnetUsersService;
        private readonly IMapper _mapper;


      
        public AspnetUsersController(IAspnetUsersService aspnetUsersService, IMapper mapper)
        {
          
            _aspnetUsersService = aspnetUsersService;
            _mapper = mapper;
           
        }


        [HttpPost]
        public async Task<IActionResult> Post(AspnetUsersDto aspnetUsersDto)
        {
            //var aspnetMembershi = _mapper.Map<AspnetMembership>(aspnetMembershipDto);
            var aspnetUser = _mapper.Map<AspnetUsers>(aspnetUsersDto);

            await _aspnetUsersService.RegisterUser(aspnetUser);

            var regreso = _aspnetUsersService.GetUserId(aspnetUser);


         //    regreso.Result.UserId;
            //await _aspnetMembershipService.RegisterUser(aspnetMembershi);

            aspnetUsersDto = _mapper.Map<AspnetUsersDto>(aspnetUser);



            var response = new ApiResponse<AspnetUsersDto>(aspnetUsersDto);  
            return Ok(response);
        }

        [HttpGet(Name = nameof(GetLogin))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<AspnetUsersDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetLogin([FromQuery] LoginQueryFilter filters)
        {
            var post = _aspnetUsersService.GetLoginByCredentials(filters);
            var postDto = _mapper.Map<IEnumerable<AspnetUsersDto>>(post);


            //var metadata = new Metadata
            //{
            //    NextPageUrl = post.Email
              
             
            //};
            //var response = new ApiResponse<IEnumerable<AspnetUsersDto>>(postDto)
            //{
            //    Meta = metadata
            //};

            //Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(postDto));
            return Ok(postDto);
        }

    }
}
