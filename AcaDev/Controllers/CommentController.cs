using AcaDev.Model.Dtos;
using AcaDev.Model.IService;
using AcaDev.Model.ResponsesDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AcaDev.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class CommentController : Controller
    {
        private readonly ICommentsService service;

        public CommentController(ICommentsService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Create(CommentDto dto)
        {
            try
            {
                var result = await service.Create(dto);
                if (result)
                {
                    return Ok(result);
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
