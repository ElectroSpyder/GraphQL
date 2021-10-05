namespace CommanderGQL.GraphQL
{
    using CommanderGQL.Models;
    using CommanderGQL.Data;
    using System.Linq;
    using HotChocolate;

    public class Query
    {
        IQueryable<Platform> GetPlatform([Service] AppDbContext context)
        {
            return context.Platforms;
        }
    }
}