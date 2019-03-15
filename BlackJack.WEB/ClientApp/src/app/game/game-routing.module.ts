import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { GameComponent } from './game.component';
import { IndexComponent } from './index/index.component';
import { StartComponent } from './start/start.component';
import { LoggedGuard } from '../account/guards/logged.guard';

const routes: Routes = [
  {
    path: '', component: GameComponent, canActivate: [LoggedGuard], children: [
      { path: '', redirectTo: 'index', pathMatch: 'full'},
      { path: 'index', component: IndexComponent },
      { path: 'start', component: StartComponent }
    ]
  }
]
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [LoggedGuard]
})
export class GameRoutingModule { }
