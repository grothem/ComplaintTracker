import { Citizen } from './citizen';

export class Complaint {
    constructor(public issueType: string, public issueLocation: string, public details: string, public citizen: Citizen) { }
}