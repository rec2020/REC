using AutoMapper.Configuration;
using NajmetAlraqee.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace NajmetAlraqee.Data.Initializer
{
    public class IdentityInitializing
    {
        public enum ROLES
        {
            Root, Administrator, Doctor, Patient
        };

        public static void Seed(IServiceProvider serviceProvider)
        {
            CreateRoles(serviceProvider);
        }

        public static User AddUser(IServiceProvider serviceProvider,
           string username, string password, string fullname, string mobile, string role)
        {
            User user = CreateUser(serviceProvider, username, password, fullname, mobile);
            AddUserToRole(serviceProvider, username, password, role);
            return user;
        }

        private static void CreateRoles(IServiceProvider serviceProvider)
        {
            string[] roleNames = { ROLES.Root.ToString(), ROLES.Administrator.ToString(),
                    ROLES.Doctor.ToString(), ROLES.Patient.ToString()};

            foreach (string roleName in roleNames)
            {
                CreateRole(serviceProvider, roleName);
            }
        }

        private static User CreateUser(IServiceProvider serviceProvider, string userEmail, string userPwd,
            string fullname, string mobile)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            Task<User> checkAppUser = userManager.FindByEmailAsync(userEmail);
            checkAppUser.Wait();

            User appUser = checkAppUser.Result;

            if (checkAppUser.Result == null)
            {
                User newAppUser = new User
                {
                    Email = userEmail,
                    UserName = userEmail,
                    PhoneNumber = mobile,                   
                };

                Task<IdentityResult> taskCreateAppUser = userManager.CreateAsync(newAppUser, userPwd);
                taskCreateAppUser.Wait();

                if (taskCreateAppUser.Result.Succeeded)
                {
                    appUser = newAppUser;
                }
            }

            return appUser;
        }

        private static bool CreateRole(IServiceProvider serviceProvider, string roleName)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            Task<bool> roleExists = roleManager.RoleExistsAsync(roleName);
            roleExists.Wait();

            if (!roleExists.Result)
            {
                Task<IdentityResult> roleResult = roleManager.CreateAsync(new IdentityRole(roleName));
                roleResult.Wait();
                return true;
            }

            return false;
        }

        private static bool AddUserToRole(IServiceProvider serviceProvider, string userEmail,
            string userPwd, string roleName)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

            Task<User> checkAppUser = userManager.FindByEmailAsync(userEmail);
            checkAppUser.Wait();

            User appUser = checkAppUser.Result;

            if (appUser != null)
            {
                Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(appUser, roleName);
                newUserRole.Wait();
                return true;
            }

            return false;
        }
    }
}
