import { Component, OnInit, ViewChild } from '@angular/core';

import { Employee } from './shared/employee.model';
import { EmployeeService } from './shared/employee.service';
import { MatSort, MatTableDataSource } from '@angular/material';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.scss']
})
export class EmployeesComponent implements OnInit {

  displayedColumns: string[] = ['firstName', 'lastName', 'yearlyPayment'];
  employees: Employee[] = [];
  dataSource = new MatTableDataSource<Employee>(this.employees);

  @ViewChild(MatSort) sort: MatSort;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.employeeService.getEmployees().subscribe(employees => {
      this.dataSource.data = employees;
      this.dataSource.sort = this.sort;
    });
  }
}
