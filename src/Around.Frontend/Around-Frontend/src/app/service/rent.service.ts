import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import 'rxjs/add/operator/map';
import { RentDto } from '../interface/rent-dto';
import { Rent } from '../model/rent';
import { RentAggregate } from '../model/rent-aggregate';

@Injectable()
export class RentService {
  constructor(private http: HttpClient) { }
  baseUrl = 'http://localhost:55555/api/Rent/';

  form: FormGroup = new FormGroup({
    id: new FormControl(null),
    name: new FormControl('', Validators.required),
    country: new FormControl('', Validators.required),
  });

  getRents() {
    return this.http.get<RentDto[]>(this.baseUrl);
}

  getRentById(id: number) {
    return this.http.get<RentDto>(this.baseUrl + id);
  }

  getRentByUserId(userId: number) {
    return this.http.get<RentDto>(this.baseUrl + 'user/' + userId);
  }

  createRent(rent: RentAggregate) {
    return this.http.post(this.baseUrl + 'create', rent,
    {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      responseType: 'text'
    })
    .subscribe(data => console.log(JSON.stringify(rent)));
  }

  updateRent(rent: Rent) {
    return this.http.put(this.baseUrl + '/' + rent.id, rent);
  }

  deleteRent(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }
}
