import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule } from '@angular/forms';
import { OrganizationComponent } from './organization/organization.component';
import { PersonComponent } from './person/person.component';
import { PersonService } from './services/personService';
import { OrganizationService } from './services/organizationService';
import { EnumToStringPipe } from './pipes/enumToStringPipe';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    OrganizationComponent,
    PersonComponent,
    EnumToStringPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [
    PersonService,
    OrganizationService
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
