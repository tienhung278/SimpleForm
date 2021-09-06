import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InternalServerComponent } from './error-pages/internal-server/internal-server.component';
import { NotFoundComponent } from './error-pages/not-found/not-found.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { path: "home", component: HomeComponent },
  { path: "user", loadChildren: () => import("./user/user.module").then(m => m.UserModule) },
  { path: "404", component: NotFoundComponent },
  { path: "500", component: InternalServerComponent },  
  { path: "", redirectTo: "/home", pathMatch: "full"},  
  { path: "**", redirectTo: "/404", pathMatch: "full"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
