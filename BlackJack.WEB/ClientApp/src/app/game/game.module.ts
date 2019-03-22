import { NgModule } from '@angular/core';
import { GameComponent } from './game.component';
import { IndexComponent } from './index/index.component';
import { StartComponent } from './start/start.component';
import { GameRoutingModule } from './game-routing.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    GameComponent,
    IndexComponent,
    StartComponent
  ],
  imports: [
    GameRoutingModule,
    SharedModule
  ]
})
export class GameModule { }
