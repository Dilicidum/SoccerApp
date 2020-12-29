import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ValidateHelperComponent } from './validate-helper.component';

describe('ValidateHelperComponent', () => {
  let component: ValidateHelperComponent;
  let fixture: ComponentFixture<ValidateHelperComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ValidateHelperComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ValidateHelperComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
