namespace CodeBase.Infrastructure.Services.Yandex
{
    public interface IYandexLeaderBoardService
    {
        void SetScore(int score);
        int GetScore();
    }
}