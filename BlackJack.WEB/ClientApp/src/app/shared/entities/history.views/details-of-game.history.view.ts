import { GameState } from "../../enums/game-state";
import { GetAllStepsGameView } from "../game.views/get-all-steps.game.view";
import { GetAllStepOfBotsGameView } from "../game.views/get-all-step-of-bots.game.view";

export class DetailsOfGameHistoryView {
  game?: GameDetailsOfGameHistoryView;
  playerSteps?: GetAllStepsGameView;
  botsSteps?: GetAllStepOfBotsGameView;

  constructor() {
    this.game = new GameDetailsOfGameHistoryView();
    this.playerSteps = new GetAllStepsGameView();
    this.botsSteps = new GetAllStepOfBotsGameView();
  }
}

export class GameDetailsOfGameHistoryView {
  id?: string;
  wonId?: string;
  gameState?: GameState;
  player?: PlayerDetailsOfGameHistoryView;

  constructor() {
    this.player = new PlayerDetailsOfGameHistoryView();
  }
}

export class PlayerDetailsOfGameHistoryView {
  userName?: string;
  id?: string;
  balance?: number;
  bet?: number;
}
