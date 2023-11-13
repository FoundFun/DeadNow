using Agava.YandexGames;

namespace BasicTemplate.CodeBase.Services.Yandex
{
    public class YandexPersonalProfileDataService : IYandexPersonalProfileDataService
    {
        public void OnRequestPersonalProfileDataPermissionButtonClick() => 
            PlayerAccount.RequestPersonalProfileDataPermission();
    }
}