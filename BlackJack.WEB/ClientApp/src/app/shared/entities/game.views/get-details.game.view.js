"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var start_game_view_1 = require("./start.game.view");
var get_all_steps_game_view_1 = require("./get-all-steps.game.view");
var get_all_step_of_bots_game_view_1 = require("./get-all-step-of-bots.game.view");
var GetDetailsGameView = /** @class */ (function () {
    function GetDetailsGameView() {
        this.game = new start_game_view_1.StartGameView();
        this.playerSteps = new get_all_steps_game_view_1.GetAllStepsGameView();
        this.botsSteps = new get_all_step_of_bots_game_view_1.GetAllStepOfBotsGameView();
    }
    return GetDetailsGameView;
}());
exports.GetDetailsGameView = GetDetailsGameView;
//# sourceMappingURL=get-details.game.view.js.map