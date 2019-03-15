import { TestBed, async, inject } from '@angular/core/testing';

import { NonLoggedGuard } from './non-logged.guard';

describe('NonLoggedGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [NonLoggedGuard]
    });
  });

  it('should ...', inject([NonLoggedGuard], (guard: NonLoggedGuard) => {
    expect(guard).toBeTruthy();
  }));
});
