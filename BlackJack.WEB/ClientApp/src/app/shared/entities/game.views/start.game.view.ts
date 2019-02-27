import { GameState } from '../../enums/game-state';

export class StartGameView {
  id?: string;
  gameState?: GameState;
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
