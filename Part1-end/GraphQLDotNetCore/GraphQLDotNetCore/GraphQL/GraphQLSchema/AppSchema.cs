using GraphQL;
using GraphQL.Types;
using GraphQLDotNetCore.GraphQL.GraphQLQueries;

namespace GraphQLDotNetCore.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver)
            :base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
        }
    }
}
