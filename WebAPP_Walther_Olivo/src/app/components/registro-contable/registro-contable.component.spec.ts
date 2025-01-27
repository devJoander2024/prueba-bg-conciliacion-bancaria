import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegistroContableComponent } from './registro-contable.component';

describe('RegistroContableComponent', () => {
  let component: RegistroContableComponent;
  let fixture: ComponentFixture<RegistroContableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RegistroContableComponent]
    });
    fixture = TestBed.createComponent(RegistroContableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
