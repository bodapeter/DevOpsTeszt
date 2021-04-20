using HelloWord.Bll.Dtos;
using HelloWord.Bll.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWord.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GreetingController : ControllerBase
    {
        private readonly IGreetingAppService greetingAppService;
        public GreetingController(IGreetingAppService greetingAppService)
        {
            this.greetingAppService = greetingAppService;
        }

        // GET: api/<GreetingController>
        [HttpGet]
        public Task<List<GreetingDto>> Get()
        {
            return greetingAppService.GetAllGreetingsAsync();
        }

        
        // POST api/<GreetingController>
        [HttpPost]
        public async Task<string> Post([FromBody] GreetingCreateDto dto)
        {
            if(string.IsNullOrWhiteSpace(dto.Name))
            {
                Response.StatusCode = 400;
                return "";
            }

            await greetingAppService.StoreGreetingAsync(dto);

            return $"Hello {dto.Name}!";
        }

    }
}
