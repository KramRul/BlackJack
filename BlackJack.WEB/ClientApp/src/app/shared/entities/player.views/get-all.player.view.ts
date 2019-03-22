export class GetAllPlayerView {
  players?: Array<PlayerGetAllPlayerViewItem>;

  constructor() {
    this.players = new Array<PlayerGetAllPlayerViewItem>();
  }
}

export class PlayerGetAllPlayerViewItem {
  userName?: string;
  playerId?: string;
  balance?: number;
  bet?: number;
}
