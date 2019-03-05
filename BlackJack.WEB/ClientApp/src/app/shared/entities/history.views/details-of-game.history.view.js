"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var get_all_steps_game_view_1 = require("../game.views/get-all-steps.game.view");
var get_all_step_of_bots_game_view_1 = require("../game.views/get-all-step-of-bots.game.view");
var DetailsOfGameHistoryView = /** @class */ (function () {
    function DetailsOfGameHistoryView() {
        this.game = new GameDetailsOfGameHistoryView();
        this.playerSteps = new get_all_steps_game_view_1.GetAllStepsGameView();
        this.botsSteps = new get_all_step_of_bots_game_view_1.GetAllStepOfBotsGameView();
        this.playerAndBotSteps = new PlayerAndBotStepsDetailsOfGameHistoryView();
    }
    return DetailsOfGameHistoryView;
}());
exports.DetailsOfGameHistoryView = DetailsOfGameHistoryView;
/*****************************************************************/
var PlayerAndBotStepsDetailsOfGameHistoryView = /** @class */ (function () {
    function PlayerAndBotStepsDetailsOfGameHistoryView() {
        this.steps = new Array();
    }
    return PlayerAndBotStepsDetailsOfGameHistoryView;
}());
exports.PlayerAndBotStepsDetailsOfGameHistoryView = PlayerAndBotStepsDetailsOfGameHistoryView;
var StepPlayerAndBotStepsDetailsOfGameHistoryViewItem = /** @class */ (function () {
    function StepPlayerAndBotStepsDetailsOfGameHistoryViewItem() {
        this.playerStep = new PlayerStepPlayerAndBotStepsDetailsOfGameHistoryView();
        this.botStep = new BotStepPlayerAndBotStepsDetailsOfGameHistoryView();
    }
    return StepPlayerAndBotStepsDetailsOfGameHistoryViewItem;
}());
exports.StepPlayerAndBotStepsDetailsOfGameHistoryViewItem = StepPlayerAndBotStepsDetailsOfGameHistoryViewItem;
var PlayerStepPlayerAndBotStepsDetailsOfGameHistoryView = /** @class */ (function () {
    function PlayerStepPlayerAndBotStepsDetailsOfGameHistoryView() {
        this.player = new PlayerPlayerAndBotStepsDetailsOfGameHistoryView();
        this.game = new PlayerPlayerAndBotStepsDetailsOfGameHistoryView();
    }
    return PlayerStepPlayerAndBotStepsDetailsOfGameHistoryView;
}());
exports.PlayerStepPlayerAndBotStepsDetailsOfGameHistoryView = PlayerStepPlayerAndBotStepsDetailsOfGameHistoryView;
var BotStepPlayerAndBotStepsDetailsOfGameHistoryView = /** @class */ (function () {
    function BotStepPlayerAndBotStepsDetailsOfGameHistoryView() {
        this.bot = new BotPlayerAndBotStepsDetailsOfGameHistoryView();
    }
    return BotStepPlayerAndBotStepsDetailsOfGameHistoryView;
}());
exports.BotStepPlayerAndBotStepsDetailsOfGameHistoryView = BotStepPlayerAndBotStepsDetailsOfGameHistoryView;
var PlayerPlayerAndBotStepsDetailsOfGameHistoryView = /** @class */ (function () {
    function PlayerPlayerAndBotStepsDetailsOfGameHistoryView() {
    }
    return PlayerPlayerAndBotStepsDetailsOfGameHistoryView;
}());
exports.PlayerPlayerAndBotStepsDetailsOfGameHistoryView = PlayerPlayerAndBotStepsDetailsOfGameHistoryView;
var GamePlayerAndBotStepsDetailsOfGameHistoryView = /** @class */ (function () {
    function GamePlayerAndBotStepsDetailsOfGameHistoryView() {
    }
    return GamePlayerAndBotStepsDetailsOfGameHistoryView;
}());
exports.GamePlayerAndBotStepsDetailsOfGameHistoryView = GamePlayerAndBotStepsDetailsOfGameHistoryView;
var BotPlayerAndBotStepsDetailsOfGameHistoryView = /** @class */ (function () {
    function BotPlayerAndBotStepsDetailsOfGameHistoryView() {
    }
    return BotPlayerAndBotStepsDetailsOfGameHistoryView;
}());
exports.BotPlayerAndBotStepsDetailsOfGameHistoryView = BotPlayerAndBotStepsDetailsOfGameHistoryView;
/***************************************************************/
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