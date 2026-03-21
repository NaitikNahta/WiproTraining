import { Component, Input, Output, EventEmitter, OnChanges } from '@angular/core';

@Component({
  selector: 'app-course-detail',
  standalone: false,
  templateUrl: './course-detail.html',
  styleUrls: ['./course-detail.css']
})
export class CourseDetail implements OnChanges {
  @Input() course: any = null;
  @Output() titleChanged = new EventEmitter<any>();

  editableCourse: any = null;

  ngOnChanges() {
    if (this.course) {
      this.editableCourse = { ...this.course };
    }
  }

  onTitleChange() {
    this.titleChanged.emit(this.editableCourse);
  }
}