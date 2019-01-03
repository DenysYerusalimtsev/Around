import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { ChequeDto } from '../interface/cheque-dto';
import { Cheque } from '../model/сheque';
import { ChequeAggregate } from '../model/cheque-aggregate';

@Injectable()
export class ChequeService {
  constructor(private http: HttpClient) { }
  baseUrl = 'http://localhost:55555/api/Cheque/';

  getCheques() {
    return this.http.get<ChequeDto[]>(this.baseUrl);
}

  getChequeById(id: number) {
    return this.http.get<ChequeDto>(this.baseUrl + '/' + id);
  }

  createCheque(cheque: ChequeAggregate) {
    return this.http.post(this.baseUrl + 'create', cheque,
    {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      responseType: 'text'
    })
    .subscribe(data => console.log('Works!'));
  }

  updateCheque(cheque: Cheque) {
    return this.http.put(this.baseUrl + '/' + cheque.id, cheque);
  }

  deleteCheque(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }
}
