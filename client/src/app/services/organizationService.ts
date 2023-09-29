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

  create(organization: InputOrganization) {
    return this.http.post<Organization>(this.baseUrl, organization);
  }

  update(organization: Organization) {
    return this.http.patch<Organization>(this.baseUrl, organization);
  }

  delete(id: string) {
    return this.http.delete(`${this.baseUrl}/${id}`);
  }  
}