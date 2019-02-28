import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [{ path: '', component: AppComponent },
  { path: 'game', loadChildren: "./game/game.module#GameModule" },
  { path: 'account', loadChildren: "./account/account.module#AccountModule" },
  { path: '**', redirectTo: '/404', pathMatch: 'full'}]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
