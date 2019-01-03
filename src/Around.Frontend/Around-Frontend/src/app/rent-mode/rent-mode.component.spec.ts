import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RentModeComponent } from './rent-mode.component';

describe('RentModeComponent', () => {
  let component: RentModeComponent;
  let fixture: ComponentFixture<RentModeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RentModeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RentModeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
