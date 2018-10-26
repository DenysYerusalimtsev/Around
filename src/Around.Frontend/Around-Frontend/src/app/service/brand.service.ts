import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Brand } from '../model/brand';

@Injectable()
export class UserService {
  constructor(private http: HttpClient) { }
  baseUrl = 'http://localhost:55555/brand/brands';

  getUsers() {
    return this.http.get<Brand[]>(this.baseUrl);
  }

  getBrandById(id: number) {
    return this.http.get<Brand>(this.baseUrl + '/' + id);
  }

  createBrand(brand: Brand) {
    return this.http.post(this.baseUrl, brand);
  }

  updateBrand(brand: Brand) {
    return this.http.put(this.baseUrl + '/' + brand.id, brand);
  }

  deleteBrand(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }
}
