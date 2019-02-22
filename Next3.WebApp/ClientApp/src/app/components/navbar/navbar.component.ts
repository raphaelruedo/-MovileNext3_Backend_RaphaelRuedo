import { Component, OnInit, Inject } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  urlDoc: string;

  constructor(@Inject('BASE_URL') baseUrl: string) {
    this.urlDoc = baseUrl + 'swagger';
  }

  ngOnInit() {
  }

}
