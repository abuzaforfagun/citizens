import { Injectable } from '@angular/core';
import { Http, HttpModule, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { HttpHeaders, HttpClient } from '@angular/common/http';



@Injectable()
export class HttpService {
  private root = 'http://localhost:5000/api/v1/';
  // private root = 'http://citizens-api.azurewebsites.net/api/v1/';
  constructor(private http: HttpClient) { }

  getData(url, parms) {
    url = this.root + url;
    this.http.get(url).map(res => res);
  }

  postData(url, body) {
    let headers = {
      headers: { 'Content-Type': 'application/json', 'Accept': 'application/json', 'Access-Control-Allow-Origin': '*' }
    };

    url = this.root + url;
    return this.http.post(url, body, headers).map(res => res);
  }
}
