import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-error-modal',
  templateUrl: './error-modal.component.html',
  styleUrls: ['./error-modal.component.css']
})
export class ErrorModalComponent implements OnInit {
  @Input() header: string = "";
  @Input() body: string = "";

  constructor() { }

  ngOnInit(): void {    
  }

  close(): void {
    $("#errorModal").hide();
  }
}
