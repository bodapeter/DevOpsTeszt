using HelloWord.Bll.Dtos;
using HelloWord.Bll.Interfaces;
using HelloWord.Bll.Models;
using HelloWord.Bll.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord.Bll.Services
{
    public class GreetingAppService : IGreetingAppService
    {
        private readonly IGreetingRepository greetingRepository;
        public GreetingAppService(IGreetingRepository greetingRepository)
        {
            this.greetingRepository = greetingRepository;
        }

        public async Task<List<GreetingDto>> GetAllGreetingsAsync()
        {
            return (await greetingRepository.GetAllGreetingsAsync())
                .Select(x =>
                    new GreetingDto
                    {
                        Name = x.Name,
                        TimeStamp = x.TimeStamp
                    })
                .ToList();
        }

        public Task StoreGreetingAsync(GreetingCreateDto dto)
        {
            return greetingRepository.InsertGreetingAsync(new Greeting(dto.Name));
        }
    }
}
