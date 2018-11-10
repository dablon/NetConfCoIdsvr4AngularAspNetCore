import { Component, OnInit } from "@angular/core";
import { OpenIdConnectService } from "../core/open-id-connect.service";

@Component({
  selector: "app-nav-menu",
  templateUrl: "./nav-menu.component.html",
  styleUrls: ["./nav-menu.component.css"]
})
export class NavMenuComponent implements OnInit {
  constructor(private openIdConnectService: OpenIdConnectService) {}

  ngOnInit() {}
}
