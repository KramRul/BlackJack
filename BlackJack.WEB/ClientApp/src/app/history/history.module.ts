import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { GameComponent } from './game/game.component';
import { HistoryComponent } from './history.component';
import { HistoryRoutingModule } from './history-routing.module';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    IndexComponent,
    GameComponent,
    HistoryComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HistoryRoutingModule,
    SharedModule
  ]
})
export class HistoryModule { }
