import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HistoryComponent } from './history.component';
import { IndexComponent } from './index/index.component';
import { GameComponent } from './game/game.component';
import { AccountGuard } from '../account/guards/account.guard';

const routes: Routes = [
  {
    path: '', component: HistoryComponent, canActivate: [AccountGuard], children: [
      { path: '', redirectTo: 'index', pathMatch: 'full' },
      { path: 'index', component: IndexComponent },
      { path: 'game', component: GameComponent }
    ]
  }
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HistoryRoutingModule { }
