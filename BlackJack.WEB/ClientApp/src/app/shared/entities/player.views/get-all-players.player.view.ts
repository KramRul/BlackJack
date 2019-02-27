export class GetAllPlayersPlayerView {
  players?: Array<PlayerGetAllPlayersPlayerViewItem>;

  constructor() {
    this.players = new Array<PlayerGetAllPlayersPlayerViewItem>();
  }
}

export class PlayerGetAllPlayersPlayerViewItem {
  userName?: string;
  playerId?: string;
  balance?: number;
  bet?: number;
}
