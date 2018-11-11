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
    status: new FormControl(null),
    latitude: new FormControl(null),
    longitude: new FormControl(null),
    brandName: new FormControl('', Validators.required),
    costPerMinute: new FormControl(null),
    maxSpeed: new FormControl(null),
    maxFlightHeight: new FormControl(null),
    control: new FormControl(null),
    droneType: new FormControl(null),
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

  updateCopter(copter: Copter) {
    return this.http.put(this.baseUrl + '/' + copter.id, copter);
  }

  deleteCopter(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }

  initializeFormGroup() {
    this.form.setValue({
      id: 0,
      name: '',
      status: 0,
      latitude: 0,
      longitude: 0,
      costPerMinute: 0,
      brandName: '',
      maxSpeed: 0,
      maxFlightHeight: 0,
      control: 0,
      droneType: 0
    });
  }
}
