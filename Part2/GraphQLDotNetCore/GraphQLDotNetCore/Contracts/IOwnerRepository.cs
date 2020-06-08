using GraphQLDotNetCore.Entities;
using System;
using System.Collections.Generic;

namespace GraphQLDotNetCore.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
        Owner GetById(Guid id);
    }
}
