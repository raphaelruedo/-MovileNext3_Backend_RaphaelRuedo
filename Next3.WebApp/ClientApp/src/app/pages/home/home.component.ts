import { Component, OnInit, ViewChild } from '@angular/core';
import { GooglePlaceDirective } from "node_modules/ngx-google-places-autocomplete/ngx-google-places-autocomplete.directive";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  @ViewChild("placesRef") placesRef: GooglePlaceDirective;
  constructor() { }

  ngOnInit() {
  }

  public onChange(address: any) {
    if(address.photos && address.photos.length > 0){
        console.dir(address.photos[0].getUrl({maxHeight:500,maxWidth:500}));
    }
    console.log(address.geometry.location.lng());
    console.log(address.geometry.location.lat());
    console.log(address.geometry.location.toJSON());
    console.log(address.geometry.viewport.getNorthEast());
}

  public handleAddressChange(address: any) {
    console.log(address);
  }

}
