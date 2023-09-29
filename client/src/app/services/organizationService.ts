import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Person } from '../models/person';
import { Organization } from '../models/organization';
import { InputOrganization } from '../models/inputOrganization';
import { Injectable } from '@angular/core';

@Injectable()
export class OrganizationService {

baseUrl = environment.apiUrl + "organization";
  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<Organization[]>(`${this.baseUrl}/all`);
  }

  get(id: string) {
    return this.http.get<Organization[]>(`${this.baseUrl}/${id}`);
  }

  create(person: InputOrganization) {
    return this.http.post<Organization>(this.baseUrl, person);
  }

  update(person: Organization) {
    return this.http.patch<Organization>(this.baseUrl, person);
  }

  delete(id: string) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }  
}