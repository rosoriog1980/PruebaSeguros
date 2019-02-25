import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PolizaDetailComponent } from './poliza-detail.component';

describe('PolizaDetailComponent', () => {
  let component: PolizaDetailComponent;
  let fixture: ComponentFixture<PolizaDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PolizaDetailComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PolizaDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
