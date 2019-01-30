import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/shared/base.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Dependent } from './dependent.model';
import { DependentForUpdate } from './dependent-for-update';

@Injectable({
  providedIn: 'root'
})
export class DependentService extends BaseService {

  constructor(private http: HttpClient) { 
    super();
  }

  getDependent(employeeId: string, dependentId: string): Observable<Dependent> {
    return this.http.get<Dependent>(`${this.apiUrl}/employees/${employeeId}/dependents/${dependentId}`)
  }

  updateDependent(dependentToUpdate: DependentForUpdate): Observable<any> {
    return this.http.put(`${this.apiUrl}/employees/${dependentToUpdate.employeeId}/dependents/${dependentToUpdate.id}`, dependentToUpdate);
  }

  removeDependent(employeeId: string, dependentId: string): Observable<any> {
    return this.http.delete(`${this.apiUrl}/employees/${employeeId}/dependents/${dependentId}`);
  }
}
