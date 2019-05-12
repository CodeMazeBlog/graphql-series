import { Injectable } from '@angular/core';
import { Apollo } from 'apollo-angular';
import { HttpLink } from 'apollo-angular-link-http';
import { InMemoryCache } from 'apollo-cache-inmemory';
import gql from 'graphql-tag';
import { OwnerType } from './types/ownerType';
import { OwnerInputType } from './types/ownerInputType';

@Injectable({
  providedIn: 'root'
})
export class GraphqlService {
  public owners: OwnerType[];
  public owner: OwnerType;
  public createdOwner: OwnerType;
  public updatedOwner: OwnerType;

  constructor(private apollo: Apollo, httpLink: HttpLink) {
    apollo.create({
      link: httpLink.create({ uri: 'https://localhost:5001/graphql' }),
      cache: new InMemoryCache()
    })
  }

  public getOwners = () => {
    this.apollo.query({
      query: gql`query getOwners{
      owners{
        id,
        name,
        address,
        accounts{
          id,
          description,
          type
        }
      }
    }`
    }).subscribe(result => {
      this.owners = result.data as OwnerType[];
    })
  }

  public getOwner = (id) => {
    this.apollo.query({
      query: gql`query getOwner($ownerID: ID!){
      owner(ownerId: $ownerID){
        id,
        name,
        address,
        accounts{
          id,
          description,
          type
        }
      }
    }`,
      variables: { ownerID: id }
    }).subscribe(result => {
      this.owner = result.data as OwnerType;
    })
  }

  public createOwner = (ownerToCreate: OwnerInputType) => {
    this.apollo.mutate({
      mutation: gql`mutation($owner: ownerInput!){
        createOwner(owner: $owner){
          id,
          name,
          address
        }
      }`,
      variables: {owner: ownerToCreate}
    }).subscribe(result => {
      this.createdOwner = result.data as OwnerType;
    })
  }

  public updateOwner = (ownerToUpdate: OwnerInputType, id: string) => {
    this.apollo.mutate({
      mutation: gql`mutation($owner: ownerInput!, $ownerId: ID!){
        updateOwner(owner: $owner, ownerId: $ownerId){
          id,
          name,
          address
        }
      }`,
      variables: {owner: ownerToUpdate, ownerId: id}
    }).subscribe(result => {
      this.updatedOwner = result.data as OwnerType;
    })
  }

  public deleteOwner = (id: string) => {
    this.apollo.mutate({
      mutation: gql`mutation($ownerId: ID!){
        deleteOwner(ownerId: $ownerId)
       }`,
      variables: { ownerId: id}
    }).subscribe(res => {
      console.log(res.data);
    })
  }
}
