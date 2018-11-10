import { Injectable } from "@angular/core";
import { UserManager, User } from "oidc-client";
import { environment } from "../../environments/environment";
import { ReplaySubject } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class OpenIdConnectService {
  private userManager: UserManager = new UserManager(
    environment.openIdConnectSettings
  );
  private currentUser: User;
  userLoaded$ = new ReplaySubject<boolean>(1);

  get userAvailable(): boolean {
    return this.currentUser != null;
  }

  get user(): User {
    return this.currentUser;
  }
  constructor() {
    this.userManager.clearStaleState();
    this.userManager.events.addUserLoaded(user => {
      this.currentUser = user;
      this.userLoaded$.next(true);
    });
    this.userManager.events.addUserUnloaded(e => {
      this.currentUser = null;
      this.userLoaded$.next(false);
    });
  }

  triggerSignIn() {
    this.userManager.signinRedirect();
  }
  triggerSignOut() {
    this.userManager.signoutRedirect();
  }
  handlerCallBack() {
    this.userManager.signinRedirectCallback();
  }
}
