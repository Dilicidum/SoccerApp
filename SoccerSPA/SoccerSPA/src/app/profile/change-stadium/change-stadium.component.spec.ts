import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangeStadiumComponent } from './change-stadium.component';

describe('ChangeStadiumComponent', () => {
  let component: ChangeStadiumComponent;
  let fixture: ComponentFixture<ChangeStadiumComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ChangeStadiumComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ChangeStadiumComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
