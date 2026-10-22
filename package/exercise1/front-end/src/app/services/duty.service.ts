import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { AstronautDuty, AstronautDetail } from "../../../models";

@Injectable({
  providedIn: 'root'
})
export class DutyService {

  public readonly baseUrl: string = 'http://localhost:5204/astronautDuty';

}