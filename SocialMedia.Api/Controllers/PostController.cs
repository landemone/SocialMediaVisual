namespace SocialMedia.Api.Controllers
{
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using SocialMedia.Api.Responses;
    using SocialMedia.Core.CustomEntities;
    using SocialMedia.Core.DTOs;
    using SocialMedia.Core.Interfaces;
    using SocialMedia.Core.QueryFilters;
    using SocialMedia.Infrastructure.Core;
    using SocialMedia.Infrastructure.Interfaces;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="PostController" />.
    /// </summary>
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        /// <summary>
        /// Defines the _postServices.
        /// </summary>
        private readonly IPostService _postServices;

        /// <summary>
        /// Defines the _mapper.
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Defines the _uriService.
        /// </summary>
        private readonly IUriService _uriService;

        /// <summary>
        /// Initializes a new instance of the <see cref="PostController"/> class.
        /// </summary>
        /// <param name="postRepository">The postRepository<see cref="IPostService"/>.</param>
        /// <param name="mapper">The mapper<see cref="IMapper"/>.</param>
        /// <param name="uriService">The uriService<see cref="IUriService"/>.</param>
        public PostController(IPostService postRepository, IMapper mapper, IUriService uriService)
        {
            _postServices = postRepository;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// The GetPosts.
        /// </summary>
        /// <param name="filters">The filters<see cref="PostQueryFilter"/>.</param>
        /// <returns>The <see cref="IActionResult"/>.</returns>
        [HttpGet(Name = nameof(GetPosts))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type =typeof(ApiResponse<IEnumerable<PostDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetPosts([FromQuery] PostQueryFilter filters)
        {
            var post = _postServices.GetPosts(filters);
            var postDto = _mapper.Map<IEnumerable<PostDto>>(post);


            var metadata = new Metadata
            {
                TotalCount = post.TotalCount,
                PageSize = post.PageSize,
                CurrentPage = post.CurrentPage,
                TotalPages = post.TotalPages,
                HasNextPage = post.HasNextPage,
                HasPreviousPage = post.HasPreviosPage,
                NextPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetPosts))).ToString(),
                PreviousPageUrl = _uriService.GetPostPaginationUri(filters, Url.RouteUrl(nameof(GetPosts))).ToString()


            };
            var response = new ApiResponse<IEnumerable<PostDto>>(postDto)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        /// <summary>
        /// The GetPost.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPost(int id)
        {
            var post = await _postServices.GetPost(id);
            var postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(response);
        }

        /// <summary>
        /// The Post.
        /// </summary>
        /// <param name="postDto">The postDto<see cref="PostDto"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            await _postServices.InsertPost(post);

            postDto = _mapper.Map<PostDto>(post);
            var response = new ApiResponse<PostDto>(postDto);
            return Ok(post);
        }

        /// <summary>
        /// The Put.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <param name="postDto">The postDto<see cref="PostDto"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpPut]
        public async Task<IActionResult> Put(int id, PostDto postDto)
        {
            var post = _mapper.Map<Post>(postDto);
            post.Id = id;
            var result = await _postServices.UpdatePost(post);
            var response = new ApiResponse<bool>(result);
            return Ok(post);
        }

        /// <summary>
        /// The Delete.
        /// </summary>
        /// <param name="id">The id<see cref="int"/>.</param>
        /// <returns>The <see cref="Task{IActionResult}"/>.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var result = await _postServices.DeletePost(id);
            var response = new ApiResponse<bool>(result);
            return Ok(result);
        }
    }
}
