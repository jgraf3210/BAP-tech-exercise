import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AstronautDuty, GetAstronautDutyByPersonNameResponse } from "../../../models";

@Injectable({
  providedIn: 'root'
})
export class DutyService {

  public readonly baseUrl: string = 'http://localhost:5204/astronautDuty';
  constructor(private readonly http: HttpClient) {

  }

  /**
   * Returns a list of all the duties for the selected astronaut
   */
  public getAstronautDutyByPersonName(name: string): Promise<AstronautDuty[]> {
    let url = this.baseUrl + '/get'
    return new Promise<AstronautDuty[]>((resolve, reject) =>
      this.http.post<GetAstronautDutyByPersonNameResponse>(
        url,
        JSON.stringify(name),
        { headers: { 'Content-Type': 'application/json' } }
      )
        .subscribe({
          next: (response) => resolve(response.astronautDuties),
          error: (error: Error) => reject(error)
        })
    );
  }

}