import { Subscription } from 'rxjs/Subscription';
import { Memorization } from './../core/memorization';
import { HttpService } from './../services/http.service';
import { Citizen } from './../core/citizen';
import { Component, OnInit } from '@angular/core';
import { fadeInAnimation } from '../_animations';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent implements OnInit {
  pledges: any[];
  groups: any[];
  memorizationList = [];
  memorizationGoalList = [];
  memorization: any;
  memorizationGoal: any;
  userDetails = new Citizen();
  registrationCompleted = false;

  constructor(private httpService: HttpService) {
    this.memorization = {
      sura: ''
    }
    this.memorizationGoal = {
      sura: ''
    }
    this.userDetails = new Citizen();
  }

  ngOnInit() {
    this.pledges = [
      {
        id: 1,
        text: 'Otext 1'
      }, {
        id: 2,
        text: 'Otext 2'
      }, {
        id: 3,
        text: 'Otext 3'
      },
    ];

    this.groups = [
      {
        id: 1,
        text: 'Teacher'
      }, {
        id: 2,
        text: 'Student'
      }
    ]
  }

  addItemInList(list, item) {
    list.push(item);
    this.memorization = {
      sura: ''
    };

    this.memorizationGoal = {
      sura: ''
    }

    // this.memorizationGoal.sura = '';
  }

  removeItemFromList(list: any[], index) {
    list.splice(index, 1);
  }

  clickSignUp() {
    this.httpService.postData('citizens/', this.userDetails).subscribe((data: Citizen) => {
      console.log(data);
      this.processMemorizations(data.id);
      this.registrationCompleted = true;
    })
    console.log(JSON.stringify(this.userDetails));
  }

  private processMemorizations(guId) {
    this.memorizationList.forEach(val => {
      val.isCompleted = true;
      val.userGuId = guId;
      this.postMemorization(val);
    });
    this.memorizationGoalList.forEach(val => {
      val.userGuId = guId;
      val.isCompleted = false;
      this.postMemorization(val);
    });
  }

  postMemorization(memorization: Memorization) {
    this.httpService.postData('memorizations/', memorization).subscribe(data => {
      console.log('Send');
    });
  }
}
