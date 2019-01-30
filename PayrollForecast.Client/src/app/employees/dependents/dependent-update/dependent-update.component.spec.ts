import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DependentUpdateComponent } from './dependent-update.component';

describe('DependentUpdateComponent', () => {
  let component: DependentUpdateComponent;
  let fixture: ComponentFixture<DependentUpdateComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DependentUpdateComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DependentUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
