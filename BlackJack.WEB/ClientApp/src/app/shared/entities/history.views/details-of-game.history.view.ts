import { GameStateType } from "../../enums/game-state-type";
import { GetAllStepsGameView } from "../game.views/get-all-steps.game.view";
import { GetAllStepOfBotsGameView } from "../game.views/get-all-step-of-bots.game.view";
import { SuiteType } from "../../enums/suite-type";
import { RankType } from "../../enums/rank-type";

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

export class PlayerAndBotStepsDetailsOfGameHistoryView {
  steps?: Array<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>;

  constructor() {
    this.steps = new Array<StepPlayerAndBotStepsDetailsOfGameHistoryViewItem>();
  }
}

export class StepPlayerAndBotStepsDetailsOfGameHistoryViewItem {
  cards?: Array<CardPlayerAndBotStepsDetailsOfGameHistoryView>;

  constructor() {
    this.cards = new Array<CardPlayerAndBotStepsDetailsOfGameHistoryView>();
  }
}

export class CardPlayerAndBotStepsDetailsOfGameHistoryView {
  id?: string;
  suite?: SuiteType;
  rank?: RankType;
  player?: PlayerCardPlayerAndBotStepsDetailsOfGameHistoryView;
  game?: GameCardPlayerAndBotStepsDetailsOfGameHistoryView;
  bot?: BotCardPlayerAndBotStepsDetailsOfGameHistoryView;

  constructor() {
    this.player = new PlayerCardPlayerAndBotStepsDetailsOfGameHistoryView();
    this.game = new GameCardPlayerAndBotStepsDetailsOfGameHistoryView();
    this.bot = new BotCardPlayerAndBotStepsDetailsOfGameHistoryView();
  }
}

export class PlayerCardPlayerAndBotStepsDetailsOfGameHistoryView {
  userName?: string;
  id?: string;
  balance?: number;
  bet?: number;
}

export class GameCardPlayerAndBotStepsDetailsOfGameHistoryView {
  id?: string;
  wonName?: string;
  gameState?: GameStateType;
}

export class BotCardPlayerAndBotStepsDetailsOfGameHistoryView {
  id?: string;
  name?: string;
  balance?: number;
  bet?: number;
}

export class GameDetailsOfGameHistoryView {
  id?: string;
  wonName?: string;
  gameState?: GameStateType;
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
