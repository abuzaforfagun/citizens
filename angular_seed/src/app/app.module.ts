import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpService } from './services/http.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import {
  MatButtonModule,
  MatInputModule,
  MatRippleModule,
  MatTooltipModule,
  MatSelectModule,
  MatOptionModule,
  MatRadioButton,
  MatRadioModule,
  MatTabsModule,
  MatCheckboxModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatIconModule
} from '@angular/material';

import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';

import { AppComponent } from './app.component';

import { DashboardComponent } from './dashboard/dashboard.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { TableListComponent } from './table-list/table-list.component';
import { TypographyComponent } from './typography/typography.component';
import { IconsComponent } from './icons/icons.component';
import { MapsComponent } from './maps/maps.component';
import { NotificationsComponent } from './notifications/notifications.component';
import { UpgradeComponent } from './upgrade/upgrade.component';

import {
  AgmCoreModule
} from '@agm/core';
import { GoalsetupComponent } from './goalsetup/goalsetup.component';
import { StatusComponent } from './status/status.component';
import { SignupComponent } from './signup/signup.component';
import { RecorderComponent } from './recorder/recorder.component';

@NgModule({
  imports: [
    BrowserAnimationsModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    ComponentsModule,
    RouterModule,
    MatButtonModule,
    MatIconModule,
    MatRippleModule,
    MatInputModule,
    MatTooltipModule,
    MatSelectModule,
    MatRadioModule,
    MatDatepickerModule,
    MatCheckboxModule,

    MatTabsModule,
    AppRoutingModule,
    MatNativeDateModule,


  ],
  declarations: [
    AppComponent,
    DashboardComponent,
    UserProfileComponent,
    TableListComponent,
    TypographyComponent,
    IconsComponent,
    MapsComponent,
    NotificationsComponent,
    UpgradeComponent,
    GoalsetupComponent,
    StatusComponent,
    SignupComponent,
    RecorderComponent
  ],
  providers: [HttpService, HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
