using Agava.YandexGames;

namespace CodeBase.Infrastructure.Services.Yandex
{
    public class YandexPersonalProfileDataService : IYandexPersonalProfileDataService
    {
        public void OnRequestPersonalProfileDataPermissionButtonClick() => 
            PlayerAccount.RequestPersonalProfileDataPermission();
    }
}