import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogCopterComponent } from './dialog-copter.component';

describe('DialogCopterComponent', () => {
  let component: DialogCopterComponent;
  let fixture: ComponentFixture<DialogCopterComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogCopterComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogCopterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
