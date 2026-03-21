import { Directive, ElementRef, Input, OnInit } from '@angular/core';

@Directive({
  selector: '[appHighlight]',
  standalone: false
})
export class HighlightDirective implements OnInit {
  @Input() appHighlight: number = 0;

  constructor(private el: ElementRef) {}

  ngOnInit() {
    if (this.appHighlight > 2000) {
      this.el.nativeElement.style.backgroundColor = '#fff9c4';
      this.el.nativeElement.style.borderLeft = '4px solid gold';
    }
  }
}