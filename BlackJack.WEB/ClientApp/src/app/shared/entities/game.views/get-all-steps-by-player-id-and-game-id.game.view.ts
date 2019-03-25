import { SuiteType } from '../../enums/suite-type';
import { RankType } from '../../enums/rank-type';
import { GameStateType } from '../../enums/game-state-type';


export class GetAllStepsByPlayerIdAndGameIdGameView {
  playerSteps?: Array<PlayerStepGetAllStepsByPlayerIdAndGameIdGameViewItem>;

  constructor() {
    this.playerSteps = new Array<PlayerStepGetAllStepsByPlayerIdAndGameIdGameViewItem>();
  }
}

export class PlayerStepGetAllStepsByPlayerIdAndGameIdGameViewItem {
  id?: string;
  suite?: SuiteType;
  rank?: RankType;
  player?: PlayerGetAllStepsByPlayerIdAndGameIdGameView;
  game?: GameGetAllStepsByPlayerIdAndGameIdGameView;

  constructor() {
    this.player = new PlayerGetAllStepsByPlayerIdAndGameIdGameView();
    this.game = new GameGetAllStepsByPlayerIdAndGameIdGameView();
  }
}

export class PlayerGetAllStepsByPlayerIdAndGameIdGameView {
  id?: string;
  balance?: number;
  bet?: number;
}

export class GameGetAllStepsByPlayerIdAndGameIdGameView {
  gameId?: string;
  gameState?: GameStateType;
}
