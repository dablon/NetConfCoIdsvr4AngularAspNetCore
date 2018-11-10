import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { HttpClient } from "@angular/common/http";
import { WorkShop } from "./workshop.model";
import { Observable } from "rxjs/internal/Observable";

@Injectable({
  providedIn: "root"
})
export class WorkShopService {
  apiUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}

  getWorkShops(): Observable<WorkShop[]> {
    return this.http.get<WorkShop[]>(`${this.apiUrl}/workshop`);
  }
  addWorkShop(workshopToAdd: WorkShop): Observable<WorkShop> {
    return this.http.post<WorkShop>(`${this.apiUrl}/workshop`, workshopToAdd, {
      headers: {
        "Content-Type": "application/json"
      }
    });
  }
  subcribeToWorkShop(workShopId: string): Observable<WorkShop> {
    return this.http.post<WorkShop>(
      `${this.apiUrl}/workshop/${workShopId}`,
      null,
      {
        headers: {
          "Content-Type": "application/json",
          "Access-Control-Allow-Origin": "*",
          "Access-Control-Allow-Credentials": "true"
        }
      }
    );
  }
}
