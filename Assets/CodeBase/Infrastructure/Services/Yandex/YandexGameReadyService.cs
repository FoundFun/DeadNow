using Agava.YandexGames;

namespace BasicTemplate.CodeBase.Services.Yandex
{
    public class YandexGameReadyService : IYandexGameReadyService
    {
        public void GameReady() => 
            YandexGamesSdk.GameReady();
    }
}