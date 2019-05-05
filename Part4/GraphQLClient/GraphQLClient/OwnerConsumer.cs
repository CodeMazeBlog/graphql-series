using GraphQL.Common.Request;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLClient
{
    public class OwnerConsumer
    {
        private readonly GraphQL.Client.GraphQLClient _client;

        public OwnerConsumer(GraphQL.Client.GraphQLClient client)
        {
            _client = client;
        }

        public async Task<List<Owner>> GetAllOwners()
        {
            var query = new GraphQLRequest
            {
                Query = @"
                        query ownersQuery{
                          owners {
                            id
                            name
                            address
                            accounts {
                              id
                              type
                              description
                            }
                          }
                        }"
            };

            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<List<Owner>>("owners");

        }

        public async Task<Owner> GetOwner(Guid id)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                        query ownerQuery($ownerID: ID!) {
                          owner(ownerId: $ownerID) {
                            id
                            name
                            address
                            accounts {
                              id
                              type
                              description
                            }
                          }
                        }",
                Variables = new { ownerID = id }
            };

            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<Owner>("owner");
        }

        public async Task<Owner> CreateOwner(OwnerInput ownerToCreate)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                        mutation($owner: ownerInput!){
                          createOwner(owner: $owner){
                            id,
                            name,
                            address
                          }
                        }",
                Variables = new {owner = ownerToCreate}
            };

            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<Owner>("createOwner");
        }

        public async Task<Owner> UpdateOwner(Guid id, OwnerInput ownerToUpdate)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                        mutation($owner: ownerInput!, $ownerId: ID!){
                          updateOwner(owner: $owner, ownerId: $ownerId){
                            id,
                            name,
                            address
                          }
                        }",
                Variables = new { owner = ownerToUpdate, ownerId = id }
            };

            var response = await _client.PostAsync(query);
            return response.GetDataFieldAs<Owner>("updateOwner");
        }

        public async Task<string> DeleteOwner(Guid id)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                       mutation($ownerId: ID!){
                          deleteOwner(ownerId: $ownerId)
                        }",
                Variables = new { ownerId = id }
            };

            var response = await _client.PostAsync(query);
            return response.Data.deleteOwner;
        }
    }
}
