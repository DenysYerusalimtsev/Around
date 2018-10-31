import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Brand } from '../model/brand';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observable, from } from 'rxjs';
import { map } from 'rxjs/operators';
import 'rxjs/add/operator/map';

@Injectable()
export class BrandService {
  constructor(private http: HttpClient) { }
  baseUrl = 'http://localhost:55555/api/Brand/';

  form: FormGroup = new FormGroup({
    id: new FormControl(null),
    name: new FormControl('', Validators.required),
    country: new FormControl('', Validators.required),
  });

  getBrands() {
    return this.http.get<Brand[]>(this.baseUrl);
}

  getBrandById(id: number) {
    return this.http.get(this.baseUrl + '/' + id);
  }

  createBrand(brand: Brand) {
    return this.http.post(this.baseUrl, brand);
  }

  updateBrand(brand: Brand) {
    return this.http.put(this.baseUrl + '/' + brand.id, brand);
  }

  deleteBrand(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }

  initializeFormGroup() {
    this.form.setValue({
      id: 0,
      name: '',
      country: '',
    });
  }
}
