import { SuiteType } from '../../enums/suite-type';
import { RankType } from '../../enums/rank-type';

export class HitGameView {
  playerId?: string;
  gameId?: string;
  suite?: SuiteType;
  rank?: RankType;
}
