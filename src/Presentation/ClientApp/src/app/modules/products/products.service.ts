import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private readonly _Url = '/api/v1/products';

  constructor(private httpClient: HttpClient) { }

  GetAll() {
    return this.httpClient.get(this._Url);
  }

  GetByFilter(filter) {
    return this.httpClient.get(`${this._Url}/filter?filter=${filter}`);
  }

  New(product) {
    return this.httpClient.post(this._Url, product);
  }

  Update(product) {
    return this.httpClient.put(this._Url, product);
  }

  Delete(productId) {
    return this.httpClient.delete(`${this._Url}/${productId}`);
  }

  AddInventory(inventory) {
    return this.httpClient.post(`${this._Url}/AddQuantity`, inventory);
  }

}
