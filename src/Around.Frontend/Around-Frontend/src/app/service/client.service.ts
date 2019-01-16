import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import 'rxjs/add/operator/map';
import { ClientDto } from '../interface/client-dto';

@Injectable()
export class ClientService {
  constructor(private http: HttpClient) { }
  baseUrl = 'http://localhost:55555/api/Client/';

  getClients() {
    return this.http.get<ClientDto[]>(this.baseUrl + 'clients');
}

  getClientById(id: number) {
    return this.http.get<ClientDto>(this.baseUrl + '/' + id);
  }

  createClient(client: ClientDto) {
    return this.http.post(this.baseUrl, client,
    {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
      responseType: 'text'
    })
    .subscribe(data => console.log('Works!'));
  }

  updateClient(client: ClientDto) {
    return this.http.put(this.baseUrl + '/' + client.id, client);
  }

  deleteClient(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }
}
