import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { GameComponent } from './game/game.component';
import { HistoryComponent } from './history.component';
import { HistoryRoutingModule } from './history-routing.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [IndexComponent, GameComponent, HistoryComponent],
  imports: [
    CommonModule,
    FormsModule,
    HistoryRoutingModule
  ]
})
export class HistoryModule { }
