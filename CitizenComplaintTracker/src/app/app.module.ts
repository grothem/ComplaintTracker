import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { DialogModule } from 'primeng/primeng';
import { DataTableModule } from 'primeng/primeng';

import { AppComponent } from './app.component';
import { ComplaintService } from './complaint.service';
import { ComplaintsComponent } from './complaints/complaints.component';
import { HeaderComponent } from'./header/header.component';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ComplaintsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    DialogModule,
    BrowserAnimationsModule,
    DataTableModule
  ],
  providers: [ComplaintService],
  bootstrap: [AppComponent]
})
export class AppModule { }
