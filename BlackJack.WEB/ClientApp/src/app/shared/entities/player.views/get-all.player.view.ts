export class GetAllPlayerView {
  players?: Array<PlayerGetAllPlayerViewItem>;

  constructor() {
    this.players = new Array<PlayerGetAllPlayerViewItem>();
  }
}

export class PlayerGetAllPlayerViewItem {
  userName?: string;
  id?: string;
  balance?: number;
  bet?: number;
}
