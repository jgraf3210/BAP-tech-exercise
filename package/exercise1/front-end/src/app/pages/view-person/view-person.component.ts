import { CommonModule } from "@angular/common";
import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { PersonAstronaut } from "../../../../models";


@Component({
  selector: 'app-view-person',
  templateUrl: './view-person.component.html',
  styleUrl: './view-person.component.scss',
  imports: [
    CommonModule
]
})
export class ViewPersonComponent implements OnInit {
  public person: PersonAstronaut | null = null;

  public title = 'View Person Duties';

  constructor(private readonly router: Router) {}
  
  ngOnInit(): void {
    const navigationState = this.router.currentNavigation();
    const person = navigationState?.extras?.state;

    if (this.isPersonAstronaut(person)) {
      this.person = person;
    }
  }

  private isPersonAstronaut(value: unknown): value is PersonAstronaut {
    return typeof value === 'object'
      && value !== null
      && 'personId' in value
      && typeof value.personId === 'number'
      && 'name' in value
      && typeof value.name === 'string';
  }
}
