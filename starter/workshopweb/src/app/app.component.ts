import { Component } from "@angular/core";
import { OpenIdConnectService } from "./core/open-id-connect.service";

@Component({
  selector: "app-root",
  templateUrl: "./app.component.html",
  styleUrls: ["./app.component.css"]
})
export class AppComponent {
  title = "event-web";

  constructor(private openIdConnectService: OpenIdConnectService) {}
  ngOnInit() {
    var path = window.localStorage.pathName;
    if (path != "signin-oidc") {
      if (this.openIdConnectService.userAvailable) {
        this.openIdConnectService.triggerSignIn();
      }
    }
  }
}
