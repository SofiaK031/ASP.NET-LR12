using Microsoft.EntityFrameworkCore;

namespace LR12.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UserModel> CreateUserAsync(string firstName, string secondName, int age)
        {
            var user = new UserModel(firstName, secondName, age);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<UserModel>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserModel> UpdateUserAsync(int id, string firstName, string secondName, int age)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                user.FirstName = firstName;
                user.SecondName = secondName;
                user.Age = age;
                await _context.SaveChangesAsync();
            }
            return user;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}