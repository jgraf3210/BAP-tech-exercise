import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core';
import { AstronautDuty, Person } from '../models';

@Injectable({
  providedIn: 'root'
})
export class DutyService {

  constructor(private readonly http: HttpClient) {

  }

  /**
   * Returns the duties for a person based on their name
   */
  public async getDutyByPersonName(): Promise<AstronautDuty> {
    let url = '/item/getAll';
    return new Promise<AstronautDuty>((resolve, reject) =>
      this.http.get<AstronautDuty>(url)
        .subscribe({
          next: (items: AstronautDuty) => resolve(items),
          error: (error: string) => reject(error)
        })
    );
  }


  /**
   * Adds a duty to a person
   */
  public async addDutyToPerson(person: Person, duty: AstronautDuty): Promise<AstronautDuty> {
    let url = '/item/getAll';
    return new Promise<AstronautDuty>((resolve, reject) =>
      this.http.get<AstronautDuty>(url)
        .subscribe({
          next: (items: AstronautDuty) => resolve(items),
          error: (error: string) => reject(error)
        })
    );
  }

}