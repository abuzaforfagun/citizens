export class Citizen {
    id: number;
    pledge: number;
    name: string;
    email: string;
    password: string;
    username: string;
    group: number;
    photoUrl: string;
    profile_type: number;
    isLookingForSponsor: boolean;
    supportEfforOf: boolean;
    sponsorStudent: boolean;
    address: string;
    guId: string;


    constructor() {
        this.pledge = -1;
        this.name = '';
        this.email = '';
        this.username = '';
        this.group = -1;
        this.photoUrl = '';
        this.profile_type = -1;
        this.address = '';
        this.isLookingForSponsor = false;
        this.supportEfforOf = false;
        this.sponsorStudent = false;
    }

    validate() {
        if (this.pledge === -1 || this.name === ''
            || this.email === '' || this.username === ''
            || this.password === '' || this.group === -1 || this.profile_type === -1) {
            return false;
        }
        return true;
    }
}
