import { TestBed } from '@angular/core/testing';

import { WorkShopService } from './work-shop.service';

describe('WorkShopService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WorkShopService = TestBed.get(WorkShopService);
    expect(service).toBeTruthy();
  });
});
