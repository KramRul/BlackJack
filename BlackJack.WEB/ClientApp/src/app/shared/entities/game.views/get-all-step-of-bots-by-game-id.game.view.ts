import { SuiteType } from '../../enums/suite-type';
import { RankType } from '../../enums/rank-type';

export class GetAllStepOfBotsByGameIdGameView {
  botSteps?: Array<BotStepGetAllStepOfBotsByGameIdGameViewItem>;

  constructor() {
    this.botSteps = new Array<BotStepGetAllStepOfBotsByGameIdGameViewItem>();
  }
}
export class BotStepGetAllStepOfBotsByGameIdGameViewItem {
  id?: string;
  suite?: SuiteType;
  rank?: RankType;
  bot?: BotGetAllStepOfBotsByGameIdGameView;

  constructor() {
    this.bot = new BotGetAllStepOfBotsByGameIdGameView();
  }
}

export class BotGetAllStepOfBotsByGameIdGameView {
  id?: string;
  name?: string;
  balance?: number;
  bet?: number;
}
