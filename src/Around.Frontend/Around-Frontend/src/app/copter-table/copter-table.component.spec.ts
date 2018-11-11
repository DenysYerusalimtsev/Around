import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CopterTableComponent } from './copter-table.component';

describe('CopterTableComponent', () => {
  let component: CopterTableComponent;
  let fixture: ComponentFixture<CopterTableComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CopterTableComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CopterTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
