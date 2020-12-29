import { TestBed } from '@angular/core/testing';

import { MineService } from './mine.service';

describe('MineService', () => {
  let service: MineService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MineService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
