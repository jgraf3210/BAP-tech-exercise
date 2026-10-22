import {
  MAT_DIALOG_DATA,
  MatDialogRef
} from '@angular/material/dialog';
import { Component, inject, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DutyService } from '../../../services/duty.service';
import { AstronautDuty } from '../../../../../models';

@Component({
  selector: 'app-person-duty-dialog',
  templateUrl: './view-person-duty-dialog.component.html',
  styleUrls: ['./view-person-duty-dialog.component.scss'],
  imports: [
    CommonModule
]
})
export class ViewPersonDutyDialogComponent implements OnInit {
 
  public title: string = '';
  public dutyService = inject(DutyService)
  public duties = signal<AstronautDuty[]>([])
  public data: {
    name:string
  } = inject(MAT_DIALOG_DATA);
  readonly dialogRef = inject(MatDialogRef<ViewPersonDutyDialogComponent>);

  constructor() {
    this.title = `${this.data.name} duties`
  }

  async ngOnInit(): Promise<void> {
    this.duties.set(await this.dutyService.getAstronautDutyByPersonName(this.data.name));
  }

}