import { GameStateType } from "../../enums/game-state-type";

export class GetHistoryOfGamesHistoryView {
  games?: Array<GameGetHistoryOfGamesHistoryViewItem>;

  constructor() {
    this.games = new Array<GameGetHistoryOfGamesHistoryViewItem>();
  }
}

export class GameGetHistoryOfGamesHistoryViewItem {
  id?: string;
  wonName?: string;
  gameState?: GameStateType;
  player?: PlayerGetHistoryOfGamesHistoryView;

  constructor() {
    this.player = new PlayerGetHistoryOfGamesHistoryView();
  }
}

export class PlayerGetHistoryOfGamesHistoryView {
  id?: string;
  userName?: string;
  balance?: number;
  bet?: number;
}
