import { Suite } from '../../enums/suite';
import { Rank } from '../../enums/rank';
import { GameState } from '../../enums/game-state';


export class GetAllStepsGameView {
  playerSteps?: Array<PlayerStepGetAllStepsGameViewItem>;

  constructor() {
    this.playerSteps = new Array <PlayerStepGetAllStepsGameViewItem>();
  }
}

export class PlayerStepGetAllStepsGameViewItem {
  id?: string;
  suite?: Suite;
  rank?: Rank;
  player?: PlayerGetAllStepsGameView;
  game?: GameGetAllStepsGameView;

  constructor() {
    this.player = new PlayerGetAllStepsGameView();
    this.game = new GameGetAllStepsGameView();
  }
}

export class PlayerGetAllStepsGameView {
  playerId?: string;
  balance?: number;
  bet?: number;
}

export class GameGetAllStepsGameView {
  gameId?: string;
  gameState?: GameState;
}
