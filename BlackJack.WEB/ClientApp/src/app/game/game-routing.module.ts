import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GameComponent } from './game.component';
import { IndexComponent } from './index/index.component';
import { StartComponent } from './start/start.component';
import { AccountGuard } from '../account/guards/account.guard';

const routes: Routes = [
  {
    path: '', component: GameComponent, canActivate: [AccountGuard],children: [
      { path: '', redirectTo: 'index', pathMatch: 'full', canActivateChild: [AccountGuard]},
      { path: 'index', component: IndexComponent },
      { path: 'start', component: StartComponent }
    ]
  }
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [AccountGuard]
})
export class GameRoutingModule { }
