import { Suite } from '../../enums/suite';
import { Rank } from '../../enums/rank';
import { GameState } from '../../enums/game-state';

export class GetAllStepsByPlayerIdPlayerView {
  playerSteps?: Array<PlayerStepGetAllStepsByPlayerIdPlayerViewItem>;

  constructor() {
    this.playerSteps = new Array<PlayerStepGetAllStepsByPlayerIdPlayerViewItem>();
  }
}

export class PlayerStepGetAllStepsByPlayerIdPlayerViewItem {
  id?: string;
  suite?: Suite;
  rank?: Rank;
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
  gameState?: GameState;
}
