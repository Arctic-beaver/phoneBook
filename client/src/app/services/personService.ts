import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Person } from '../models/person';
import { InputPerson } from '../models/inputPerson';
import { Injectable } from '@angular/core';

@Injectable()
export class PersonService {

baseUrl = environment.apiUrl + "person";
  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<Person[]>(`${this.baseUrl}/all`);
  }

  get(id: string) {
    return this.http.get<Person[]>(`${this.baseUrl}/${id}`);
  }

  create(person: InputPerson) {
    return this.http.post<Person>(this.baseUrl, person);
  }

  update(person: Person) {
    return this.http.patch<Person>(this.baseUrl, person);
  }

  delete(id: string) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }  
}