import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Subscription } from 'rxjs';

import { Dependent } from '../shared/dependent.model';
import { DependentService } from '../shared/dependent.service';
@Component({
  selector: 'app-dependent-update',
  templateUrl: './dependent-update.component.html',
  styleUrls: ['./dependent-update.component.scss']
})
export class DependentUpdateComponent implements OnInit, OnDestroy {
  public dependentForm: FormGroup;
  private dependent: Dependent;
  private employeeId: string;
  private dependentId: string;
  private sub: Subscription;

  constructor(private dependentService: DependentService,
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
        this.dependentId = params['dependentId'];

        this.dependentService.getDependent(this.employeeId, this.dependentId)
          .subscribe(dependent => {
            this.dependent = dependent;
            this.updateDependentForm();
          });
      }
    );
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  private updateDependentForm(): void {
    this.dependentForm.patchValue({
      firstName: this.dependent.firstName,
      lastName: this.dependent.lastName      
    });
  }

  saveDependent(): void {
    if (this.dependentForm.dirty && this.dependentForm.valid) {
      let changedDependentForUpdate = automapper.map('DependentFormModel', 'DependentForUpdate', this.dependentForm.value);
      changedDependentForUpdate.id = this.dependentId;
      changedDependentForUpdate.employeeId = this.employeeId;

      this.dependentService.updateDependent(changedDependentForUpdate)
      .subscribe(
        () => {
          this.router.navigateByUrl(`/employees/${this.employeeId}/dependents/${this.dependentId}`);
        }
      );
    }
  }

}