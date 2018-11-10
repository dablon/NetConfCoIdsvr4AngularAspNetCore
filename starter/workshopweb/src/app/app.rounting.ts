import { Routes, RouterModule } from "@angular/router";
import { NgModule } from "@angular/core";
import { SigninOidcComponent } from "./signin-oidc/signin-oidc.component";
import { HomeComponent } from "./home/home.component";
import { WorkshopComponent } from "./workshop/workshop.component";
import { WorkshopAddComponent } from "./workshop-add/workshop-add.component";

const routes: Routes = [
  { path: "", component: HomeComponent },
  { path: "workshop", component: WorkshopComponent },
  { path: "workshop-add", component: WorkshopAddComponent },
  { path: "signin-oidc", component: SigninOidcComponent }
];

// define a module
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
