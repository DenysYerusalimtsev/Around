import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import 'rxjs/add/operator/map';
import { ChequeDto } from '../interface/cheque-dto';
import { Cheque } from '../model/сheque';

@Injectable()
export class ChequeService {
  constructor(private http: HttpClient) { }
  baseUrl = 'http://localhost:55555/api/Cheque/';

  form: FormGroup = new FormGroup({
    id: new FormControl(null),
    name: new FormControl('', Validators.required),
    country: new FormControl('', Validators.required),
  });

  getCheques() {
    return this.http.get<ChequeDto[]>(this.baseUrl);
}

  getChequeById(id: number) {
    return this.http.get<ChequeDto>(this.baseUrl + '/' + id);
  }

  createCheque(cheque: Cheque) {
    return this.http.post(this.baseUrl, cheque);
  }

  updateCheque(cheque: Cheque) {
    return this.http.put(this.baseUrl + '/' + cheque.id, cheque);
  }

  deleteCheque(id: number) {
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
