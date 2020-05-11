using CachingMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CachingMVC.Services
{
    public class UserService
    {
        private readonly ApplicationContext _dbcontext;
        private readonly IMemoryCache _cache;

        public UserService(IMemoryCache cache, ApplicationContext context)
        {
            _cache = cache;
            _dbcontext = context;
        }

        public void Initialize()
        {
            if (!_dbcontext.Users.Any())
            {
                _dbcontext.Users.AddRange(
                    new User { Name = "Tom", Email = "tom@gmail.com", Age = 35 },
                    new User { Name = "Alice", Email = "alice@yahoo.com", Age = 29 },
                    new User { Name = "Sam", Email = "sam@online.com", Age = 37 }
                );
                _dbcontext.SaveChanges();
            }

        }

        public async Task<IEnumerable<User>> GetUsersAsync() => await _dbcontext.Users.ToListAsync();

        public async Task AddUserAsync(User user)
        {
            await _dbcontext.AddAsync(user);
                        
            int n = await _dbcontext.SaveChangesAsync();
            
            if (n > 0)
            {
                _cache.Set(user.Id, user, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5)
                });
            }
        }

        public async Task<User> GetUserAsync(int id)
        {
            User user = null;
            
            if (!_cache.TryGetValue(id, out user))
            {
                user = await _dbcontext.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (user != null)
                {
                    _cache.Set(user.Id, user, new MemoryCacheEntryOptions() { AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5) });
                }
            }

            return user;
        }
    }
}
