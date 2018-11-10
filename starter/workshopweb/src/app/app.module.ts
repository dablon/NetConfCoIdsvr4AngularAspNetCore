import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { AppComponent } from "./app.component";
import { NavMenuComponent } from "./nav-menu/nav-menu.component";
import { OpenIdConnectService } from "./core/open-id-connect.service";
import { SigninOidcComponent } from "./signin-oidc/signin-oidc.component";
import { AppRoutingModule } from "./app.rounting";
import { RequireAuthenticateUserGuardService } from "./core/require-authenticate-user-guard.service";
import { HomeComponent } from "./home/home.component";
import { WorkshopComponent } from "./workshop/workshop.component";
import { HttpClientModule } from "@angular/common/http";
import { WorkshopAddComponent } from "./workshop-add/workshop-add.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    SigninOidcComponent,
    HomeComponent,
    WorkshopComponent,
    WorkshopAddComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [OpenIdConnectService, RequireAuthenticateUserGuardService],
  bootstrap: [AppComponent]
})
export class AppModule {}
