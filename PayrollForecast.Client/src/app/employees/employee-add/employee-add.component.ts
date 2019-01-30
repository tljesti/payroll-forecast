import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EmployeeService } from '../shared/employee.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-employee-add',
  templateUrl: './employee-add.component.html',
  styleUrls: ['./employee-add.component.scss']
})
export class EmployeeAddComponent implements OnInit {    
  public employeeForm: FormGroup;

  constructor(
    private employeeService: EmployeeService, 
    private formBuilder: FormBuilder,
    private router: Router
  ) { }

  ngOnInit() {
    this.employeeForm = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.maxLength(30)]],
      lastName: ['', [Validators.required, Validators.maxLength(30)]]
    });
  }

  addEmployee(): void {
    let employee = automapper.map('EmployeeFormModel', 'EmployeeForCreation', this.employeeForm.value);
    this.employeeService.addEmployee(employee)
      .subscribe(
        () => {
          this.router.navigateByUrl('/employees');
        }
      );
  }  

}
