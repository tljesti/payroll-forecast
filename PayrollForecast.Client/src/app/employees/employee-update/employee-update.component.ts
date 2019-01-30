import { Component, OnInit, OnDestroy } from '@angular/core';
import { EmployeeService } from '../shared/employee.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';

import { Employee } from '../shared/employee.model';
import { EmployeeForUpdate } from '../shared/employee-for-update.model';

@Component({
  selector: 'app-employee-update',
  templateUrl: './employee-update.component.html',
  styleUrls: ['./employee-update.component.scss']
})
export class EmployeeUpdateComponent implements OnInit, OnDestroy {

  public employeeForm: FormGroup;
  private employee: Employee;
  private employeeId: string;
  private sub: Subscription;

  constructor(private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.employeeForm = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.maxLength(30)]],
      lastName: ['', [Validators.required, Validators.maxLength(30)]]
    });

    this.sub = this.route.params.subscribe(
      params => {
        this.employeeId = params['employeeId'];

        this.employeeService.getEmployee(this.employeeId)
          .subscribe(employee => {
            this.employee = employee;
            this.updateEmployeeForm();
          });
      }
    );
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  private updateEmployeeForm(): void {
    this.employeeForm.patchValue({
      firstName: this.employee.firstName,
      lastName: this.employee.lastName      
    });
  }

  saveEmployee(): void {
    if (this.employeeForm.dirty && this.employeeForm.valid) {
      let changedEmployeeForUpdate = automapper.map('EmployeeFormModel', 'EmployeeForUpdate', this.employeeForm.value);
      changedEmployeeForUpdate.id = this.employeeId;

      this.employeeService.updateEmployee(changedEmployeeForUpdate)
      .subscribe(
        () => {
          this.router.navigateByUrl(`/employees/${this.employeeId}`);
        }
      );
    }
  }

}
