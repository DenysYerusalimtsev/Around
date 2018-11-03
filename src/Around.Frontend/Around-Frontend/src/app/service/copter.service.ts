import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import 'rxjs/add/operator/map';
import { Copter } from '../model/copter';
import { CopterDto } from '../interface/copter-dto';

@Injectable()
export class CopterService {
  constructor(private http: HttpClient) { }
  baseUrl = 'http://localhost:55555/api/Copter/';

  form: FormGroup = new FormGroup({
    id: new FormControl(null),
    name: new FormControl('', Validators.required),
    country: new FormControl('', Validators.required),
  });

  getCopters() {
    return this.http.get<CopterDto[]>(this.baseUrl);
}

  getCopterById(id: number) {
    return this.http.get<CopterDto>(this.baseUrl + '/' + id);
  }

  createCopter(copter: Copter) {
    return this.http.post(this.baseUrl, copter);
  }

  updateBrand(copter: Copter) {
    return this.http.put(this.baseUrl + '/' + copter.id, copter);
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
