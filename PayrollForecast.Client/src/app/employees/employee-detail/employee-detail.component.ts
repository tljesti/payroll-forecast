import { Component, OnInit, OnDestroy } from '@angular/core';
import { Employee } from '../shared/employee.model';
import { EmployeeService } from '../shared/employee.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.scss']
})
export class EmployeeDetailComponent implements OnInit, OnDestroy {
  
  private employee: Employee;
  private employeeId: string;
  private sub: Subscription;
  displayedColumns: string[] = ['firstName', 'lastName'];

  constructor(private employeeService: EmployeeService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
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

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  removeEmployee(): void {
    this.employeeService.removeEmployee(this.employeeId)
    .subscribe(
      () => {
        this.router.navigateByUrl(`/employees`);
      }
    );
  }

}
