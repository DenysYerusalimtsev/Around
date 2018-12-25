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
}
