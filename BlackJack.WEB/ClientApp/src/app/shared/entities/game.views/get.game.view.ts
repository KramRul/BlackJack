import { GameStateType } from 'src/app/shared/enums/game-state-type';

export class GetGameView {
  id?: string;
  gameState?: GameStateType;
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
