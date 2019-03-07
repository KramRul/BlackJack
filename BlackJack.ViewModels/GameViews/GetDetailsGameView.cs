namespace BlackJack.ViewModels.GameViews
{
    public class GetDetailsGameView
    {
        public StartGameView Game { get; set; }
        public GetAllStepsGameView PlayerSteps { get; set; }
        public GetAllStepOfBotsGameView BotsSteps { get; set; }
    }
}
