import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { App } from './app';
import { CourseList } from './components/course-list/course-list';
import { CourseDetail } from './components/course-detail/course-detail';

@NgModule({
  declarations: [App, CourseList, CourseDetail],
  imports: [BrowserModule, FormsModule],
  providers: [provideBrowserGlobalErrorListeners()],
  bootstrap: [App],
})
export class AppModule {}
