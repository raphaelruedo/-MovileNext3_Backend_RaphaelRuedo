import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  HOST_URI: string;
  LOCAL_URI: string;


  constructor(public http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.HOST_URI = baseUrl;
  }

  get(endpoint: string, params?: any, reqOpts?: any) {
    const $t = this;
    return new Promise(function (resolve, reject) {
      $t.http.get($t.HOST_URI + endpoint, reqOpts)
        .subscribe((resp) => {
          resolve(resp);
        }, (err) => {
          reject(err);
        });
    });
  }

  post(endpoint: string, body: any, reqOpts?: any) {
    const $t = this;
    return new Promise(function (resolve, reject) {
      $t.http.post($t.HOST_URI + '/' + endpoint, body, reqOpts)
        .subscribe((resp) => {
          resolve(resp);
        }, (err) => {
          reject(err);
        });
    });
  }

  put(endpoint: string, body: any, reqOpts?: any) {
    const $t = this;
    return new Promise(function (resolve, reject) {
      $t.http.put($t.HOST_URI + '/' + endpoint, body, reqOpts)
        .subscribe((resp) => {
          resolve(resp);
        }, (err) => {
          reject(err);
        });
    });
  }

  delete(endpoint: string, reqOpts?: any) {
    const $t = this;
    return new Promise(function (resolve, reject) {
      $t.http.delete($t.HOST_URI + '/' + endpoint, reqOpts)
        .subscribe((resp) => {
          resolve(resp);
        }, (err) => {
          reject(err);
        });
    });
  }

  patch(endpoint: string, body: any, reqOpts?: any) {
    const $t = this;
    return new Promise(function (resolve, reject) {
      $t.http.patch($t.HOST_URI + '/' + endpoint, body, reqOpts)
        .subscribe((resp) => {
          resolve(resp);
        }, (err) => {
          reject(err);
        });
    });
  }
}
