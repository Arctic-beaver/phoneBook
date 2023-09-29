import { Component, OnInit } from '@angular/core';
import { Person } from '../models/person';
import { PersonService } from '../services/personService';
import { Observable } from 'rxjs';
import { Gender } from '../models/gender';
import { InputPerson } from '../models/inputPerson';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  persons$: Observable<Person[]> = this.personService.getAll();
  Gender = Gender;
  isObservingMode = false;
  isCreatingMode = false;
  isEditingMode = false;
  isInitialMode = true;
  activePerson: Person = {
    id: '',
    name: '',
    phoneNumber: '',
    gender: 0
  };

  constructor(private personService: PersonService) {}

  ngOnInit(): void {
    this.updatePersonList()
  }

  onRowClick(person: Person) {
    console.log('Clicked on row with index:', person.id);
    this.activateObservingMode(person);
  }

  activateObservingMode(person: Person){
    this.deactivateAllMods();
    this.activePerson = person;
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
    this.activePerson = {
      id: '',
      name: '',
      phoneNumber: '',
      gender: 0
    };
    this.updatePersonList();
  }

  deactivateAllMods(){
    this.isObservingMode = false;
    this.isEditingMode = false;
    this.isCreatingMode = false;
    this.isInitialMode = false;
  }

  updatePersonList(){
    this.persons$ = this.personService.getAll();
  }

  createPerson(person: Person): void {
    const inputPerson: InputPerson = {
      name: person.name,
      phoneNumber: person.phoneNumber,
      comments: person.comments,
      birthDate: person.birthDate,
      gender: person.gender
    };
    this.personService.create(inputPerson).subscribe(() => {
      this.persons$ = this.personService.getAll();
    });
    this.activateInitialMode();
  }

  updatePerson(person: Person): void {
    this.personService.update(person).subscribe(() => {
      this.persons$ = this.personService.getAll();
    });
    this.activateObservingMode(person);
  }

  deletePerson(id: string): void {
    this.personService.delete(id).subscribe(() => {
      this.persons$ = this.personService.getAll();
    });
    this.activateInitialMode();
  }
}