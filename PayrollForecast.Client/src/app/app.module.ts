import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule, MatButtonModule, MatFormFieldModule, MatInputModule, MatIconModule, MatListModule, MatSortModule } from '@angular/material';
import { FlexLayoutModule } from '@angular/flex-layout';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeesComponent } from './employees/employees.component';
import { EmployeeService } from './employees/shared/employee.service';
import { HttpClientModule } from '@angular/common/http';
import { EmployeeAddComponent } from './employees/employee-add/employee-add.component';
import { EmployeeUpdateComponent } from './employees/employee-update/employee-update.component';
import { DependentsComponent } from './employees/dependents/dependents.component';
import { EmployeeDetailComponent } from './employees/employee-detail/employee-detail.component';
import { DependentAddComponent } from './employees/dependents/dependent-add/dependent-add.component';
import { DependentDetailComponent } from './employees/dependents/dependent-detail/dependent-detail.component';
import { DependentUpdateComponent } from './employees/dependents/dependent-update/dependent-update.component';

@NgModule({
  declarations: [
    AppComponent,
    EmployeesComponent,
    EmployeeAddComponent,
    EmployeeUpdateComponent,
    DependentsComponent,
    EmployeeDetailComponent,
    DependentAddComponent,
    DependentDetailComponent,
    DependentUpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FlexLayoutModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatSortModule,
    MatTableModule,
    ReactiveFormsModule
  ],
  providers: [
    EmployeeService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { 
  constructor() {
    automapper.createMap('EmployeeFormModel', 'EmployeeForCreation');
    automapper.createMap('EmployeeFormModel', 'EmployeeForUpdate');
    automapper.createMap('DependentFormModel', 'DependentForCreation');
    automapper.createMap('DependentFormModel', 'DependentForUpdate');
  }
}
