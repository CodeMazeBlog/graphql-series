using GraphQLDotNetCore.Entities;
using System.Collections.Generic;

namespace GraphQLDotNetCore.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
    }
}
