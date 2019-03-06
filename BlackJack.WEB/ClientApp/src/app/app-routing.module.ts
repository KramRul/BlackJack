import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';

const routes: Routes = [{
  path: '', children:
    [
      { path: '', redirectTo: 'game', pathMatch: 'full' },
      { path: 'game', loadChildren: "./game/game.module#GameModule" },
      { path: 'account', loadChildren: "./account/account.module#AccountModule" },
      { path: 'history', loadChildren: "./history/history.module#HistoryModule" }
    ]
},
{ path: '**', redirectTo: '/404', pathMatch: 'full' }]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
