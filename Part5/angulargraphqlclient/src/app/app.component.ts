import { Component, OnInit } from '@angular/core';
import { GraphqlService } from './graphql.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  implements OnInit{


  constructor(private service: GraphqlService) {
  }

  ngOnInit(): void {
    // this.service.getOwners();

    // this.service.getOwner('514c3bc3-14df-4515-bc13-256e75dd2e9f');

    // const ownerToCreate = {
    //   name: 'new name',
    //   address: 'new address'
    // }
    // this.service.createOwner(ownerToCreate);

    // const ownerToUpdate = {
    //   name: 'updated name',
    //   address: 'updated address'
    // }
    // this.service.updateOwner(ownerToUpdate, 'BEABBE64-C19A-4FFE-B149-34D1F5B1BC45');

    //this.service.deleteOwner('BEABBE64-C19A-4FFE-B149-34D1F5B1BC45');
  }
  title = 'angulargraphqlclient';
}
