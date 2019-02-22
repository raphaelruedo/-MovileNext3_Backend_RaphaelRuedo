import { Component, OnInit } from '@angular/core';
import { RestaurantService } from '../../../../services/restaurant/restaurant.service';
@Component({
  selector: 'app-list-restaurant',
  templateUrl: './list-restaurant.component.html',
  styleUrls: ['./list-restaurant.component.scss']
})
export class ListRestaurantComponent implements OnInit {

  constructor(private restaurantService: RestaurantService) { }

  ngOnInit() {
   console.log(this.restaurantService.getAll(1, 10));
  }

}
