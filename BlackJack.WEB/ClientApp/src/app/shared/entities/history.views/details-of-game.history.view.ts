import { GameState } from "../../enums/game-state";
import { GetAllStepsGameView } from "../game.views/get-all-steps.game.view";
import { GetAllStepOfBotsGameView } from "../game.views/get-all-step-of-bots.game.view";
import { Suite } from "../../enums/suite";
import { Rank } from "../../enums/rank";

export class DetailsOfGameHistoryView {
  game?: GameDetailsOfGameHistoryView;
  playerSteps?: GetAllStepsGameView;
  botsSteps?: GetAllStepOfBotsGameView;
  playerAndBotSteps?: PlayerAndBotStepsDetailsOfGameHistoryView;

  constructor() {
    this.game = new GameDetailsOfGameHistoryView();
    this.playerSteps = new GetAllStepsGameView();
    this.botsSteps = new GetAllStepOfBotsGameView();
    this.playerAndBotSteps = new PlayerAndBotStepsDetailsOfGameHistoryView();
  }
}

/*****************************************************************/
export class PlayerAndBotStepsDetailsOfGameHistoryView {
  steps?: Array<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>;

  constructor() {
    this.steps = new Array<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>();
  }
}

export class StepPlayerAndBotStepsDetailsOfGameHistoryViewItem {
  playerStep?: PlayerStepPlayerAndBotStepsDetailsOfGameHistoryView;
  botStep?: BotStepPlayerAndBotStepsDetailsOfGameHistoryView;

  constructor() {
    this.playerStep = new PlayerStepPlayerAndBotStepsDetailsOfGameHistoryView();
    this.botStep = new BotStepPlayerAndBotStepsDetailsOfGameHistoryView();
  }
}

export class PlayerStepPlayerAndBotStepsDetailsOfGameHistoryView {
  id?: string;
  suite?: Suite;
  rank?: Rank;
  player?: PlayerPlayerAndBotStepsDetailsOfGameHistoryView;
  game?: PlayerPlayerAndBotStepsDetailsOfGameHistoryView;

  constructor() {
    this.player = new PlayerPlayerAndBotStepsDetailsOfGameHistoryView();
    this.game = new PlayerPlayerAndBotStepsDetailsOfGameHistoryView();
  }
}

export class BotStepPlayerAndBotStepsDetailsOfGameHistoryView {
  id?: string;
  suite?: Suite;
  rank?: Rank;
  bot?: BotPlayerAndBotStepsDetailsOfGameHistoryView;

  constructor() {
    this.bot = new BotPlayerAndBotStepsDetailsOfGameHistoryView();
  }
}

export class PlayerPlayerAndBotStepsDetailsOfGameHistoryView {
  userName?: string;
  id?: string;
  balance?: number;
  bet?: number;
}

export class GamePlayerAndBotStepsDetailsOfGameHistoryView {
  id?: string;
  wonId?: string;
  gameState?: GameState;
}

export class BotPlayerAndBotStepsDetailsOfGameHistoryView {
  id?: string;
  userName?: string;
  balance?: number;
  bet?: number;
}
/***************************************************************/
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
