import { GameState } from 'src/app/shared/enums/game-state';

export class GetGameView {
  id?: string;
  gameState?: GameState;
  player?: PlayerGetGameView;

  constructor() {
    this.player = new PlayerGetGameView();
  }
}

export class PlayerGetGameView {
  playerId?: string;
  balance?: number;
  bet?: number;
}
