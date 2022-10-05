using GrapfQL.Core.Models.ViewModels;
using GrapfQL.Core.Resources;
using GrapfQL.Core.Services.Security;

namespace GrapfQL.Core.Resolvers.Mutations.UserMutation
{
    [ExtendObjectType("Mutation")]
    public class UserMutationResolver
    {
        [GraphQLName("registerUser")]
        [GraphQLDescription("Registrar Usuario")]
        public async Task<UserResource> RegisterUserAsync(UserInputs userInputs, [Service] IUserService userService)
        {
            var user = new RegisterResource(userInputs.UserName, userInputs.Email, userInputs.Password);
            return await userService.Register(user);
        }
    }
}
