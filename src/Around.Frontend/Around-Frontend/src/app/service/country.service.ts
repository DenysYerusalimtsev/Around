import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Country } from '../interface/country-dto';

@Injectable()
export class CountryService {
  constructor(private http: HttpClient) { }
  baseUrl = 'http://localhost:55555/api/Brand/countries';

  getCountries() {
    return this.http.get<Country[]>(this.baseUrl);
  }
}
