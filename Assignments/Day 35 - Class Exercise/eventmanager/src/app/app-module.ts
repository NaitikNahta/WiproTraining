import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { App } from './app';
import { EventList } from './components/event-list/event-list';
import { PriceFormatPipe } from './pipes/price-format-pipe';
import { HighlightDirective } from './directives/highlight';

@NgModule({
  declarations: [App, EventList, PriceFormatPipe, HighlightDirective],
  imports: [BrowserModule],
  providers: [provideBrowserGlobalErrorListeners()],
  bootstrap: [App],
})
export class AppModule {}
