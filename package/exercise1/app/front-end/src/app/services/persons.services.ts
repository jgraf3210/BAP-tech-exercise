import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Person } from "../../../models";

@Injectable({
  providedIn: 'root'
})
export class PersonsService {

  public readonly baseUrl = 'http://localhost:5204/api/persons';

  constructor(private readonly http: HttpClient) {

  }

  /**
   * Returns a list of all items in the database
   */
  public async getAllPeople(): Promise<Person[]> {
    let url = '';

    return new Promise<Person[]>((resolve, reject) =>
      this.http.get<Person[]>(url)
        .subscribe({
          next: (items: Person[]) => resolve(items),
          error: (error: Error) => reject(error)
        })
    );
  }


}