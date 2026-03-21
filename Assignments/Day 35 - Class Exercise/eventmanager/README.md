# Eventmanager

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 21.2.3.

# Event Management Portal

## Description
An Angular SPA that displays upcoming events with custom pipe formatting
and directive-based premium event highlighting.

## Installation & Run
npm install
ng serve

## Implemented Features

### Custom Pipe (PriceFormatPipe)
Formats ticket prices to Indian currency format.
Example: 3500 → ₹3,500.00

### Custom Directive (HighlightDirective)
Automatically highlights premium events (price above ₹2000)
with a light gold background and gold left border.

### Animation
Hover animation on table rows using CSS transform scale transition.