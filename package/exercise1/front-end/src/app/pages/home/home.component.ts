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
  public persons = signal<PersonAstronaut[]>([])
  public title = 'Home page'

  constructor(
    private readonly dialog: MatDialog
  ){

  }
  
  async ngOnInit(): Promise<void> {
    this.persons.set(await this.personsService.getAllPeople());
  }

  /**
   * Opens a dialog to edit the selected Item
   * @param item The Item to edit
   */
  public openPersonDialog(person: PersonAstronaut) {
    this.dialog.open(
      ViewPersonDutyDialogComponent, {
      maxHeight: '60vh',
      data: {
        name: person.name
      },
    }).afterClosed().subscribe()
  }


}