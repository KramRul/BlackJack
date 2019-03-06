import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ForNonLoggedPlayersMenuComponent } from './for-non-logged-players-menu.component';

describe('ForNonLoggedPlayersMenuComponent', () => {
  let component: ForNonLoggedPlayersMenuComponent;
  let fixture: ComponentFixture<ForNonLoggedPlayersMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ForNonLoggedPlayersMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ForNonLoggedPlayersMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
