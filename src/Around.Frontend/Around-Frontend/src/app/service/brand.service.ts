import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Brand } from '../model/brand';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import 'rxjs/add/operator/map';
import { BrandDto } from '../interface/brand-dto';
import { BrandAggregate } from '../model/brand-aggregate';

@Injectable()
export class BrandService {
  constructor(private http: HttpClient) { }
  baseUrl = 'http://localhost:55555/api/Brand/';

  form: FormGroup = new FormGroup({
    id : new FormControl(null),
    name: new FormControl('', Validators.required),
    country: new FormControl('', Validators.required),
  });

  getBrands() {
    return this.http.get<BrandDto[]>(this.baseUrl);
}

  getBrandById(id: number) {
    return this.http.get<BrandDto>(this.baseUrl + '/' + id);
  }

  createBrand(brand: BrandAggregate) {
    console.log(brand);

    return this.http.post(this.baseUrl + 'create', brand,
    {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      responseType: 'text'
    })
    .subscribe(data => console.log('Works!'));
  }

  updateBrand(brand: BrandAggregate) {
    return this.http.put(this.baseUrl + 'brand/', brand,
    {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      responseType: 'text'
    })
    .subscribe(data => console.log('Works!'));
  }

  deleteBrand(id: number) {
    return this.http.delete(this.baseUrl + '/' + id,
    {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      responseType: 'text'
    })
    .subscribe(data => console.log('Works!'));
  }

  initializeFormGroup() {
    this.form.setValue({
      id: null,
      name: '',
      country: '',
    });
  }
}
