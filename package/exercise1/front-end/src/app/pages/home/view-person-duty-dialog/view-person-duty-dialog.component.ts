import {
  MAT_DIALOG_DATA,
  MatDialogRef
} from '@angular/material/dialog';
import { PersonAstronaut } from '../../../../../models';
import { inject } from '@angular/core';

export class ViewPersonDutyDialogComponent {
 
  public title: string = '';
  public data: PersonAstronaut = inject(MAT_DIALOG_DATA);
  readonly dialogRef = inject(MatDialogRef<ViewPersonDutyDialogComponent>);

  constructor() {

  }



}