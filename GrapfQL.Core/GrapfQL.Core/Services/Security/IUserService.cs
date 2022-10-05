using GrapfQL.Core.Resources;

namespace GrapfQL.Core.Services.Security
{
    public interface IUserService
    {
        Task<UserResource> Register(RegisterResource resource);
        Task<UserResource> Login(LoginResource resource);
    }
}
