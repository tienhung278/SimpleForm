import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DetailsComponent } from './details/details.component';
import { FormComponent } from './form/form.component';
import { ListComponent } from './list/list.component';

const routes: Routes = [  
  { path: "list", component: ListComponent },
  { path: "details/:id", component: DetailsComponent },
  { path: "add", component: FormComponent },
  { path: "update/:id", component: FormComponent },
  { path: '', component: ListComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }
