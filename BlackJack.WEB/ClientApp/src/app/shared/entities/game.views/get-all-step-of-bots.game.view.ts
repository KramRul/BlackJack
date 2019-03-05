import { Suite } from '../../enums/suite';
import { Rank } from '../../enums/rank';

export class GetAllStepOfBotsGameView {
  botSteps?: Array<BotStepGetAllStepOfBotsViewItem>;

  constructor() {
    this.botSteps = new Array<BotStepGetAllStepOfBotsViewItem>();
  }
}
export class BotStepGetAllStepOfBotsViewItem {
  id?: string;
  suite?: Suite;
  rank?: Rank;
  bot?: BotGetAllStepOfBotsView;

  constructor() {
    this.bot = new BotGetAllStepOfBotsView();
  }
}

export class BotGetAllStepOfBotsView {
  id?: string;
  name?: string;
  Balance?: number;
  Bet?: number;
}
