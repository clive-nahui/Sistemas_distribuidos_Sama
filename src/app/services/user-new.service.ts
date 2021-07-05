import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserNewService {

  constructor(private readonly http: HttpClient) { }
  
  insert(data, headers) {
    return this.http.post<any>('https://localhost:44309/api/User/insert', data);
  }
}