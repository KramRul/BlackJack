"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var GetGameView = /** @class */ (function () {
    function GetGameView() {
        this.player = new PlayerGetGameView();
    }
    return GetGameView;
}());
exports.GetGameView = GetGameView;
var GameState;
(function (GameState) {
    GameState[GameState["Unknown"] = 0] = "Unknown";
    GameState[GameState["PlayerWon"] = 1] = "PlayerWon";
    GameState[GameState["BotWon"] = 2] = "BotWon";
    GameState[GameState["Draw"] = 3] = "Draw";
})(GameState || (GameState = {}));
var PlayerGetGameView = /** @class */ (function () {
    function PlayerGetGameView() {
    }
    return PlayerGetGameView;
}());
exports.PlayerGetGameView = PlayerGetGameView;
//# sourceMappingURL=get.game.view.js.map