using NajmetAlraqee.Data.Entities;
using System.Linq;

namespace NajmetAlraqee.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private NajmetAlraqeeContext _context;

        public UserRepository(NajmetAlraqeeContext context)
        {
            _context = context;
        }

        public bool SetMobileAsVerified(string userId)
        {
            var user = GetUser(userId);
            if (user == null)
                return false;

            user.MobileIsVerified = true;
            _context.SaveChanges();

            return true;
        }

        public bool UpdateOTP(string userId, string oTP)
        {
            var user = GetUser(userId);
            if (user == null)
                return false;

            user.OTP = oTP;
            _context.SaveChanges();

            return true;
        }

        public User GetUser(string userId)
        {
            return _context.Users.Find(userId);
        }
        public IQueryable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User GetUserByMobile(string mobileNumber)
        {
            return _context.Users.FirstOrDefault(m => m.Mobile == mobileNumber);
        }

        public User GetUserByName(string Name)
        {
            return _context.Users.FirstOrDefault(m => m.UserName == Name);
        }
    }
}
