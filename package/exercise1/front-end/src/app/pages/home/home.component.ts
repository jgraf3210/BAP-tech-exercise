import { Component, inject, OnInit, signal } from "@angular/core";
import { MatProgressBarModule } from "@angular/material/progress-bar";
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { PersonAstronaut } from "../../../../models";
import { PersonsService } from "../../services/persons.services";
import { MatDialog } from "@angular/material/dialog";
import { ViewPersonDutyDialogComponent } from "./view-person-duty-dialog/view-person-duty-dialog.component";


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
  private readonly router = inject(Router)
  public persons = signal<PersonAstronaut[]>([])
  public title = 'Home page'

  constructor(
    private readonly dialog: MatDialog
  ){

  }
  
  async ngOnInit(): Promise<void> {
    this.persons.set(await this.personsService.getAllPeople());
  }

  public viewPerson(person: PersonAstronaut): void {
    void this.router.navigate(['/view'], { state: { person } });
  }

  /**
   * Opens a dialog to edit the selected Item
   * @param item The Item to edit
   */
  public editItem(person: PersonAstronaut) {
    this.dialog.open(
      ViewPersonDutyDialogComponent, {
      data: {
        person: person
      },
    }).afterClosed().subscribe()
  }


}