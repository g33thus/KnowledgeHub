import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { MsalGuard } from "@azure/msal-angular";

const routes: Routes = [
  {
    path: "",
    loadChildren: () => import("./home/home.module").then((m) => m.HomeModule),
  },
  {
    path: "dashboard",
    canActivate: [MsalGuard],
    loadChildren: () =>
      import("./dashboard/dashboard.module").then((m) => m.DashboardModule),
  },
  {
    path: "admin",
    canActivate: [MsalGuard],
    loadChildren: () =>
      import("./admin/admin.module").then((ad) => ad.AdminModule),
  },
  {
    path: "feeds",
    canActivate: [MsalGuard],
    loadChildren: () =>
      import("./feeds/feeds.module").then((m) => m.FeedsModule),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
