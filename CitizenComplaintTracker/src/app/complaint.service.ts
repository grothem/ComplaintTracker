import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/observable/throw';

import { Complaint } from './complaint';

@Injectable()
export class ComplaintService {
    private complaintsUrl = 'api/complaints';

    constructor(private http: Http) { }

    getComplaints(): Observable<Complaint[]> {
        return this.http.get(this.complaintsUrl)
            .map(this.extractData)
            .catch(this.handleError);
    }

    addComplaint(complaint: Complaint): Observable<Complaint> {
        return this.http.post(this.complaintsUrl, complaint)
            .map(this.extractData)
            .catch(this.handleError);
    }

    private extractData(res: Response) {
        let body = res.json();
        return body || {};
    }

    private handleError(error: Response | any) {
        let errMsg: string;
        if (error instanceof Response) {
            errMsg = `${error.status} - ${error.statusText || ''}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}