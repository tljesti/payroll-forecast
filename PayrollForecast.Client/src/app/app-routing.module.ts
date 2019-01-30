import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { EmployeesComponent } from './employees/employees.component';
import { EmployeeAddComponent } from './employees/employee-add/employee-add.component';
import { EmployeeUpdateComponent } from './employees/employee-update/employee-update.component';
import { EmployeeDetailComponent } from './employees/employee-detail/employee-detail.component';
import { DependentAddComponent } from './employees/dependents/dependent-add/dependent-add.component';
import { DependentDetailComponent } from './employees/dependents/dependent-detail/dependent-detail.component';
import { DependentUpdateComponent } from './employees/dependents/dependent-update/dependent-update.component';

const routes: Routes = [
  { path: '', redirectTo: 'employees', pathMatch: 'full'},
  { path: 'employees', component: EmployeesComponent },
  { path: 'employees/:employeeId', component: EmployeeDetailComponent },
  { path: 'employee-add', component: EmployeeAddComponent },
  { path: 'employee-update/:employeeId', component: EmployeeUpdateComponent },
  { path: 'employees/:employeeId/dependent-add', component: DependentAddComponent },
  { path: 'employees/:employeeId/dependents/:dependentId', component: DependentDetailComponent },
  { path: 'employees/:employeeId/dependent-update/:dependentId', component: DependentUpdateComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
