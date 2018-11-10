import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { WorkshopAddComponent } from './workshop-add.component';

describe('WorkshopAddComponent', () => {
  let component: WorkshopAddComponent;
  let fixture: ComponentFixture<WorkshopAddComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ WorkshopAddComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(WorkshopAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
