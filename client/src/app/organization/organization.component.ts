import { Component, OnInit } from '@angular/core';
import { Organization } from '../models/organization';
import { OrganizationService } from '../services/organizationService';
import { Observable, defer } from 'rxjs';
import { OrganizationType } from '../models/organizationType';
import { InputOrganization } from '../models/inputOrganization';

@Component({
  selector: 'app-organization',
  templateUrl: './organization.component.html',
  styleUrls: ['./organization.component.css']
})
export class OrganizationComponent implements OnInit {

  organizations$: Observable<Organization[]> = this.organizationService.getAll();
  OrganizationType = OrganizationType;
  isObservingMode = false;
  isCreatingMode = false;
  isEditingMode = false;
  isInitialMode = true;
  activeOrganization: Organization = {
    organizationType: OrganizationType.Private,
    id: '',
    name: '',
    phoneNumber: ''
  }

  constructor(private organizationService: OrganizationService) {}

  ngOnInit(): void {
    this.updateOrganizationList();
  }

  onRowClick(organization: Organization) {
    console.log('Clicked on row with index:', organization.id);
    this.activateObservingMode(organization);
  }

  activateObservingMode(organization: Organization){
    this.deactivateAllMods();
    this.activeOrganization = organization;
    this.isObservingMode = true;
  }

  activateEditingMode(){
    this.deactivateAllMods();
    this.isEditingMode = true;
  }

  activateCreatingMode(){
    this.deactivateAllMods();
    this.isCreatingMode = true;
  }

  activateInitialMode(){
    this.deactivateAllMods()
    this.isInitialMode = true;
    this.activeOrganization = {
      organizationType: OrganizationType.Private,
      id: '',
      name: '',
      phoneNumber: ''
    };
    this.updateOrganizationList();
  }

  deactivateAllMods(){
    this.isObservingMode = false;
    this.isEditingMode = false;
    this.isCreatingMode = false;
    this.isInitialMode = false;
  }

  updateOrganizationList(){
    this.organizations$ = this.organizationService.getAll();
  }

  createOrganization(organization: Organization): void {
    const inputOrganization: InputOrganization = {
      name: organization.name,
      phoneNumber: organization.phoneNumber,
      comments: organization.comments,
      organizationType: organization.organizationType,
      email: organization.email
    };
    this.organizationService.create(inputOrganization).subscribe(() => {
      this.organizations$ = this.organizationService.getAll();
    });
    this.activateInitialMode();
  }

  updateOrganization(organization: Organization): void {
    this.organizationService.update(organization).subscribe(() => {
      this.organizations$ = this.organizationService.getAll();
    });
    this.activateObservingMode(organization);
  }

  deleteOrganization(id: string): void {
    this.organizationService.delete(id).subscribe(() => {
      this.organizations$ = this.organizationService.getAll();
    });
    this.activateInitialMode();
  }
}