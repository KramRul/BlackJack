import { StartGameView } from "./start.game.view";
import { GetAllStepsByPlayerIdAndGameIdGameView } from './get-all-steps-by-player-id-and-game-id.game.view';
import { GetAllStepOfBotsByGameIdGameView } from './get-all-step-of-bots-by-game-id.game.view';

export class GetDetailsByPlayerIdAndGameIdGameView {
  game?: StartGameView;
  playerSteps?: GetAllStepsByPlayerIdAndGameIdGameView;
  botsSteps?: GetAllStepOfBotsByGameIdGameView;

  constructor() {
    this.game = new StartGameView();
    this.playerSteps = new GetAllStepsByPlayerIdAndGameIdGameView();
    this.botsSteps = new GetAllStepOfBotsByGameIdGameView();
  }
}
