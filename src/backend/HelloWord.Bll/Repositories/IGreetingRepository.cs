using HelloWord.Bll.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord.Bll.Repositories
{
    public interface IGreetingRepository
    {
        Task<List<Greeting>> GetAllGreetingsAsync();
        Task InsertGreetingAsync(Greeting entity);
    }
}
