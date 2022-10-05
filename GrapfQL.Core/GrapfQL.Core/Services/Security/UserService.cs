using GrapfQL.Core.Models;
using GrapfQL.Core.Resources;
using Microsoft.EntityFrameworkCore;

namespace GrapfQL.Core.Services.Security
{
    public class UserService : IUserService
    {
        private readonly UserDbContext userDbContext;
        private readonly string _pepper;
        private readonly int _iteration = 3;

        public UserService(UserDbContext userDbContext)
        {
            this.userDbContext = userDbContext;
            _pepper = Environment.GetEnvironmentVariable("PasswordHashExamplePepper");
            
        }

        public async Task<UserResource> Login(LoginResource resource)
        {
            var user = await userDbContext.Users
             .FirstOrDefaultAsync(x => x.Username == resource.UserName);

            if (user == null)
                throw new Exception("Username or password did not match.");

            var passwordHash = PasswordHasher.ComputeHash(resource.Password, user.PasswordSalt, _pepper, _iteration);
            if (user.PasswordHash != passwordHash)
                throw new Exception("Username or password did not match.");

            return new UserResource(user.Id, user.Username, user.Email);
        }

        public async Task<UserResource> Register(RegisterResource resource)
        {
            var user = new User
            {
                Username = resource.UserName,
                Email = resource.Email,
                PasswordSalt = PasswordHasher.GenerateSalt()
            };
            user.PasswordHash = PasswordHasher.ComputeHash(resource.Password, user.PasswordSalt, _pepper, _iteration);
            await userDbContext.Users.AddAsync(user);
            await userDbContext.SaveChangesAsync();

            return new UserResource(user.Id, user.Email, user.PasswordSalt);
        }
    }
}
