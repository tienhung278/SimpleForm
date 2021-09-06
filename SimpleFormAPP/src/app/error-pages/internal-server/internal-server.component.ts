import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-internal-server',
  templateUrl: './internal-server.component.html',
  styleUrls: ['./internal-server.component.css']
})
export class InternalServerComponent implements OnInit {
  message: string = "THERE IS AN SERVER ERROR, CONTACT ADMINISTRATOR";

  constructor() { }

  ngOnInit(): void {
  }

}
