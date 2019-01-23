using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data.Interfaces;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DatingAppDBContext _context;

        public DatingRepository(DatingAppDBContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(long userID)
        {
            var user = _context.User.Include(p => p.Photo).FirstOrDefaultAsync(x => x.Id == userID);
            return await user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.User.Include(p => p.Photo).ToListAsync();

            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}