import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginAccountView } from './entities/account.views/login.account.view';
import { LoginAccountResponseView } from './entities/account.views/login-response.account.view';
import { RegisterAccountView } from './entities/account.views/register.account.view';
import { RegisterAccountResponseView } from './entities/account.views/register-response.account.view';
import { GetGameView } from './entities/game.views/get.game.view';
import { GetAllStepOfBotsGameView } from './entities/game.views/get-all-step-of-bots.game.view';
import { GetAllStepsGameView } from './entities/game.views/get-all-steps.game.view';
import { GetGamesByPlayerIdGameView } from './entities/game.views/get-games-by-playerId.game.view';
import { HitGameView } from './entities/game.views/hit.game.view';
import { StartGameView } from './entities/game.views/start.game.view';
import { StartGameResultView } from './entities/game.views/start-result.game.view';
import { GetAllPlayersPlayerView } from './entities/player.views/get-all-players.player.view';
import { GetAllStepsByPlayerIdPlayerView } from './entities/player.views/get-all-steps-by-playerId.player.view';
import { GetPlayerByIdPlayerView } from './entities/player.views/get-player-by-id.player.view';

@NgModule({
  declarations: [LoginAccountView, LoginAccountResponseView, RegisterAccountView, RegisterAccountResponseView,
    GetGameView, GetAllStepOfBotsGameView, GetAllStepsGameView, GetGamesByPlayerIdGameView, HitGameView, StartGameView, StartGameResultView,
    GetAllPlayersPlayerView, GetAllStepsByPlayerIdPlayerView, GetPlayerByIdPlayerView],
  imports: [
    CommonModule
  ]
})
export class SharedModule { }
