import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameComponent } from './game.component';
import { IndexComponent } from './index/index.component';
import { StartComponent } from './start/start.component';
import { GameRoutingModule } from './game-routing.module';
import { FormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { ForLoggedPlayersMenuComponent } from '../shared/components/for-logged-players-menu/for-logged-players-menu.component';
import { ForNonLoggedPlayersMenuComponent } from '../shared/components/for-non-logged-players-menu/for-non-logged-players-menu.component';

@NgModule({
  declarations: [GameComponent, IndexComponent, StartComponent],
  imports: [
    CommonModule,
    FormsModule,
    GameRoutingModule,
    SharedModule
  ]
})
export class GameModule { }
