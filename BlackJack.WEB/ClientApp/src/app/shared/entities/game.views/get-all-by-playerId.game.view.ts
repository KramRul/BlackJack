import { GameStateType } from '../../enums/game-state-type';

export class GetAllByPlayerIdGameView {
  games?: Array<GameGetAllByPlayerIdGameViewItem>;

  constructor() {
    this.games = new Array <GameGetAllByPlayerIdGameViewItem>();
  }
}

export class GameGetAllByPlayerIdGameViewItem {
  gameId?: string;
  gameState?: GameStateType;
  player?: PlayerGetAllByPlayerIdGameView;

  constructor() {
    this.player = new PlayerGetAllByPlayerIdGameView();
  }
}

export class PlayerGetAllByPlayerIdGameView {
  playerId?: string;
  balance?: number;
  bet?: number;
}
