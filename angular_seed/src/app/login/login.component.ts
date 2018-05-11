import { HttpService } from './../services/http.service';
import { Citizen } from './../core/citizen';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  userDetails: Citizen;
  constructor(private httpService: HttpService) {
    this.userDetails = new Citizen();
  }

  ngOnInit() {
  }

  login() {
    console.log("login");
    this.httpService.postData('citizens/validate', this.userDetails).subscribe((data: Citizen) => {
      console.log(data);
    })
    console.log(JSON.stringify(this.userDetails));
  }
}

