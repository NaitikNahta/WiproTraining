import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FavHobbies } from './fav-hobbies';

describe('FavHobbies', () => {
  let component: FavHobbies;
  let fixture: ComponentFixture<FavHobbies>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FavHobbies],
    }).compileComponents();

    fixture = TestBed.createComponent(FavHobbies);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
