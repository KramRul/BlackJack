import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HistoryComponent } from './history.component';
import { IndexComponent } from './index/index.component';
import { GameComponent } from './game/game.component';
import { LoggedGuard } from '../account/guards/logged.guard';

const routes: Routes = [
  { path: '', redirectTo: 'index', pathMatch: 'full' },
  {
    path: '', component: HistoryComponent, canActivate: [LoggedGuard], children: [     
      { path: 'index', component: IndexComponent },
      { path: 'game', component: GameComponent }
    ]
  }
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [LoggedGuard]
})
export class HistoryRoutingModule { }
