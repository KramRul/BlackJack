import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ForLoggedPlayersMenuComponent } from './for-logged-players-menu.component';

describe('ForLoggedPlayersMenuComponent', () => {
  let component: ForLoggedPlayersMenuComponent;
  let fixture: ComponentFixture<ForLoggedPlayersMenuComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ForLoggedPlayersMenuComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ForLoggedPlayersMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
