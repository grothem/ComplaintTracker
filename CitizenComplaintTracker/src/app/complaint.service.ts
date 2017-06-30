import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
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
        console.log('in complaint  service, post complaint');
        console.log(complaint);
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
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }
}