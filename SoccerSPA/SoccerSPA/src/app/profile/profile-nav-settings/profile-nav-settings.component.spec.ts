import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileNavSettingsComponent } from './profile-nav-settings.component';

describe('ProfileNavSettingsComponent', () => {
  let component: ProfileNavSettingsComponent;
  let fixture: ComponentFixture<ProfileNavSettingsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProfileNavSettingsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileNavSettingsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
