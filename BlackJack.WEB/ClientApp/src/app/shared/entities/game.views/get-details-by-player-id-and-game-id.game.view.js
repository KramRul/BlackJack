"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var start_game_view_1 = require("./start.game.view");
var get_all_steps_by_player_id_and_game_id_game_view_1 = require("./get-all-steps-by-player-id-and-game-id.game.view");
var get_all_step_of_bots_by_game_id_game_view_1 = require("./get-all-step-of-bots-by-game-id.game.view");
var GetDetailsByPlayerIdAndGameIdGameView = /** @class */ (function () {
    function GetDetailsByPlayerIdAndGameIdGameView() {
        this.game = new start_game_view_1.StartGameView();
        this.playerSteps = new get_all_steps_by_player_id_and_game_id_game_view_1.GetAllStepsByPlayerIdAndGameIdGameView();
        this.botsSteps = new get_all_step_of_bots_by_game_id_game_view_1.GetAllStepOfBotsByGameIdGameView();
    }
    return GetDetailsByPlayerIdAndGameIdGameView;
}());
exports.GetDetailsByPlayerIdAndGameIdGameView = GetDetailsByPlayerIdAndGameIdGameView;
//# sourceMappingURL=get-details-by-player-id-and-game-id.game.view.js.map