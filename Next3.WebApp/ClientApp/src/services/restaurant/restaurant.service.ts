import { Injectable } from '@angular/core';
import { ApiService } from '../api/api.service';
import { environment } from '../../environments/environment';
import { Restaurant } from '../../models/restaurant';

@Injectable({
  providedIn: 'root'
})
export class RestaurantService {

  headers: Headers;

  constructor(private api: ApiService) {
    this.headers = new Headers();
    this.headers.append("Accept", 'application/json');
    this.headers.append('Content-Type', 'application/json');
  }

  async getAll(pageIndex: number, pageSize: number) {
    const result = await this.api.get(environment.API.RESTAURANT.LIST + pageIndex + '/' + + pageSize, null, { headers: this.headers });
    const restaurants = new Array<Restaurant>();
    for (const restaraunt in result)
      restaurants.push(new Restaurant(result[restaraunt]));

    return restaurants;
  }

}
