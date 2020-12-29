import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileNavMenuComponent } from './profile-nav-menu.component';

describe('ProfileNavMenuComponent', () => {
  let component: ProfileNavMenuComponent;
  let fixture: ComponentFixture<ProfileNavMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfileNavMenuComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileNavMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
