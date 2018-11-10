import { TestBed } from '@angular/core/testing';

import { RequireAuthenticateUserGuardService } from './require-authenticate-user-guard.service';

describe('RequireAuthenticateUserGuardService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RequireAuthenticateUserGuardService = TestBed.get(RequireAuthenticateUserGuardService);
    expect(service).toBeTruthy();
  });
});
