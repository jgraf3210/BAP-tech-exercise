import { Component, inject, OnInit } from "@angular/core";
import { MatProgressBarModule } from "@angular/material/progress-bar";
import { CommonModule } from '@angular/common';
import { Person } from "../../../../models";
import { PersonsService } from "../../services/persons.services";


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss',
  imports: [
    MatProgressBarModule,
    CommonModule
]
})
export class HomeComponent implements OnInit{

  public personsService = inject(PersonsService)
  public persons: Person[] = []
  public title = 'Home page'
  
  ngOnInit(): void {
    this.personsService.getAllPeople().then(persons => {
      this.persons = persons;
    });
  }

  calculateProgress(startDate: Date, endDate: Date): number {
    const now = new Date().getTime();
    const start = new Date(startDate).getTime();
    const end = new Date(endDate).getTime();
    const elapsed = now - start;
    const total = end - start;
    return Math.min((elapsed / total) * 100, 100); // Ensure it doesn't exceed 100%
  }

}