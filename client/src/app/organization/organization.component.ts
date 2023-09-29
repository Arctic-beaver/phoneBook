import { Component, OnInit } from '@angular/core';
import { Organization } from '../models/organization';
import { OrganizationService } from '../services/organizationService';
import { Observable, defer } from 'rxjs';
import { OrganizationType } from '../models/organizationType';

@Component({
  selector: 'app-organization',
  templateUrl: './organization.component.html',
  styleUrls: ['./organization.component.css']
})
export class OrganizationComponent implements OnInit {

  organizations$: Observable<Organization[]> = this.organizationService.getAll();
  OrganizationType = OrganizationType;

  constructor(private organizationService: OrganizationService) {}

  ngOnInit(): void {
    this.organizations$ = this.organizationService.getAll();
  }

  // Метод для создания нового человека
  createOrganization(organization: Organization): void {
    this.organizationService.create(organization).subscribe(() => {
      // Обновляем коллекцию людей после успешного создания нового человека
      this.organizations$ = this.organizationService.getAll();
    });
  }

  // Метод для обновления существующего человека
  updateOrganization(organization: Organization): void {
    this.organizationService.update(organization).subscribe(() => {
      // Обновляем коллекцию людей после успешного обновления существующего человека
      this.organizations$ = this.organizationService.getAll();
    });
  }

  // Метод для удаления человека
  deleteOrganization(id: string): void {
    this.organizationService.delete(id).subscribe(() => {
      // Обновляем коллекцию людей после успешного удаления человека
      this.organizations$ = this.organizationService.getAll();
    });
  }
}