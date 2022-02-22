//using MMIS.DataAccessLayer.Contracts;
//using MMIS.DataAccessLayer.Shared;
//using MMIS.DomainLayer.Entities.Users;
//using Microsoft.EntityFrameworkCore;
//using System.Threading.Tasks;

//namespace MMIS.DataAccessLayer.Users
//{
//    public class UserRepository : RepositoryBase<User>, IUserRepository
//    {
//        public UserRepository(MMISDbContext dbContext) : base(dbContext) { }

//        public async Task<User> GetUserByUserNameAsync(string userName)
//        {
//           return await this.DbSet.FirstOrDefaultAsync(u => u.UserName.ToLower() == userName.ToLower() );
//        }
//    }
//}
