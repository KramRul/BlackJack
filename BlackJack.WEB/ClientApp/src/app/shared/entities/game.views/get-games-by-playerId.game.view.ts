import { GameState } from '../../enums/game-state';

export class GetGamesByPlayerIdGameView {
  games?: Array<GameGetGamesByPlayerIdGameViewItem>;

  constructor() {
    this.games = new Array <GameGetGamesByPlayerIdGameViewItem>();
  }
}

export class GameGetGamesByPlayerIdGameViewItem {
  gameId?: string;
  gameState?: GameState;
  player?: PlayerGetAllGamesByPlayerIdGameView;

  constructor() {
    this.player = new PlayerGetAllGamesByPlayerIdGameView();
  }
}

export class PlayerGetAllGamesByPlayerIdGameView {
  playerId?: string;
  balance?: number;
  bet?: number;
}
