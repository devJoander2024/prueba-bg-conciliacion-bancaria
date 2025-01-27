import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MovimientoBancarioComponent } from './movimiento-bancario.component';

describe('MovimientoBancarioComponent', () => {
  let component: MovimientoBancarioComponent;
  let fixture: ComponentFixture<MovimientoBancarioComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MovimientoBancarioComponent]
    });
    fixture = TestBed.createComponent(MovimientoBancarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
