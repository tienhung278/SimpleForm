import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  users: User[] = [];
  title: string = "";
  body: string = "";
  errMsg: string = "";

  constructor(private repository: RepositoryService,
              private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.getAllUsers();
  }

  getAllUsers(): void {
    this.repository.get("api/users").subscribe( 
      value => this.users = value,
      err => {
        this.errorHandler.handleError(err);
        this.errMsg = this.errorHandler.errMsg;
        this.title = "ERROR MESSAGE";
        $("#errorModal").show();
      }
    );
    $("#successModal").hide();
  }

  delete(id: string): void {
    this.repository.delete("api/users/" + id).subscribe(
      value => {
        this.title = "DELETE MESSAGE";
        this.body = "Successfully";
        $("#successModal").show();
      },
      err => {
        this.errorHandler.handleError(err);
        this.errMsg = this.errorHandler.errMsg;
        this.title = "ERROR MESSAGE";
        $("#errorModal").show();
      }
    );
  }
}
