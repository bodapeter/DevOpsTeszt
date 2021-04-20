using HelloWord.Bll.Models;
using HelloWord.Bll.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWord.Dal.Repositories
{
    public class GreetingRepository : IGreetingRepository
    {
        private readonly AppDbContext context;
        public GreetingRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Task<List<Greeting>> GetAllGreetingsAsync()
        {
            return context.Greetings.OrderByDescending(x => x.TimeStamp).ToListAsync();
        }

        public async Task InsertGreetingAsync(Greeting entity)
        {
            await context.AddAsync(entity);
            await context.SaveChangesAsync();
        }
    }
}
