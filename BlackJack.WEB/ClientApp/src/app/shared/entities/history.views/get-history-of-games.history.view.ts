import { GameState } from "../../enums/game-state";

export class GetHistoryOfGamesHistoryView {
  games?: Array<GameGetHistoryOfGamesHistoryViewItem>;

  constructor() {
    this.games = new Array<GameGetHistoryOfGamesHistoryViewItem>();
  }
}

export class GameGetHistoryOfGamesHistoryViewItem {
  id?: string;
  gameState?: GameState;
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
