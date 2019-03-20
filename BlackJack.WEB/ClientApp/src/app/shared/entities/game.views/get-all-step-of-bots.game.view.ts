import { SuiteType } from '../../enums/suite-type';
import { RankType } from '../../enums/rank-type';

export class GetAllStepOfBotsGameView {
  botSteps?: Array<BotStepGetAllStepOfBotsViewItem>;

  constructor() {
    this.botSteps = new Array<BotStepGetAllStepOfBotsViewItem>();
  }
}
export class BotStepGetAllStepOfBotsViewItem {
  id?: string;
  suite?: SuiteType;
  rank?: RankType;
  bot?: BotGetAllStepOfBotsView;

  constructor() {
    this.bot = new BotGetAllStepOfBotsView();
  }
}

export class BotGetAllStepOfBotsView {
  id?: string;
  name?: string;
  balance?: number;
  bet?: number;
}
