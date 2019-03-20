import { SuiteType } from '../../enums/suite-type';
import { RankType } from '../../enums/rank-type';
import { GameStateType } from '../../enums/game-state-type';

export class GetAllStepsByPlayerIdPlayerView {
  playerSteps?: Array<PlayerStepGetAllStepsByPlayerIdPlayerViewItem>;

  constructor() {
    this.playerSteps = new Array<PlayerStepGetAllStepsByPlayerIdPlayerViewItem>();
  }
}

export class PlayerStepGetAllStepsByPlayerIdPlayerViewItem {
  id?: string;
  suite?: SuiteType;
  rank?: RankType;
  player?: PlayerGetAllStepsByPlayerIdPlayerView;
  game?: GameGetAllStepsByPlayerIdPlayerView;

  constructor() {
    this.player = new PlayerGetAllStepsByPlayerIdPlayerView();
    this.game = new GameGetAllStepsByPlayerIdPlayerView();
  }
}

export class PlayerGetAllStepsByPlayerIdPlayerView {
  playerId?: string;
  balance?: number;
  bet?: number;
}

export class GameGetAllStepsByPlayerIdPlayerView {
  gameId?: string;
  gameState?: GameStateType;
}
