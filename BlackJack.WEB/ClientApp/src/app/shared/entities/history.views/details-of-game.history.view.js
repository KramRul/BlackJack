"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var get_all_steps_game_view_1 = require("../game.views/get-all-steps.game.view");
var get_all_step_of_bots_game_view_1 = require("../game.views/get-all-step-of-bots.game.view");
var DetailsOfGameHistoryView = /** @class */ (function () {
    function DetailsOfGameHistoryView() {
        this.game = new GameDetailsOfGameHistoryView();
        this.playerSteps = new get_all_steps_game_view_1.GetAllStepsGameView();
        this.botsSteps = new get_all_step_of_bots_game_view_1.GetAllStepOfBotsGameView();
    }
    return DetailsOfGameHistoryView;
}());
exports.DetailsOfGameHistoryView = DetailsOfGameHistoryView;
var GameDetailsOfGameHistoryView = /** @class */ (function () {
    function GameDetailsOfGameHistoryView() {
        this.player = new PlayerDetailsOfGameHistoryView();
    }
    return GameDetailsOfGameHistoryView;
}());
exports.GameDetailsOfGameHistoryView = GameDetailsOfGameHistoryView;
var PlayerDetailsOfGameHistoryView = /** @class */ (function () {
    function PlayerDetailsOfGameHistoryView() {
    }
    return PlayerDetailsOfGameHistoryView;
}());
exports.PlayerDetailsOfGameHistoryView = PlayerDetailsOfGameHistoryView;
//# sourceMappingURL=details-of-game.history.view.js.map