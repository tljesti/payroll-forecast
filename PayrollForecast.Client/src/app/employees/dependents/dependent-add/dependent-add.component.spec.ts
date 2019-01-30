import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DependentAddComponent } from './dependent-add.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatInputModule, MatIconModule } from '@angular/material';
import { AppRoutingModule } from 'src/app/app-routing.module';

describe('DependentAddComponent', () => {
  let component: DependentAddComponent;
  let fixture: ComponentFixture<DependentAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DependentAddComponent ],
      imports: [ ReactiveFormsModule, MatInputModule, MatIconModule, AppRoutingModule ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DependentAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
