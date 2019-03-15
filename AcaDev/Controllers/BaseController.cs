using AcaDev.Model.IService;
using AcaDev.Model.ResponsesDto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace AcaDev.Controllers
{
    [Route("api/[controller]/[action]")]
    [Produces("application/json")]
    public class BaseController<T, S> : Controller
        where S : IService<T>
    {
        protected readonly S service;

        public BaseController(S service)
        {
            this.service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await service.GetById(id);
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
        public async Task<IActionResult> All()
        {
            try
            {
                var result = await service.GetAll();
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
