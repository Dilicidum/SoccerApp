import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllplayersComponent } from './allplayers.component';

describe('AllplayersComponent', () => {
  let component: AllplayersComponent;
  let fixture: ComponentFixture<AllplayersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AllplayersComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AllplayersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
