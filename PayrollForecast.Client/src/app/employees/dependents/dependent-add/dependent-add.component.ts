import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { EmployeeService } from '../../shared/employee.service';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Employee } from '../../shared/employee.model';

@Component({
  selector: 'app-dependent-add',
  templateUrl: './dependent-add.component.html',
  styleUrls: ['./dependent-add.component.scss']
})
export class DependentAddComponent implements OnInit {
  public dependentForm: FormGroup;
  private employeeId: string;
  private employee: Employee;
  private sub: Subscription;

  constructor(private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router,
    private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.dependentForm = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.maxLength(30)]],
      lastName: ['', [Validators.required, Validators.maxLength(30)]]
    });

    this.sub = this.route.params.subscribe(
      params => {
        this.employeeId = params['employeeId'];

        this.employeeService.getEmployee(this.employeeId)
          .subscribe(employee => {
            this.employee = employee;
          });
      }
    );
  }

  addDependent(): void {
    let dependent = automapper.map('DependentFormModel', 'DependentForCreation', this.dependentForm.value);
    this.employeeService.addDependent(this.employeeId, dependent)
      .subscribe(
        () => {
          this.router.navigateByUrl(`/employees/${this.employeeId}`);
        }
      );
  }  

}
