import { CommonModule } from "@angular/common";
import { Component, OnInit } from "@angular/core";


@Component({
  selector: 'app-view-person',
  templateUrl: './view-person.component.html',
  styleUrl: './view-person.component.scss',
  imports: [
    CommonModule
]
})
export class ViewPersonComponent implements OnInit {
  
  
  ngOnInit(): void {
    throw new Error("Method not implemented.");
  }

}
