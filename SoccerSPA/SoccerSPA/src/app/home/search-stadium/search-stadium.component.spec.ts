import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchStadiumComponent } from './search-stadium.component';

describe('SearchStadiumComponent', () => {
  let component: SearchStadiumComponent;
  let fixture: ComponentFixture<SearchStadiumComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchStadiumComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchStadiumComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
