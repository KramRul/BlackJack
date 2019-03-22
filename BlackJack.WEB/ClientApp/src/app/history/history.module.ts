import { NgModule } from '@angular/core';
import { IndexComponent } from './index/index.component';
import { GameComponent } from './game/game.component';
import { HistoryComponent } from './history.component';
import { HistoryRoutingModule } from './history-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    IndexComponent,
    GameComponent,
    HistoryComponent
  ],
  imports: [
    HistoryRoutingModule,
    SharedModule
  ]
})
export class HistoryModule { }
