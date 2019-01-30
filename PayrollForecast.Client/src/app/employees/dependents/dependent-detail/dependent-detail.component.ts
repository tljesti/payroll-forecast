import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Dependent } from '../shared/dependent.model';
import { DependentService } from '../shared/dependent.service';

@Component({
  selector: 'app-dependent-detail',
  templateUrl: './dependent-detail.component.html',
  styleUrls: ['./dependent-detail.component.scss']
})
export class DependentDetailComponent implements OnInit, OnDestroy {
  
  private dependent: Dependent;
  private employeeId: string;
  private dependentId: string;
  private sub: Subscription;

  constructor(private dependentService: DependentService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(
      params => {
        this.employeeId = params['employeeId'];
        this.dependentId = params['dependentId'];

        this.dependentService.getDependent(this.employeeId, this.dependentId)
          .subscribe(dependent => {
            this.dependent = dependent;
          });
      }
    );
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }

  removeDependent(): void {
    this.dependentService.removeDependent(this.employeeId, this.dependentId)
    .subscribe(
      () => {
        this.router.navigateByUrl(`/employees/${this.employeeId}`);
      }
    );

  }

}
