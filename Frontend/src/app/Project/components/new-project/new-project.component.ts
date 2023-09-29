import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-new-project',
  templateUrl: './new-project.component.html',
  styleUrls: ['./new-project.component.scss']
})
export class NewProjectComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  submitted = false

  onSubmit() {
    this.submitted = true

    newProjectForm: FormGroup;
}

}
