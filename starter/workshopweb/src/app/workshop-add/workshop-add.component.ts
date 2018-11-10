import { Component, OnInit } from "@angular/core";
import { WorkShopService } from "../core/work-shop.service";
import {
  FormBuilder,
  FormGroup,
  Validators,
  FormControl
} from "@angular/forms";
import { Router } from "@angular/router";
import { OpenIdConnectService } from "../core/open-id-connect.service";
import { WorkShop } from "../core/workshop.model";

@Component({
  selector: "workshop-add",
  templateUrl: "./workshop-add.component.html",
  styleUrls: ["./workshop-add.component.css"]
})
export class WorkshopAddComponent implements OnInit {
  public workShopForm: FormGroup;
  constructor(
    private workshopService: WorkShopService,
    private formBuilder: FormBuilder,
    private router: Router,
    private openIdConnectService: OpenIdConnectService
  ) {}

  ngOnInit() {
    this.workShopForm = this.formBuilder.group({
      description: ["", Validators.required],
      isFree: new FormControl("", Validators.required)
    });
  }

  addWorkShop(): void {
    var workShopToSave = new WorkShop();
    if (this.workShopForm.dirty && this.workShopForm.valid) {
      workShopToSave.description = this.workShopForm.get("description").value;
      workShopToSave.isFree = this.workShopForm.get("isFree").value;
      this.workshopService.addWorkShop(workShopToSave).subscribe(() => {
        this.router.navigateByUrl("/workshop");
      });
    }
  }
}
