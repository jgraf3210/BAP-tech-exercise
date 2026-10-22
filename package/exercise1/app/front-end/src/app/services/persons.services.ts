import { HttpClient, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Person } from "../../../models";

@Injectable({
  providedIn: 'root'
})
export class PersonsService {

  public readonly baseUrl: string = 'http://localhost:5204/api/person';

  constructor(private readonly http: HttpClient) {

  }

  /**
   * Returns a list of all items in the database
   */
  public async getAllPeople(): Promise<Person[]> {
    
    return new Promise<Person[]>((resolve, reject) =>
      this.http.get<Person[]>(this.baseUrl)
        .subscribe({
          next: (items: Person[]) => resolve(items),
          error: (error: Error) => reject(error)
        })
    );
  }

  /**
   * Returns a single person from the database based on the provided name
   */
  public async getPersonByName(person: Person): Promise<Person> {
    let url = this.baseUrl + '/get';

    return new Promise<Person>((resolve, reject) =>
      this.http.post<Person>(url, { body: person })
        .subscribe({
          next: (items: Person) => resolve(items),
          error: (error: Error) => reject(error)
        })
    );
  }

}