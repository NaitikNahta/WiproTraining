import { Component } from '@angular/core';

@Component({
  selector: 'app-course-list',
  standalone: false,
  templateUrl: './course-list.html',
  styleUrls: ['./course-list.css']
})
export class CourseList {
  courses = [
    { id: 1, title: 'Angular Basics', duration: '4 weeks', instructor: 'John Doe' },
    { id: 2, title: 'TypeScript Essentials', duration: '3 weeks', instructor: 'Jane Smith' },
    { id: 3, title: 'Node.js Fundamentals', duration: '5 weeks', instructor: 'Bob Martin' }
  ];

  selectedCourse: any = null;

  onViewDetails(course: any) {
    this.selectedCourse = { ...course };
  }
}