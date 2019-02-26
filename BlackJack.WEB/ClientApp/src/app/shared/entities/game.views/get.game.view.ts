export class GetGameView {
  id?: number;
  gameState?: GameState;
  player?: PlayerGetGameView;

  constructor() {
    this.player = new PlayerGetGameView();
  }
}

enum GameState {
  Unknown,
  PlayerWon,
  BotWon,
  Draw
}

export class PlayerGetGameView {
  PlayerId?: number;
  Balance?: number;
  Bet?: number;
}
