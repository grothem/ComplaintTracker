import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { ComplaintService } from './complaint.service';
import { ComplaintsComponent } from './complaints/complaints.component';

@NgModule({
  declarations: [
    AppComponent,
    ComplaintsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule
  ],
  providers: [ComplaintService],
  bootstrap: [AppComponent]
})
export class AppModule { }
