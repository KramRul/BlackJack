"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var start_game_view_1 = require("./start.game.view");
var get_all_steps_game_view_1 = require("./get-all-steps.game.view");
var get_all_step_of_bots_game_view_1 = require("./get-all-step-of-bots.game.view");
var StartGameResultView = /** @class */ (function () {
    function StartGameResultView() {
        this.game = new start_game_view_1.StartGameView();
        this.playerSteps = new get_all_steps_game_view_1.GetAllStepsGameView();
        this.botsSteps = new get_all_step_of_bots_game_view_1.GetAllStepOfBotsGameView();
    }
    return StartGameResultView;
}());
exports.StartGameResultView = StartGameResultView;
//# sourceMappingURL=start-result.game.view.js.map