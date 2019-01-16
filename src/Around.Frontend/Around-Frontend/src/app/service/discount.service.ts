import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Country } from '../interface/country-dto';

@Injectable()
export class DiscountService {
  constructor(private http: HttpClient) { }
  baseUrl = 'http://localhost:55555/api/Client/discounts';

  getDiscounts() {
    return this.http.get<Country[]>(this.baseUrl);
  }
}
