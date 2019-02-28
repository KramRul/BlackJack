import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GameComponent } from './game.component';
import { IndexComponent } from './index/index.component';
import { StartComponent } from './start/start.component';
import { GameRoutingModule } from './game-routing.module';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [GameComponent, IndexComponent, StartComponent],
  imports: [
    CommonModule,
    FormsModule,
    GameRoutingModule
  ]
})
export class GameModule { }
