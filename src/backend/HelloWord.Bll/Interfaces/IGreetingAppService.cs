using HelloWord.Bll.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord.Bll.Interfaces
{
    public interface IGreetingAppService
    {
        Task<List<GreetingDto>> GetAllGreetingsAsync();
        Task StoreGreetingAsync(GreetingCreateDto dto);
    }
}
