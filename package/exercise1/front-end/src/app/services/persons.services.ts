import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Person, PersonAstronaut, GetAllPeopleResponse, GetPersonResponse } from "../../../models";

@Injectable({
  providedIn: 'root'
})
export class PersonsService {

  public readonly baseUrl: string = 'http://localhost:5204/person';

  constructor(
    private readonly http: HttpClient
  ) {

  }

  /**
   * Returns a list of all items in the database
   */
  public async getAllPeople(): Promise<PersonAstronaut[]> {
    return new Promise<PersonAstronaut[]>((resolve, reject) =>
      this.http.get<GetAllPeopleResponse>(this.baseUrl)
        .subscribe({
          next: (response) => resolve(response.people),
          error: (error: Error) => reject(error)
        })
    );
  }

  /**
   * Returns a single person from the database based on the provided name
   */
  public async getPersonByName(person: Person): Promise<PersonAstronaut> {
    let url = this.baseUrl + '/get';

    return new Promise<PersonAstronaut>((resolve, reject) =>
      this.http.post<GetPersonResponse>(url, 
        JSON.stringify(person.name),
        { headers: { 'Content-Type': 'application/json' } })
        .subscribe({
          next: (response: GetPersonResponse) => resolve(response.person),
          error: (error: Error) => reject(error)
        })
    );
  }

}