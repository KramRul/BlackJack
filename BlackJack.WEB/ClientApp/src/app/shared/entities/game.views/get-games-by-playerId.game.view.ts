import { GameStateType } from '../../enums/game-state-type';

export class GetGamesByPlayerIdGameView {
  games?: Array<GameGetGamesByPlayerIdGameViewItem>;

  constructor() {
    this.games = new Array <GameGetGamesByPlayerIdGameViewItem>();
  }
}

export class GameGetGamesByPlayerIdGameViewItem {
  gameId?: string;
  gameState?: GameStateType;
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
