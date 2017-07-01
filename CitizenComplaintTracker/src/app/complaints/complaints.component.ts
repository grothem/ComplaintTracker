import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

import { ComplaintService } from '../complaint.service';
import { Complaint } from '../complaint';
import { Citizen } from '../citizen';

@Component({
  selector: 'app-complaints',
  templateUrl: './complaints.component.html',
  styleUrls: ['./complaints.component.css'],
})
export class ComplaintsComponent implements OnInit {
  @ViewChild('f') complaintForm: NgForm;

  errorMessage: string;
  complaints: Complaint[];

  complaint: Complaint;
  citizen: Citizen;

  issueTypes = ['Graffiti', 'Traffic', 'Parks & Rec', 'Grass/Weeds', 'Roads', 'Signs'];
  selectedIssue = '';

  displayDialog: boolean = false;
  selectedComplaint: Complaint;

  constructor(private complaintService: ComplaintService) { }

  ngOnInit() {
    this.getComplaints();
  }

  getComplaints() {
    this.complaintService.getComplaints()
      .subscribe(
      complaints => this.complaints = complaints,
      error => this.errorMessage = error);
  }

  addComplaint(newComplaint: Complaint) {
    this.complaintService.addComplaint(newComplaint).subscribe(
      complaint => {
        this.complaints.push(complaint)
        this.complaintForm.resetForm();
        this.errorMessage = '';
      },
      error => this.errorMessage = <any>error);
  }

  showDetails(complaint: Complaint) {
    this.selectedComplaint = complaint;
    this.displayDialog = true;
  }

  onSubmit() {
    this.citizen = new Citizen(this.complaintForm.value.firstName,
      this.complaintForm.value.lastName,
      this.complaintForm.value.email,
      this.complaintForm.value.phoneNumber)

    this.complaint = new Complaint(this.selectedIssue,
      this.complaintForm.value.issueLocation,
      this.complaintForm.value.details,
      this.citizen);

    this.addComplaint(this.complaint);
  }
}
