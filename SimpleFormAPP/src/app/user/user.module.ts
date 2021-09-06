import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserRoutingModule } from './user-routing.module';
import { UserComponent } from './user.component';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';
import { FormComponent } from './form/form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';


@NgModule({
  declarations: [
    UserComponent,
    ListComponent,
    DetailsComponent,
    FormComponent
  ],
  imports: [
    SharedModule,
    ReactiveFormsModule,
    CommonModule,
    UserRoutingModule
  ]
})
export class UserModule { }
