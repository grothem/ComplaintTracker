import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ComplaintService } from '../complaint.service';
import { Complaint } from '../complaint';
import { Citizen } from '../citizen';

@Component({
  selector: 'app-complaints',
  templateUrl: './complaints.component.html',
  styleUrls: ['./complaints.component.css']
})
export class ComplaintsComponent implements OnInit {
  @ViewChild('f') complaintForm: NgForm;

  errorMessage: string;
  complaints: Complaint[];

  complaint: Complaint;
  citizen: Citizen;

  issueTypes = ['Graffiti', 'Traffic', 'Parks & Rec'];
  selectedIssue = '';

  constructor(private complaintService: ComplaintService) { }

  ngOnInit() {
    this.getComplaints();
  }

  getComplaints() {
    this.complaintService.getComplaints()
      .subscribe(
      complaints => this.complaints = complaints,
      error => this.errorMessage = <any>error);
  }

  addComplaint() {
    this.complaintService.addComplaint(this.complaint).subscribe(
      complaint => {
        this.complaints.push(this.complaint)
        this.complaintForm.resetForm();
        this.errorMessage = '';
      },
      error => this.errorMessage = <any>error);
  }

  onSubmit() {
    this.citizen = new Citizen(this.complaintForm.value.firstName,
      this.complaintForm.value.lastName,
      this.complaintForm.value.email,
      this.complaintForm.value.phone)

    this.complaint = new Complaint(this.selectedIssue,
      this.complaintForm.value.issueLocation,
      this.complaintForm.value.details,
      this.citizen);

    this.addComplaint();
  }
}
