using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;
using GraphQLDotNetCore.GraphQL.GraphQLQueries;
using System;

namespace GraphQLDotNetCore.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider)
            :base(provider)
        {
            Query = provider.GetRequiredService<AppQuery>();
        }
    }
}
