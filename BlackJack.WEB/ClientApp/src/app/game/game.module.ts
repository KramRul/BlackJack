import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameComponent } from './game.component';
import { IndexComponent } from './index/index.component';
import { StartComponent } from './start/start.component';
import { GameRoutingModule } from './game-routing.module';

@NgModule({
  declarations: [GameComponent, IndexComponent, StartComponent],
  imports: [
    CommonModule,
    GameRoutingModule
  ]
})
export class GameModule { }
