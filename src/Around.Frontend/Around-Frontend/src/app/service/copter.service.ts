import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import 'rxjs/add/operator/map';
import { Copter } from '../model/copter';
import { CopterDto } from '../interface/copter-dto';
import { CopterAggregate } from '../model/copter-aggregate';

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

  createCopter(copter: CopterAggregate) {
    return this.http.post(this.baseUrl, copter,
    {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      responseType: 'text'
    })
    .subscribe(data => console.log('Works!'));
  }

  updateCopter(copter: Copter) {
    return this.http.put(this.baseUrl + '/' + copter.id, copter);
  }

  deleteCopter(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }
}
