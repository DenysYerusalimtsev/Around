import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import 'rxjs/add/operator/map';
import { RentDto } from '../interface/rent-dto';
import { Rent } from '../model/rent';

@Injectable()
export class RentService {
  constructor(private http: HttpClient) { }
  baseUrl = 'http://localhost:55555/api/Rent/';

  form: FormGroup = new FormGroup({
    id: new FormControl(null),
    name: new FormControl('', Validators.required),
    country: new FormControl('', Validators.required),
  });

  getBrands() {
    return this.http.get<RentDto[]>(this.baseUrl);
}

  getBrandById(id: number) {
    return this.http.get<RentDto>(this.baseUrl + '/' + id);
  }

  createBrand(rent: Rent) {
    return this.http.post(this.baseUrl, rent);
  }

  updateBrand(rent: Rent) {
    return this.http.put(this.baseUrl + '/' + rent.id, rent);
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
