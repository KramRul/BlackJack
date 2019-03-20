import { GameStateType } from '../../enums/game-state-type';

export class StartGameView {
  id?: string;
  wonName?: string;
  gameState?: GameStateType;
  countOfBots?: number;
  player?: PlayerStartGameView;

  constructor() {
    this.player = new PlayerStartGameView();
  }
}

export class PlayerStartGameView {
  userName?: string;
  playerId?: string;
  balance?: number;
  bet?: number;
}
