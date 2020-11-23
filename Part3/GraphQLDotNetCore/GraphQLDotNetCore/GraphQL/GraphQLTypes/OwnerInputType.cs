using GraphQL.Types;

namespace GraphQLDotNetCore.GraphQL.GraphQLTypes
{
	public class OwnerInputType : InputObjectGraphType
	{
		public OwnerInputType()
		{
			Name = "ownerInput";
			Field<NonNullGraphType<StringGraphType>>("name");
			Field<NonNullGraphType<StringGraphType>>("address");
		}
	}
}
