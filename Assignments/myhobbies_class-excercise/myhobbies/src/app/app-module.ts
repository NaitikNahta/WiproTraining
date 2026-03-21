import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { App } from './app';
import { Menu } from './components/menu/menu';
import { Home } from './components/home/home';
import { MyHobbies } from './components/my-hobbies/my-hobbies';
import { NewHobby } from './components/new-hobby/new-hobby';
import { FavHobbies } from './components/fav-hobbies/fav-hobbies';

@NgModule({
  declarations: [
    App,
    Menu,
    Home,
    MyHobbies,
    NewHobby,
    FavHobbies
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule
  ],
  bootstrap: [App]
})
export class AppModule { }
