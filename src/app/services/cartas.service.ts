import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CartasService {

  constructor(private readonly http: HttpClient) { }

  getProject() {
    return this.http.get('/api/project/GetProject');
  }
}
