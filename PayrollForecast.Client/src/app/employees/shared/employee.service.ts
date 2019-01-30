import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/shared/base.service';
import { HttpClient } from '@angular/common/http';
import { Employee } from './employee.model';
import { Observable } from 'rxjs';
import { EmployeeForCreation } from './employee-for-creation.model';
import { EmployeeForUpdate } from './employee-for-update.model';
import { DependentForCreation } from '../dependents/shared/dependent-for-creation';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService extends BaseService {

  constructor(private http: HttpClient) { 
    super();
  }

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.apiUrl}/employees`);
  }

  getEmployee(employeeId: string): Observable<Employee> {
    return this.http.get<Employee>(`${this.apiUrl}/employees/${employeeId}`)
  }

  addEmployee(employeeToAdd: EmployeeForCreation): Observable<Employee> {
    return this.http.post<Employee>(`${this.apiUrl}/employees`, employeeToAdd);
  }

  updateEmployee(employeeToUpdate: EmployeeForUpdate): Observable<any> {
    return this.http.put(`${this.apiUrl}/employees/${employeeToUpdate.id}`, employeeToUpdate);
  }

  addDependent(employeeId: string, dependentToAdd: DependentForCreation): any {
    return this.http.post(`${this.apiUrl}/employees/${employeeId}/dependents`, dependentToAdd);
  }

  removeEmployee(employeeId: string): any {
    return this.http.delete(`${this.apiUrl}/employees/${employeeId}`);
  }

}
