namespace BlackJack.ViewModels.GameViews
{
    public class GetDetailsByPlayerIdAndGameIdGameView
    {
        public StartGameView Game { get; set; }
        public GetAllStepsByPlayerIdAndGameIdGameView PlayerSteps { get; set; }
        public GetAllStepOfBotsByGameIdGameView BotsSteps { get; set; }
    }
}
