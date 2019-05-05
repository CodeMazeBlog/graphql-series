using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLClient
{
    public class Account
    {
        public Guid Id { get; set; }
        public TypeOfAccount Type { get; set; }
        public string Description { get; set; }
    }
}
