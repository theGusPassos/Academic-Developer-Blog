using AcaDev.Model.Entities;
using AcaDev.Model.IService;
using AcaDev.Model.ResponsesDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AcaDev.Controllers
{
    public class PostsController : BaseController<Post, IPostsService>
    {
        public PostsController(IPostsService service) : base(service)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetWithComments(int id)
        {
            try
            {
                var result = await service.GetWithComments(id);
                if (result)
                {
                    return Ok(result.Value);
                }
                else
                {
                    return StatusCode((int)result.Code, ErrorResponseDto.Create((int)result.Code, result.Error));
                }
            }
            catch (Exception)
            {
                return StatusCode(500, ErrorResponseDto.Create(500, "internal server error"));
            }
        }

        [HttpGet]
        [Route("{tagId}")]
        public async Task<IActionResult> GetByTag(int tagId)
        {
            try
            {
                var result = await service.GetByTag(tagId);
                if (result)
                {
                    return Ok(result.Value);
                }
                else
                {
                    return StatusCode((int)result.Code, ErrorResponseDto.Create((int)result.Code, result.Error));
                }
            }
            catch (Exception)
            {
                return StatusCode(500, ErrorResponseDto.Create(500, "internal server error"));
            }
        }
    }
}
