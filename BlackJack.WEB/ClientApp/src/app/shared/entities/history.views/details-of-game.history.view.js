"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var DetailsOfGameHistoryView = /** @class */ (function () {
    function DetailsOfGameHistoryView() {
        this.game = new GameDetailsOfGameHistoryView();
        this.playerAndBotSteps = new PlayerAndBotStepsDetailsOfGameHistoryView();
    }
    return DetailsOfGameHistoryView;
}());
exports.DetailsOfGameHistoryView = DetailsOfGameHistoryView;
var PlayerAndBotStepsDetailsOfGameHistoryView = /** @class */ (function () {
    function PlayerAndBotStepsDetailsOfGameHistoryView() {
        this.steps = new Array();
    }
    return PlayerAndBotStepsDetailsOfGameHistoryView;
}());
exports.PlayerAndBotStepsDetailsOfGameHistoryView = PlayerAndBotStepsDetailsOfGameHistoryView;
var StepPlayerAndBotStepsDetailsOfGameHistoryViewItem = /** @class */ (function () {
    function StepPlayerAndBotStepsDetailsOfGameHistoryViewItem() {
        this.cards = new Array();
    }
    return StepPlayerAndBotStepsDetailsOfGameHistoryViewItem;
}());
exports.StepPlayerAndBotStepsDetailsOfGameHistoryViewItem = StepPlayerAndBotStepsDetailsOfGameHistoryViewItem;
var CardPlayerAndBotStepsDetailsOfGameHistoryView = /** @class */ (function () {
    function CardPlayerAndBotStepsDetailsOfGameHistoryView() {
        this.player = new PlayerCardPlayerAndBotStepsDetailsOfGameHistoryView();
        this.game = new GameCardPlayerAndBotStepsDetailsOfGameHistoryView();
        this.bot = new BotCardPlayerAndBotStepsDetailsOfGameHistoryView();
    }
    return CardPlayerAndBotStepsDetailsOfGameHistoryView;
}());
exports.CardPlayerAndBotStepsDetailsOfGameHistoryView = CardPlayerAndBotStepsDetailsOfGameHistoryView;
var PlayerCardPlayerAndBotStepsDetailsOfGameHistoryView = /** @class */ (function () {
    function PlayerCardPlayerAndBotStepsDetailsOfGameHistoryView() {
    }
    return PlayerCardPlayerAndBotStepsDetailsOfGameHistoryView;
}());
exports.PlayerCardPlayerAndBotStepsDetailsOfGameHistoryView = PlayerCardPlayerAndBotStepsDetailsOfGameHistoryView;
var GameCardPlayerAndBotStepsDetailsOfGameHistoryView = /** @class */ (function () {
    function GameCardPlayerAndBotStepsDetailsOfGameHistoryView() {
    }
    return GameCardPlayerAndBotStepsDetailsOfGameHistoryView;
}());
exports.GameCardPlayerAndBotStepsDetailsOfGameHistoryView = GameCardPlayerAndBotStepsDetailsOfGameHistoryView;
var BotCardPlayerAndBotStepsDetailsOfGameHistoryView = /** @class */ (function () {
    function BotCardPlayerAndBotStepsDetailsOfGameHistoryView() {
    }
    return BotCardPlayerAndBotStepsDetailsOfGameHistoryView;
}());
exports.BotCardPlayerAndBotStepsDetailsOfGameHistoryView = BotCardPlayerAndBotStepsDetailsOfGameHistoryView;
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