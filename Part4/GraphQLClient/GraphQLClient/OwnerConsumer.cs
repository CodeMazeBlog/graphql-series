using GraphQL;
using GraphQL.Client.Abstractions;
using GraphQLClient.ResponsTypes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLClient
{
    public class OwnerConsumer
    {
        private readonly IGraphQLClient _client;

        public OwnerConsumer(IGraphQLClient client)
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
                        }",
            };

            var response = await _client.SendQueryAsync<ResponseOwnerCollectionType>(query);
            return response.Data.Owners;

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

            var response = await _client.SendQueryAsync<ResponseOwnerType>(query);
            return response.Data.Owner;
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
                Variables = new { owner = ownerToCreate }
            };

            var response = await _client.SendMutationAsync<ResponseOwnerType>(query);
            return response.Data.Owner;
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

            var response = await _client.SendMutationAsync<ResponseOwnerType>(query);
            return response.Data.Owner;
        }

        public async Task<Owner> DeleteOwner(Guid id)
        {
            var query = new GraphQLRequest
            {
                Query = @"
                           mutation($ownerId: ID!){
                              deleteOwner(ownerId: $ownerId)
                            }",
                Variables = new { ownerId = id }
            };

            var response = await _client.SendMutationAsync<ResponseOwnerType>(query);
            return response.Data.Owner;
        }
    }
}
