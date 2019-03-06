import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { IndexComponent } from './index/index.component';
import { GameComponent } from './game/game.component';
import { HistoryComponent } from './history.component';
import { HistoryRoutingModule } from './history-routing.component';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { ForLoggedPlayersMenuComponent } from '../shared/components/for-logged-players-menu/for-logged-players-menu.component';
import { ForNonLoggedPlayersMenuComponent } from '../shared/components/for-non-logged-players-menu/for-non-logged-players-menu.component';

@NgModule({
  declarations: [IndexComponent, GameComponent, HistoryComponent],
  imports: [
    CommonModule,
    FormsModule,
    HistoryRoutingModule,
    SharedModule
  ]
})
export class HistoryModule { }
