import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import 'rxjs/add/operator/map';
import { ClientDto } from '../interface/client-dto';

@Injectable()
export class ClientService {
  constructor(private http: HttpClient) { }
  baseUrl = 'http://localhost:55555/api/Client/';

  form: FormGroup = new FormGroup({
    id: new FormControl(null),
    name: new FormControl('', Validators.required),
    country: new FormControl('', Validators.required),
  });

  getClients() {
    return this.http.get<ClientDto[]>(this.baseUrl);
}

  getClientById(id: number) {
    return this.http.get<ClientDto>(this.baseUrl + '/' + id);
  }

  createClient(client: ClientDto) {
    return this.http.post(this.baseUrl, client);
  }

  updateClient(client: ClientDto) {
    return this.http.put(this.baseUrl + '/' + client.id, client);
  }

  deleteClient(id: number) {
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
