import { Component, OnInit } from "@angular/core";
import { WorkShopService } from "../core/work-shop.service";
import { WorkShop } from "../core/workshop.model";

@Component({
  selector: "app-workshop",
  templateUrl: "./workshop.component.html",
  styleUrls: ["./workshop.component.css"]
})
export class WorkshopComponent implements OnInit {
  title: string = "WorkShops";
  workshops: WorkShop[] = [];
  constructor(private workshopService: WorkShopService) {}

  ngOnInit() {
    this.getWorkShopsList();
  }
  getWorkShopsList() {
    this.workshopService.getWorkShops().subscribe(workshops => {
      this.workshops = workshops;
    });
  }
  subscribeToWorkShop(workshopId: string) {
    this.workshopService.subcribeToWorkShop(workshopId).subscribe(res => {
      this.getWorkShopsList();
    });
  }
}
