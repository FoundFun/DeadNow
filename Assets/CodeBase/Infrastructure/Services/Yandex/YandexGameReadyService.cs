using Agava.YandexGames;

namespace CodeBase.Infrastructure.Services.Yandex
{
    public class YandexGameReadyService : IYandexGameReadyService
    {
        public void GameReady() => 
            YandexGamesSdk.GameReady();
    }
}