import { TestBed } from '@angular/core/testing';

import { UserNewService } from './user-new.service';

describe('UserNewService', () => {
  let service: UserNewService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserNewService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
