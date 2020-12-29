import { Component, OnInit , Input } from '@angular/core';
import { FormControl } from '@angular/forms';
@Component({
  selector: 'app-validate-helper',
  templateUrl: './validate-helper.component.html',
  styleUrls: ['./validate-helper.component.css']
})
export class ValidateHelperComponent implements OnInit {
  @Input('name')formControl:FormControl
  constructor() { }

  ngOnInit(): void {
  }

}
