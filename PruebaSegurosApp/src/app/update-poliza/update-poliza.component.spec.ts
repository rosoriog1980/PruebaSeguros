import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatePolizaComponent } from './update-poliza.component';

describe('UpdatePolizaComponent', () => {
  let component: UpdatePolizaComponent;
  let fixture: ComponentFixture<UpdatePolizaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UpdatePolizaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UpdatePolizaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
