namespace CommanderGQL.GraphQL
{
    using CommanderGQL.Models;
    using CommanderGQL.Data;
    using System.Linq;
    using HotChocolate;
    using HotChocolate.Data;

    public class Query
    {
        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }

         [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}