using GrapfQL.Core.Models.ViewModels;
using GrapfQL.Core.Resources;
using GrapfQL.Core.Services.Security;

namespace GrapfQL.Core.Resolvers.Queries
{
    [ExtendObjectType("Query")]
    public class UserQueryResolver
    {

        [GraphQLName("loginUser")]
        [GraphQLDescription("Retorna usuario logeado")]
        public async Task<UserResource> GetPLoginAsync(UserInputs userInputs, [Service] IUserService userService)
        {
            var resource = new LoginResource(userInputs.UserName, userInputs.Password);
            return await userService.Login(resource);
        }
    }
}
