import { StartGameView } from "./start.game.view";
import { GetAllStepsGameView } from "./get-all-steps.game.view";
import { GetAllStepOfBotsGameView } from "./get-all-step-of-bots.game.view";

export class GetDetailsGameView {
  game?: StartGameView;
  playerSteps?: GetAllStepsGameView;
  botsSteps?: GetAllStepOfBotsGameView;

  constructor() {
    this.game = new StartGameView();
    this.playerSteps = new GetAllStepsGameView();
    this.botsSteps = new GetAllStepOfBotsGameView();
  }
}
