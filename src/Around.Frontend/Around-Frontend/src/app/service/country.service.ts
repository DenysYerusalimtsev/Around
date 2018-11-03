import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import 'rxjs/add/operator/map';
import { CountryDto } from '../interface/country-dto';

@Injectable()
export class BrandService {
  constructor(private http: HttpClient) { }
  baseUrl = 'http://localhost:55555/api/Country/';

  form: FormGroup = new FormGroup({
    id: new FormControl(null),
    name: new FormControl('', Validators.required),
    country: new FormControl('', Validators.required),
  });

  getCountries() {
    return this.http.get<CountryDto>(this.baseUrl);
  }
}
