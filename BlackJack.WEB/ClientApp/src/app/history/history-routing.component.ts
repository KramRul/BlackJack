import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HistoryComponent } from './history.component';
import { IndexComponent } from './index/index.component';
import { GameComponent } from './game/game.component';

const routes: Routes = [
  {
    path: '', component: HistoryComponent, children: [
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
