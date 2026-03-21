# EduLearn - Course Management SPA

## Project Overview
A Single Page Application built with Angular for managing courses.
It demonstrates Property Binding, Event Binding, and Two-Way Binding.

---

## Project Structure
```
edulearn/
├── src/
│   └── app/
│       ├── components/
│       │   ├── course-list/
│       │   │   ├── course-list.ts
│       │   │   ├── course-list.html
│       │   │   └── course-list.css
│       │   └── course-detail/
│       │       ├── course-detail.ts
│       │       ├── course-detail.html
│       │       └── course-detail.css
│       ├── app.ts
│       ├── app.html
│       └── app.module.ts
├── package.json
└── angular.json
```

---

## Steps to Install and Run

### 1. Install Dependencies
```
npm install
```

### 2. Run the Application
```
ng serve
```

### 3. Open in Browser
```
http://localhost:4200
```

---

## Data Binding Usage

### Property Binding
Used in `course-list.html` to pass the selected course from
CourseListComponent down to CourseDetailComponent.
```
[course]="selectedCourse"
```

### Event Binding
Used in `course-list.html` to capture the "View Details"
button click and update the selected course.
```
(click)="onViewDetails(course)"
```

### Two-Way Binding
Used in `course-detail.html` to allow real-time editing
of the course title with changes reflected instantly in the UI.
```
[(ngModel)]="editableCourse.title"
```

---

## Technologies Used
- Angular (NgModule architecture)
- TypeScript
- HTML & CSS