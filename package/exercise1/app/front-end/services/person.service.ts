import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core';
import { AstronautDuty, Person } from '../models';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  constructor(private readonly http: HttpClient) {

  }

  /**
   * Returns all Persons in the database
   */
  public async getAllPersons(): Promise<Person[]> {
    let url = '/person/getAll';
    return new Promise<Person[]>((resolve, reject) =>
      this.http.get<Person[]>(url)
        .subscribe({
          next: (persons: Person[]) => resolve(persons),
          error: (error: Error) => reject(error)
        })
    );
  }


  /**
   * Retreives a person by the person's name.
   */
  public async getPersonByName(person: Person): Promise<Person> {
    let url = '/person/get';
    return new Promise<Person>((resolve, reject) =>
      this.http.get<Person>(url)
        .subscribe({
          next: (person: Person) => resolve(person),
          error: (error: Error) => reject(error)
        })
    );
  }


  /**
   * Creates a person
   * @param person The person to create
   */
  public async createPerson(person: Person): Promise<Person> {
    let url = '/person/get';
    return new Promise<Person>((resolve, reject) =>
      this.http.post<Person>(url, person)
        .subscribe({
          next: (result: Person) => resolve(result),
          error: (error: Error) => reject(error)
        })
    );
  }

  /**
   * Updates a person by the person's name.
   */
    public async updatePerson(person: Person): Promise<Person> {
      let url = '/person/get';
      return new Promise<Person>((resolve, reject) =>
        this.http.put<Person>(url, person)
          .subscribe({
            next: (result: Person) => resolve(result),
            error: (error: Error) => reject(error)
          })
      );
    }

}