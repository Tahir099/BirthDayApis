using BirthDay.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BirthDay.Repository
{
    public interface IuserRepository
    {
        Task<IEnumerable<User>> GetUser();
        Task<User> insertUser(User objUser);
        bool DeleteUser(int ID);
        Task<User> UpdateUser(User objAnbar);
        Task<User> GetUserByid(int id);


    }
    public class UserRepository : IuserRepository
    {
        private readonly ApiDbContext apiDbContext_;

        public async Task<User> UpdateUser(User objUser)
        {
            apiDbContext_.Entry(objUser).State = EntityState.Modified;
            await apiDbContext_.SaveChangesAsync();
            return objUser;
        }
        public UserRepository(ApiDbContext context)
        {
            apiDbContext_ = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool DeleteUser(int ID)
        {
            bool result = false;
            var User = apiDbContext_.users.Find(ID);
            if (User != null)
            {
                apiDbContext_.Entry(User).State = EntityState.Deleted;
                apiDbContext_.SaveChanges();
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }


        public async Task<IEnumerable<User>> GetUser()
        {
            var result = await apiDbContext_.users.FromSqlRaw("EXEC sp_SelectUsersByBirthday").ToListAsync();
            return result;
        }

        public async Task<User> insertUser(User objUser)
        {
            apiDbContext_.users.Add(objUser);
            await apiDbContext_.SaveChangesAsync();
            return  objUser;
        }

        public async Task<User> GetUserByid(int id)
        {
            var user = await apiDbContext_.users.FindAsync(id);
            return user;
        }
    }
}
