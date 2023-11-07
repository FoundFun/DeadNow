namespace BasicTemplate.CodeBase.Services.Yandex
{
    public interface IYandexLeaderBoardService
    {
        void SetScore(int score);
        int GetScore();
    }
}