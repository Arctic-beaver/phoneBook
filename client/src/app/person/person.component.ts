import { Component, OnInit } from '@angular/core';
import { Person } from '../models/person';
import { PersonService } from '../services/personService';
import { Observable } from 'rxjs';
import { Gender } from '../models/gender';

@Component({
  selector: 'app-person',
  templateUrl: './person.component.html',
  styleUrls: ['./person.component.css']
})
export class PersonComponent implements OnInit {

  persons$: Observable<Person[]> = this.personService.getAll();
  Gender = Gender;

  constructor(private personService: PersonService) {}

  ngOnInit(): void {
    this.persons$ = this.personService.getAll();
  }

  onRowClick(person: Person) {
    // В этом методе вы можете выполнить действия при клике на строку
    console.log('Clicked on row with index:', person.id);
  }

  // Метод для создания нового человека
  createPerson(person: Person): void {
    this.personService.create(person).subscribe(() => {
      // Обновляем коллекцию людей после успешного создания нового человека
      this.persons$ = this.personService.getAll();
    });
  }

  // Метод для обновления существующего человека
  updatePerson(person: Person): void {
    this.personService.update(person).subscribe(() => {
      // Обновляем коллекцию людей после успешного обновления существующего человека
      this.persons$ = this.personService.getAll();
    });
  }

  // Метод для удаления человека
  deletePerson(id: string): void {
    this.personService.delete(id).subscribe(() => {
      // Обновляем коллекцию людей после успешного удаления человека
      this.persons$ = this.personService.getAll();
    });
  }
}