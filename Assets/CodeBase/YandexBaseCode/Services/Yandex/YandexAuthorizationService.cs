using Agava.YandexGames;
using BasicTemplate.CodeBase.Yandex;

namespace BasicTemplate.CodeBase.Services.Yandex
{
    public class YandexAuthorizationService : IYandexAuthorizationService
    {
        private readonly YandexAuthorizationView _view;

        public YandexAuthorizationService(YandexAuthorizationView view)
        {
            _view = view;

            Enable();
        }

        public void Open()
        {
#if YANDEX_GAMES
            OnAuthorizeButtonClick();
            OnRequestPersonalProfileDataPermissionButtonClick();
#endif
        }

        private void OnAuthorizeButtonClick() =>
            PlayerAccount.Authorize();

        private void OnRequestPersonalProfileDataPermissionButtonClick() =>
            PlayerAccount.RequestPersonalProfileDataPermission();

        private void Enable() =>
            _view.AcceptButtonClick += Open;

        private void Disable() =>
            _view.AcceptButtonClick -= Open;
    }
}