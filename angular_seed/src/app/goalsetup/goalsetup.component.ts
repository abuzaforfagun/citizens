import { Component, OnInit } from '@angular/core';
import { MatNativeDateModule } from '@angular/material';
import { fadeInAnimation } from '../_animations';

@Component({
  selector: 'app-goalsetup',
  templateUrl: './goalsetup.component.html',
  styleUrls: ['./goalsetup.component.scss'],
  providers: [MatNativeDateModule],
  animations: [fadeInAnimation],
  // tslint:disable-next-line:use-host-property-decorator
  host: { '[@fadeInAnimation]': '' }
})
export class GoalsetupComponent implements OnInit {
  suraList: any[];
  constructor() { }

  ngOnInit() {
    this.suraList = [{
      id: 1,
      text: 'Sura 1'
    }, {
      id: 2,
      text: 'Sura 2'
    }, {
      id: 3,
      text: 'Sura 3'
    }, {
      id: 4,
      text: 'Sura 4'
    }];
  }

}
