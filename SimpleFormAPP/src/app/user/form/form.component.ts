import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from 'src/app/models/user.model';
import { ErrorHandlerService } from 'src/app/shared/services/error-handler.service';
import { RepositoryService } from 'src/app/shared/services/repository.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnInit {
  simpleForm: FormGroup;
  title: string = "";
  body: string = "";
  errorMsg: string = "";
  Id: string = "";
  user: User = new User();
  validationMessages: any = {
    "firstName": {
      "required": "First Name is required"
    },
    "lastName": {
      "required": "Last Name is required"
    }
  };
  formErrors: any = {
    "firstName": "",
    "lastName": ""
  }

  constructor(private repository: RepositoryService,
              private formBuilder: FormBuilder,
              private route: ActivatedRoute,
              private errorHandler: ErrorHandlerService,
              private router: Router) {
    this.simpleForm = this.formBuilder.group({
      id: [''],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.route.params.subscribe(
      value => {
        this.Id = value["id"];
        if (this.Id === undefined) {
          this.title = "ADD USER";
        } else {
          this.title = "UPDATE USER";          
          this.repository.get("api/users/" + this.Id).subscribe(
            value => {
              this.user = value;
              this.simpleForm.setValue(this.user);
            },
            error => {
              this.errorHandler.handleError(error);
              this.errorMsg = this.errorHandler.errMsg;
            }
          );
        }
      }
    );

    this.simpleForm.valueChanges.subscribe(
      data => this.checkValidation()
    );
  }

  checkValidation(): void {
    Object.keys(this.simpleForm.controls).forEach(value => {
        this.formErrors[value] = "";
        let control = this.simpleForm.get(value);
        if (control?.invalid && control?.touched) {
          let messages = this.validationMessages[value];
          for (let errorKey in control.errors) {
            this.formErrors[value] = messages[errorKey];
          }
        }
      }
    );
  }

  submit(): void {
    if (this.simpleForm.valid) {
      this.user = this.simpleForm.value;
      if (this.Id === undefined) {
        this.repository.add("api/users", this.user).subscribe(
          data => {
            this.body = "Adding successfully";
            $("#successModal").show();          
          },
          error => {
            this.errorHandler.handleError(error);
            this.errorMsg = this.errorHandler.errMsg;
          }        
        );
      } else {
        this.repository.update("api/users/" + this.Id, this.user).subscribe(
          data => {
            this.body = "Updating successfully";
            $("#successModal").show();          
          },
          error => {
            this.errorHandler.handleError(error);
            this.errorMsg = this.errorHandler.errMsg;
          }        
        );
      }      
    }
  }

  close(): void {
    this.router.navigate(["/user"]);
  }
}
