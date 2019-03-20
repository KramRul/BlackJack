import { SuiteType } from '../../enums/suite-type';
import { RankType } from '../../enums/rank-type';
import { GameStateType } from '../../enums/game-state-type';


export class GetAllStepsGameView {
  playerSteps?: Array<PlayerStepGetAllStepsGameViewItem>;

  constructor() {
    this.playerSteps = new Array <PlayerStepGetAllStepsGameViewItem>();
  }
}

export class PlayerStepGetAllStepsGameViewItem {
  id?: string;
  suite?: SuiteType;
  rank?: RankType;
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
  gameState?: GameStateType;
}
