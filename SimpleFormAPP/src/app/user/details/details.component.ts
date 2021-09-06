import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  user: User = new User();
  title: string = "ERROR MESSAGE"
  body: string = "";
  id: string = "";

  constructor(private repository: RepositoryService,
              private route: ActivatedRoute,
              private errorHandler: ErrorHandlerService) { }

  ngOnInit(): void {
    this.route.params.subscribe(
      value => {
        this.id = value["id"];        
      }
    );

    this.repository.get("api/users/" + this.id).subscribe(
      value => this.user = value,
      error => {
        this.errorHandler.handleError(error);
        this.body = this.errorHandler.errMsg;
      }
    );
  }

}
