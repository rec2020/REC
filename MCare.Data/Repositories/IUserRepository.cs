﻿using NajmetAlraqee.Data.Entities;
using System.Linq;

namespace NajmetAlraqee.Data.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> GetAllUsers();
        User GetUser(string userId);
        User GetUserByMobile(string mobileNumber);

        User GetUserByName(string Name);
        bool SetMobileAsVerified(string userId);
        bool UpdateOTP(string userId, string oTP);
    }
}